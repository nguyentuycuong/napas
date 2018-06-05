using Microsoft.Web.Iis.Rewrite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace HttpHandleSP
{
    public class HttpHandleSP : IRewriteProvider, IProviderDescriptor
    {
        char oldChar, newChar;     

        public void Initialize(IDictionary<string, string> settings, IRewriteContext rewriteContext)
        {
            string oldCharString, newCharString;
            File.AppendAllText("c:\\SharePointLog\\modules.log", DateTime.Now.ToString() + ": " + " Module.Initialize " + Environment.NewLine);
            if (!settings.TryGetValue("OldChar", out oldCharString) || string.IsNullOrEmpty(oldCharString))
                throw new ArgumentException("OldChar provider setting is required and cannot be empty");

            if (!settings.TryGetValue("NewChar", out newCharString) || string.IsNullOrEmpty(newCharString))
                throw new ArgumentException("NewChar provider setting is required and cannot be empty");

            File.AppendAllText("c:\\SharePointLog\\modules.log", DateTime.Now.ToString() + ": " + " Module.Initialize oldCharString" + oldCharString +  Environment.NewLine);

            if (!string.IsNullOrEmpty(oldCharString))
                oldChar = oldCharString.Trim()[0];
            else
                throw new ArgumentException("OldChar parameter cannot be empty");

            File.AppendAllText("c:\\SharePointLog\\modules.log", DateTime.Now.ToString() + ": " + " Module.Initialize oldChar" + oldChar + Environment.NewLine);

            if (!string.IsNullOrEmpty(newCharString))
                newChar = newCharString.Trim()[0];
            else
                throw new ArgumentException("NewChar parameter cannot be empty");
            File.AppendAllText("c:\\SharePointLog\\modules.log", DateTime.Now.ToString() + ": " + " Module.Initialize newChar" + newChar + Environment.NewLine);
        }

        public string Rewrite(string value)
        {
            File.AppendAllText("c:\\SharePointLog\\modules.log", DateTime.Now.ToString() + ": " + " Module.Rewrite value" + value + Environment.NewLine);
            return value.Replace(oldChar, newChar);
        }

        public IEnumerable<SettingDescriptor> GetSettings()
        {
            yield return new SettingDescriptor("OldChar", "Old Character");
            yield return new SettingDescriptor("NewChar", "New Character");
        }
    }
}
