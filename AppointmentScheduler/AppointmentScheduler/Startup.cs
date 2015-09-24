using AppointmentScheduler.App_Start;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppointmentScheduler.Startup))]
namespace AppointmentScheduler
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            DatabaseStartup db = new DatabaseStartup();
            db.Init();
            ConfigureAuth(app);
        }
    }
}
