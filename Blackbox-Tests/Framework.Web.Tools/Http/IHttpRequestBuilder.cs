using System.Net.Http;

namespace Framework.Web.Tools.Http
{
    public interface IHttpRequestBuilder
    {
        IHttpRequestBuilder WithGetVerb();
        IHttpRequestBuilder WithDeleteVerb();
        IHttpRequestsWithContentBuilder WithPutVerb();
        IHttpRequestsWithContentBuilder WithPostVerb();
        IHttpRequestBuilder WithUrl(string url);
        IHttpRequestBuilder WithToken(string tokenValue, TokenType tokenType);
        IHttpRequestBuilder WithAcceptHeader(string value);
        HttpRequestMessage Build();
    }
}
