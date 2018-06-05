using System.Web.UI;
using Microsoft.SharePoint;

namespace NAPAS.Portal.Common.Framework.Core.WebControls
{
    public class ScriptLink : System.Web.UI.Control
    {
        public string ScriptPath { get; set; }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
            writer.AddAttribute(HtmlTextWriterAttribute.Src, SPContext.Current.Web.Url + "/" + ScriptPath);
            writer.RenderBeginTag(HtmlTextWriterTag.Script);
            writer.RenderEndTag();
        }
    }
}

