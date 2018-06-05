using System;
using Microsoft.SharePoint;

namespace NAPAS.Portal.Common.Framework.Core.Helpers
{
    public class UrlFieldCreator : BaseFieldCreator
    {
        public UrlFieldCreator(string internalName, string displayName) : base(internalName, displayName, SPFieldType.URL)
        {
        }

        public override bool EnforceUniqueValues
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public override string ValidationFormula
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public SPUrlFieldFormatType DisplayFormat { get; set; }

        internal override void CreateField(SPList list)
        {
            SPFieldUrl field;

            try
            {
                field = (SPFieldUrl)list.Fields.GetFieldByInternalName(InternalName);
            }
            catch
            {
                list.Fields.AddFieldAsXml(this.XMLFieldFormat(string.Empty), true, SPAddFieldOptions.AddFieldInternalNameHint);
                list.Update();
            }

            field = (SPFieldUrl)list.Fields.GetFieldByInternalName(InternalName);
            //field.Description = Description;
            field.DisplayFormat = DisplayFormat;
            field.Title = Name;
            field.AllowDeletion = true;
            field.Update();
        }
    }
}