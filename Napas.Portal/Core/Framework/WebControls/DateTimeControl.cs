using System;
using System.Web.UI;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace NAPAS.Portal.Common.Framework.Core.WebControls
{
    public class DateTimeControl : Microsoft.SharePoint.WebControls.DateTimeControl
    {
        public DateTimeControl()
        {
            var web = SPContext.Current.Web;
            LocaleId = web.Locale.LCID;
            ShowDateFormatHint = true;
            DatePickerFrameUrl = web.Url + "/_layouts/15/iframe.aspx";
        }

        public bool ShowDateFormatHint { get; set; }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            if (Page.Items["IS_SHORT_DATE_PATTERN_REGISTED"] == null)
            {
                Page.ClientScript.RegisterHiddenField("Short_Date_Pattern", SPContext.Current.Web.Locale.DateTimeFormat.ShortDatePattern);
                Page.Items["IS_SHORT_DATE_PATTERN_REGISTED"] = true;
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (ShowDateFormatHint)
            {
                var formContext = SPContext.Current.FormContext;
                if (formContext != null && (formContext.FormMode == SPControlMode.New || formContext.FormMode == SPControlMode.Edit))
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Cellpadding, "0");
                    writer.AddAttribute(HtmlTextWriterAttribute.Cellspacing, "0");
                    writer.RenderBeginTag(HtmlTextWriterTag.Table);

                    writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);
                    base.Render(writer);
                    writer.RenderEndTag(); // td
                    writer.RenderEndTag();

                    writer.RenderBeginTag(HtmlTextWriterTag.Tr);
                    writer.RenderBeginTag(HtmlTextWriterTag.Td);

                    writer.AddAttribute(HtmlTextWriterAttribute.Class, "ms-date-format-hint");
                    writer.RenderBeginTag(HtmlTextWriterTag.Span);
                    writer.Write(string.Format("Enter date in {0} format.", SPContext.Current.Web.Locale.DateTimeFormat.ShortDatePattern));
                    writer.RenderEndTag(); // span

                    writer.RenderEndTag(); // td
                    writer.RenderEndTag();

                    writer.RenderEndTag(); // table
                }
                else
                {
                    base.Render(writer);
                }
            }
            else
            {
                base.Render(writer);
            }
        }
    }
}

