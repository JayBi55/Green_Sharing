using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace GreenSharing.API.Security
{
    /// <summary>
    /// @TODO: Authentication & Authorization
    /// </summary>
    public class AuthOptions
    {
        private static readonly log4net.ILog Logger = log4net.LogManager.GetLogger(typeof(AuthOptions));

        public const string ISSUER = "MORGANSTANLEY GREENSHARING AUTH SERVER";
        public const string AUDIENCE = "morganstanley.greensharing";
        public const int LIFETIME = 1;

        private static readonly string KEY = Environment.GetEnvironmentVariable("MORGANSTANLEY_BEARER_KEY");

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            Logger.InfoFormat($"MORGANSTANLEY_BEARER_KEY:: {KEY}");
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

        public static string GetAudience()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Logger.InfoFormat($"ASPNETCORE_ENVIRONMENT:: {env}");
            string audience;
            switch (env)
            {
                case "Development":
                    audience = "morganstanley.greensharing.Development";
                    break;
                case "Staging":
                    audience = "morganstanley.greensharing.Staging";
                    break;
                case "Production":
                    audience = "morganstanley.greensharing.Production";
                    break;
                default:
                    audience = "https://morganstanley.greensharing.com:443";
                    break;
            }
            Logger.InfoFormat($"audience:: {audience}");
            return audience;
        }

        public static string GetIssuer()
        {
            var env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            string issuer;
            switch (env)
            {
                case "Development":
                    issuer = "https://localhost:3027";
                    break;
                case "Staging":
                    issuer = "http://morganstanley.greensharing:8040";
                    break;
                case "Production":
                    issuer = "http://localhost:3027";
                    break;
                default:
                    issuer = "https://morganstanley.greensharing.com:443";
                    break;
            }
            Logger.InfoFormat($"issuer:: {issuer}");
            return issuer;
        }
    }
}
