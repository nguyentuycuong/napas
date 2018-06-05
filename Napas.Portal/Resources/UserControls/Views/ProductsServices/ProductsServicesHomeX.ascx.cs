using Microsoft.SharePoint;
using Napas.Portal.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Linq;
namespace Napas.Portal.ControlTemplates
{
    public partial class ProductsServicesHomeX : UserControl
    {


        #region Init page

        private static bool itemRemoved = false;
        private static CacheItemRemovedReason reason;
        private CacheItemRemovedCallback onRemove = null;
        private static object _lock = new object();
        private SPWeb web = SPContext.Current.Web;
        // ProductsServicesGroup productServiceGroupBo = new ProductsServicesGroup(SPContext.Current.Web);
        private ProductService productServiceBo;

        private int parrentId = 0;
        private string serviceId = string.Empty;
        private string catId = string.Empty;
        private string type = string.Empty;
        private uint language = SPContext.Current.Web.Language;

        #endregion Init page

        protected void Page_Load(object sender, EventArgs e)
        {
            
            serviceId = Request.QueryString["serviceId"];
            catId = Request.QueryString["catId"];
            type = Request.QueryString["type"];

            if (!IsPostBack)
            {
                ltMenu.Text = BuildNewMenu(catId, serviceId);

                var productServiceGroupBo = new ProductsServicesGroup(SPContext.Current.Web);
                productServiceBo = new ProductService(SPContext.Current.Web);
                var productService = CacheData();
                ltProductServiceGroup.Text = productService.catValue;
                ltProductServices.Text = productService.Title;


                if (serviceId != null)
                {
                    int id = 0;
                    if (int.TryParse(serviceId, out id))
                    {
                        parrentId = productService.SubServiceValue != null ? productService.SubServiceValue.LookupId : 0;

                        GetContentProductService(productService);
                    }
                }

                
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
                    productServiceInfo = productServiceBo.get_ProductSeviceInfoById(web, Convert.ToString(serviceId));
                    Cache.Add("productServiceInfo" + language, productServiceInfo, null, DateTime.Now.AddSeconds(3), Cache.NoSlidingExpiration, CacheItemPriority.High, onRemove);
                }
            }

            return productServiceInfo;
        }

        public List<ProductsServicesMenu> CacheMenu()
        {
            List<ProductsServicesMenu> productServiceMenu;

            lock (_lock)
            {
                onRemove = new CacheItemRemovedCallback(this.RemovedCallback);
                productServiceMenu = (List<ProductsServicesMenu>)Cache["productServiceMenu" + language];
                if (productServiceMenu == null)
                {
                    var productServiceGroupBo = new ProductsServicesGroup(SPContext.Current.Web);
                    productServiceMenu = productServiceGroupBo.get_ProductsServicesMenu(web);
                    Cache.Add("productServiceMenu" + language, productServiceMenu, null, DateTime.Now.AddSeconds(30), Cache.NoSlidingExpiration, CacheItemPriority.High, onRemove);
                }
            }

            return productServiceMenu;
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


        #region Main

        private void GetContentProductService(ProductServiceInfo productService)
        {
            var partnerCustomerBo = new PartnersCustomers(SPContext.Current.Web);
            VendersBo vendersBo = new VendersBo(SPContext.Current.Web);

            ltProductserviceName.Text = productService.Title;
            ltContent.Text = productService.Content;
            ltContent2.Text = productService.Content1;
            ltContent3.Text = productService.Content2;
            ltContent4.Text = productService.Content3;
            divVenders.Visible = productService.HasVenders;

            var listBank1 = partnerCustomerBo.Get_PartnersCustomersInfoByIds(web, productService.Partner1.Select(value => value.LookupId).ToList());
            rpBanks.DataSource = listBank1;
            rpBanks.DataBind();

            var listBank2 = partnerCustomerBo.Get_PartnersCustomersInfoByIds(web, productService.Partner2.Select(value => value.LookupId).ToList());
            rpBanks2.DataSource = listBank2;
            rpBanks2.DataBind();

            var listBank3 = partnerCustomerBo.Get_PartnersCustomersInfoByIds(web, productService.Partner3.Select(value => value.LookupId).ToList());
            rpBanks3.DataSource = listBank3;
            rpBanks3.DataBind();

            if (productService.HasVenders)
            {
                List<int> venders = new List<int>();
                venders = productService.Communication.Select(value => value.LookupId).ToList();

                if (venders.Any())
                {
                    rpCommunication.DataSource = vendersBo.Get_VenderInfoByIds(web, venders);
                    rpCommunication.DataBind();
                }
                else
                {
                    rpCommunication.Visible = false;
                }

                venders = productService.Digital.Select(value => value.LookupId).ToList();
                if (venders.Any())
                {
                    rpDigital.DataSource = vendersBo.Get_VenderInfoByIds(web, venders);
                    rpDigital.DataBind();

                }
                else
                {
                    rpDigital.Visible = false;
                }

                venders = productService.ElectronicWallet.Select(value => value.LookupId).ToList();
                if (venders.Any())
                {
                    rpElectronicWallet.DataSource = vendersBo.Get_VenderInfoByIds(web, venders);
                    rpElectronicWallet.DataBind();

                }
                else
                {
                    rpElectronicWallet.Visible = false;
                }

                venders = productService.Ensurance.Select(value => value.LookupId).ToList();
                if (venders.Any())
                {
                    rpEnsurance.DataSource = vendersBo.Get_VenderInfoByIds(web, venders);
                    rpEnsurance.DataBind();
                }
                else
                {
                    rpEnsurance.Visible = false;
                }

                venders = productService.Game.Select(value => value.LookupId).ToList();
                if (venders.Any())
                {
                    rpGame.DataSource = vendersBo.Get_VenderInfoByIds(web, venders);
                    rpGame.DataBind();
                }
                else
                {
                    rpGame.Visible = false;
                }

                venders = productService.Other.Select(value => value.LookupId).ToList();
                if (venders.Any())
                {
                    rpOthers.DataSource = vendersBo.Get_VenderInfoByIds(web, venders);
                    rpOthers.DataBind();
                }
                else
                {
                    rpOthers.Visible = false;
                }

                venders = productService.Retail.Select(value => value.LookupId).ToList();
                if (venders.Any())
                {
                    rpRetail.DataSource = vendersBo.Get_VenderInfoByIds(web, venders);
                    rpRetail.DataBind();
                }
                else
                {
                    rpRetail.Visible = false;
                }

                venders = productService.Tranformer.Select(value => value.LookupId).ToList();
                if (venders.Any())
                {
                    rpTranformer.DataSource = vendersBo.Get_VenderInfoByIds(web, venders);
                    rpTranformer.DataBind();
                }
                else
                {
                    rpTranformer.Visible = false;
                }

            }


            SetPageTitles(productService.Title);
        }
        #endregion

        private string BuildNewMenu(string catId, string serviceId)
        {
            string strMenu = "<ul id=\"menu\" class=\"menuleft\">";
            string l = "<li class='{2}'><a href='{1}'><i class=\"fa fa-angle-right\"></i>{0}</a>";


            string ll3 = string.Empty;


            var menus = CacheMenu();

            int p = 0;
            var parrent = menus.Where(c => c.Id == Convert.ToInt32(serviceId) && c.level == 3).ToList();
            if(parrent.Count > 0)
            {
                if(parrent[0].ParrentId != null)
                {
                    p = parrent[0].ParrentId;
                }
                
            }

            var l11 = menus.Where(c => c.level == 1).ToList();

            foreach (var x in l11)
            {

                if(x.Id == Convert.ToInt32(catId))
                {
                    strMenu += string.Format(l, x.Title, x.Url, "active");
                }
                else
                {
                    strMenu += string.Format(l, x.Title, x.Url, string.Empty);
                }
                

                var l22 = menus.Where(c => c.level == 2 && c.ParrentId == x.Id).ToList();
                if (l22.Count > 0)
                {
                    strMenu += "<ul class=\"lv2\">";
                    foreach (var y in l22)
                    {
                        if(y.Id == Convert.ToInt32(serviceId) || y.Id == p)
                        {
                            strMenu += string.Format(l, y.Title, y.Url, "active");
                        }
                        else
                        {
                            strMenu += string.Format(l, y.Title, y.Url, string.Empty);
                        }
                        
                        var l33 = menus.Where(c => c.level == 3 && c.ParrentId == y.Id).ToList();
                        if (l33.Count > 0)
                        {
                            strMenu += "<ul class=\"lv3\">";
                            foreach (var z in l33)
                            {
                                if(z.Id == Convert.ToInt32(serviceId))
                                {
                                    strMenu += string.Format(l, z.Title, z.Url, "active") + "</li>";
                                }
                                else
                                {
                                    strMenu += string.Format(l, z.Title, z.Url, string.Empty) + "</li>";
                                }
                                
                            }
                            strMenu += "</ul>";
                        }

                        strMenu += "</li>";

                    }

                    strMenu += "</ul>";
                }

            }

            strMenu += "</ul>";

            return strMenu;
        }
    }
}