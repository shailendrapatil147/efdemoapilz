using LZ.Common.ApiClient;
using LZ.Common.efdemo.Constants;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace LZ.Common.efdemo.ServiceClient
{
    public class ServiceClientBase
    {
        protected IConfiguration _configuration { get; set; }

        protected readonly IApiClient _apiClient;

        protected ILogger _logger { get; set; }

        protected int _timeOut = 30;

        private HttpContext _context { get; set; }

        public ServiceClientBase(IConfiguration configuration, IApiClient apiClient, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _apiClient = apiClient;
        }
        public HttpContext AddAPIKey(string key)
        {
            string apiKey = _configuration[key];

            if (_context == null)
            {
                _context = new DefaultHttpContext();
            }

            if (_context != null && !string.IsNullOrEmpty(apiKey) && !_context.Request.Headers.ContainsKey(AppSettingCode.AUTH_X_LZ_API_KEY))
            {
                _context.Request.Headers.Add(AppSettingCode.AUTH_X_LZ_API_KEY, apiKey);
            }
            return _context;
        }
    }
}
