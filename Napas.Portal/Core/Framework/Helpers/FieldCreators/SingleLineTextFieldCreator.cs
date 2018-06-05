using Microsoft.SharePoint;
using System;

namespace NAPAS.Portal.Common.Framework.Core.Helpers
{
    public class SingleLineTextFieldCreator : BaseFieldCreator
    {
        public SingleLineTextFieldCreator(string name)
            : base(name, name, SPFieldType.Text)
        {
            this.MaxLength = 255;
        }

        public SingleLineTextFieldCreator(string internalName, string displayName)
            : base(internalName, displayName, SPFieldType.Text)
        {
            this.MaxLength = 255;
        }


        /// <summary>
        /// Gets or sets the maximum number of characters that can be typed in the field. 
        /// </summary>
        public int MaxLength { get; set; }

        internal override void CreateField(SPList list)
        {
            SPFieldText field;
            try
            {
                field = (SPFieldText)list.Fields.GetFieldByInternalName(InternalName);
            }
            catch
            {
                list.Fields.AddFieldAsXml(this.XMLFieldFormat(string.Empty), true, SPAddFieldOptions.AddFieldInternalNameHint);
                list.Update();
            }

            field = (SPFieldText)list.Fields.GetFieldByInternalName(InternalName);
            //field.Description = Description;
            field.MaxLength = MaxLength;
            field.DefaultValue = DefaultValue;
            
            if (EnforceUniqueValues)
            {
                field.Indexed = true;
                field.EnforceUniqueValues = true;    
            }
            
            field.ValidationFormula = ValidationFormula;
            field.ValidationMessage = ValidationMessage;
            field.AllowDeletion = true;
              
            field.Update();            
        }
    }
}