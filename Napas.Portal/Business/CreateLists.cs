using Microsoft.SharePoint;
using Napas.Portal.Common;
using Napas.SharePoint;
using NAPAS.Portal.Common.Framework.Core.Helpers;
using NAPAS.Portal.Common.Framework.Core.WebParts;
using System.Collections.Specialized;
using System.Globalization;
using System.Reflection;

namespace Napas.Portal.Business
{
    public class CreateLists
    {
        /// <summary>
        /// dsjh
        /// </summary>
        /// <param name="web"></param>
        public void SetupLists(SPWeb web)
        {            
            CreatePages(web);

            if (web.Language == 1033)
            {
                CreateNewsCategoryEn(web);
                CreateNewsEn(web);
                CreateIntroductionEn(web);

                CreateVenderServiceEn(web);
                CreateCustomerPartnerEn(web);

                CreateProductionAndServiceGroupEn(web);
                CreateProductionAndServiceEn(web);

                CreateMeetingPartnersEn(web);
                CreateOrganizationEn(web);
                CreateDocumentGroupEn(web);
                CreateDocumentEn(web, Constants.DocumentShareholder.ListNameEnglish);
                CreateDocumentEn(web, Constants.DocumentLegen.ListNameEnglish);
                CreateDocumentEn(web, Constants.DocumentOther.ListNameEnglish);

                CreateTermOfUseEn(web);
                CreateContactInfomationEn(web);
                ContactInforEn(web);
                HumanResourceEn(web);
                ApplicationInforEn(web);
                CreateCareerResultEn(web);
                CreateCVDocumentEn(web);
                CreateContactEn(web);
                CreateSliderEn(web);
                CreateSettingsEN(web);
                CreateOrganizationChartEn(web);
                CreateOrganizationBroadEn(web);

                CreateMilestonesEn(web);
            }
            else
            {
                CreateNewsCategory(web);
                CreateNews(web);
                CreateIntroduction(web);

                CreateVenderService(web);
                CreateCustomerPartner(web);

                CreateProductionAndServiceGroup(web);
                CreateProductionAndService(web);

                //CreateUserGuide(web);
                //CreateNewsVideo(web);
                //CreateFAQ(web);
                //CreateCustomerCategory(web);
                //CreateCustomerAndService(web);

                
                //CreatePromotion(web);
                //CreateListInteriorCard(web);
                //CreateInteriorCardInformation(web);
                CreateMeetingPartners(web);
                CreateOrganization(web);
                CreateDocumentGroup(web);
                CreateDocument(web, Constants.DocumentShareholder.ListName);
                CreateDocument(web, Constants.DocumentLegen.ListName);
                CreateDocument(web, Constants.DocumentOther.ListName);
                //CreateCities(web);
                //CreateDistrict(web);
                CreateTermOfUse(web);
                CreateContactInfomation(web);
                ContactInfor(web);
                HumanResource(web);
                ApplicationInfor(web);
                CreateCareerResult(web);
                CreateCVDocument(web);
                CreateContact(web);
                CreateSlider(web);
                CreateSettings(web);
                CreateOrganizationChart(web);
                CreateOrganizationBroad(web);
                //ShoppingOnline(web);
                //CreateTranfeRelatedBanking247(web);
                //CreateTopup(web);
                //CreatePayBills(web);
                CreateMilestones(web);
            }
        }

        #region News category

        private void CreateNewsCategory(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.CategoryNews.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.CategoryNews.InternalFields.Description, Constants.CategoryNews.DisplayFields.Description)
            {
                RichText = false,
                Required = false
            });

            helper.AddField(new NumberFieldCreator(Constants.CategoryNews.InternalFields.Order, Constants.CategoryNews.DisplayFields.Order)
            {
                Required = true,
                DisplayFormat = SPNumberFormatTypes.NoDecimal,
            });

            helper.AddField(new BooleanFieldCreator(Constants.CategoryNews.InternalFields.Activate, Constants.CategoryNews.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.CategoryNews.DisplayFields.Name, true, false);
        }

        private void CreateNewsCategoryEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.CategoryNews.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.CategoryNews.InternalFields.Description, Constants.CategoryNews.EnglishFields.Description)
            {
                RichText = false,
                Required = false
            });

            helper.AddField(new NumberFieldCreator(Constants.CategoryNews.InternalFields.Order, Constants.CategoryNews.EnglishFields.Order)
            {
                Required = true,
                DisplayFormat = SPNumberFormatTypes.NoDecimal,
            });

            helper.AddField(new BooleanFieldCreator(Constants.CategoryNews.InternalFields.Activate, Constants.CategoryNews.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.CategoryNews.EnglishFields.Name, true, false);
        }

        #endregion News category

        #region News

        private void CreateNews(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.News.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.News.InternalFields.Description, Constants.News.DisplayFields.Description)
            {
                RichText = false,
                Required = true,
                NumberOfLines = 3
            });

            //helper.AddField(new SingleLineTextFieldCreator(Constants.News.InternalFields.Thumbar, Constants.News.DisplayFields.Thumbar)
            //{
            //    Required = true,
            //});

            helper.AddField(new LookupFieldCreator(Constants.News.InternalFields.Category, Constants.News.DisplayFields.Category)
            {
                Required = true,
                LookupList = Constants.CategoryNews.ListName,
                LookupField = Constants.CategoryNews.InternalFields.Name,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.News.InternalFields.Content, Constants.News.DisplayFields.Content)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.News.InternalFields.Activate, Constants.News.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            helper.AddField(new DateTimeFieldCreator(Constants.News.InternalFields.FromDate, Constants.News.DisplayFields.FromDate)
            {
                DefaultValue = "[TODAY]",
                DisplayFormat = SPDateTimeFieldFormatType.DateOnly
            });

            helper.AddField(new DateTimeFieldCreator(Constants.News.InternalFields.ToDate, Constants.News.DisplayFields.ToDate)
            {
                //DefaultValue = "[TODAY]"
                DisplayFormat = SPDateTimeFieldFormatType.DateOnly
            });

            //helper.AddField(new UserFieldCreator(Constants.News.InternalFields.Author, Constants.News.DisplayFields.Author)
            //{
            //});

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.News.DisplayFields.Name, true, false);

            AddImageField(list, Constants.News.InternalFields.Thumbar, Constants.News.DisplayFields.Thumbar, "Ảnh");
            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        private void CreateNewsEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.News.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.News.InternalFields.Description, Constants.News.EnglishFields.Description)
            {
                RichText = false,
                Required = true,
                NumberOfLines = 3
            });


            helper.AddField(new LookupFieldCreator(Constants.News.InternalFields.Category, Constants.News.EnglishFields.Category)
            {
                Required = true,
                LookupList = Constants.CategoryNews.ListNameEnglish,
                LookupField = Constants.CategoryNews.InternalFields.Name,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.News.InternalFields.Content, Constants.News.EnglishFields.Content)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.News.InternalFields.Activate, Constants.News.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            helper.AddField(new DateTimeFieldCreator(Constants.News.InternalFields.FromDate, Constants.News.EnglishFields.FromDate)
            {
                DefaultValue = "[TODAY]",
                DisplayFormat = SPDateTimeFieldFormatType.DateOnly
            });

            helper.AddField(new DateTimeFieldCreator(Constants.News.InternalFields.ToDate, Constants.News.EnglishFields.ToDate)
            {                
                DisplayFormat = SPDateTimeFieldFormatType.DateOnly
            });
            
            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.News.EnglishFields.Name, true, false);

            AddImageField(list, Constants.News.InternalFields.Thumbar, Constants.News.EnglishFields.Thumbar, "Images");
            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        private void CreateMeetingPartners(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.MeetingPartners.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.MeetingPartners.InternalFields.Description, Constants.MeetingPartners.DisplayFields.Description)
            {
                RichText = false,
                Required = true,
                NumberOfLines = 3
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.MeetingPartners.InternalFields.Content, Constants.MeetingPartners.DisplayFields.Content)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.MeetingPartners.InternalFields.Activate, Constants.MeetingPartners.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();
            this.UpdateTitleField(list, Constants.MeetingPartners.DisplayFields.Name, true, false);
            AddImageField(list, Constants.MeetingPartners.InternalFields.Image, Constants.MeetingPartners.DisplayFields.Image, "Ảnh");
            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        private void CreateMeetingPartnersEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.MeetingPartners.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.MeetingPartners.InternalFields.Description, Constants.MeetingPartners.EnglishFields.Description)
            {
                RichText = false,
                Required = true,
                NumberOfLines = 3
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.MeetingPartners.InternalFields.Content, Constants.MeetingPartners.EnglishFields.Content)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.MeetingPartners.InternalFields.Activate, Constants.MeetingPartners.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();
            this.UpdateTitleField(list, Constants.MeetingPartners.EnglishFields.Name, true, false);
            AddImageField(list, Constants.MeetingPartners.InternalFields.Image, Constants.MeetingPartners.EnglishFields.Image, "Images");
            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        #endregion News

        #region Introduction

        private void CreateIntroduction(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.Introduction.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Introduction.InternalFields.Description, Constants.Introduction.DisplayFields.Description)
            {
                RichText = false,
                Required = true,
                NumberOfLines = 3
            });
                        
            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Introduction.InternalFields.Content, Constants.Introduction.DisplayFields.Content)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new NumberFieldCreator(Constants.Introduction.InternalFields.Order, Constants.Introduction.DisplayFields.Order)
            {
                Required = true,
                DefaultValue = "0"
            });

            helper.AddField(new BooleanFieldCreator(Constants.Introduction.InternalFields.Activate, Constants.Introduction.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.Introduction.DisplayFields.Name, true, false);

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        private void CreateIntroductionEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.Introduction.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Introduction.InternalFields.Description, Constants.Introduction.EnglishFields.Description)
            {
                RichText = false,
                Required = true,
                NumberOfLines = 3
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Introduction.InternalFields.Content, Constants.Introduction.EnglishFields.Content)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new NumberFieldCreator(Constants.Introduction.InternalFields.Order, Constants.Introduction.EnglishFields.Order)
            {
                Required = true,
                DefaultValue = "0"
            });

            helper.AddField(new BooleanFieldCreator(Constants.Introduction.InternalFields.Activate, Constants.Introduction.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.Introduction.EnglishFields.Name, true, false);

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        #endregion Introduction

        #region Product and service

        private void CreateProductionAndServiceGroup(SPWeb web)
        {
            //System.Diagnostics.Debugger.Launch();
            var helper = new ListHelper(web)
            {
                Title = Constants.ProductionServicesGroup.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new NumberFieldCreator(Constants.ProductionServicesGroup.InternalFields.Order, Constants.ProductionServicesGroup.DisplayFields.Order)
            {
                Required = true,
                DisplayFormat = SPNumberFormatTypes.NoDecimal,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ProductionServicesGroup.InternalFields.Description, Constants.ProductionServicesGroup.DisplayFields.Description)
            {
                Required = false,
            });

            //helper.AddField(new MultipleLinesTextFieldCreator(Constants.ProductionServices.InternalFields.Content, Constants.ProductionServices.DisplayFields.Content)
            //{
            //    RichTextMode = SPRichTextMode.FullHtml,
            //    RichText = true,
            //    NumberOfLines = 10,
            //});

            helper.AddField(new BooleanFieldCreator(Constants.ProductionServicesGroup.InternalFields.Activate, Constants.ProductionServicesGroup.DisplayFields.Activate)
            {
                DefaultYesValue = true,
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.ProductionServicesGroup.DisplayFields.Name, true, false);

            AddImageField(list, Constants.ProductionServicesGroup.InternalFields.Image, Constants.ProductionServicesGroup.DisplayFields.Image, "Ảnh");
            AddImageField(list, Constants.ProductionServicesGroup.InternalFields.MenuIcon, Constants.ProductionServicesGroup.DisplayFields.MenuIcon, "Ảnh");

            //if (!list.Fields.ContainsFieldWithStaticName(Constants.ProductionServices.InternalFields.SubName))
            //{
            //    var subName = list.Fields.AddLookup(Constants.ProductionServices.InternalFields.SubName, list.ID, false);
            //    SPFieldLookup usernameField = (SPFieldLookup)list.Fields[subName];
            //    usernameField.LookupField = Constants.CommonField.Title;
            //    usernameField.Title = Constants.ProductionServices.DisplayFields.SubName;
            //    usernameField.Update();
            //}
        }

        private void CreateProductionAndServiceGroupEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.ProductionServicesGroup.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new NumberFieldCreator(Constants.ProductionServicesGroup.InternalFields.Order, Constants.ProductionServicesGroup.EnglishFields.Order)
            {
                Required = true,
                DisplayFormat = SPNumberFormatTypes.NoDecimal,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ProductionServicesGroup.InternalFields.Description, Constants.ProductionServicesGroup.EnglishFields.Description)
            {
                Required = false,
            });
            
            helper.AddField(new BooleanFieldCreator(Constants.ProductionServicesGroup.InternalFields.Activate, Constants.ProductionServicesGroup.EnglishFields.Activate)
            {
                DefaultYesValue = true,
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.ProductionServicesGroup.EnglishFields.Name, true, false);

            AddImageField(list, Constants.ProductionServicesGroup.InternalFields.Image, Constants.ProductionServicesGroup.EnglishFields.Image, "Images");
            AddImageField(list, Constants.ProductionServicesGroup.InternalFields.MenuIcon, Constants.ProductionServicesGroup.EnglishFields.MenuIcon, "Imanges");
        }

        private void CreateProductionAndService(SPWeb web)
        {
            //System.Diagnostics.Debugger.Launch();
            var helper = new ListHelper(web)
            {
                Title = Constants.ProductionServices.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.ProductsServices, Constants.ProductionServices.DisplayFields.ProductsServices)
            {
                LookupField = Constants.CommonField.Title,
                LookupList = Constants.ProductionServicesGroup.ListName,
                Required = true,
            });
            helper.AddField(new NumberFieldCreator(Constants.ProductionServices.InternalFields.Order, Constants.ProductionServices.DisplayFields.Order)
            {
                Required = true,
                DisplayFormat = SPNumberFormatTypes.NoDecimal,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ProductionServices.InternalFields.Description, Constants.ProductionServices.DisplayFields.Description)
            {
                Required = false,
            });

            helper.AddField(new BooleanFieldCreator(Constants.ProductionServices.InternalFields.Activate, Constants.ProductionServices.DisplayFields.Activate)
            {
                DefaultYesValue = true,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ProductionServices.InternalFields.Content, Constants.ProductionServices.DisplayFields.Content)
            {
                Required = true,
                RichText = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10,
            });

            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Partner1, Constants.ProductionServices.DisplayFields.Partner1)
            {
                LookupField = Constants.CommonField.Title,
                LookupList = Constants.CustomerPartner.ListName,
                AllowMultipleValues = true,
                Required = false,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ProductionServices.InternalFields.Content1, Constants.ProductionServices.DisplayFields.Content1)
            {
                Required = false,
                RichText = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 1,
            });

            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Partner2, Constants.ProductionServices.DisplayFields.Partner2)
            {
                LookupField = Constants.CommonField.Title,
                LookupList = Constants.CustomerPartner.ListName,
                AllowMultipleValues = true,
                Required = false,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ProductionServices.InternalFields.Content2, Constants.ProductionServices.DisplayFields.Content2)
            {
                Required = false,
                RichText = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 1,
            });

            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Partner3, Constants.ProductionServices.DisplayFields.Partner3)
            {
                LookupField = Constants.CommonField.Title,
                LookupList = Constants.CustomerPartner.ListName,
                AllowMultipleValues = true,
                Required = false,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ProductionServices.InternalFields.Content3, Constants.ProductionServices.DisplayFields.Content3)
            {
                Required = false,
                RichText = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 1,
            });

            helper.AddField(new BooleanFieldCreator(Constants.ProductionServices.InternalFields.IsShowVenders, Constants.ProductionServices.DisplayFields.IsShowVenders)
            {
                DefaultYesValue = false,
            });

            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Tranformer, Constants.ProductionServices.EnglishFields.Tranformer)
            {
                LookupList = Constants.VenderService.ListName,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });

            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Retail, Constants.ProductionServices.EnglishFields.Retail)
            {
                LookupList = Constants.VenderService.ListName,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });
            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Communication, Constants.ProductionServices.EnglishFields.Communication)
            {
                LookupList = Constants.VenderService.ListName,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });
            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Ensurance, Constants.ProductionServices.EnglishFields.Ensurance)
            {
                LookupList = Constants.VenderService.ListName,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });
            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Game, Constants.ProductionServices.EnglishFields.Game)
            {
                LookupList = Constants.VenderService.ListName,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });
            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Digital, Constants.ProductionServices.EnglishFields.Digital)
            {
                LookupList = Constants.VenderService.ListName,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });
            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.ElectronicWallet, Constants.ProductionServices.EnglishFields.ElectronicWallet)
            {
                LookupList = Constants.VenderService.ListName,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });
            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.AnotherServices, Constants.ProductionServices.EnglishFields.AnotherServices)
            {
                LookupList = Constants.VenderService.ListName,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ProductionServices.InternalFields.Content4, Constants.ProductionServices.DisplayFields.Content4)
            {
                Required = false,
                RichText = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 1,
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.ProductionServices.DisplayFields.Name, true, false);
            // AddPublishingPageContentField(web, list, Constants.ProductionServices.DisplayFields.Content);

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        private void CreateProductionAndServiceEn(SPWeb web)
        {
            //System.Diagnostics.Debugger.Launch();
            var helper = new ListHelper(web)
            {
                Title = Constants.ProductionServices.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.ProductsServices, Constants.ProductionServices.EnglishFields.ProductsServices)
            {
                LookupField = Constants.CommonField.Title,
                LookupList = Constants.ProductionServicesGroup.ListNameEnglish,
                Required = true,
            });
            helper.AddField(new NumberFieldCreator(Constants.ProductionServices.InternalFields.Order, Constants.ProductionServices.EnglishFields.Order)
            {
                Required = true,
                DisplayFormat = SPNumberFormatTypes.NoDecimal,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ProductionServices.InternalFields.Description, Constants.ProductionServices.EnglishFields.Description)
            {
                Required = false,
            });

            helper.AddField(new BooleanFieldCreator(Constants.ProductionServices.InternalFields.Activate, Constants.ProductionServices.EnglishFields.Activate)
            {
                DefaultYesValue = true,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ProductionServices.InternalFields.Content, Constants.ProductionServices.EnglishFields.Content)
            {
                Required = true,
                RichText = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10,
            });

            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Partner1, Constants.ProductionServices.EnglishFields.Partner1)
            {
                LookupField = Constants.CommonField.Title,
                LookupList = Constants.CustomerPartner.ListNameEnglish,
                AllowMultipleValues = true,
                Required = false,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ProductionServices.InternalFields.Content1, Constants.ProductionServices.EnglishFields.Content1)
            {
                Required = false,
                RichText = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 1,
            });

            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Partner2, Constants.ProductionServices.EnglishFields.Partner2)
            {
                LookupField = Constants.CommonField.Title,
                LookupList = Constants.CustomerPartner.ListNameEnglish,
                AllowMultipleValues = true,
                Required = false,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ProductionServices.InternalFields.Content2, Constants.ProductionServices.EnglishFields.Content2)
            {
                Required = false,
                RichText = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 1,
            });

            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Partner3, Constants.ProductionServices.EnglishFields.Partner3)
            {
                LookupField = Constants.CommonField.Title,
                LookupList = Constants.CustomerPartner.ListNameEnglish,
                AllowMultipleValues = true,
                Required = false,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ProductionServices.InternalFields.Content3, Constants.ProductionServices.EnglishFields.Content3)
            {
                Required = false,
                RichText = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 1,
            });

            helper.AddField(new BooleanFieldCreator(Constants.ProductionServices.InternalFields.IsShowVenders, Constants.ProductionServices.EnglishFields.IsShowVenders)
            {
                DefaultYesValue = false,
            });

            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Tranformer, Constants.ProductionServices.EnglishFields.Tranformer)
            {
                LookupList = Constants.VenderService.ListNameEnglish,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });

            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Retail, Constants.ProductionServices.EnglishFields.Retail)
            {
                LookupList = Constants.VenderService.ListNameEnglish,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });
            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Communication, Constants.ProductionServices.EnglishFields.Communication)
            {
                LookupList = Constants.VenderService.ListNameEnglish,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });
            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Ensurance, Constants.ProductionServices.EnglishFields.Ensurance)
            {
                LookupList = Constants.VenderService.ListNameEnglish,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });
            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Game, Constants.ProductionServices.EnglishFields.Game)
            {
                LookupList = Constants.VenderService.ListNameEnglish,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });
            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.Digital, Constants.ProductionServices.EnglishFields.Digital)
            {
                LookupList = Constants.VenderService.ListNameEnglish,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });
            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.ElectronicWallet, Constants.ProductionServices.EnglishFields.ElectronicWallet)
            {
                LookupList = Constants.VenderService.ListNameEnglish,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });
            helper.AddField(new LookupFieldCreator(Constants.ProductionServices.InternalFields.AnotherServices, Constants.ProductionServices.EnglishFields.AnotherServices)
            {
                LookupList = Constants.VenderService.ListNameEnglish,
                LookupField = Constants.CommonField.Title,
                Required = false,
                AllowMultipleValues = true,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ProductionServices.InternalFields.Content4, Constants.ProductionServices.EnglishFields.Content4)
            {
                Required = false,
                RichText = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 1,
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.ProductionServices.EnglishFields.Name, true, false);
            
            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        #endregion Product and service

        #region Customer and partner

        private void CreateCustomerPartner(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.CustomerPartner.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new UrlFieldCreator(Constants.CustomerPartner.InternalFields.Website, Constants.CustomerPartner.DisplayFields.Website)
            {
                Required = true,
            });

            
            helper.AddField(new MultipleLinesTextFieldCreator(Constants.CustomerPartner.InternalFields.Description, Constants.CustomerPartner.DisplayFields.Description));
            
            helper.AddField(new BooleanFieldCreator(Constants.CustomerPartner.InternalFields.Activate, Constants.CustomerPartner.DisplayFields.Activate));

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.CustomerPartner.DisplayFields.Name, true, false);

            AddImageField(list, Constants.CustomerPartner.InternalFields.Image, Constants.CustomerPartner.DisplayFields.Image, "Ảnh");
                        
        }

        private void CreateCustomerPartnerEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.CustomerPartner.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new UrlFieldCreator(Constants.CustomerPartner.InternalFields.Website, Constants.CustomerPartner.EnglishFields.Website)
            {
                Required = true,
            });

            helper.AddField(new NumberFieldCreator(Constants.CustomerPartner.InternalFields.Order, Constants.CustomerPartner.EnglishFields.Order)
            {
                Required = true,
                DisplayFormat = SPNumberFormatTypes.NoDecimal,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.CustomerPartner.InternalFields.Description, Constants.CustomerPartner.EnglishFields.Description));
                        
            helper.AddField(new BooleanFieldCreator(Constants.CustomerPartner.InternalFields.Activate, Constants.CustomerPartner.EnglishFields.Activate));

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.CustomerPartner.EnglishFields.Name, true, false);

            AddImageField(list, Constants.CustomerPartner.InternalFields.Image, Constants.CustomerPartner.EnglishFields.Image, "Images");

            
        }

        #endregion Customer and partner

        #region Video

        private void CreateNewsVideo(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.Video.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false,
                ListTemplateType = SPListTemplateType.DocumentLibrary
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Video.InternalFields.Description, Constants.Video.DisplayFields.Description)
            {
                RichText = false,
                Required = false
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Video.InternalFields.DescriptionEn, Constants.Video.EnglishFields.Description)
            {
                RichText = false,
                Required = false
            });

            helper.AddField(new NumberFieldCreator(Constants.Video.InternalFields.Order, Constants.Video.DisplayFields.Order)
            {
                Required = true,
                DisplayFormat = SPNumberFormatTypes.NoDecimal,
            });

            helper.AddField(new BooleanFieldCreator(Constants.Video.InternalFields.Activate, Constants.Video.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();
        }

        #endregion Video

        #region Commons

        /// <summary>
        /// Update default Title field
        /// </summary>
        /// <param name="list">List contains title field</param>
        /// <param name="newTitle">New Name of Title</param>
        /// <param name="isRequired">Is Required </param>
        /// <param name="isUnique">bool Is Unique</param>
        protected void UpdateTitleField(SPList list, string newTitle, bool isRequired, bool isUnique)
        {
            if (list.Fields.ContainsField("Title"))
            {
                SPField titleField = list.Fields.GetFieldByInternalName("Title");
                titleField.Title = newTitle;
                titleField.Required = isRequired;
                if (isUnique)
                {
                    titleField.Indexed = true;
                    titleField.EnforceUniqueValues = true;
                }

                titleField.Update();
            }
        }

        private void CreatePages(SPWeb web)
        {
            //System.Diagnostics.Debugger.Launch();
            // Create default page
            WebPageHelper.CreateDefaultWebPage(web, "default.aspx", web.Language == 1033 ? "Home" : "Trang chủ", true, false);
            AddUserControlToPage(web, "default", "Home", "UserControls/Views/Global/Home.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "search.aspx", "Search", true, false);
            AddUserControlToPage(web, "search", "Search", "UserControls/Views/Global/Search.ascx", true);

            // Create Home page
            WebPageHelper.CreateDefaultWebPage(web, "News.aspx", web.Language == 1033 ? "News" : "Tin tức", true, false);
            AddUserControlToPage(web, "News", "News", "UserControls/Views/News/NewsHome.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "newscategories.aspx", web.Language == 1033 ? "News category" : "Tin tức", true, false);
            AddUserControlToPage(web, "newscategories", "Category news", "UserControls/Views/News/NewsCategory.ascx", true);

            // Create Home page
            WebPageHelper.CreateDefaultWebPage(web, "newsdetails.aspx", web.Language == 1033 ? "News" : "Tin tức", true, false);
            AddUserControlToPage(web, "newsdetails", "News", "UserControls/Views/News/NewsDetails.ascx", true);

            // Create Admin page
            WebPageHelper.CreateDefaultWebPage(web, "admin.aspx", web.Language == 1033 ? "Admin" : "Admin", true, true);
            AddUserControlToPage(web, "admin", "admin", "UserControls/Views/Global/Admin.ascx", true);

            // Create Products services page
            WebPageHelper.CreateDefaultWebPage(web, "productsservices.aspx", web.Language == 1033 ? "Products and services" : "Sản phẩm dịch vụ", true, false);
            AddUserControlToPage(web, "productsservices", "Products Services", "UserControls/Views/ProductsServices/ProductsServicesHomeX.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "productsservices_home.aspx", web.Language == 1033 ? "Products and services" : "Sản phẩm dịch vụ", true, false);
            AddUserControlToPage(web, "productsservices_home", "Products Services", "UserControls/Views/ProductsServices/ProductsServices.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "shareholders-meeting.aspx", web.Language == 1033 ? "Shareholders meeting" : "Đại hội cổ đông", true, false);
            AddUserControlToPage(web, "shareholders-meeting", "Đại hội cổ đông", "UserControls/Views/ShareholderMeeting/ShareHolderMeeting.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "shareholders-meeting-details.aspx", web.Language == 1033 ? "Shareholders meeting" : "Đại hội cổ đông", true, false);
            AddUserControlToPage(web, "shareholders-meeting-details", "Đại hội cổ đông", "UserControls/Views/ShareholderMeeting/ShareHolderMeetingdetails.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "documents-for-shareholders.aspx", web.Language == 1033 ? "Document" : "Tài liệu cổ đông", true, false);
            AddUserControlToPage(web, "documents-for-shareholders", "Documents for shareholders", "UserControls/Views/DocumentPartner/DocumentPartner.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "tai-lieu-van-ban-phap-quy.aspx", web.Language == 1033 ? "Lagend's document" : "Văn bản pháp quy", true, false);
            AddUserControlToPage(web, "tai-lieu-van-ban-phap-quy", "tai-lieu-van-ban-phap-quy", "UserControls/Views/Documents/LegalDocuments.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "other-document.aspx", web.Language == 1033 ? "Other document" : "Tài liệu khác", true, false);
            AddUserControlToPage(web, "other-document", "other-document", "UserControls/Views/Documents/OtherDocuments.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "about.aspx", web.Language == 1033 ? "About US" : "Về NAPAS", true, false);
            AddUserControlToPage(web, "about", "About", "UserControls/Views/About/About.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "organizationboardassembly.aspx", web.Language == 1033 ? "Organization" : "Cơ cấu tổ chứ", true, false);
            AddUserControlToPage(web, "organizationboardassembly", "Organization Board Assembly", "UserControls/Views/About/OrganizationBoardAssembly.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "organizationboardcommittee.aspx", web.Language == 1033 ? "Organization" : "Cơ cấu tổ chức", true, false);
            AddUserControlToPage(web, "organizationboardcommittee", "Organization Board Committee", "UserControls/Views/About/OrganizationBoardCommittee.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "organizationboardexecutive.aspx", web.Language == 1033 ? "Organization" : "Cơ cấu tổ chức", true, false);
            AddUserControlToPage(web, "organizationboardexecutive", "Organization Board Executive", "UserControls/Views/About/OrganizationBoardExecutive.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "organizationchart.aspx", web.Language == 1033 ? "Organization" : "Cơ cấu tổ chức", true, false);
            AddUserControlToPage(web, "organizationchart", "Organization Chart", "UserControls/Views/About/OrganizationChart.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "organization.aspx", web.Language == 1033 ? "Organization" : "Cơ cấu tổ chức", true, false);
            AddUserControlToPage(web, "organization", "Organization", "UserControls/Views/About/OrganizationalStructure.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "term-of-use.aspx", web.Language == 1033 ? "Term of condition" : "Điều khoản sử dụng", true, false);
            AddUserControlToPage(web, "term-of-use", "Term Of Use", "UserControls/Views/TermOfUse/TermOfUse.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "contactinfor.aspx", web.Language == 1033 ? "Constact" : "Liên hệ", true, false);
            AddUserControlToPage(web, "contactinfor", "Contact Infor", "UserControls/Views/Recruitment/ContactInfor.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "cvdocument.aspx", web.Language == 1033 ? "CV" : "CV", true, false);
            AddUserControlToPage(web, "cvdocument", "CV Document", "UserControls/Views/Recruitment/CVDocument.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "careerresult.aspx", web.Language == 1033 ? "Career" : "Kết quả tuyển dụng", true, false);
            AddUserControlToPage(web, "careerresult", "Career Result", "UserControls/Views/Recruitment/CareerResult.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "humanresource.aspx", web.Language == 1033 ? "Human resource" : "Chính sách nhân sự", true, false);
            AddUserControlToPage(web, "humanresource", "Human Resource", "UserControls/Views/Recruitment/HumanResource.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "career.aspx", web.Language == 1033 ? "Career" : "Cơ hội nghề nghiệp", true, false);
            AddUserControlToPage(web, "career", "Career", "UserControls/Views/Recruitment/Career.ascx", true);

            WebPageHelper.CreateDefaultWebPage(web, "lien-he-chung.aspx", web.Language == 1033 ? "Contact" : "Liên hệ", true, false);
            AddUserControlToPage(web, "lien-he-chung", "Liên hệ chung", "UserControls/Views/Contacts/ContactGeneral.ascx", true);

            //WebPageHelper.CreateDefaultWebPage(web, "lien-he-van-hanh.aspx", web.Language == 1033 ? "Contact" : "Liên hệ", true, false);
            //AddUserControlToPage(web, "lien-he-van-hanh", "Liên hệ vận hành", "UserControls/Views/Contacts/ContactProcess.ascx", true);

            //// Danh cho khach hang moi

            WebPageHelper.CreateDefaultWebPage(web, "milestones.aspx", web.Language == 1033 ? "Milestones" : "Milestones", true, false);
            AddUserControlToPage(web, "milestones", "milestones", "UserControls/Views/About/Milestones.ascx", true);
        }

        private static void AddUserControlToPage(SPWeb web, string pageName, string pageTitle, string userControlPath, bool fullPath)
        {
            ContainerWebPart containerWebPart = WebPartHelper.GetContainerWebPart(web);
            if (containerWebPart != null)
            {
                containerWebPart.Title = pageTitle;
                if (fullPath)
                {
                    containerWebPart.UserControlPath = userControlPath;
                }
                else
                {
                    containerWebPart.UserControlPath = string.Format(CultureInfo.CurrentCulture, "UserControls/Dialogs/{0}.ascx", userControlPath);
                }

                WebPartHelper.AddWebPart(web, string.Format(CultureInfo.InvariantCulture, "{0}.aspx", pageName), containerWebPart, "Main", 0);
            }
        }

        private void AddImageField(SPList list, string internalName, string displayName, string uploadImagesTo)
        {
            if (!list.Fields.ContainsFieldWithStaticName(internalName))
            {
                var field = list.Fields.CreateNewField("ImageUpload", internalName) as ImageUploadFieldType;
                var fieldName = list.Fields.Add(field);

                field = list.Fields[fieldName] as ImageUploadFieldType;
                field.UploadImagesTo = uploadImagesTo;
                field.Title = displayName;
                field.Required = true;
                field.Update();
            }
        }

        private void AddPublishingPageContentField(SPWeb web, SPList list, string displayName)
        {
            if (!list.Fields.ContainsFieldWithStaticName(Constants.CommonField.PublishingPageContent))
            {
                var fieldName = list.Fields.Add(web.Fields.GetFieldByInternalName(Constants.CommonField.PublishingPageContent));
                var field = list.Fields.GetFieldByInternalName(fieldName);
                field.Title = displayName;
                field.Update();
                list.Update();
            }
        }

        private void AddField(SPList list, string internalName, string displayName)
        {
            if (!list.Fields.ContainsFieldWithStaticName(internalName))
            {
                var fieldName = list.Fields.Add(internalName, SPFieldType.Note, false);
                var field = list.Fields.GetFieldByInternalName(fieldName);
                field.Title = displayName;
                field.Update();
                list.Update();
            }
        }

        private void AddSingleTextField(SPList list, string internalName, string displayName)
        {
            if (!list.Fields.ContainsFieldWithStaticName(internalName))
            {
                var fieldName = list.Fields.Add(internalName, SPFieldType.Text, false);
                var field = list.Fields.GetFieldByInternalName(fieldName);
                field.Title = displayName;
                field.Update();
                list.Update();
            }
        }

        private void AddCustomUrlField(SPList list)
        {
            if (!list.Fields.ContainsFieldWithStaticName(Constants.CommonField.Custom_URL))
            {
                var fieldName = list.Fields.Add(Constants.CommonField.Custom_URL, SPFieldType.Text, false);
                var field = list.Fields.GetFieldByInternalName(fieldName);

                field.ShowInEditForm = false;
                field.ShowInDisplayForm = false;
                field.ShowInNewForm = false;
                field.ShowInListSettings = true;
                field.Update();

                list.Update();
            }
        }

        #endregion Commons

        #region Document's partner

        private void CreateDocument(SPWeb web, string title)
        {
            var helper = new ListHelper(web)
            {
                Title = title,
                OnQuickLaunch = true,
                EnableAttachments = false,
                ListTemplateType = SPListTemplateType.DocumentLibrary
            };

            helper.AddField(new LookupFieldCreator(Constants.DocumentShareholder.InternalFields.Type, Constants.DocumentShareholder.DisplayFields.Type)
            {
                Required = true,
                LookupList = Constants.DocumentGroup.ListName,
                LookupField = Constants.CommonField.Title,
            });

            //helper.AddField(new DateTimeFieldCreator(Constants.DocumentShareholder.InternalFields.DocumentDate, Constants.DocumentShareholder.DisplayFields.DocumentDate)
            //{
            //    Required = true,
            //    DisplayFormat = SPDateTimeFieldFormatType.DateOnly
            //});

            helper.AddField(new BooleanFieldCreator(Constants.DocumentShareholder.InternalFields.Activate, Constants.DocumentShareholder.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        private void CreateDocumentEn(SPWeb web, string title)
        {
            var helper = new ListHelper(web)
            {
                Title = title,
                OnQuickLaunch = true,
                EnableAttachments = false,
                ListTemplateType = SPListTemplateType.DocumentLibrary
            };

            helper.AddField(new LookupFieldCreator(Constants.DocumentShareholder.InternalFields.Type, Constants.DocumentShareholder.EnglishFields.Type)
            {
                Required = true,
                LookupList = Constants.DocumentGroup.ListNameEnglish,
                LookupField = Constants.CommonField.Title,
            });

            //helper.AddField(new DateTimeFieldCreator(Constants.DocumentShareholder.InternalFields.DocumentDate, Constants.DocumentShareholder.DisplayFields.DocumentDate)
            //{
            //    Required = true,
            //    DisplayFormat = SPDateTimeFieldFormatType.DateOnly
            //});

            helper.AddField(new BooleanFieldCreator(Constants.DocumentShareholder.InternalFields.Activate, Constants.DocumentShareholder.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        #endregion Document's partner

        #region Document

        private void CreateDocumentGroup(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.DocumentGroup.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false,
            };

            helper.AddField(new ChoiceFieldCreator(Constants.DocumentGroup.InternalFields.DocumentType, Constants.DocumentGroup.DisplayFields.DocumentType)
            {
                Required = true,
                Choices = Constants.DocumentGroup.TypeValue.valueStringCollection,
            });

            helper.AddField(new NumberFieldCreator(Constants.DocumentGroup.InternalFields.Order, Constants.DocumentGroup.DisplayFields.Order)
            {
                Required = true,
            });

            helper.AddField(new BooleanFieldCreator(Constants.DocumentGroup.InternalFields.Activate, Constants.DocumentGroup.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.DocumentGroup.DisplayFields.Name, true, false);
        }

        private void CreateDocumentGroupEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.DocumentGroup.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false,
            };

            helper.AddField(new ChoiceFieldCreator(Constants.DocumentGroup.InternalFields.DocumentType, Constants.DocumentGroup.EnglishFields.DocumentType)
            {
                Required = true,
                Choices = Constants.DocumentGroup.TypeValue.valueStringCollection,
            });

            helper.AddField(new NumberFieldCreator(Constants.DocumentGroup.InternalFields.Order, Constants.DocumentGroup.EnglishFields.Order)
            {
                Required = true,
            });

            helper.AddField(new BooleanFieldCreator(Constants.DocumentGroup.InternalFields.Activate, Constants.DocumentGroup.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.DocumentGroup.EnglishFields.Name, true, false);
        }

        #endregion Document

        #region Organization

        public void CreateOrganizationEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.Organization.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new LookupFieldCreator(Constants.Organization.InternalFields.Parent, Constants.Organization.EnglishFields.Parent)
            {
                Required = false,
                LookupList = Constants.Organization.ListNameEnglish,
                LookupField = Constants.Organization.InternalFields.Name,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Organization.InternalFields.Description, Constants.Organization.EnglishFields.Description)
            {
                RichText = false,
                Required = false
            });

            helper.AddField(new BooleanFieldCreator(Constants.Organization.InternalFields.Activate, Constants.Organization.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.Organization.EnglishFields.Name, true, false);

            AddImageField(list, Constants.Organization.InternalFields.Image, Constants.Organization.EnglishFields.Image, "Images");

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        public void CreateOrganization(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.Organization.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new LookupFieldCreator(Constants.Organization.InternalFields.Parent, Constants.Organization.DisplayFields.Parent)
            {
                Required = false,
                LookupList = Constants.Organization.ListName,
                LookupField = Constants.Organization.InternalFields.Name,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Organization.InternalFields.Description, Constants.Organization.DisplayFields.Description)
            {
                RichText = false,
                Required = false
            });

            helper.AddField(new BooleanFieldCreator(Constants.Organization.InternalFields.Activate, Constants.Organization.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.Organization.DisplayFields.Name, true, false);

            AddImageField(list, Constants.Organization.InternalFields.Image, Constants.Organization.DisplayFields.Image, "Ảnh");

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        #endregion Organization

        #region Term of use

        private void CreateTermOfUse(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.TermsOfUse.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false,
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.TermsOfUse.InternalFields.Content, Constants.TermsOfUse.EnglishFields.Content)
            {
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                RichText = true,
                NumberOfLines = 20,
            });

            helper.AddField(new NumberFieldCreator(Constants.TermsOfUse.InternalFields.Order, Constants.TermsOfUse.EnglishFields.Order)
            {
                Required = true,
                DefaultValue = "1",
            });

            helper.AddField(new BooleanFieldCreator(Constants.TermsOfUse.InternalFields.Activate, Constants.TermsOfUse.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true,
            });

            var list = helper.Apply();
            this.UpdateTitleField(list, Constants.TermsOfUse.EnglishFields.Name, true, false);

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        private void CreateTermOfUseEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.TermsOfUse.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false,
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.TermsOfUse.InternalFields.Content, Constants.TermsOfUse.DisplayFields.Content)
            {
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                RichText = true,
                NumberOfLines = 20,
            });

            helper.AddField(new NumberFieldCreator(Constants.TermsOfUse.InternalFields.Order, Constants.TermsOfUse.DisplayFields.Order)
            {
                Required = true,
                DefaultValue = "1",
            });

            helper.AddField(new BooleanFieldCreator(Constants.TermsOfUse.InternalFields.Activate, Constants.TermsOfUse.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true,
            });

            var list = helper.Apply();
            this.UpdateTitleField(list, Constants.TermsOfUse.DisplayFields.Name, true, false);

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        #endregion Term of use

        #region Contact infomation

        private void CreateContactInfomation(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.ContactInfomation.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false,
            };

            helper.AddField(new ChoiceFieldCreator(Constants.ContactInfomation.InternalFields.ContactType, Constants.ContactInfomation.DisplayFields.ContactType)
            {
                Required = true,
                EnforceUniqueValues = true,
                Choices = Constants.ContactInfomation.ContactTypeCollection
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ContactInfomation.InternalFields.Content, Constants.ContactInfomation.DisplayFields.Content)
            {
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                RichText = true,
                NumberOfLines = 10,
            });

            helper.AddField(new NumberFieldCreator(Constants.ContactInfomation.InternalFields.Order, Constants.ContactInfomation.DisplayFields.Order)
            {
                Required = true,
                DefaultValue = "1",
            });

            helper.AddField(new BooleanFieldCreator(Constants.ContactInfomation.InternalFields.Activate, Constants.ContactInfomation.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true,
            });

            var list = helper.Apply();
            this.UpdateTitleField(list, Constants.ContactInfomation.DisplayFields.Name, true, false);
        }

        private void CreateContactInfomationEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.ContactInfomation.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false,
            };

            helper.AddField(new ChoiceFieldCreator(Constants.ContactInfomation.InternalFields.ContactType, Constants.ContactInfomation.EnglishFields.ContactType)
            {
                Required = true,
                EnforceUniqueValues = true,
                Choices = Constants.ContactInfomation.ContactTypeCollection
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ContactInfomation.InternalFields.Content, Constants.ContactInfomation.EnglishFields.Content)
            {
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                RichText = true,
                NumberOfLines = 10,
            });

            helper.AddField(new NumberFieldCreator(Constants.ContactInfomation.InternalFields.Order, Constants.ContactInfomation.EnglishFields.Order)
            {
                Required = true,
                DefaultValue = "1",
            });

            helper.AddField(new BooleanFieldCreator(Constants.ContactInfomation.InternalFields.Activate, Constants.ContactInfomation.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true,
            });

            var list = helper.Apply();
            this.UpdateTitleField(list, Constants.ContactInfomation.EnglishFields.Name, true, false);
        }

        private void CreateContact(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.Contact.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false,
            };

            helper.AddField(new SingleLineTextFieldCreator(Constants.Contact.InternalFields.Mobile, Constants.Contact.DisplayFields.Mobile)
            {
                Required = true,
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Contact.InternalFields.Email, Constants.Contact.DisplayFields.Email)
            {
                Required = true,
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Contact.InternalFields.Subject, Constants.Contact.DisplayFields.Subject)
            {
                Required = true,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Contact.InternalFields.Content, Constants.Contact.DisplayFields.Content)
            {
                Required = true,
                RichText = false,
                NumberOfLines = 10,
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Contact.InternalFields.ContactType, Constants.Contact.DisplayFields.ContactType));

            helper.AddField(new ChoiceFieldCreator(Constants.Contact.InternalFields.Status, Constants.Contact.DisplayFields.Status)
            {
                Choices = Constants.Contact.StatusCollection,
                DefaultValue = Constants.Contact.StatusCollection[0],
            });

            var list = helper.Apply();
            this.UpdateTitleField(list, Constants.Contact.DisplayFields.Name, true, false);
        }

        private void CreateContactEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.Contact.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false,
            };

            helper.AddField(new SingleLineTextFieldCreator(Constants.Contact.InternalFields.Mobile, Constants.Contact.EnglishFields.Mobile)
            {
                Required = true,
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Contact.InternalFields.Email, Constants.Contact.EnglishFields.Email)
            {
                Required = true,
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Contact.InternalFields.Subject, Constants.Contact.EnglishFields.Subject)
            {
                Required = true,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Contact.InternalFields.Content, Constants.Contact.EnglishFields.Content)
            {
                Required = true,
                RichText = false,
                NumberOfLines = 10,
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Contact.InternalFields.ContactType, Constants.Contact.EnglishFields.ContactType));

            helper.AddField(new ChoiceFieldCreator(Constants.Contact.InternalFields.Status, Constants.Contact.EnglishFields.Status)
            {
                Choices = Constants.Contact.StatusCollection,
                DefaultValue = Constants.Contact.StatusCollection[0],
            });

            var list = helper.Apply();
            this.UpdateTitleField(list, Constants.Contact.EnglishFields.Name, true, false);
        }

        #endregion Contact infomation

        #region Recruitment

        public void ContactInforEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.ContactInfor.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new SingleLineTextFieldCreator(Constants.ContactInfor.InternalFields.ContactUsr, Constants.ContactInfor.EnglishFields.ContactUsr)
            {
                Required = true,
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.ContactInfor.InternalFields.Phone, Constants.ContactInfor.EnglishFields.Phone)
            {
                Required = true,
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.ContactInfor.InternalFields.PhoneExt, Constants.ContactInfor.EnglishFields.PhoneExt)
            {
                Required = true,
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.ContactInfor.InternalFields.Email, Constants.ContactInfor.EnglishFields.Email)
            {
                Required = true,
            });

            helper.AddField(new BooleanFieldCreator(Constants.ContactInfor.InternalFields.Activate, Constants.ContactInfor.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.ContactInfor.DisplayFields.Name, true, false);

            AddImageField(list, Constants.ContactInfor.InternalFields.Image, Constants.ContactInfor.EnglishFields.Image, "Images");

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        public void ContactInfor(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.ContactInfor.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new SingleLineTextFieldCreator(Constants.ContactInfor.InternalFields.ContactUsr, Constants.ContactInfor.DisplayFields.ContactUsr)
            {
                Required = true,
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.ContactInfor.InternalFields.Phone, Constants.ContactInfor.DisplayFields.Phone)
            {
                Required = true,
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.ContactInfor.InternalFields.PhoneExt, Constants.ContactInfor.DisplayFields.PhoneExt)
            {
                Required = true,
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.ContactInfor.InternalFields.Email, Constants.ContactInfor.DisplayFields.Email)
            {
                Required = true,
            });

            helper.AddField(new BooleanFieldCreator(Constants.ContactInfor.InternalFields.Activate, Constants.ContactInfor.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.ContactInfor.DisplayFields.Name, true, false);

            AddImageField(list, Constants.ContactInfor.InternalFields.Image, Constants.ContactInfor.DisplayFields.Image, "Ảnh");

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        public void HumanResourceEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.HumanResource.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.HumanResource.InternalFields.Description, Constants.HumanResource.EnglishFields.Description)
            {
                RichText = false,
                Required = false
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.HumanResource.InternalFields.Content, Constants.HumanResource.EnglishFields.Content)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.HumanResource.InternalFields.Activate, Constants.HumanResource.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.HumanResource.EnglishFields.Name, true, false);

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        public void HumanResource(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.HumanResource.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.HumanResource.InternalFields.Description, Constants.HumanResource.DisplayFields.Description)
            {
                RichText = false,
                Required = false
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.HumanResource.InternalFields.Content, Constants.HumanResource.DisplayFields.Content)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.HumanResource.InternalFields.Activate, Constants.HumanResource.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.HumanResource.DisplayFields.Name, true, false);

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        public void ApplicationInforEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.ApplicationInformation.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ApplicationInformation.InternalFields.Description, Constants.ApplicationInformation.EnglishFields.Description)
            {
                RichText = false,
                Required = false
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ApplicationInformation.InternalFields.Content, Constants.ApplicationInformation.EnglishFields.Content)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.ApplicationInformation.InternalFields.Activate, Constants.ApplicationInformation.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.ApplicationInformation.EnglishFields.Name, true, false);
        }

        public void ApplicationInfor(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.ApplicationInformation.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ApplicationInformation.InternalFields.Description, Constants.ApplicationInformation.DisplayFields.Description)
            {
                RichText = false,
                Required = false
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.ApplicationInformation.InternalFields.Content, Constants.ApplicationInformation.DisplayFields.Content)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.ApplicationInformation.InternalFields.Activate, Constants.ApplicationInformation.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.ApplicationInformation.DisplayFields.Name, true, false);
        }

        public void CreateCareerResultEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.CareerResult.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.CareerResult.InternalFields.Description, Constants.CareerResult.EnglishFields.Description)
            {
                RichText = false,
                Required = false
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.CareerResult.InternalFields.Content, Constants.CareerResult.EnglishFields.Content)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.CareerResult.InternalFields.Activate, Constants.CareerResult.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.CareerResult.EnglishFields.Name, true, false);

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        public void CreateCareerResult(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.CareerResult.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.CareerResult.InternalFields.Description, Constants.CareerResult.DisplayFields.Description)
            {
                RichText = false,
                Required = false
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.CareerResult.InternalFields.Content, Constants.CareerResult.DisplayFields.Content)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.CareerResult.InternalFields.Activate, Constants.CareerResult.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.CareerResult.DisplayFields.Name, true, false);

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        private void CreateCVDocument(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.CVDocument.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false,
                ListTemplateType = SPListTemplateType.DocumentLibrary
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.CVDocument.InternalFields.Description, Constants.CVDocument.DisplayFields.Description)
            {
                RichText = false,
                Required = false
            });

            helper.AddField(new DateTimeFieldCreator(Constants.CVDocument.InternalFields.DocumentDate, Constants.CVDocument.DisplayFields.DocumentDate)
            {
                Required = true,
                DisplayFormat = SPDateTimeFieldFormatType.DateOnly
            });

            helper.AddField(new BooleanFieldCreator(Constants.CVDocument.InternalFields.Activate, Constants.CVDocument.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        private void CreateCVDocumentEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.CVDocument.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false,
                ListTemplateType = SPListTemplateType.DocumentLibrary
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.CVDocument.InternalFields.Description, Constants.CVDocument.EnglishFields.Description)
            {
                RichText = false,
                Required = false
            });

            helper.AddField(new DateTimeFieldCreator(Constants.CVDocument.InternalFields.DocumentDate, Constants.CVDocument.EnglishFields.DocumentDate)
            {
                Required = true,
                DisplayFormat = SPDateTimeFieldFormatType.DateOnly
            });

            helper.AddField(new BooleanFieldCreator(Constants.CVDocument.InternalFields.Activate, Constants.CVDocument.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        #endregion Recruitment

        #region Organization

        private void CreateOrganizationChart(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.OrganizationChart.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.OrganizationChart.InternalFields.Description, Constants.OrganizationChart.DisplayFields.Description)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.OrganizationChart.InternalFields.Activate, Constants.OrganizationChart.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.OrganizationChart.DisplayFields.Name, true, false);

            AddImageField(list, Constants.OrganizationChart.InternalFields.Image, Constants.OrganizationChart.DisplayFields.Image, "Ảnh");
        }

        private void CreateOrganizationChartEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.OrganizationChart.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.OrganizationChart.InternalFields.Description, Constants.OrganizationChart.EnglishFields.Description)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.OrganizationChart.InternalFields.Activate, Constants.OrganizationChart.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();
            this.UpdateTitleField(list, Constants.OrganizationChart.EnglishFields.Name, true, false);

            AddImageField(list, Constants.OrganizationChart.InternalFields.Image, Constants.OrganizationChart.EnglishFields.Image, "Images");
        }

        private void CreateOrganizationBroad(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.OrganizationBroad.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new ChoiceFieldCreator(Constants.OrganizationBroad.InternalFields.Division, Constants.OrganizationBroad.DisplayFields.Division)
            {
                Choices = new StringCollection() { Constants.OrgNameVn.GeneralAssembly, Constants.OrgNameVn.ExecutiveBoard, Constants.OrgNameVn.ExecutiveCommittee },
                DefaultValue = Constants.OrgNameVn.GeneralAssembly
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.OrganizationBroad.InternalFields.PersonName, Constants.OrganizationBroad.DisplayFields.PersonName));

            helper.AddField(new SingleLineTextFieldCreator(Constants.OrganizationBroad.InternalFields.Duty, Constants.OrganizationBroad.DisplayFields.Duty));

            helper.AddField(new ChoiceFieldCreator(Constants.OrganizationBroad.InternalFields.Level, Constants.OrganizationBroad.DisplayFields.Level)
            {
                Choices = Constants.OrganizationBroad.GroupColection,
                DefaultValue = Constants.OrganizationBroad.GroupColection[0],
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.OrganizationBroad.InternalFields.History, Constants.OrganizationBroad.DisplayFields.History)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.OrganizationBroad.InternalFields.Activate, Constants.OrganizationBroad.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.OrganizationChart.DisplayFields.Name, true, false);

            AddImageField(list, Constants.OrganizationBroad.InternalFields.Image, Constants.OrganizationBroad.DisplayFields.Image, "Ảnh");
        }

        private void CreateOrganizationBroadEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.OrganizationBroad.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new ChoiceFieldCreator(Constants.OrganizationBroad.InternalFields.Division, Constants.OrganizationBroad.EnglishFields.Division)
            {
                Choices = new StringCollection() { Constants.OrgNameEn.GeneralAssembly, Constants.OrgNameEn.ExecutiveBoard, Constants.OrgNameEn.ExecutiveCommittee },
                DefaultValue = Constants.OrgNameEn.GeneralAssembly
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.OrganizationBroad.InternalFields.PersonName, Constants.OrganizationBroad.EnglishFields.PersonName));

            helper.AddField(new SingleLineTextFieldCreator(Constants.OrganizationBroad.InternalFields.Duty, Constants.OrganizationBroad.EnglishFields.Duty));

            helper.AddField(new ChoiceFieldCreator(Constants.OrganizationBroad.InternalFields.Level, Constants.OrganizationBroad.EnglishFields.Level)
            {
                Choices = Constants.OrganizationBroad.GroupColection,
                DefaultValue = Constants.OrganizationBroad.GroupColection[0],
            });

            //helper.AddField(new SingleLineTextFieldCreator(Constants.OrganizationBroad.InternalFields.Level, Constants.OrganizationBroad.EnglishFields.Level));

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.OrganizationBroad.InternalFields.History, Constants.OrganizationBroad.EnglishFields.History)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.OrganizationBroad.InternalFields.Activate, Constants.OrganizationBroad.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.OrganizationChart.DisplayFields.Name, true, false);

            AddImageField(list, Constants.OrganizationBroad.InternalFields.Image, Constants.OrganizationBroad.EnglishFields.Image, "Images");
        }

        #endregion Organization

        public void CreateSlider(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.Slider.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false,
            };

            helper.AddField(new UrlFieldCreator(Constants.Slider.InternalFields.LinkToContent, Constants.Slider.DisplayFields.LinkToContent) { Required = true });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Slider.InternalFields.Description, Constants.Slider.DisplayFields.Description)
            {
                Required = true,
                RichTextMode = SPRichTextMode.Compatible,
                RichText = false,
            });

            helper.AddField(new ChoiceFieldCreator(Constants.Slider.InternalFields.Slider, Constants.Slider.DisplayFields.Slider)
            {
                Required = true,
                Choices = new StringCollection() { "1", "2", "3", "4" }
            });

            helper.AddField(new NumberFieldCreator(Constants.Slider.InternalFields.Order, Constants.Slider.DisplayFields.Order)
            {
                Required = true,
            });

            helper.AddField(new BooleanFieldCreator(Constants.Slider.InternalFields.Active, Constants.Slider.DisplayFields.Active)
            {
                Required = true,
                DefaultYesValue = true,
            });

            var list = helper.Apply();
            UpdateTitleField(list, Constants.Slider.DisplayFields.Slogan, true, false);

            AddImageField(list, Constants.Slider.InternalFields.Banner1366, Constants.Slider.DisplayFields.Banner1366, "Ảnh");
            AddImageField(list, Constants.Slider.InternalFields.Banner1024, Constants.Slider.DisplayFields.Banner1024, "Ảnh");
            AddImageField(list, Constants.Slider.InternalFields.Banner480, Constants.Slider.DisplayFields.Banner480, "Ảnh");
        }

        public void CreateSliderEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.Slider.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false,
            };

            helper.AddField(new UrlFieldCreator(Constants.Slider.InternalFields.LinkToContent, Constants.Slider.EnglishFields.LinkToContent) { Required = true });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Slider.InternalFields.Description, Constants.Slider.EnglishFields.Description)
            {
                Required = true,
                RichTextMode = SPRichTextMode.Compatible,
                RichText = false,
            });

            helper.AddField(new ChoiceFieldCreator(Constants.Slider.InternalFields.Slider, Constants.Slider.DisplayFields.Slider)
            {
                Required = true,
                Choices = new StringCollection() { "1", "2", "3", "4" }
            });

            helper.AddField(new NumberFieldCreator(Constants.Slider.InternalFields.Order, Constants.Slider.DisplayFields.Order)
            {
                Required = true,
            });

            helper.AddField(new BooleanFieldCreator(Constants.Slider.InternalFields.Active, Constants.Slider.DisplayFields.Active)
            {
                Required = true,
                DefaultYesValue = true,
            });

            var list = helper.Apply();
            UpdateTitleField(list, Constants.Slider.EnglishFields.Slogan, true, false);

            AddImageField(list, Constants.Slider.InternalFields.Banner1366, Constants.Slider.EnglishFields.Banner1366, "Images");
            AddImageField(list, Constants.Slider.InternalFields.Banner1024, Constants.Slider.EnglishFields.Banner1024, "Images");
            AddImageField(list, Constants.Slider.InternalFields.Banner480, Constants.Slider.EnglishFields.Banner480, "Images");
        }

        public void CreateSettings(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.Setting.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false,
            };

            helper.AddField(new SingleLineTextFieldCreator(Constants.Setting.InternalFields.CompanyNameEn, Constants.Setting.DisplayFields.CompanyNameEn) { Required = true });
            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Setting.InternalFields.Address, Constants.Setting.DisplayFields.Address)
            {
                Required = true,
                RichText = false,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Setting.InternalFields.SubAddress, Constants.Setting.DisplayFields.SubAddress)
            {
                Required = true,
                RichText = false,
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Setting.InternalFields.Mobile, Constants.Setting.DisplayFields.Mobile) { Required = true });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Setting.InternalFields.Hotline, Constants.Setting.DisplayFields.Hotline) { Required = true });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Setting.InternalFields.Email, Constants.Setting.DisplayFields.Email) { Required = true });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Setting.InternalFields.Facebook, Constants.Setting.DisplayFields.Facebook) { Required = true });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Setting.InternalFields.Youtube, Constants.Setting.DisplayFields.Youtube) { Required = true });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Setting.InternalFields.Twitter, Constants.Setting.DisplayFields.Twitter) { Required = false });

            var list = helper.Apply();
            UpdateTitleField(list, Constants.Setting.DisplayFields.CompanyName, true, false);
            var ImageLibrary = "Ảnh";
            AddImageField(list, Constants.Setting.InternalFields.Logo, Constants.Setting.DisplayFields.Logo, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.LogoFooter, Constants.Setting.DisplayFields.LogoFooter, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerAboutUs, Constants.Setting.DisplayFields.BanerAboutUs, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerNews, Constants.Setting.DisplayFields.BanerNews, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerProduct, Constants.Setting.DisplayFields.BanerProduct, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerCustomer, Constants.Setting.DisplayFields.BanerCustomer, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerPartner, Constants.Setting.DisplayFields.BanerPartner, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerUserGuide, Constants.Setting.DisplayFields.BanerUserGuide, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerDocument, Constants.Setting.DisplayFields.BanerDocument, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerCeare, Constants.Setting.DisplayFields.BanerCeare, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerTermCondition, Constants.Setting.DisplayFields.BanerTermCondition, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerHotline, Constants.Setting.DisplayFields.BanerHotline, ImageLibrary);
        }

        public void CreateSettingsEN(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.Setting.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false,
            };

            helper.AddField(new SingleLineTextFieldCreator(Constants.Setting.InternalFields.CompanyNameEn, Constants.Setting.EnglishFields.CompanyNameEn) { Required = true });
            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Setting.InternalFields.Address, Constants.Setting.EnglishFields.Address)
            {
                Required = true,
                RichText = false,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.Setting.InternalFields.SubAddress, Constants.Setting.EnglishFields.SubAddress)
            {
                Required = true,
                RichText = false,
            });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Setting.InternalFields.Mobile, Constants.Setting.EnglishFields.Mobile) { Required = true });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Setting.InternalFields.Hotline, Constants.Setting.EnglishFields.Hotline) { Required = true });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Setting.InternalFields.Email, Constants.Setting.EnglishFields.Email) { Required = true });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Setting.InternalFields.Facebook, Constants.Setting.EnglishFields.Facebook) { Required = true });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Setting.InternalFields.Youtube, Constants.Setting.EnglishFields.Youtube) { Required = true });

            helper.AddField(new SingleLineTextFieldCreator(Constants.Setting.InternalFields.Twitter, Constants.Setting.EnglishFields.Twitter) { Required = false });

            var list = helper.Apply();
            UpdateTitleField(list, Constants.Setting.InternalFields.CompanyName, true, false);
            var ImageLibrary = "Images";
            AddImageField(list, Constants.Setting.InternalFields.Logo, Constants.Setting.EnglishFields.Logo, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.LogoFooter, Constants.Setting.EnglishFields.LogoFooter, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerAboutUs, Constants.Setting.EnglishFields.BanerAboutUs, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerNews, Constants.Setting.EnglishFields.BanerNews, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerProduct, Constants.Setting.EnglishFields.BanerProduct, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerCustomer, Constants.Setting.EnglishFields.BanerCustomer, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerPartner, Constants.Setting.EnglishFields.BanerPartner, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerUserGuide, Constants.Setting.EnglishFields.BanerUserGuide, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerDocument, Constants.Setting.EnglishFields.BanerDocument, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerCeare, Constants.Setting.EnglishFields.BanerCeare, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerTermCondition, Constants.Setting.EnglishFields.BanerTermCondition, ImageLibrary);
            AddImageField(list, Constants.Setting.InternalFields.BanerHotline, Constants.Setting.EnglishFields.BanerHotline, ImageLibrary);
        }

        #region Vender service

        private void CreateVenderService(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.VenderService.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleChoiceFieldCreator(Constants.VenderService.InternalFields.Services, Constants.VenderService.DisplayFields.Services)
            {
                Required = true,
                Choices = new StringCollection()
                {
                    Constants.VenderService.Services.Transportation, Constants.VenderService.Services.Retail, Constants.VenderService.Services.Telecommunication,
                    Constants.VenderService.Services.Insurrance, Constants.VenderService.Services.Game, Constants.VenderService.Services.Television, Constants.VenderService.Services.Finance, Constants.VenderService.Services.InternetADSL
                }
            });

            helper.AddField(new UrlFieldCreator(Constants.VenderService.InternalFields.PartnerWebsite, Constants.VenderService.DisplayFields.PartnerWebsite)
            {
                Required = false,
                DisplayFormat = SPUrlFieldFormatType.Hyperlink
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.VenderService.InternalFields.DeploymentServices, Constants.VenderService.DisplayFields.DeploymentServices)
            {
                RichText = false,
                Required = false,
                NumberOfLines = 3
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.VenderService.InternalFields.CustomerCode, Constants.VenderService.DisplayFields.CustomerCode)
            {
                RichText = false,
                Required = false,
                NumberOfLines = 3
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.VenderService.InternalFields.FaceValueOfTheChargeCard_PaymentAmount, Constants.VenderService.DisplayFields.FaceValueOfTheChargeCard_PaymentAmount)
            {
                RichText = false,
                Required = false,
                NumberOfLines = 3
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.VenderService.InternalFields.InformationNote, Constants.VenderService.DisplayFields.InformationNote)
            {
                RichText = false,
                Required = false,
                NumberOfLines = 3
            });

            helper.AddField(new BooleanFieldCreator(Constants.VenderService.InternalFields.Activate, Constants.VenderService.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.VenderService.DisplayFields.Name, true, false);
            AddImageField(list, Constants.VenderService.InternalFields.Image, Constants.VenderService.DisplayFields.Image, "Ảnh");
        }

        private void CreateVenderServiceEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.VenderService.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new MultipleChoiceFieldCreator(Constants.VenderService.InternalFields.Services, Constants.VenderService.EnglishFields.Services)
            {
                Required = true,
                Choices = new StringCollection()
                {
                    Constants.VenderService.Services.Transportation, Constants.VenderService.Services.Retail, Constants.VenderService.Services.Telecommunication,
                    Constants.VenderService.Services.Insurrance, Constants.VenderService.Services.Game, Constants.VenderService.Services.Television, Constants.VenderService.Services.Finance, Constants.VenderService.Services.InternetADSL
                }
            });

            helper.AddField(new UrlFieldCreator(Constants.VenderService.InternalFields.PartnerWebsite, Constants.VenderService.EnglishFields.PartnerWebsite)
            {
                Required = false,
                DisplayFormat = SPUrlFieldFormatType.Hyperlink
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.VenderService.InternalFields.DeploymentServices, Constants.VenderService.EnglishFields.DeploymentServices)
            {
                RichText = false,
                Required = false,
                NumberOfLines = 3
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.VenderService.InternalFields.CustomerCode, Constants.VenderService.EnglishFields.CustomerCode)
            {
                RichText = false,
                Required = false,
                NumberOfLines = 3
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.VenderService.InternalFields.FaceValueOfTheChargeCard_PaymentAmount, Constants.VenderService.EnglishFields.FaceValueOfTheChargeCard_PaymentAmount)
            {
                RichText = false,
                Required = false,
                NumberOfLines = 3
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.VenderService.InternalFields.InformationNote, Constants.VenderService.EnglishFields.InformationNote)
            {
                RichText = false,
                Required = false,
                NumberOfLines = 3
            });

            helper.AddField(new BooleanFieldCreator(Constants.VenderService.InternalFields.Activate, Constants.VenderService.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.VenderService.DisplayFields.Name, true, false);
            AddImageField(list, Constants.VenderService.InternalFields.Image, Constants.VenderService.EnglishFields.Image, "Images");
        }

        #endregion Vender service

        private void CreateMilestones(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.MilestonesAchievements.ListName,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new NumberFieldCreator(Constants.MilestonesAchievements.InternalFields.Year, Constants.MilestonesAchievements.DisplayFields.Year)
            {
                MinimumValue = 1900,
                Required = true,
                DisplayFormat = SPNumberFormatTypes.NoDecimal,
                EnforceUniqueValues = true,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.MilestonesAchievements.InternalFields.Content, Constants.MilestonesAchievements.DisplayFields.Content)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.Introduction.InternalFields.Activate, Constants.Introduction.DisplayFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.MilestonesAchievements.DisplayFields.Name, true, false);

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }

        private void CreateMilestonesEn(SPWeb web)
        {
            var helper = new ListHelper(web)
            {
                Title = Constants.MilestonesAchievements.ListNameEnglish,
                OnQuickLaunch = true,
                EnableAttachments = false
            };

            helper.AddField(new NumberFieldCreator(Constants.MilestonesAchievements.InternalFields.Year, Constants.MilestonesAchievements.EnglishFields.Year)
            {
                MinimumValue = 1900,
                Required = true,
                DisplayFormat = SPNumberFormatTypes.NoDecimal,
                EnforceUniqueValues = true,
            });

            helper.AddField(new MultipleLinesTextFieldCreator(Constants.MilestonesAchievements.InternalFields.Content, Constants.MilestonesAchievements.EnglishFields.Content)
            {
                RichText = true,
                Required = true,
                RichTextMode = SPRichTextMode.FullHtml,
                NumberOfLines = 10
            });

            helper.AddField(new BooleanFieldCreator(Constants.Introduction.InternalFields.Activate, Constants.Introduction.EnglishFields.Activate)
            {
                Required = true,
                DefaultYesValue = true
            });

            var list = helper.Apply();

            this.UpdateTitleField(list, Constants.MilestonesAchievements.EnglishFields.Name, true, false);

            this.AddCustomUrlField(list);

            list.EventReceivers.Add(SPEventReceiverType.ItemAdded, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");

            list.EventReceivers.Add(SPEventReceiverType.ItemUpdated, Assembly.GetExecutingAssembly().FullName, "Napas.Portal.Business.EventReceiver.EventReceiver");
        }
    }
}