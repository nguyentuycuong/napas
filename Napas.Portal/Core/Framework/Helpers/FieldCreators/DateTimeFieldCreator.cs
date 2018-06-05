namespace NAPAS.Portal.Common.Framework.Core.Helpers
{
    using Microsoft.SharePoint;

    public class DateTimeFieldCreator : BaseFieldCreator
    {
        public DateTimeFieldCreator(string internalName, string displayName)
            : base(internalName, displayName, SPFieldType.DateTime)
        {
        }

        /// <summary>
        /// Gets or sets the type of date and time format that is used in the field. 
        /// </summary>
        public SPDateTimeFieldFormatType DisplayFormat { get; set; }

        internal override void CreateField(SPList list)
        {
            SPFieldDateTime field;

            try
            {
                field = (SPFieldDateTime)list.Fields.GetFieldByInternalName(InternalName);
            }
            catch
            {
                list.Fields.AddFieldAsXml(this.XMLFieldFormat(string.Empty), true, SPAddFieldOptions.AddFieldInternalNameHint);
                list.Update();
            }

            field = (SPFieldDateTime)list.Fields.GetFieldByInternalName(InternalName);
            //field.Description = Description;
            field.DisplayFormat = this.DisplayFormat;
            field.DefaultValue = DefaultValue;
            if (EnforceUniqueValues)
            {
                field.Indexed = true;
                field.EnforceUniqueValues = true;
            }
            field.ValidationFormula = ValidationFormula;
            field.ValidationMessage = ValidationMessage;
            field.Title = Name;
            field.AllowDeletion = true;
            field.Update();
        }
    }
}