using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Web;

namespace NAPAS.Portal.Common.Framework.Core.Utils
{
    public class UrlBuilder
    {
        private readonly Hashtable keyValues;
        private readonly string path;

        private UrlBuilder()
        {
            keyValues = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
        }

        public UrlBuilder(Uri uri) : this()
        {
            path = uri.GetLeftPart(UriPartial.Path);
            AppendQueryString(uri.Query);
        }

        public UrlBuilder(string path) : this()
        {
            var indexOf = path.IndexOf('?');
            if (indexOf > -1)
            {
                this.path = path.Substring(0, indexOf);
                AppendQueryString(path.Substring(indexOf + 1));    
            }
            else
            {
                this.path = path;
            }
        }

        public void AppendQueryString(string queryString)
        {
            if (string.IsNullOrEmpty(queryString))
            {
                return;
            }

            var queryStrings = queryString.TrimStart('?').Split(new[] { "&" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var str in queryStrings)
            {
                if (string.IsNullOrEmpty(str))
                {
                    continue;
                }
                var split = str.Split('=');
                var value = split.Length == 2 ? HttpUtility.UrlDecode(split[1]) : string.Empty;
                keyValues[split[0]] = value;
            }
        }

        public void AddQueryString(string key, string value)
        {
            keyValues[key] = value;
        }

        public void RemoveQueryString(string key)
        {
            keyValues.Remove(key);
        }

        public void ClearQueryString()
        {
            keyValues.Clear();
        }

        public T GetQueryStringValue<T>(string key)
        {
            var value = keyValues[key];
            if (value == null || value.ToString() == string.Empty)
            {
                return default(T);
            }

            try
            {
                return (T) Convert.ChangeType(value, typeof (T));
            }
            catch(FormatException)
            {
                return default(T);
            }
        }

        internal string GetUrlWithoutFilterValue(string fieldName)
        {
            var hashtable = (Hashtable) keyValues.Clone();

            var key = (from entry in hashtable.Cast<DictionaryEntry>().Where(entry => String.Equals(Convert.ToString(entry.Value), fieldName, StringComparison.InvariantCultureIgnoreCase))
                          where entry.Key.ToString().StartsWith("FilterField")
                          select entry.Key.ToString()).FirstOrDefault();

            if (!string.IsNullOrEmpty(key))
            {
                var surfix = key.Replace("FilterField", "");
                hashtable.Remove(key);
                hashtable.Remove("FilterValue" + surfix);
            }

            hashtable.Remove("PageFirstRow");
            hashtable.Remove("Paged");
            hashtable["FilterClear"] = "1";

            return ToString(path, hashtable);
        }

        internal void RemoveAllFilterQueryString()
        {
            var keys = keyValues.Keys.Cast<string>().Where(k => k.StartsWith("FilterField")).ToList();
            foreach (var key in keys)
            {
                var surfix = key.Replace("FilterField", "");
                keyValues.Remove(key);
                keyValues.Remove("FilterValue" + surfix);
            }
        }

        internal void RemoveAllSortQueryString()
        {
            var keys = keyValues.Keys.Cast<string>().Where(k => k.StartsWith("p_")).ToList();
            foreach (var key in keys)
            {
                keyValues.Remove(key);
            }
            keyValues.Remove("PageFirstRow");
        }

        public override string ToString()
        {
            return ToString(path, keyValues);
        }

        private static string ToString(string urlPath, Hashtable queryStrings)
        {
            var sb = new StringBuilder();
            sb.Append(urlPath);

            if (queryStrings.Count > 0)
            {
                var hasQueryString = false;
                sb.Append("?");
                foreach (DictionaryEntry entry in queryStrings)
                {
                    if (hasQueryString)
                    {
                        sb.Append("&");
                    }
                    sb.Append(entry.Key);
                    sb.Append("=");
                    sb.Append(HttpUtility.UrlEncode(Convert.ToString(entry.Value)));
                    hasQueryString = true;
                }
            }

            return sb.ToString();
        }
    }
}