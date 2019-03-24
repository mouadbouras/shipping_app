using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Funq;
using ServiceStack;
using ServiceStack.Configuration;
using ServiceStack.Auth;
using MyApp.ServiceInterface;
using ServiceStack.Caching;
using MyApp.DataAccess.DataAccess;
using ServiceStack.Data;
using ServiceStack.OrmLite;

namespace MyApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseServiceStack(new AppHost
            {
                AppSettings = new NetCoreAppSettings(Configuration)
            });
        }
    }

    public class AppHost : AppHostBase
    {
        public AppHost() : base("MyApp", typeof(MyServices).Assembly) { }

        // Configure your AppHost with the necessary configuration and dependencies your App needs
        public override void Configure(Container container)
        {

            Plugins.Add(new SessionFeature());
            Plugins.Add(new CorsFeature());
            Plugins.Add(new AuthFeature(() => new AuthUserSession(),
            new IAuthProvider[] { 
                //new BasicAuthProvider(),
                new CredentialsAuthProvider()
                // , 
                // new CredentialsAuthProvider(), //HTML Form post of UserName/Password credentials
            }));

            //container.RegisterAs<CustomAuthEvents,IAuthEvents>();

            Plugins.Add(new RegistrationFeature());

            container.Register<ICacheClient>(new MemoryCacheClient());

            container.Register<IDbConnectionFactory>(c =>
                new OrmLiteConnectionFactory(shippingcoContext.connstring, SqlServer2012Dialect.Provider));

            container.Register<IAuthRepository>(c =>
                new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>()));

            container.Resolve<IAuthRepository>().InitSchema(); // Create any missing UserAuth tables

            // var userRep = new InMemoryAuthRepository();
            // container.Register<IUserAuthRepository>(userRep);




            // Plugins.Add(new AuthFeature(() => new AuthUserSession(),
            //     new IAuthProvider[] { 
            //        new BasicAuthProvider(), //Sign-in with HTTP Basic Auth
            //         new CredentialsAuthProvider() //HTML Form post of UserName/Password credentials
            // }));

            // Plugins.Add(new AuthFeature(() => new AuthUserSession(), 
            //             new IAuthProvider[] {
            //             new JwtAuthProvider(AppSettings) { AuthKey = AesUtils.CreateKey() },
            //             new CredentialsAuthProvider(AppSettings)
            //                     }));

        // Plugins.Add(new AuthFeature(...,
        //     new IAuthProvider[] {
        //         new JwtAuthProvider(AppSettings) { AuthKey = AesUtils.CreateKey() },
        //         new CredentialsAuthProvider(AppSettings),
        //         //...
        //     }));            

            // Plugins.Add(new RegistrationFeature());

            // container.Register<ICacheClient>(new MemoryCacheClient());
            // var userRep = new InMemoryAuthRepository();
            // container.Register<IUserAuthRepository>(userRep);

            SetConfig(new HostConfig
            {
                DefaultRedirectPath = "/metadata",
                DebugMode = AppSettings.Get(nameof(HostConfig.DebugMode), false)
            });
        }
    }
}
