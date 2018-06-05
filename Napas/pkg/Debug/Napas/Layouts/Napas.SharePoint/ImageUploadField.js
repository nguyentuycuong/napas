function launchUploadImagePage(imageControlID, urlHolderControlID, listID, fieldID) {
	/*This function launches a dialog page that allows user to upload the image. The dialogCallBack function
	will update the specified image control with the URL of the newly uploaded image. The callBack function
	will also copy this URL to a specified hidden control. This hidden control will allow our custom field to
	extract the new URL and save it to the SharePoint field on postBack.
				
	imageControlID:	the HTML ID of the IMG element that is used to display the uploaded image.
	urlHolderControlID:	the HTML ID of the INPUT (hidden) element that will hold the URL of the uploaded image.
	listID: SharePoint ID of the list containing the field that represents the image. This will be passed to the 
		dialog page as part of the queryString
	fieldID: SharePoint ID of the field that represents this image. This will be passed to the dialog page as part of the
		queryString.*/

	var dialogOptions = {
		url: SP.Utilities.Utility.getLayoutsPageUrl("Napas.SharePoint/UploadImage.aspx?lID=" + listID + "&fID=" + fieldID),
		title: "Upload an Image",
		args: { imageElementID: imageControlID, urlHolderElementID: urlHolderControlID },
		dialogReturnValueCallback: Function.createDelegate(null, uploadImagePage_OnClose)
	};

	SP.UI.ModalDialog.showModalDialog(dialogOptions);
}

function uploadImagePage_OnClose(result, eventArgs) {
	/*eventArgs is an object containing the following fields:

	eventArgs.imageUrl:							URL	of the uploaded image
	eventArgs.controlIDs.imageElementID:		HTML ID of the IMG that is used to display the image
	eventArgs.controlIDs.urlHolderElementID:	HTML ID of the hidden control that is used to store the URL of the image
	*/

	if (result == SP.UI.DialogResult.OK) {
		//Clean any " from the URL
		while (eventArgs.imageUrl.indexOf('"') != -1) {
			eventArgs.imageUrl = returnValue.imageUrl.replace('"', '');
		}

		//The Image and the Remove Image elements would have been hidden if the field did not have
		//a value specified. Unhide them here.
		var imgElement = document.getElementById(eventArgs.controlIDs.imageElementID);
		imgElement.src = eventArgs.imageUrl;
		imgElement.style.display = "block";

		var removeImgElement = getRelatedElementFromImageElementID(imgElement.id, "btnRemoveImage");
		removeImgElement.style.display = "inline";

		//Further UI tweaks
		var uploadImgElement = getRelatedElementFromImageElementID(imgElement.id, "lnkLaunchUploadImagePage");
		uploadImgElement.innerText = "Upload another image";

		document.getElementById(eventArgs.controlIDs.urlHolderElementID).value = eventArgs.imageUrl;
	}
}

function getRelatedElementFromImageElementID(imgElementID, relatedElementServerSideID) {
	/*Returns the specified related element (e.g. Upload Image or Remove Image link) 
	from the specified Image element ID. As these elements are nested within the same set of server 
	side controls, we can expect their client ID to be the same, except for their server side IDs of course.*/
	return document.getElementById(imgElementID.replace("imgImage", relatedElementServerSideID));
}