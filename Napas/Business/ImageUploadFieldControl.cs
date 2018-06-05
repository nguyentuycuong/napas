using System;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace Napas.SharePoint
{
	public class ImageUploadFieldControl : BaseFieldControl
	{
		#region Overview of how this control works
		/*How this control works:
		 * 
		 * In edit mode, the upload link uses JS to launch the UploadImage page in a dialog. 4 parameters are passed
		 * to the JS function that launches the UploadImage page:
		 * 
		 * imageControlID: Identifies the IMG element that is used to display the image.
		 * urlHolderControlID: Identifies a hidden control that is used to store the URL of the uploaded image 
		 *		so that this could be extracted by our custom field on postBack. 
		 * listID: The SharePoint ID of the list containing our field. 
		 * fieldID: The SharePoint ID of our field.
		 * 
		 * The JS function passes the first 2 params to the UploadImage page using the args parameter 
		 * of the dialogOption object when opening the page as a dialog. The 3rd and 4th params are passed 
		 * as query string params to the UploadImage page, which uses these params to read additional 
		 * settings associated with the field, e.g. location to upload the image to.
		 * 
		 * The UploadImage page calls a JS callBack function upon closing. The page passes in 2 parameters to this callBack
		 * function. The first param is the dialog result as per normal SP convention. The second param is an object (eventArgs)
		 * that has the following fields:
		 * 
		 * eventArgs.imageUrl:						URL of the uploaded image
		 * eventArgs.controlIDs.imageElementID:		HTML ID of the IMG that is used to display the image
		 * eventArgs.controlIDs.urlHolderElementID:	HTML ID of the hidden control that is used to store the URL of the image
		 * 
		 * The callBack function uses this object to update the HTML of the page.
		 * */
		#endregion

		//These controls are common to both edit/display templates
		private Image imgImage;

		//Edit template controls
		private HtmlAnchor lnkLaunchUploadImagePage;
		private LinkButton btnRemoveImage;
		private HtmlInputHidden hiddenImageUrl;

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			if (Page.IsPostBack)
			{
				//Sync up the image and the urlHolder for each post back if we are in edit/new mode
				if (base.ControlMode == SPControlMode.Edit || base.ControlMode == SPControlMode.New)
				{
					imgImage.ImageUrl = hiddenImageUrl.Value;

					bool isValueSpecified = !String.IsNullOrEmpty(hiddenImageUrl.Value);
					SetupEditControlsForFieldValueState(isValueSpecified);
				}
			}
		}

		protected override void CreateChildControls()
		{
			//If the field we are working on is null then exit and do nothing
			if (base.Field == null)
			{
				return;
			}
			
			base.CreateChildControls();
			
			//Now instantiate the control instance variables with the controls defined in the rendering templates.
			InstantiateMemberControls();

			if (base.ControlMode == SPControlMode.Display)
			{
				SetupDisplayTemplateControls();
			}
			else
			{
				SetupEditTemplateControls();
			}
		}

		#region Server side handlers
		void btnRemoveImage_Click(object sender, EventArgs e)
		{
			imgImage.ImageUrl = hiddenImageUrl.Value = String.Empty;
			SetupEditControlsForFieldValueState(false);
		}
		#endregion

		#region Private methods
		private void SetupDisplayTemplateControls()
		{
			bool isFieldValueSpecified = base.ItemFieldValue != null;

			//Hide the image if we do not have a URL to display
			SetControlCssVisibility(imgImage, isFieldValueSpecified);

			if (isFieldValueSpecified)
			{
				imgImage.ImageUrl = ((SPFieldUrlValue)base.ItemFieldValue).Url;
			}
		}

		private void SetupEditTemplateControls()
		{
			lnkLaunchUploadImagePage.HRef = String.Format(lnkLaunchUploadImagePage.HRef,
				imgImage.ClientID, hiddenImageUrl.ClientID, base.List.ID, base.Field.Id);
			
			bool isFieldValueSpecified = base.ItemFieldValue != null;
			SetupEditControlsForFieldValueState(isFieldValueSpecified);

			btnRemoveImage.Click += new EventHandler(btnRemoveImage_Click);
		}
		
		/// <summary>
		/// Tweaks controls depending on whether a value has been specified for the field.
		/// </summary>
		/// <param name="isValueSpecified"></param>
		private void SetupEditControlsForFieldValueState(bool isValueSpecified)
		{
			SetControlCssVisibility(imgImage, isValueSpecified);
			SetControlCssVisibility(btnRemoveImage, isValueSpecified);

			lnkLaunchUploadImagePage.InnerText = isValueSpecified ? "Upload another image" : "Upload an image";
		}

		private void InstantiateMemberControls()
		{
			//Common
			imgImage = (Image)base.TemplateContainer.FindControl("imgImage");

			//Edit controls
			lnkLaunchUploadImagePage = (HtmlAnchor)base.TemplateContainer.FindControl("lnkLaunchUploadImagePage");
			btnRemoveImage = (LinkButton)base.TemplateContainer.FindControl("btnRemoveImage");
			hiddenImageUrl = (HtmlInputHidden)base.TemplateContainer.FindControl("hiddenImageUrl");
		}

		private void SetControlCssVisibility(WebControl control, bool visible)
		{
			//While we want to hide the control, we still want it to be rendered out to the client. This is
			//so that we can use JS to make the control visible again (e.g. after the user has uploaded an image). This
			//is why we are hiding by CSS.
			if (!visible)
			{
				control.Style["display"] = "none";
			}
			else
			{
				control.Style.Remove("display");
			}
		}
		#endregion

		#region Properties
		public override object Value
		{
			//This is called at begining and editing of a list item. This means we only have to deal with
			//the editing template. Our field is based on the URL field so we will need to deal with SPFieldUrlValue.
			get
			{
				EnsureChildControls();

				if (String.IsNullOrEmpty(hiddenImageUrl.Value))
				{
					//Returning null here will cause SharePoint to NOT call the GetValidatedString() method
					//in our field type class. Return an empty UrlValue instead.
					return new SPFieldUrlValue();
				}

				var urlValue = new SPFieldUrlValue();
				urlValue.Url = urlValue.Description = hiddenImageUrl.Value;
				return urlValue;
			}
			set
			{
				EnsureChildControls();

				var urlValue = (SPFieldUrlValue)value;
				if (urlValue != null)
				{
					imgImage.ImageUrl = hiddenImageUrl.Value = urlValue.Url;
				}
				else
				{
					imgImage.ImageUrl = hiddenImageUrl.Value = String.Empty;
				}
			}
		}

		protected override string DefaultTemplateName
		{
			get
			{
				return base.ControlMode == SPControlMode.Display ? this.DisplayTemplateName : "ImageUploadField";
			}
		}

		public override string DisplayTemplateName
		{
			get { return "ImageUploadFieldDisplay"; }
			set { throw new NotSupportedException(); }
		}
		#endregion
	}
}
