using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using NetTestFramework.Services;
using NLog;
using RestSharp;
using RestSharp.Authenticators;

namespace NetTestFramework.Clients
{
    public sealed class RestClientExtended
    {
        private readonly RestClient _client;
        private readonly Logger _logger = LogManager.GetCurrentClassLogger();
        public static RestResponse? LastResponse;

        public RestClientExtended()
        {
          var options = new RestClientOptions(Configurator.AppSettings.ApiUrl ?? throw new InvalidOperationException());
          _client = new RestClient(options);
          //Debug.Assert(Configurator.Admin != null, "Configurator.Admin != null");
          _client.Authenticator =new HttpBasicAuthenticator(Configurator.Admin.Username, Configurator.Admin.Password);
        }

        public async Task<T> ExecuteAsync<T>(RestRequest request)
        {
            LogRequest(request);
            var response = await _client.ExecuteAsync<T>(request);
            LastResponse = response;
            LogResponse(response);
            return response.Data ?? throw new InvalidOperationException();
        }

        public async Task<RestResponse> ExecuteAsync(RestRequest request)
        {
            LogRequest(request);
            var response = await _client.ExecuteAsync(request);
            LogResponse(response);
            return response;
        }

        private void LogRequest(RestRequest request)
        {
            _logger.Debug($"{request.Method} request to : {request.Resource}");
            var body = request.Parameters.FirstOrDefault(p => p.Type == ParameterType.RequestBody)?.Value;
            if (body != null)
            {
                _logger.Debug($"body : {body}");
            }
        }

        private void LogResponse(RestResponse response)
        {
            if (response.ErrorException != null)
            {
                _logger.Error(
                    $"Error retrieving response. Check inner details for more info. \n{response.ErrorException.Message}");
            }

            _logger.Debug($"Request finished with status code : {response.StatusCode}");
            if (!string.IsNullOrEmpty(response.Content))
            {
                _logger.Debug(response.Content);
            }
        }

        public void Dispose()
        {
            _client.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}