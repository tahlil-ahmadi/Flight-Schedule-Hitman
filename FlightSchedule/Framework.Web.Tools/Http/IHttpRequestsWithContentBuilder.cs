namespace Framework.Web.Tools.Http
{
    public interface IHttpRequestsWithContentBuilder : IHttpRequestBuilder
    {
        IHttpRequestsWithContentBuilder WithContentAsJson(object content, string domainModel = null);
        IHttpRequestsWithContentBuilder WithContentAsPlainText(string content, string domainModel = null);
        
    }
}