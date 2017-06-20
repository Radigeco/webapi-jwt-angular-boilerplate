using System;
using System.Configuration;
using Microsoft.Owin.Security.Infrastructure;

namespace Security.Providers
{
    public class ApiRefreshTokenProvider : AuthenticationTokenProvider
    {
        public override void Create(AuthenticationTokenCreateContext context)
        {
            int refreshTokenDurationInDays = Convert.ToInt32(ConfigurationManager.AppSettings["RefreshTokenDuration"]);
            context.Ticket.Properties.ExpiresUtc = new DateTimeOffset(DateTime.Now.AddDays(refreshTokenDurationInDays));
            context.SetToken(context.SerializeTicket());
        }

        public override void Receive(AuthenticationTokenReceiveContext context)
        {
            context.DeserializeTicket(context.Token);
        }
    }
}
