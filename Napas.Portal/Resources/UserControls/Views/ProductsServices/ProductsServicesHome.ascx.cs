using Microsoft.SharePoint;
using Napas.Portal.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Caching;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Napas.Portal.ControlTemplates
{
    public partial class ProductsServicesHome : UserControl
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

                ParentRepeater.DataSource = productServiceGroupBo.get_ProductsServicesGroup(web, catId);
                ParentRepeater.DataBind();
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

        #region Left menu
        protected void ItemBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfParentId = (HiddenField)args.Item.FindControl("hfParentId");
                Repeater childRepeater = (Repeater)args.Item.FindControl("ChildRepeater");
                childRepeater.DataSource = productServiceBo.get_ProductServiceByGroup(web, hfParentId.Value, serviceId, parrentId);
                childRepeater.DataBind();
            }
        }

        protected void ChildRepeater_OnItemDataBound(object sender, RepeaterItemEventArgs args)
        {
            if (args.Item.ItemType == ListItemType.Item || args.Item.ItemType == ListItemType.AlternatingItem)
            {
                HiddenField hfParentId = (HiddenField)args.Item.FindControl("hfLevel1Id");
                HiddenField hfHaveSubService = (HiddenField)args.Item.FindControl("hfHaveSubService");
                HtmlGenericControl ul = (HtmlGenericControl)args.Item.FindControl("ulChilrent");
                if (hfHaveSubService.Value == "False")
                {
                    ul.Visible = false;
                }
                Repeater childRepeater = (Repeater)args.Item.FindControl("subRepeater");
                childRepeater.DataSource = productServiceBo.get_ChilrentProductService(web, hfParentId.Value, serviceId);
                childRepeater.DataBind();
            }
        }
        #endregion

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

    }
}