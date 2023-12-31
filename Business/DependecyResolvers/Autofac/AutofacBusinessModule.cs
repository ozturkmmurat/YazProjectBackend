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
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
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
            builder.RegisterType<EfEducationDal>().As<IEducationDal>().InstancePerLifetimeScope();
            builder.RegisterType<EducationManager>().As<IEducationService>().InstancePerLifetimeScope();

            builder.RegisterType<EfEducationContentDal>().As<IEducationContentDal>().InstancePerLifetimeScope();
            builder.RegisterType<EducationContentManager>().As<IEducationContentService>().InstancePerLifetimeScope();

            builder.RegisterType<EfEducatorDal>().As<IEducatorDal>().InstancePerLifetimeScope();
            builder.RegisterType<EducatorManager>().As<IEducatorService>().InstancePerLifetimeScope();

            builder.RegisterType<EfUserEducationDal>().As<IUserEducationDal>().InstancePerLifetimeScope();
            builder.RegisterType<UserEducationManager>().As<IUserEducationService>().InstancePerLifetimeScope();

            builder.RegisterType<EfFileDal>().As<IFileDal>().InstancePerLifetimeScope();
            builder.RegisterType<FileManager>().As<IFileService>().InstancePerLifetimeScope();

            builder.RegisterType<UserManager>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserDal>().As<IUserDal>().InstancePerLifetimeScope();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>().InstancePerLifetimeScope();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>().InstancePerLifetimeScope();

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>().InstancePerLifetimeScope();

            builder.RegisterType<AuthManager>().As<IAuthService>().InstancePerLifetimeScope();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().InstancePerLifetimeScope();

            builder.RegisterType<FileHelperManager>().As<IFileHelper>().InstancePerLifetimeScope();

            builder.RegisterType<YazContext>().InstancePerLifetimeScope();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).InstancePerLifetimeScope();
        }
    }
}
