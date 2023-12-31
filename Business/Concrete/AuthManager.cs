﻿using Business.Abstract;
using Business.Constans;
using Business.ValidationRules.FluentValidation.User;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Core.Entities.Concrete;
using Core.Utilities.Result.Abstract;
using Core.Utilities.Result.Concrete;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Dtos.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    [LogAspect(typeof(FileLogger))]
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserOperationClaimService _userOperationClaimService;
        public AuthManager(
            IUserService userService,
            ITokenHelper tokenHelper,
            IUserOperationClaimService userOperationClaimService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userOperationClaimService = userOperationClaimService;
        }
        [ValidationAspect(typeof(UserForRegisterDtoValidator))]
        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;

            if (_userService.GetByMail(userForRegisterDto.Email) != null)
            {
                return new ErrorDataResult<User>(message: Messages.CurrentMail);
            }

            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                RegistrationDate = DateTime.Now
            };
            _userService.Add(user);
            var newUser = _userService.GetByMail(userForRegisterDto.Email);

            var userOperationClaim = new UserOperationClaim()
            {
                UserId = newUser.Id,
                OperationClaimId = 3
            };
            _userOperationClaimService.Add(userOperationClaim);
            return new SuccessDataResult<User>(user, Messages.SuccessRegister);
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);

            IResult result = BusinessRules.Run(_userService.CheckPassword(userForLoginDto.Email, userForLoginDto.Password), _userService.CheckEmail(userForLoginDto.Email), CheckStatus(userForLoginDto.Email));
            if (result == null)
            {
                return new SuccessDataResult<Core.Entities.Concrete.User>(userToCheck, "Başarılı giriş");
            }
            return new ErrorDataResult<Core.Entities.Concrete.User>(Messages.LoginCheck);

        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAvailable);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, "Token oluşturuldu.");
        }

        public IResult CheckStatus(string email)
        {
            var statusCheck = _userService.GetByMail(email);
            if (statusCheck != null)
            {
                if (statusCheck.Status != false)
                {
                    return new SuccessResult();
                }
            }

            return new ErrorResult("Yetkililer tarafından hesabınızın aktif hale getirilmesi gerekmektedir.");
        }
    }
}
