namespace Protfolio.Helpers
{
    public class ConfigurationHelper
    {
        private IConfiguration _configuration;

        public ConfigurationHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            AppSettings.connectionString = _configuration.GetSection("connectionString").Value;
        }
    }
}
