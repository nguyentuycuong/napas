// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SectionPanel.cs" company="">
//   
// </copyright>
// <summary>
//   The section panel.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace NAPAS.Portal.Common.Framework.Core.WebControls
{
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Microsoft.SharePoint;
    using Microsoft.SharePoint.WebControls;

    /// <summary>
    /// The section panel.
    /// </summary>
    public class SectionPanel : Panel, IPostBackDataHandler
    {
        #region Fields

        /// <summary>
        /// The hdf state.
        /// </summary>
        protected HiddenField hdfState;

        /// <summary>
        /// The base user control.
        /// </summary>
        private BaseUserControl baseUserControl;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether collapsed.
        /// </summary>
        [Browsable(true)]
        [Category("Properties")]
        [DefaultValue(false)]
        public bool Collapsed
        {
            get
            {
                this.EnsureChildControls();
                var value = this.hdfState.Value;
                if (string.IsNullOrEmpty(value))
                {
                    return false;
                }

                return Convert.ToBoolean(value);
            }

            set
            {
                this.EnsureChildControls();
                this.hdfState.Value = value.ToString();
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether read only.
        /// </summary>
        public bool ReadOnly
        {
            get
            {
                var value = this.ViewState["ReadOnly"];
                if (value == null)
                {
                    return false;
                }

                return (bool)value;
            }

            set
            {
                this.ViewState["ReadOnly"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the section content css class.
        /// </summary>
        [Browsable(true)]
        [Category("Properties")]
        public string SectionContentCssClass
        {
            get
            {
                var s = (string)this.ViewState["SectionContentCssClass"];
                return s ?? string.Empty;
            }

            set
            {
                this.ViewState["SectionContentCssClass"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the section header css class.
        /// </summary>
        [Browsable(true)]
        [Category("Properties")]
        public string SectionHeaderCssClass
        {
            get
            {
                var s = (string)this.ViewState["SectionHeaderCssClass"];
                return s ?? string.Empty;
            }

            set
            {
                this.ViewState["SectionHeaderCssClass"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the section header text css class.
        /// </summary>
        [Browsable(true)]
        [Category("Properties")]
        public string SectionHeaderTextCssClass
        {
            get
            {
                var s = (string)this.ViewState["SectionHeaderTextCssClass"];
                return s ?? string.Empty;
            }

            set
            {
                this.ViewState["SectionHeaderTextCssClass"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the section title.
        /// </summary>
        [Browsable(true)]
        [Category("Properties")]
        public string SectionTitle
        {
            get
            {
                var s = (string)this.ViewState["SectionTitle"];
                return s ?? string.Empty;
            }

            set
            {
                this.ViewState["SectionTitle"] = value;
            }
        }

        /// <summary>
        /// Gets or sets the width.
        /// </summary>
        public override Unit Width
        {
            get
            {
                if (base.Width == Unit.Empty)
                {
                    base.Width = Unit.Percentage(100);
                }

                return base.Width;
            }

            set
            {
                base.Width = value;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the base user control.
        /// </summary>
        protected BaseUserControl BaseUserControl
        {
            get
            {
                if (this.baseUserControl != null)
                {
                    return this.baseUserControl;
                }

                this.baseUserControl = GetParent(this.NamingContainer);
                return this.baseUserControl;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The load post data.
        /// </summary>
        /// <param name="postDataKey">
        /// The post data key.
        /// </param>
        /// <param name="postCollection">
        /// The post collection.
        /// </param>
        /// <returns>
        /// The System.Boolean.
        /// </returns>
        public bool LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            this.EnsureChildControls();
            var oldValue = this.hdfState.Value;
            var postedValue = postCollection[this.hdfState.UniqueID];
            if (oldValue != postedValue)
            {
                this.hdfState.Value = postedValue;
                return true;
            }

            return false;
        }

        /// <summary>
        /// The raise post data changed event.
        /// </summary>
        public void RaisePostDataChangedEvent()
        {
        }

        #endregion

        #region Methods

        /// <summary>
        /// The add attributes to render.
        /// </summary>
        /// <param name="writer">
        /// The writer.
        /// </param>
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            if (this.ID != null)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);
            }

            AddScrollingAttribute(this.ScrollBars, writer);
            var horizontalAlign = this.HorizontalAlign;
            if (horizontalAlign != HorizontalAlign.NotSet)
            {
                var converter = TypeDescriptor.GetConverter(typeof(HorizontalAlign));
                writer.AddStyleAttribute(HtmlTextWriterStyle.TextAlign, converter.ConvertToInvariantString(horizontalAlign).ToLowerInvariant());
            }

            if (!this.Wrap)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.WhiteSpace, "nowrap");
            }

            if (this.Direction == ContentDirection.LeftToRight)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Dir, "ltr");
            }
            else if (this.Direction == ContentDirection.RightToLeft)
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Dir, "rtl");
            }
        }

        /// <summary>
        /// The create child controls.
        /// </summary>
        protected override void CreateChildControls()
        {
            this.hdfState = new HiddenField { Value = "False" };
            this.Controls.Add(this.hdfState);
            base.CreateChildControls();
        }

        /// <summary>
        /// The on init.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.Page.RegisterRequiresPostBack(this);

            // Set Control Mode
            var formContext = SPContext.Current.FormContext;
            if (formContext != null)
            {
                if (formContext.FormMode != SPControlMode.Display && this.ReadOnly)
                {
                    foreach (var control in this.Controls.OfType<BaseFieldControl>())
                    {
                        control.ControlMode = SPControlMode.Display;
                    }
                }
            }
        }

        /// <summary>
        /// The on pre render.
        /// </summary>
        /// <param name="e">
        /// The e.
        /// </param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            const string key = "SectionControl_OnClick";
            if (!this.Page.ClientScript.IsClientScriptBlockRegistered(this.GetType(), key))
            {
                var script = new StringBuilder();
                script.Append("function SectionControl_OnClick(hdfStateClientId, contentClientId){");
                script.Append("var hdfState = $('#' + hdfStateClientId);");
                script.Append("if(hdfState.val() == 'False'){");
                script.Append("$('#' + contentClientId).slideUp('fast');");
                script.Append("$('#' + contentClientId + '_Icon').attr('src', '/_layouts/images/dlmax.gif');");
                script.Append("hdfState.val('True');}");
                script.Append("else{$('#' + contentClientId).slideDown('fast');");
                script.Append("$('#' + contentClientId + '_Icon').attr('src', '/_layouts/images/dlmin.gif');");
                script.Append("hdfState.val('False');}");
                script.Append("}"); // end function
                this.Page.ClientScript.RegisterClientScriptBlock(this.GetType(), key, script.ToString(), true);
            }
        }

        /// <summary>
        /// The render.
        /// </summary>
        /// <param name="writer">
        /// The writer.
        /// </param>
        protected override void Render(HtmlTextWriter writer)
        {
            if (string.IsNullOrEmpty(this.CssClass))
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.MarginTop, "0");
                writer.AddStyleAttribute(HtmlTextWriterStyle.MarginBottom, "0");
            }
            else
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, this.CssClass);
            }

            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, this.Width.ToString());

            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            // Render header
            if (string.IsNullOrEmpty(this.SectionHeaderCssClass))
            {
                writer.AddStyleAttribute("border-top", "#b8babd 1px solid");
                writer.AddStyleAttribute("min-height", "29px");
                writer.AddStyleAttribute("background", "url(/_layouts/images/selbg.png/images/selbg.png) #EAF1F7 repeat-x left top");
                writer.AddStyleAttribute("border-bottom", "#e0e0e0 1px solid");
                writer.AddStyleAttribute(HtmlTextWriterStyle.Height, "29px");
                writer.AddStyleAttribute(HtmlTextWriterStyle.MarginBottom, "0");
                writer.AddStyleAttribute("border-left", "#e0e0e0 1px solid");
                writer.AddStyleAttribute("border-right", "#e0e0e0 1px solid");
            }
            else
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, this.SectionHeaderCssClass);
            }

            writer.AddStyleAttribute(HtmlTextWriterStyle.Width, "100%");

            writer.RenderBeginTag(HtmlTextWriterTag.Div);

            // Render header text
            if (string.IsNullOrEmpty(this.SectionHeaderTextCssClass))
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.FontWeight, "bold");
            }
            else
            {
                writer.AddAttribute(HtmlTextWriterAttribute.Class, this.SectionHeaderTextCssClass);
            }

            writer.AddStyleAttribute("float", "left");
            writer.AddStyleAttribute(HtmlTextWriterStyle.PaddingLeft, "10px");
            writer.AddStyleAttribute("line-height", "29px");
            writer.AddStyleAttribute("vertical-align", "middle");
            writer.AddAttribute("onmouseover", "this.style.textDecoration = 'none';");
            writer.RenderBeginTag(HtmlTextWriterTag.A);
            writer.Write(this.SectionTitle);
            writer.RenderEndTag();

            // Render header status icon
            writer.AddStyleAttribute("float", "right");
            writer.AddStyleAttribute(HtmlTextWriterStyle.PaddingRight, "10px");
            writer.AddStyleAttribute("line-height", "29px");
            writer.AddAttribute(HtmlTextWriterAttribute.Href, "#");
            writer.AddAttribute(HtmlTextWriterAttribute.Border, "none");
            writer.AddAttribute(HtmlTextWriterAttribute.Onclick, string.Format("SectionControl_OnClick('{0}', '{1}');return false;", this.hdfState.ClientID, this.ClientID));
            writer.RenderBeginTag(HtmlTextWriterTag.A);

            writer.AddAttribute(HtmlTextWriterAttribute.Border, "none");
            writer.AddAttribute(HtmlTextWriterAttribute.Src, this.Collapsed ? "/_layouts/images/dlmax.gif" : "/_layouts/images/dlmin.gif");
            writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID + "_Icon");
            writer.RenderBeginTag(HtmlTextWriterTag.Img);
            writer.RenderEndTag(); // img

            writer.RenderEndTag(); // p

            writer.RenderEndTag(); // div

            // Render Content
            if (this.Collapsed)
            {
                writer.AddStyleAttribute(HtmlTextWriterStyle.Display, "none");
            }

            base.Render(writer);

            writer.RenderEndTag(); // div
        }

        /// <summary>
        /// The add scrolling attribute.
        /// </summary>
        /// <param name="scrollBars">
        /// The scroll bars.
        /// </param>
        /// <param name="writer">
        /// The writer.
        /// </param>
        private static void AddScrollingAttribute(ScrollBars scrollBars, HtmlTextWriter writer)
        {
            switch (scrollBars)
            {
                case ScrollBars.Horizontal:
                    writer.AddStyleAttribute(HtmlTextWriterStyle.OverflowX, "scroll");
                    return;

                case ScrollBars.Vertical:
                    writer.AddStyleAttribute(HtmlTextWriterStyle.OverflowY, "scroll");
                    return;

                case ScrollBars.Both:
                    writer.AddStyleAttribute(HtmlTextWriterStyle.Overflow, "scroll");
                    return;

                case ScrollBars.Auto:
                    writer.AddStyleAttribute(HtmlTextWriterStyle.Overflow, "auto");
                    return;
            }
        }

        /// <summary>
        /// The get parent.
        /// </summary>
        /// <param name="control">
        /// The control.
        /// </param>
        /// <returns>
        /// The NAPAS.Portal.Common.Framework.Core.WebControls.BaseUserControl.
        /// </returns>
        private static BaseUserControl GetParent(Control control)
        {
            if (control == null)
            {
                return null;
            }

            if (control is BaseUserControl)
            {
                return (BaseUserControl)control;
            }

            return GetParent(control.NamingContainer);
        }

        #endregion
    }
}