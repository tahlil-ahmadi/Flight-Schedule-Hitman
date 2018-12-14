using System;
using Framework.Web.Tools.Http;

namespace Framework.Web.Tools.Serialization
{
    public static class SerializerFactory
    {
        public static ISerializer Create(ContentType contentType)
        {
            if (contentType == ContentType.Json) return new JsonSerializer();
            if (contentType == ContentType.PlainText) return new PlainTextSerializer();
            throw new NotSupportedException();
        }
    }
}