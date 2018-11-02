using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Framework.Web.Tools.Http
{
    public static class HttpRequestExtentions
    {
        private static HttpClient _client;
        static HttpRequestExtentions()
        {
            _client = new HttpClient();    
        }
        public static void SetClient(HttpClient client)
        {
            _client = client;
        }
    
        public static async Task<TResponse> DispatchAsync<TResponse>(this IHttpRequestBuilder httpRequestBuilder, IExceptionParser exceptionParser = null)
        {
            Enforce.That.ExceptionParserHasBeenInitialized(ref exceptionParser);

            var httpRequest = httpRequestBuilder.Build();
            var response = await _client.SendAsync(httpRequest);
             
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
                exceptionParser.ParseException(responseContent);

            return JsonConvert.DeserializeObject<TResponse>(responseContent);
        }
        public static Task<HttpResponseMessage> DispatchAsync(this IHttpRequestBuilder httpRequestBuilder)
        {
            var httpRequest = httpRequestBuilder.Build();
            return _client.SendAsync(httpRequest);
        }
    }
}
