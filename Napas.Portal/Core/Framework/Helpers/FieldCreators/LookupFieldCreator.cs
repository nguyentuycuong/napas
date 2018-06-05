namespace NAPAS.Portal.Common.Framework.Core.Helpers
{
    using System;
    using System.IO;
    using Microsoft.SharePoint;


    public class LookupFieldCreator : BaseFieldCreator
    {
        public LookupFieldCreator(string internalName, string displayName)
            : base(internalName, displayName, SPFieldType.Lookup)
        {
        }

        public override string ValidationFormula
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Gets or sets a Boolean value that specifies whether multiple values can be used in the lookup field.
        /// </summary>
        public bool AllowMultipleValues { get; set; }

        /// <summary>
        /// Gets or sets a Boolean value that specifies whether index can be used in the lookup field.
        /// </summary>
        public bool Indexed { get; set; }

        /// <summary>
        /// Gets or sets a Boolean value that indicates whether the lookup field is discoverable from the list to which it looks for its value.
        /// </summary>
        public bool IsRelationship { get; set; }

        /// <summary>
        /// Gets or sets a field name for lookup (Internal Name).
        /// </summary>
        public string LookupField { get; set; }

        /// <summary>
        /// Gets or sets a list name for lookup (URL name)
        /// </summary>
        public string LookupList { get; set; }

        /// <summary>
        /// Gets or sets the delete behavior of the lookup field.
        /// </summary>
        public SPRelationshipDeleteBehavior RelationshipDeleteBehavior { get; set; }

        internal override void CreateField(SPList list)
        {
            var targetList = list.ParentWeb.Lists[LookupList];
            
            var name = list.Fields.AddLookup(InternalName, targetList.ID, Required);

            //var name = list.Fields.AddLookup(Name, targetList.ID, Required);

            var field = (SPFieldLookup)list.Fields.GetFieldByInternalName(InternalName);
            //field.Description = this.Description;
            field.Title = Name;
            field.LookupField = this.LookupField;
            field.AllowMultipleValues = this.AllowMultipleValues;
            field.IsRelationship = this.IsRelationship;
            field.RelationshipDeleteBehavior = this.RelationshipDeleteBehavior;
            field.Required = this.Required;
            field.Indexed = this.Indexed;

            #region Changed by DungNT34
            if (EnforceUniqueValues)
            {
                field.Indexed = true;
                field.EnforceUniqueValues = true;
            }
            #endregion

            field.Update();
            //if (targetList != null)
            //{
              
            //    //SPField lookupField = targetList.Fields.GetFieldByInternalName(this.LookupField);

            //    SPFieldLookup field;

            //    try
            //    {
            //        field = (SPFieldLookup)list.Fields.GetFieldByInternalName(InternalName);
            //    }
            //    catch
            //    {
            //        list.Fields.AddFieldAsXml(this.XMLFieldFormat(targetList.ID.ToString(), this.LookupField), true, SPAddFieldOptions.AddFieldInternalNameHint);
            //        list.Update();
            //    }
            //    /*
            //    field = (SPFieldLookup)list.Fields.GetFieldByInternalName(InternalName);
            //    //field.Description = this.Description;
            //    //field.LookupField = this.LookupField;
            //    field.AllowMultipleValues = this.AllowMultipleValues;
            //    field.IsRelationship = this.IsRelationship;
            //    field.RelationshipDeleteBehavior = this.RelationshipDeleteBehavior;

            //    if (EnforceUniqueValues)
            //    {
            //        field.Indexed = true;
            //        field.EnforceUniqueValues = true;
            //    }

            //    field.Title = Name;
            //    field.AllowDeletion = true;
            //    field.Update();
            //     * */
            //}
        }
    }
}