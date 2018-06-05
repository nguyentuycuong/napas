using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Microsoft.SharePoint.WebControls;

namespace NAPAS.Portal.Common.Framework.Core.WebControls
{
    public class CheckBoxChoiceField : Microsoft.SharePoint.WebControls.CheckBoxChoiceField
    {
        public string OnClientClick { get; set; }

        /// <summary>
        /// Multiple default value, separate by ;#
        /// </summary>
        public string DefaultValues { get; set; }

        protected override void CreateChildControls()
        {
            base.CreateChildControls();

            List<string> defaultValues;
            if (!Page.IsPostBack && ControlMode == SPControlMode.New && !string.IsNullOrEmpty(DefaultValues))
            {
                defaultValues = DefaultValues.Split(new[] {";#"}, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            else
            {
                defaultValues = new List<string>();
            }

            if (!string.IsNullOrEmpty(OnClientClick))
            {
                foreach (var control in Controls)
                {
                    if (control is CheckBox)
                    {
                        var checkBox = (CheckBox)control;
                        checkBox.Attributes.Add("onclick", string.Format("{0}(this, '{1}')", OnClientClick, checkBox.Text));

                        if (defaultValues.Contains(checkBox.Text))
                        {
                            checkBox.Checked = true;
                        }
                    }
                }
            }
        }
    }
}
