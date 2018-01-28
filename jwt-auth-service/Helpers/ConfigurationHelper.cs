using Microsoft.Extensions.Configuration;

namespace jwt_auth_service.Helpers
{
    public class ConfigurationHelper
    {
        private readonly IConfiguration _configuration;

        public ConfigurationHelper(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string JwtIssuer => _configuration["JwtIssuer"];
        public string JwtKey => _configuration["JwtKey"];
        public string JwtExpireDays => _configuration["JwtExpireDays"];
    }
}
