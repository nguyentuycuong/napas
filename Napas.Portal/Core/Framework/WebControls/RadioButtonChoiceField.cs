using System.Web.UI.WebControls;

namespace NAPAS.Portal.Common.Framework.Core.WebControls
{
    public class RadioButtonChoiceField : Microsoft.SharePoint.WebControls.RadioButtonChoiceField
    {
        public string OnClientClick { get; set; }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            if (!string.IsNullOrEmpty(OnClientClick))
            {
                foreach (var control in Controls)
                {
                    if (control is RadioButton)
                    {
                        var radioControl = (RadioButton) control;
                        radioControl.Attributes.Add("onclick", string.Format("{0}(this, '{1}')", OnClientClick, radioControl.Text));
                    }
                }
            }
        }
    }
}
