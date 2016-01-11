using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using Owin;
using SignalR.MeuChat.Authorization;
using SignalRMeuChat.Authorization;

[assembly: OwinStartup(typeof(SignalRMeuChat.Startup))]
namespace SignalRMeuChat
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            //var aut = new CustomAuthorize();
            //GlobalHost.HubPipeline.AddModule(new AuthorizeModule(aut,aut));
            app.MapSignalR();
            //app.MapSignalR<AuthorizationPersistentConnection>("/Authorization/AuthorizationPersistentConnection");
   
        }
    }
}