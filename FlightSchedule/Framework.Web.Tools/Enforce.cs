using Framework.Web.Tools.Http;

namespace Framework.Web.Tools
{
    public static class Enforce
    {
        public static class That
        {
            public static void ExceptionParserHasBeenInitialized(ref IExceptionParser exceptionParser)
            {
                if (exceptionParser == null)
                    exceptionParser = new ExceptionParser();
            }
        }
    }

}
