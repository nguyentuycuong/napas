using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using Microsoft.SharePoint;

namespace Napas.Features.napas.theme
{
    /// <summary>
    /// This class handles events raised during feature activation, deactivation, installation, uninstallation, and upgrade.
    /// </summary>
    /// <remarks>
    /// The GUID attached to this class may be used during packaging and should not be modified.
    /// </remarks>

    [Guid("f48f5e20-2182-4fbc-89b0-c2d30b6b9dcf")]
    public class napasEventReceiver : SPFeatureReceiver
    {
        public override void FeatureActivated(SPFeatureReceiverProperties properties)
        {
            return;
            SPSite site = properties.Feature.Parent as SPSite;
           // System.Diagnostics.Debugger.Launch();
            if (site != null)
            {
                SPWeb topLevelSite = site.RootWeb;

                // Calculate relative path to site from Web Application root.
                string webAppRelativePath = topLevelSite.ServerRelativeUrl;
                if (!webAppRelativePath.EndsWith("/"))
                {
                    webAppRelativePath += "/";
                }

                // Activate publishing infrastructure
                // site.Features.Add(new Guid("f6924d36-2fa8-4f0b-b16d-06b7250180fa"), true);

                SPList masterPageGallery =
                site.GetCatalog(SPListTemplateType.MasterPageCatalog);

                foreach (SPListItem li in masterPageGallery.Items)
                {
                    if (li.File.Name.ToLower() == "napas.master")
                    {

                        if (!li.HasPublishedVersion)
                        {
                            li.File.CheckIn("Automatically checked in by NAPAS.CDMS.Branding Master Page feature",
                                            SPCheckinType.MajorCheckIn);
                            li.File.Update();
                            li.File.Approve("Automatically approved by NAPAS.CDMS.Branding Master Page feature");
                            li.File.Update();

                        }

                    }

                    // Enumerate through each site and apply branding.
                    foreach (SPWeb web in site.AllWebs)
                    {
                        // Activate the publishing feature for all webs.
                        // web.Features.Add(new Guid("94c94ca6-b32f-4da9-a9e3-1f3d343d7ecb"), true);
                        web.MasterUrl = webAppRelativePath + "_catalogs/masterpage/napas_theme/napas.master";
                        web.CustomMasterUrl = webAppRelativePath + "_catalogs/masterpage/napas_theme/napas.master";

                        web.Update();
                    }
                }
            }
        }


        // Uncomment the method below to handle the event raised before a feature is deactivated.

        public override void FeatureDeactivating(SPFeatureReceiverProperties properties)
        {
            return;
            SPSite siteCollection = properties.Feature.Parent as SPSite;
            if (siteCollection != null)
            {
                SPWeb topLevelSite = siteCollection.RootWeb;

                // Calculate relative path to site from Web Application root.
                string webAppRelativePath = topLevelSite.ServerRelativeUrl;
                if (!webAppRelativePath.EndsWith("/"))
                {
                    webAppRelativePath += "/";
                }

                // Enumerate through each site and apply branding.
                foreach (SPWeb site in siteCollection.AllWebs)
                {
                    site.MasterUrl = webAppRelativePath + "_catalogs/masterpage/seattle.master";
                    site.CustomMasterUrl = webAppRelativePath + "_catalogs/masterpage/seattle.master";
                    site.SiteLogoUrl = string.Empty;
                    site.Update();
                }
            }
        }
    }
}
