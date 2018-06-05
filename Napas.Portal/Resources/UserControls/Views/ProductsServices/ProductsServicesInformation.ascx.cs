using Microsoft.SharePoint;
using Napas.Portal.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.WebControls;
using Napas.Portal.Common;

namespace Napas.Portal.ControlTemplates
{
    public partial class ProductsServicesInformation : UserControl
    {
        #region Init page
        private static bool itemRemoved = false;
        private static CacheItemRemovedReason reason;
        private CacheItemRemovedCallback onRemove = null;
        private static object _lock = new object();

        private ProductService productServiceBo;
        private PartnersCustomers partnerCustomerBo;
        private uint language = SPContext.Current.Web.Language;
        VendersBo vendersBo = new VendersBo(SPContext.Current.Web);

        private string serviceId = string.Empty;
        private string catId = string.Empty;
        private string type = string.Empty;
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {


            serviceId = Request.QueryString["serviceId"];
            catId = Request.QueryString["catId"];
            type = Request.QueryString["type"];

            if (!IsPostBack)
            {
                productServiceBo = new ProductService(SPContext.Current.Web);
                partnerCustomerBo = new PartnersCustomers(SPContext.Current.Web);
                var productId = 0;
                if (!int.TryParse(serviceId, out productId))
                {
                    serviceId = "0";
                }

                var productService = CacheData();
                ltProductserviceName.Text = productService.Title;
                ltContent.Text = productService.Content;
                ltContent2.Text = productService.Content1;
                ltContent3.Text = productService.Content2;
                ltContent4.Text = productService.Content3;
                divVenders.Visible = productService.HasVenders;
                
                var listBank1 = partnerCustomerBo.Get_PartnersCustomersInfoByIds(productService.Partner1.Select(value => value.LookupId).ToList());
                rpBanks.DataSource = listBank1;
                rpBanks.DataBind();

                var listBank2 = partnerCustomerBo.Get_PartnersCustomersInfoByIds(productService.Partner2.Select(value => value.LookupId).ToList());
                rpBanks2.DataSource = listBank2;
                rpBanks2.DataBind();

                var listBank3 = partnerCustomerBo.Get_PartnersCustomersInfoByIds(productService.Partner3.Select(value => value.LookupId).ToList());
                rpBanks3.DataSource = listBank3;
                rpBanks3.DataBind();

                if (productService.HasVenders)
                {
                    List<int> venders = new List<int>();
                    venders = productService.Communication.Select(value => value.LookupId).ToList();

                    if (venders.Any())
                    {
                        rpCommunication.DataSource = vendersBo.Get_VenderInfoByIds(venders);
                        rpCommunication.DataBind();
                    }
                    else
                    {
                        rpCommunication.Visible = false;
                    }

                    venders = productService.Digital.Select(value => value.LookupId).ToList();
                    if (venders.Any())
                    {
                        rpDigital.DataSource = vendersBo.Get_VenderInfoByIds(venders);
                        rpDigital.DataBind();
    
                    }
                    else
                    {
                        rpDigital.Visible = false;
                    }

                    venders = productService.ElectronicWallet.Select(value => value.LookupId).ToList();
                    if (venders.Any())
                    {
                        rpElectronicWallet.DataSource = vendersBo.Get_VenderInfoByIds(venders);
                        rpElectronicWallet.DataBind();
    
                    }
                    else
                    {
                        rpElectronicWallet.Visible = false;
                    }

                    venders = productService.Ensurance.Select(value => value.LookupId).ToList();
                    if (venders.Any())
                    {
                        rpEnsurance.DataSource = vendersBo.Get_VenderInfoByIds(venders);
                        rpEnsurance.DataBind();    
                    }
                    else
                    {
                        rpEnsurance.Visible = false;
                    }

                    venders = productService.Game.Select(value => value.LookupId).ToList();
                    if (venders.Any())
                    {
                        rpGame.DataSource = vendersBo.Get_VenderInfoByIds(venders);
                        rpGame.DataBind();
                    }
                    else
                    {
                        rpGame.Visible = false;
                    }

                    venders = productService.Other.Select(value => value.LookupId).ToList();
                    if (venders.Any())
                    {
                        rpOthers.DataSource = vendersBo.Get_VenderInfoByIds(venders);
                        rpOthers.DataBind();    
                    }
                    else
                    {
                        rpOthers.Visible = false;
                    }

                    venders = productService.Retail.Select(value => value.LookupId).ToList();
                    if (venders.Any())
                    {
                        rpRetail.DataSource = vendersBo.Get_VenderInfoByIds(venders);
                        rpRetail.DataBind();    
                    }
                    else
                    {
                        rpRetail.Visible = false;
                    }

                    venders = productService.Tranformer.Select(value => value.LookupId).ToList();
                    if (venders.Any())
                    {
                        rpTranformer.DataSource = vendersBo.Get_VenderInfoByIds(venders);
                        rpTranformer.DataBind();    
                    }
                    else
                    {
                        rpTranformer.Visible = false;
                    }
                    
                }


                SetPageTitles(productService.Title);
            }
        }

        public ProductServiceInfo CacheData()
        {
            ProductServiceInfo productServiceInfo;

            lock (_lock)
            {
                onRemove = new CacheItemRemovedCallback(this.RemovedCallback);
                productServiceInfo = (ProductServiceInfo)Cache["productServiceInfo" + language];
                if (productServiceInfo == null || productServiceInfo.Id == 0)
                {
                    productServiceInfo = productServiceBo.get_ProductSeviceInfoById(Convert.ToString(serviceId));
                    Cache.Add("productServiceInfo" + language, productServiceInfo, null, DateTime.Now.AddSeconds(3), Cache.NoSlidingExpiration, CacheItemPriority.High, onRemove);
                }
            }

            return productServiceInfo;
        }

        public void RemovedCallback(String k, Object v, CacheItemRemovedReason r)
        {
            itemRemoved = true;
            reason = r;
        }

        private void SetPageTitles(string Title)
        {
            ContentPlaceHolder contentPlaceHolder = (ContentPlaceHolder)Page.Master.FindControl("PlaceHolderPageTitle");
            contentPlaceHolder.Controls.Clear();
            LiteralControl title = new LiteralControl();
            title.Text = Title;
            contentPlaceHolder.Controls.Add(title);
        }
        //        private void get_PartnersCustomersList(string serviceId)
        //        {
        //            var a = @"<div>
        //                        <div class='bank-logo'>
        //                            {0}
        //                        </div>
        //                    </div>";
        //            string subS = "<a href='{0}' arget='_blank'><img alt='' src='{1}' /></a>";

        //            var partnersInfo = partnerCustomerBo.get_PartnersCustomers(serviceId);
        //            string s = string.Empty;

        //            if (partnersInfo.Count > 0)
        //            {
        //                for (int i = 0; i < partnersInfo.Count; i = i + 2)
        //                {
        //                    var item = partnersInfo[i];
        //                    var sub = string.Format(subS, item.Website, item.Image);
        //                    if (i + 1 <= partnersInfo.Count - 1)
        //                    {
        //                        var item2 = partnersInfo[i + 1];
        //                        sub += string.Format(subS, item2.Website, item2.Image);
        //                    }

        //                    s += string.Format(a, sub);
        //                }
        //            }

        //            ltPartnersCustomers.Text = s;
        //        }
    }
}