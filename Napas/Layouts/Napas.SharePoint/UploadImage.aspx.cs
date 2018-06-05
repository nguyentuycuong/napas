using System;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace Napas.SharePoint
{
	public partial class UploadImage : DialogAwareLayoutsPageBage
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		}

		protected void btnUpload_Click(object sender, EventArgs e)
		{
			//TODO: Handle case where file to upload has not been selected

			var uploadLocation = GetUploadLocation();

			//TODO: Handle case where uploadLocation is not specified
			var imageUrl = UploadImageToLibrary(uploadLocation);

			/*Close the dialog and set the eventArgs param for the JS callBack function. The fields are as follow:
			 * 
			 * imageUrl:	URL	of the uploaded image
			 * controlIDs:	The args object that was originally passed to this dialog
			 * */

			var eventArgsJavaScript = String.Format("{{imageUrl:'{0}',controlIDs:window.frameElement.dialogArgs}}", imageUrl);
			base.EndOperation(ModalDialogResult.OK, eventArgsJavaScript);
		}
		
		protected void btnCancel_Click(object sender, EventArgs e)
		{
			base.EndOperation(ModalDialogResult.Cancel);
		}

		private string GetUploadLocation()
		{
			//TODO: Handle case where the IDs are not specified.
			var listID = this.Request.QueryString["lID"];
			var fieldID = this.Request.QueryString["fID"];
			var list = SPContext.Current.Web.Lists.GetList(new Guid(listID), false);
			var field = list.Fields[new Guid(fieldID)];

			return ((ImageUploadFieldType)field).UploadImagesTo;
		}

		/// <summary>
		/// Returns the URL of the newly uploaded image
		/// </summary>
		/// <param name="uploadLocation">The name of a library in the current web where the image should be uploaded to</param>
		/// <returns></returns>
		private string UploadImageToLibrary(string uploadLocation)
		{
			if (fileUpload.HasFile)
			{
                SPFile uploadedFile;
                string libraryTo = uploadLocation;
                string folderTo = string.Empty;

                if(uploadLocation.Contains("/"))
                {
                    libraryTo = uploadLocation.Split('/')[0];
                    folderTo = uploadLocation.Split('/')[1];
                }

				//TODO: Handle case where location is not valid
				var web = SPContext.Current.Web;

                var fd = web.GetFolder("/" + uploadLocation.TrimStart('/').TrimEnd('/') + "/");
                uploadedFile = fd.Files.Add(fileUpload.FileName, fileUpload.PostedFile.InputStream, true);

				//var library = web.Lists[uploadLocation];
                //var library = web.Lists[libraryTo];

                //if (!string.IsNullOrEmpty(folderTo))
                //{
                //    SPFolder folder = library.RootFolder.SubFolders[folderTo];
                //    uploadedFile = folder.Files.Add(fileUpload.FileName, fileUpload.PostedFile.InputStream, true);
                //}
                //else
                //{
                //    uploadedFile = library.RootFolder.Files.Add(fileUpload.FileName, fileUpload.PostedFile.InputStream, true);
                //}

				//TODO: Handle existing file - for now we are overwriting
				//SPFile uploadedFile = library.RootFolder.Files.Add(fileUpload.FileName, fileUpload.PostedFile.InputStream, true);
				return web.Url.TrimEnd('/') + '/' + uploadedFile.Url.TrimStart('/');
			}
			return String.Empty;
		}
	}
}
