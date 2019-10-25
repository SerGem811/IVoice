using Autofac;
using Autofac.Integration.Mvc;
using IVoice.Database;
using IVoice.Interfaces;
using IVoice.Services;
using IVoice.Json;
using System;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace IVoice
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            RegisterDependencyResolver();
        }

        private void RegisterDependencyResolver()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<EOneEntities>()
                .As<EOneEntities>()
                .AsSelf()
                .InstancePerRequest();

            RegisterServices(builder);

            builder.RegisterType<JsonNetActionInvoker>()
                .As<IActionInvoker>()
                .WithParameter("injectActionMethodParameters", true);
            builder.RegisterControllers(typeof(MvcApplication).Assembly).InjectActionInvoker();


            builder.Register(c => new EOneEntities());

            builder.RegisterModelBinders(typeof(MvcApplication).Assembly);
            builder.RegisterModelBinderProvider();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<CategoryRepository>()
                .As(typeof(ICategoryRepository))
                .InstancePerRequest();

            builder.RegisterType<ForumAnswerRepository>()
                .As(typeof(IForumAnswerRepository))
                .InstancePerRequest();

            builder.RegisterType<ForumAnswersAttachRepository>()
                .As(typeof(IForumAnswersAttachRepository))
                .InstancePerRequest();

            builder.RegisterType<ForumAnswerVotesRepository>()
                .As(typeof(IForumAnswerVotesRepository))
                .InstancePerRequest();

            builder.RegisterType<ForumTopicsViewRepository>()
                .As(typeof(IForumTopicsViewRepository))
                .InstancePerRequest();

            builder.RegisterGeneric(typeof(GenericRepository<>))
                .As(typeof(IGenericRepository<>))
                .InstancePerRequest();

            builder.RegisterType<TopicRepository>()
                .As(typeof(ITopicRepository))
                .InstancePerRequest();

            builder.RegisterType<UserRepository>()
                .As(typeof(IUserRepository))
                .InstancePerRequest();

            builder.RegisterType<UserIPSpreadsRepository>()
                .As(typeof(IUserIPSpreadsRepository))
                .InstancePerRequest();

            builder.RegisterType<UsersIPRepository>()
                .As(typeof(IUsersIPRepository))
                .InstancePerRequest();

            builder.RegisterType<UserIPAdsRepository>()
                .As(typeof(IUserIPAdsRepository))
                .InstancePerRequest();

            builder.RegisterType<UserActivityRepository>()
                .As(typeof(IUsersActivityRepository))
                .InstancePerRequest();

            builder.RegisterType<UsersConnectionsRepository>()
                .As(typeof(IUsersConnectionRepository))
                .InstancePerRequest();

            builder.RegisterType<UserAttachmentsRepository>()
                .As(typeof(IUserAttachmentsRepository))
                .InstancePerRequest();

            builder.RegisterType<WhisperRepository>()
                .As(typeof(IWhisperRepository))
                .InstancePerRequest();

            builder.RegisterType<UsersIPCommentsRepository>()
                .As(typeof(IUsersIPCommentsRepository))
                .InstancePerRequest();
        }
    }
}
