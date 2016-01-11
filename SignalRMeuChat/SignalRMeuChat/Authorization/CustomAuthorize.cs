using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SignalRMeuChat.Authorization
{
    public class CustomAuthorize : IAuthorizeHubMethodInvocation, IAuthorizeHubConnection 
    {

        public bool AuthorizeHubMethodInvocation(IHubIncomingInvokerContext hubIncomingInvokerContext, bool appliesToMethod)
        {
            return true;
        }

        public bool AuthorizeHubConnection(HubDescriptor hubDescriptor, Microsoft.AspNet.SignalR.IRequest request)
        {
    
            return true;
        }
    }
}