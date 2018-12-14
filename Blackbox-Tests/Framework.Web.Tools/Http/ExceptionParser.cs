using System;

namespace Framework.Web.Tools.Http
{
    public  class ExceptionParser : IExceptionParser
    {
        public override void ParseException(string content)
        {
            throw new Exception(content);
        }
    }
}