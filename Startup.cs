using Owin;
using System.Web.Http;

namespace NLogWithELK
{
    public class Startup
    {
        /// <summary>
        ///  configure Web API
        /// </summary>
        /// <param name="app">application builder</param>
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // registe attribute routes
            config.MapHttpAttributeRoutes();

            // register route
            config.Routes.MapHttpRoute(
                name: "DefaultAPI",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            app.UseWebApi(config);
        }
    }
}
