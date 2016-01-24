using System.Web.Http;

namespace Rinita.Stephan
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

	        AutofacConfig.Start();
        }
    }
}
