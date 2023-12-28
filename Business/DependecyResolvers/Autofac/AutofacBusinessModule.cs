using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Helpers.FileHelper;
using Core.Utilities.Helpers;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Module = Autofac.Module;

namespace Business.DependecyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<EfEducationDal>().As<IEducationDal>().SingleInstance();
            builder.RegisterType<EducationManager>().As<IEducationService>().SingleInstance();

            builder.RegisterType<EfEducationContentDal>().As<IEducationContentDal>().SingleInstance();
            builder.RegisterType<EducationContentManager>().As<IEducationContentService>().SingleInstance();

            builder.RegisterType<EfEducatorDal>().As<IEducatorDal>().SingleInstance();
            builder.RegisterType<EducatorManager>().As<IEducatorService>().SingleInstance();

            builder.RegisterType<EfUserEducationDal>().As<IUserEducationDal>().SingleInstance();
            builder.RegisterType<UserEducationManager>().As<IUserEducationService>().SingleInstance();

            builder.RegisterType<EfFileDal>().As<IFileDal>().SingleInstance();
            builder.RegisterType<FileManager>().As<IFileService>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().SingleInstance();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().SingleInstance();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().SingleInstance();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().SingleInstance();


            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
