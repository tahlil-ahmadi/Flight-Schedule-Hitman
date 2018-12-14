using System.Collections.Generic;
using System.Linq;
using Framework.Web.Tools.Data;

namespace Framework.Web.Tools.Http
{
    public class QueryStringBuilder
    {
        private readonly Dictionary<string, string> _dictionary;
        public QueryStringBuilder()
        {
            this._dictionary = new Dictionary<string, string>();
        }
        public void AddOrUpdate(string key, string value)
        {
            if (string.IsNullOrEmpty(value)) return;
            this._dictionary.AddOrUpdate(key,value);
        }
        public virtual string Build()
        {
            var parameters = _dictionary.Select(a => $"{a.Key}={a.Value}").ToList();
            return "?" + string.Join("&", parameters);
        }
    }
}