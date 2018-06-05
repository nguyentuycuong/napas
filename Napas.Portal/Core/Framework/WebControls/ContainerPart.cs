using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;

namespace NAPAS.Portal.Common.Framework.Core.WebControls
{
    public class ContainerPart : System.Web.UI.Control, INamingContainer
    {
        protected System.Web.UI.Control userControl;

        public string UserControlPath { get; set; }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            if (string.IsNullOrEmpty(UserControlPath))
            {
                Controls.Clear();
                Controls.Add(new Literal { Text = "(No User Control Specified)" });
            }
            else
            {
                try
                {
                    var path = UserControlPath.Replace("$Site", SPContext.Current.Web.ServerRelativeUrl).Replace("//", "/");
                    userControl = Page.LoadControl(path);
                    userControl.ID = ID + "_UserControl";
                    Controls.Add(userControl);
                }
                catch (Exception ex)
                {
                    Controls.Clear();
                    Controls.Add(new Literal { Text = string.Format("ContainerPart ({0})", ex.Message) });
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            EnsureChildControls();
            base.OnInit(e);
        }
    }
}
