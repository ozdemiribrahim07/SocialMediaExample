using Autofac;
using Autofac.Extras.DynamicProxy;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using Data.Abstract;
using Data.Concrete.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DependencyResolvers.AutoFac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            builder.RegisterType<CommentManager>().As<ICommentService>().SingleInstance();
            builder.RegisterType<EfCommentDal>().As<ICommentDal>().SingleInstance();

            builder.RegisterType<PostTopicManager>().As<IPostTopicService>().SingleInstance();
            builder.RegisterType<EfPostTopicDal>().As<IPostTopicDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<PostManager>().As<IPostService>().SingleInstance();
            builder.RegisterType<EfPostDal>().As<IPostDal>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableClassInterceptors(new ProxyGenerationOptions
            {
                Selector = new AspectInterceptorSelector()

            }).SingleInstance();


        }

    }
}
