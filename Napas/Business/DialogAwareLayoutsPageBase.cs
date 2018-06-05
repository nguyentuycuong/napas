using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Microsoft.SharePoint;
using Microsoft.SharePoint.Utilities;
using Microsoft.SharePoint.WebControls;

namespace Napas.SharePoint
{
	/// <summary>
	/// Modal Dialog-aware Application Page base class.
	/// 
	/// Source: http://blog.mastykarz.nl/sharepoint-2010-application-pages-modal-dialogs/ (used with minor
	/// refactoring and renaming).
	/// </summary>
	public abstract class DialogAwareLayoutsPageBage : LayoutsPageBase
	{
		/// <summary>
		/// URL of the page to redirect to when not in Dialog mode.
		/// </summary>
		protected string PageToRedirectOnOK { get; set; }

		/// <summary>
		/// Returns true if the Application Page is displayed in Modal Dialog.
		/// </summary>
		protected bool IsInDialogMode
		{
			get
			{
				return !String.IsNullOrEmpty(base.Request.QueryString["IsDlg"]);
			}
		}

		/// <summary>
		/// Closes the dialog and returns the OK result to the client script caller.
		/// </summary>
		protected void EndOperation()
		{
			EndOperation(ModalDialogResult.OK);
		}

		/// <summary>
		/// Closes the dialog and returns the specified result to the client script caller.
		/// </summary>
		/// <param name="result"></param>
		protected void EndOperation(ModalDialogResult result)
		{
			EndOperation(result, this.PageToRedirectOnOK);
		}

		/// <summary>
		/// Closes the dialog and returns the specified result and returnValue to the client script caller.
		/// </summary>
		/// <param name="result"></param>
		/// <param name="returnValue">Value to pass to the client script callback method defined when opening the Modal Dialog.</param>
		protected void EndOperation(ModalDialogResult result, string returnValue)
		{
			if (this.IsInDialogMode)
			{
				Page.Response.Clear();
				Page.Response.Write(String.Format(CultureInfo.InvariantCulture, 
					"<script type=\"text/javascript\">window.frameElement.commonModalDialogClose({0}, {1});</script>", 
					new object[]
					{
						(int)result, 
						String.IsNullOrEmpty(returnValue) ? "null" : returnValue
					}));
				Page.Response.End();
			}
			else
			{
				RedirectOnOK();
			}
		}

		/// <summary>
		/// Redirects to the URL specified in the PageToRedirectOnOK property.
		/// </summary>
		private void RedirectOnOK()
		{
			SPUtility.Redirect(this.PageToRedirectOnOK ?? SPContext.Current.Web.Url, SPRedirectFlags.UseSource, this.Context);
		}
	}
}
