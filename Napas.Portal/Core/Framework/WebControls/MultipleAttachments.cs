using System.Web.UI;
using System.Web.UI.WebControls;

namespace NAPAS.Portal.Common.Framework.Core.WebControls
{
    public class MultipleAttachments : System.Web.UI.Control
    {
        public Unit LabelWidth { get; set; }

        public string CssClass { get; set; }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);

            if (string.IsNullOrEmpty(CssClass))
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "ms-attachments");    
            }
            else
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, "ms-attachments " + CssClass);
            }
            
            writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "0");
            writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0");
            writer.RenderBeginTag(HtmlTextWriterTag.Table);

            writer.RenderBeginTag(HtmlTextWriterTag.Tr);

            if (!LabelWidth.IsEmpty)
            {
                switch (LabelWidth.Type)
                {
                    case UnitType.Pixel:
                        writer.AddStyleAttribute(HtmlTextWriterStyle.Width, LabelWidth.Value + "px");
                        break;
                    default:
                        writer.AddStyleAttribute(HtmlTextWriterStyle.Width, LabelWidth.Value.ToString());
                        break;
                }
            }
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.Write("&nbsp;");
            writer.RenderEndTag(); // td

            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.Write("&nbsp;");
            writer.RenderEndTag(); // td

            writer.RenderEndTag(); // tr

            writer.RenderEndTag(); // table

            writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
            writer.RenderBeginTag(HtmlTextWriterTag.Script);
            writer.Write("$(document).ready(function(){");

            // Move attachments table into correct position
            writer.Write(string.Format("$('#{0}').prepend($('#idAttachmentsRow'));", ClientID));

            // Move attachment panel into page bottom
            writer.Write("$('#part1').after($('#partAttachment'));");

            // Remove width attribute
            writer.Write(string.Format("$('td.ms-formbody', $('#{0}')).removeAttr('width');", ClientID));

            writer.Write("});");
            writer.RenderEndTag(); // script
        }
    }
}
