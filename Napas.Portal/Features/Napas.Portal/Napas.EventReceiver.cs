using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;
using System.Globalization;
using NAPAS.Portal.Common.Framework.Core.Helpers;
using NAPAS.Portal.Common.Framework.Core.WebParts;
using Napas.Portal.Business;
//using NAPAS.CDMS.Common.Framework.Core.Helpers;
//using NAPAS.CDMS.Common.Framework.Core.WebParts;


namespace Napas.Portal.Features.Napas.Portal
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("a87da71c-bdda-475c-98c6-26f0eb9c8a2a")]
    public class NapasEventReceiver : SPFeatureReceiver
    {
        // Uncomment the method below to handle the event raised after a feature has been activated.

        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            //SPWeb web = ((SPWeb)(properties.Feature.Parent));
            ////this.CreatePages(web);

            //var createList = new CreateLists();
            //createList.SetupLists(web);
        }        
    }
}
