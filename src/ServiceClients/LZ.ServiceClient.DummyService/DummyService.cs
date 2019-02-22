using LZ.Common.ApiClient;
using LZ.Common.efdemo.ServiceClient;
using LZ.Common.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace LZ.ServiceClient.DummyService
{
    //***********************************************************************************************
    //Note : 1. This is just sample given. Get rid of DummyService Project once you include actual Service.
    //       2. Handle exception scenario's
    //***********************************************************************************************
    public class DummyService : ServiceClientBase, IDummyService
    {
        public DummyService(IConfiguration configuration, ILoggingService loggingService, IHttpContextAccessor httpContextAccessor, IApiClient apiClient)
            : base(configuration, apiClient, httpContextAccessor)
        {
            _logger = loggingService.GetLogger<DummyService>(nameof(DummyService));
        }
        public async Task<bool> GetResponse()
        {
            var url = string.Empty;
           return await _apiClient.GetJsonAsync<bool>(new Uri(url), _timeOut).ConfigureAwait(false);
        }
    }
}
