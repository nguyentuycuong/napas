using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace Napas.SharePoint
{
	public class ImageUploadFieldType : SPFieldUrl
	{
		public ImageUploadFieldType(SPFieldCollection fields, string fieldName) : base(fields, fieldName)
		{
			this.DisplayFormat = SPUrlFieldFormatType.Image;
		}

		public ImageUploadFieldType(SPFieldCollection fields, string typeName, string displayName)
			: base(fields, typeName, displayName)
		{
			this.DisplayFormat = SPUrlFieldFormatType.Image;
		}

		public override void OnAdded(SPAddFieldOptions op)
		{
			/*We will need to update the field again after it is added to save the custom setting properties. For more
			 * info see http://msdn.microsoft.com/en-us/library/cc889345(office.12).aspx#CreatingWSS3CustomFields_StoringFieldSetting */

			base.OnAdded(op);
			this.Update();
		}

		public override void Update()
		{
			var uploadImagesToValueFromThreadData = Thread.GetData(Thread.GetNamedDataSlot(ImageUploadFieldTypeCustomPropertyNames.UploadImagesTo));

			if (uploadImagesToValueFromThreadData != null)
			{
				this.UploadImagesTo = (string)uploadImagesToValueFromThreadData;
			}
			base.Update();
		}

		public override string GetValidatedString(object value)
		{
			if (!base.Required)
			{
				return base.GetValidatedString(value);
			}

			var urlValue = value as SPFieldUrlValue;
			if (urlValue == null || String.IsNullOrEmpty(urlValue.Url))
			{
				throw new SPFieldValidationException(base.Title + " is a required field.");
			}
			return base.GetValidatedString(value);
		}

		public override BaseFieldControl FieldRenderingControl
		{
			get
			{
				return new ImageUploadFieldControl() { FieldName = base.InternalName };
			}
		}

		public string UploadImagesTo
		{
			get
			{
				return (string)base.GetCustomProperty(ImageUploadFieldTypeCustomPropertyNames.UploadImagesTo);
			}
			set
			{
				base.SetCustomProperty(ImageUploadFieldTypeCustomPropertyNames.UploadImagesTo, value); 
			}
		}
	}
}
