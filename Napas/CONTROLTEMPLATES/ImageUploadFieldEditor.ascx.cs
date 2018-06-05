using System;
using System.Threading;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace Napas.SharePoint
{
	public partial class ImageUploadFieldEditor : UserControl, IFieldEditor
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		public bool DisplayAsNewSection
		{
			get { return false; }
		}

		public void InitializeWithField(SPField field)
		{
			//In this method we will sync the custom settings of the field with 
			//our custom setting controls on the editor screen. Field however will be null when we are in create mode, in
			//which case the default value (as specified in the fldtypes XML will apply).
			if (!Page.IsPostBack && field != null)
			{
				txtUploadImagesTo.Text = ((ImageUploadFieldType)field).UploadImagesTo;
			}
		}

		public void OnSaveChange(SPField field, bool isNewField)
		{
			/*This is perhaps the most tricky part in implementing custom field type properties. 
			 * The field param passed in to this method is a different object instance to the actual field being edited.
			 * This is why we'll need to set the value to be saved into the LocalThreadStorage, and retrieve it back out
			 * in the FieldType class and update the field with the custom setting properties. For more info see
			 * http://msdn.microsoft.com/en-us/library/cc889345(office.12).aspx#CreatingWSS3CustomFields_StoringFieldSetting */

			//TODO: Handle case where location is not specified or not valid
			Thread.SetData(Thread.GetNamedDataSlot(ImageUploadFieldTypeCustomPropertyNames.UploadImagesTo), txtUploadImagesTo.Text);
		}
	}
}
