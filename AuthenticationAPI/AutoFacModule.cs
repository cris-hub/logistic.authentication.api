using AuthenticationAPI.DatabaseContext;
using AuthenticationAPI.Repositories;
using AuthenticationAPI.Services;
using Autofac;

namespace AuthenticationAPI
{

    public class AutoFacModule : Module
    {
        private readonly IConfiguration _configuration;
        public AutoFacModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration).As<IConfiguration>();


            builder.RegisterType<LogisticAuthenticationContext>().As<BaseContext>();
            builder.Register<IDbContextFactory>(ctx =>
            {
                var allContext = new Dictionary<string, BaseContext>
                {
                    { "LogisticAuthenticationContext", ctx.Resolve<LogisticAuthenticationContext>() }
                };
                return new DbContextFactory(allContext);

            });

            builder.RegisterType<UserService>().As<IUserService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();

        }
    }
}