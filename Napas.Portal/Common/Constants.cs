using System.Collections.Specialized;

namespace Napas.Portal.Common
{
    public static class Constants
    {
        #region Common field

        public static class CommonField
        {
            public const string Created = "Created";
            public const string Modified = "Modified";
            public const string Title = "Title";
            public const string ID = "ID";
            public const string Name = "Name";
            public const string PublishingPageContent = "PublishingPageContent";
            public const string PublishingPageContent1 = "PublishingPageContent1";
            public const string Custom_URL = "CustomURL";
        }

        #endregion Common field

        #region Session text

        public static class SessionText
        {
            public const string CategorySession = "CategorySession";
        }

        #endregion Session text

        #region Category

        public static class CategoryNews
        {
            public static string ListName = "Nhóm tin tức";
            public static string ListNameEnglish = "News Catogory";

            public static class DisplayFields
            {
                public const string Name = "Tên";
                public const string Order = "STT";
                public const string Description = "Mô tả";
                public const string Activate = "Kích hoạt";
            }

            public static class EnglishFields
            {
                public const string Name = "Name";
                public const string Order = "Order ";
                public const string Description = "Description";
                public const string Activate = "Activate";
            }

            public static class InternalFields
            {
                public const string Name = "Title";

                public const string Order = "OderSort";
                public const string Description = "Description";
                public const string Activate = "Activate";
            }
        }

        #endregion Category

        #region News

        public static class News
        {
            public static string ListName = "Tin tức";
            public static string ListNameEnglish = "News";

            public static class DisplayFields
            {
                public const string Name = "Tiêu đề";
                public const string Description = "Mô tả";
                public const string Thumbar = "Ảnh đại diện";
                public const string Category = "Nhóm tin";
                public const string Content = "Nội dung";
                public const string Activate = "Kích hoạt";
                public const string FromDate = "Từ ngày";
                public const string ToDate = "Tới ngày";
                public const string ShowHomePage = "Hien trang chu";
            }

            public static class EnglishFields
            {
                public const string Name = "Title";
                public const string Description = "Description";
                public const string Thumbar = "Shortcut";
                public const string Category = "Category";
                public const string Content = "Content";
                public const string Activate = "Activate";
                public const string FromDate = "From date";
                public const string ToDate = "To date";
                public const string ShowHomePage = "Show Home Page";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string Description = "Description";
                public const string Thumbar = "Thumb";
                public const string Category = "Category";
                public const string Content = "Content";
                public const string Activate = "Activate";
                public const string FromDate = "FromDate";
                public const string ToDate = "ToDate";
                public const string ShowHomePage = "ShowHomePage";                
            }

            public static class Queries
            {
                public const string getNewbyID = @"<Where>
                                                      <Eq>
                                                         <FieldRef Name='ID' />
                                                         <Value Type='Counter'>{0}</Value>
                                                      </Eq>
                                                   </Where>";

                public const string getNewbyCategory = @"<Where>
                                                          <Eq>
                                                             <FieldRef Name='Category' LookupId='TRUE'/>
                                                             <Value Type='Lookup'>{0}</Value>
                                                          </Eq>
                                                       </Where>
                                                       <OrderBy>
                                                          <FieldRef Name='ID' Ascending='False' />
                                                       </OrderBy>";

                public const string getSomeNew = @"<Where>
                                                      <And>
                                                         <Lt>
                                                            <FieldRef Name='ID' />
                                                            <Value Type='Counter'>{0}</Value>
                                                         </Lt>
                                                         <Eq>
                                                            <FieldRef Name='Category' LookupId='TRUE'/>
                                                            <Value Type='Lookup'>{1}</Value>
                                                         </Eq>
                                                      </And>
                                                   </Where>
                                                   <OrderBy>
                                                      <FieldRef Name='ID' Ascending='False' />
                                                   </OrderBy>";
            }
        }

        public static class MeetingPartners
        {
            public static string ListName = "Đại hội cổ đông";
            public static string ListNameEnglish = "Shareholder meeting";

            public static class DisplayFields
            {
                public const string Name = "Tiêu đề";
                public const string Description = "Mô tả";
                public const string Image = "Ảnh";
                public const string Content = "Nội dung";
                public const string Activate = "Kích hoạt";
            }

            public static class EnglishFields
            {
                public const string Name = "Title";
                public const string Description = "Description";
                public const string Image = "Image";
                public const string Content = "Content";
                public const string Activate = "Activate";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string Description = "Description";
                public const string Image = "Image";
                public const string Content = "Content";
                public const string Activate = "Activate";
                public const string Category = "Category";
                public const string DateCreate = "DateCreate";
            }
        }

        #endregion News

        #region Customer - Partner

        public static class CustomerPartner
        {
            public static string ListName = "Khách hàng - Đối tác";
            public static string ListNameEnglish = "Customer - Partner";

            public static class DisplayFields
            {
                public const string Name = "Tên";
                public const string Website = "Website";
                public const string Image = "Ảnh";
                public const string Order = "STT";
                public const string Description = "Mô tả";
                public const string IsCustomerPartner = "Là khách hàng - đối tác";

                //public const string Tranfer247AccountNumber = "Chuyển tiền nhanh liên ngân hàng 24/7 Qua số tài khoản";
                //public const string Tranfer247CardNumber = "Chuyển tiền nhanh Liên ngân hàng qua số thẻ";
                public const string Activate = "Kích hoạt";

                public const string TransferModel = "Mô hình chuyển";
                public const string ModelAcceptsTheTypeOfCardToAccept = "Mô hình nhận loại thẻ cho phép nhận";
                public const string ProductService = "Sản phẩm dịch vụ";

                public const string Acronym = "Viết tắt";
                public const string FormOfRemittance = "Hình thức chuyển tiền";
                public const string MoneyTransferChannel = "Kênh chuyển tiền";

                public const string TypeCard = "Loại thẻ";
                public const string RegistrationService = "Dịch vụ đăng ký";
                public const string RegistrationMethod = "Cách thức đăng ký";
                public const string AcceptOTP = "Cách thức nhận OTP";
            }

            public static class EnglishFields
            {
                public const string Name = "Name";
                public const string Website = "Website";
                public const string Image = "Image";
                public const string Order = "Order ";
                public const string Description = "Description";
                public const string IsCustomerPartner = "Customer - Partner";

                //public const string Tranfer247AccountNumber = "Transfer money via account number";
                //public const string Tranfer247CardNumber = "transfer money via card number";
                public const string Activate = "Active";

                public const string TransferModel = "Transfer model";
                public const string ModelAcceptsTheTypeOfCardToAccept = "Model accepts the type of card to accept";

                public const string Acronym = "Acronym";
                public const string FormOfRemittance = "Form of remittance";
                public const string MoneyTransferChannel = "Money transfer channel";

                public const string TypeCard = "TypeCard";
                public const string RegistrationService = "Registration service";
                public const string RegistrationMethod = "Registration method";
                public const string AcceptOTP = "Accept OTP";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string Website = "Website";
                public const string Order = "MyOrder";
                public const string Description = "Description";
                public const string IsCustomerPartner = "CustomerPartner";
                public const string Activate = "Activate";
                public const string Image = "Image";
            }
        }

        #endregion Customer - Partner

        #region Production and services

        public static class ProductionServicesGroup
        {
            public static string ListName = "Nhóm sản phẩm dịch vụ";
            public static string ListNameEnglish = "Production and Services Group";

            public static class DisplayFields
            {
                public const string Name = "Tên";
                public const string Order = "STT";
                public const string Description = "Mô tả";
                public const string Activate = "Kích hoạt";
                public const string Image = "Ảnh";
                public const string MenuIcon = "Ảnh top menu";
            }

            public static class EnglishFields
            {
                public const string Name = "Name";
                public const string Order = "Order ";
                public const string Description = "Description";
                public const string Activate = "Active";
                public const string Image = "Image";
                public const string MenuIcon = "Menu Icon";
            }

            public static class InternalFields
            {
                public const string Name = "Name";
                public const string Order = "MyOrder";
                public const string Description = "Description";
                public const string Activate = "Active";
                public const string Image = "Image";
                public const string MenuIcon = "MenuIcon";
            }
        }

        public static class ProductionServices
        {
            public static string ListName = "Sản phẩm dịch vụ";
            public static string ListNameEnglish = "Production and Services";

            public static class DisplayFields
            {
                public const string Name = "Tên dịch vụ";
                public const string ProductsServices = "Nhóm sản phẩm dịch vụ";
                public const string Order = "STT";
                public const string Description = "Mô tả";
                public const string SubService = "Nhóm dịch vụ";
                public const string Activate = "Kích hoạt";

                public const string Content = "Nội dung p1";
                public const string Partner1 = "Danh sách đối tác 1";
                public const string Content1 = "Nội dung p2";
                public const string Partner2 = "Danh sách đối tác 2";
                public const string Content2 = "Nội dung p3";
                public const string Partner3 = "Danh sách đối tác 3";
                public const string Content3 = "Nội dung p4";

                public const string IsShowVenders = "Hiển thị nhà cung cấp";
                public const string Tranformer = "Vận tải - hàng không";
                public const string Retail = "Bán lẻ";
                public const string Communication = "Viễn thông";
                public const string Ensurance = "Bảo hiểm";
                public const string Game = "Game";
                public const string Digital = "Nội dung số";
                public const string ElectronicWallet = "Ví điện tử - tiện ích";
                public const string AnotherServices = "Giải trí - Du lịch - Tiêu dùng - Khác ";

                public const string Content4 = "Nội dung p5";
            }

            public static class EnglishFields
            {
                public const string Name = "Name";
                public const string ProductsServices = "Production and service group";
                public const string Order = "Order ";
                public const string Description = "Description";
                public const string SubService = "Sub Service";
                public const string Activate = "Active";

                public const string Content = "Content 1";
                public const string Partner1 = "Partner 1";
                public const string Content1 = "Content 2";
                public const string Partner2 = "Partner 2";
                public const string Content2 = "Content 3";
                public const string Partner3 = "Partner 3";
                public const string Content3 = "Content 4";

                public const string IsShowVenders = "Show Venders";
                public const string Tranformer = "Tranformer";
                public const string Retail = "Retail";
                public const string Communication = "Communication";
                public const string Ensurance = "Ensurance";
                public const string Game = "Game";
                public const string Digital = "Digital";
                public const string ElectronicWallet = "Electronic Wallet";
                public const string AnotherServices = "Another ";

                public const string Content4 = "Content 5";
            }

            public static class InternalFields
            {
                public const string Name = "Name";
                public const string ProductsServices = "ProductionAndService";
                public const string Order = "MyOrder";
                public const string Description = "Description";
                public const string SubService = "SubService";
                public const string Activate = "Active";

                public const string Content = "PublishingPageContent";
                public const string Partner1 = "Partner1";
                public const string Content1 = "Content1";
                public const string Partner2 = "Partner2";
                public const string Content2 = "Content2";
                public const string Partner3 = "Partner3";
                public const string Content3 = "Content3";

                public const string IsShowVenders = "isShowVenders";
                public const string Tranformer = "Tranformer";
                public const string Retail = "Retail";
                public const string Communication = "Communication";
                public const string Ensurance = "Ensurance";
                public const string Game = "Game";
                public const string Digital = "Digital";
                public const string ElectronicWallet = "ElectronicWallet";
                public const string AnotherServices = "AnotherServices";

                public const string Content4 = "Content4";
            }
        }

        #endregion Production and services

        #region Introduction

        public static class Introduction
        {
            public static string ListName = "Về Napas";
            public static string ListNameEnglish = "Introduction";

            public static class DisplayFields
            {
                public const string Name = "Tiêu đề";
                public const string Description = "Mô tả";
                public const string Order = "STT";
                public const string Content = "Nội dung";
                public const string Activate = "Kích hoạt";
            }

            public static class EnglishFields
            {
                public const string Name = "Title";
                public const string Description = "Description";
                public const string Order = "Order ";
                public const string Content = "Content";
                public const string Activate = "Active";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string Description = "Description";
                public const string Order = "MyOrder";
                public const string Content = "Content";
                public const string Activate = "Active";
            }
        }

        #endregion Introduction

        #region Venders

        public static class VenderService
        {
            public static string ListName = "Nhà cung cấp dịch vụ";
            public static string ListNameEnglish = "Vender service";

            public static class DisplayFields
            {
                public const string Name = "Tên nhà cung cấp";
                public const string DeploymentServices = "Dịch vụ triển khai";
                public const string CustomerCode = "Mã khách hàng";
                public const string FaceValueOfTheChargeCard_PaymentAmount = "Mệnh giá thẻ nạp/số tiền thanh toán";
                public const string InformationNote = "Thông tin lưu ý";
                public const string PartnerWebsite = "Website đơn vị";
                public const string Services = "Dịch vụ cung cấp";
                public const string Image = "Ảnh";
                public const string Activate = "Kích hoạt";
            }

            public static class EnglishFields
            {
                public const string Name = "Title";
                public const string DeploymentServices = "Deployment services";
                public const string CustomerCode = "Customer's code";
                public const string FaceValueOfTheChargeCard_PaymentAmount = "Face value card/payment amount";
                public const string InformationNote = "Information note";
                public const string PartnerWebsite = "Website's partner";
                public const string Services = "Service";
                public const string Image = "Image";
                public const string Activate = "Active";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string DeploymentServices = "DeploymentServices";
                public const string CustomerCode = "CustomerCode";
                public const string FaceValueOfTheChargeCard_PaymentAmount = "FaceValueCard_PaymentAmount";
                public const string InformationNote = "InformationNote";
                public const string PartnerWebsite = "PartnerWebsite";
                public const string Services = "Service";
                public const string Image = "Image";

                public const string Activate = "Active";
            }

            public static class Services
            {
                public const string Transportation = "Vận tải – Hàng không";
                public const string Retail = "Bán lẻ ";
                public const string Telecommunication = "Viễn thông";
                public const string Insurrance = "Bảo hiểm";
                public const string Game = "Game";
                public const string Television = "Nội dung số";
                public const string Finance = "Ví điện tử - Tiện ích";
                public const string InternetADSL = "Giải trí – Du lịch – Tiêu dùng – khác";
            }
        }

        #endregion Venders

        #region Video

        public static class Video
        {
            public static string ListName = "Video";
            public static string ListNameEnglish = "Video";

            public static class DisplayFields
            {
                public const string Name = "Tên";
                public const string Order = "STT";
                public const string Description = "Mô tả";
                public const string Activate = "Kích hoạt";
            }

            public static class EnglishFields
            {
                public const string Name = "Name";
                public const string Order = "Order ";
                public const string Description = "Description";
                public const string Activate = "Active";
            }

            public static class InternalFields
            {
                public const string Name = "Title";

                public const string Order = "OderSort";
                public const string Description = "Description";
                public const string DescriptionEn = "DescriptionEn";
                public const string Activate = "Active";
            }
        }

        #endregion Video

        #region DocumentPartner

        public static class DocumentGroup
        {
            public static string ListName = "Nhóm tài liệu";
            public static string ListNameEnglish = "Document group";

            public static class DisplayFields
            {
                public const string Name = "Tên";
                public const string DocumentType = "Phân loại";
                public const string Order = "STT";
                public const string Description = "Mô tả";
                public const string Activate = "Kích hoạt";
            }

            public static class EnglishFields
            {
                public const string Name = "Group name";
                public const string DocumentType = "Document type";
                public const string Order = "Order ";
                public const string Description = "Description";
                public const string Activate = "Active";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string DocumentType = "DocumentType";
                public const string Order = "MySort";
                public const string Description = "Description";
                public const string Activate = "Active";
            }

            public static class TypeValue
            {
                public static StringCollection valueStringCollection = new StringCollection()
                {
                    "Tài liệu dành cho cổ đông", "Tài liệu văn bản pháp quy", "Tài liệu khác"
                };

                public static StringCollection valueStringCollectionEn = new StringCollection()
                {
                    "Documents for partners", "Legal documents", "Other Documents"
                };
            }
        }

        public static class DocumentLegen
        {
            public static string ListName = "Tài liệu văn bản pháp quy";
            public static string ListNameEnglish = "Legen's documents";
        }

        public static class DocumentOther
        {
            public static string ListName = "Tài liệu khác";
            public static string ListNameEnglish = "Documents other";
        }

        public static class DocumentShareholder
        {
            public static string ListName = "Tài liệu dành cho cổ đông";
            public static string ListNameEnglish = "Partner's documents";

            public static class DisplayFields
            {
                public const string Name = "Tên tài liệu";
                public const string Type = "Phân loại";
                public const string DocumentDate = "Ngày phát hành";

                //public const string Description = "Mô tả";
                public const string Activate = "Kích hoạt";
            }

            public static class EnglishFields
            {
                public const string Name = "Document name";
                public const string Type = "Document type";
                public const string DocumentDate = "Document date";

                // public const string Description = "Description";
                public const string Activate = "Active";
            }

            public static class InternalFields
            {
                public const string Type = "DocumentType";
                public const string DocumentDate = "DocumentDate";

                //public const string Description = "Description";
                //public const string DescriptionEn = "DescriptionEn";
                public const string Activate = "Active";
            }
        }

        #endregion DocumentPartner

        #region organization

        public static class Organization
        {
            public static string ListName = "Cơ cấu tổ chức";
            public static string ListNameEnglish = "Organization";

            public static class DisplayFields
            {
                public const string Name = "Phòng ban";
                public const string Parent = "Trực thuộc";
                public const string Description = "Mô tả";
                public const string Activate = "Kích hoạt";
                public const string Image = "Ảnh";
            }

            public static class EnglishFields
            {
                public const string Name = "Division";
                public const string Parent = "Parent Division ";
                public const string Description = "Description";
                public const string Activate = "Activate";
                public const string Image = "Image";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string Parent = "Parent";
                public const string Description = "Description";
                public const string Activate = "Activate";
                public const string Image = "Image";
            }
        }

        #endregion organization

        #region terms of use

        public static class TermsOfUse
        {
            public static string ListName = "Điều khoản sử dụng";
            public static string ListNameEnglish = "Terms of use";

            public static class DisplayFields
            {
                public const string Name = "Tiêu đề";
                public const string Order = "STT";
                public const string Content = "Nội dung";
                public const string Activate = "Kích hoạt";
            }

            public static class EnglishFields
            {
                public const string Name = "Title";
                public const string Order = "Order ";
                public const string Content = "Content";
                public const string Activate = "Active";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string Order = "MyOrder";
                public const string Content = "Content";
                public const string Activate = "Active";
            }
        }

        #endregion terms of use

        #region Contact

        public static class ContactInfomation
        {
            public static string ListName = "Thông tin liên hệ";
            public static string ListNameEnglish = "Contact infomation";

            public static class DisplayFields
            {
                public const string Name = "Tiêu đề";
                public const string ContactType = "Loại liên hệ";
                public const string Order = "STT";
                public const string Content = "Thông tin liên hệ";
                public const string Activate = "Kích hoạt";
            }

            public static class EnglishFields
            {
                public const string Name = "Title";
                public const string ContactType = "Contact type";
                public const string Order = "Order ";
                public const string Content = "Contact Information";
                public const string Activate = "Active";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string ContactType = "ContactType";
                public const string Order = "MyOrder";
                public const string Content = "PublishingPageContent";
                public const string Activate = "Active";
            }

            public static StringCollection ContactTypeCollection = new StringCollection()
            {
                "Liên hệ tuyển dụng",
                "Liên hệ chung",
                "Liên hệ vận hành",
                "Liên hệ tra soát khiếu nại"
            };
        }

        public static class Contact
        {
            public static string ListName = "Danh sách liên hệ";
            public static string ListNameEnglish = "Contact";

            public static class DisplayFields
            {
                public const string Name = "Họ tên";
                public const string Mobile = "Số điện thoại";
                public const string Email = "Địa chỉ email";
                public const string Subject = "Tiêu đề";
                public const string Content = "Nội dung ý kiến";
                public const string ContactType = "Loại liên hệ";
                public const string Status = "Trang thái";
            }

            public static class EnglishFields
            {
                public const string Name = "Full name";
                public const string Mobile = "Mobile";
                public const string Email = "Email";
                public const string Subject = "Subject";
                public const string Content = "Content";
                public const string ContactType = "Type of contact";
                public const string Status = "Status";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string Mobile = "Mobile";
                public const string Email = "Email";
                public const string Subject = "Subject";
                public const string Content = "Content";
                public const string ContactType = "TypeOfContact";
                public const string Status = "Status";
            }

            public static StringCollection StatusCollection = new StringCollection() { "Đã nhận", "Đã phản hồi", "Spam" };
        }

        #endregion Contact

        #region Recruitment

        public static class ContactInfor
        {
            public static string ListName = "Thông tin liên hệ nhân sự";
            public static string ListNameEnglish = "HR Contact Infor";

            public static class DisplayFields
            {
                public const string Name = "Tiêu đề";
                public const string ContactUsr = "Người liên hệ";
                public const string Phone = "Số điện thoại";
                public const string PhoneExt = "Số nội bộ";
                public const string Email = "Thư điện tử";
                public const string Image = "Ảnh";
                public const string Activate = "Kích hoạt";
            }

            public static class EnglishFields
            {
                public const string Name = "Title";
                public const string ContactUsr = "Contact User";
                public const string Phone = "Phone";
                public const string PhoneExt = "Phone Ext";
                public const string Email = "Email";
                public const string Image = "Image";
                public const string Activate = "Activate";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string ContactUsr = "ContactUsr";
                public const string Phone = "Phone";
                public const string PhoneExt = "PhoneExt";
                public const string Email = "Email";
                public const string Image = "Image";
                public const string Activate = "Activate";
            }
        }

        public static class HumanResource
        {
            public static string ListName = "Chính sách nhân sự";
            public static string ListNameEnglish = "Human Resource";

            public static class DisplayFields
            {
                public const string Name = "Tiêu đề";
                public const string Description = "Mô tả";
                public const string Content = "Nội dung";
                public const string Activate = "Kích hoạt";
                public const string FromDate = "Từ ngày";
                public const string ToDate = "Tới ngày";
                public const string Author = "Người biên soạn";
            }

            public static class EnglishFields
            {
                public const string Name = "Title";
                public const string Description = "Description";
                public const string Content = "Content";
                public const string Activate = "Activate";
                public const string FromDate = "From date";
                public const string ToDate = "To date";
                public const string Author = "Author ";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string Description = "Description";
                public const string Content = "Content";
                public const string Activate = "Activate";
                public const string FromDate = "FromDate";
                public const string ToDate = "ToDate";
                public const string Author = "AuthorPublish";
            }
        }

        public static class ApplicationInformation
        {
            public static string ListName = "Thông tin tuyển dụng";
            public static string ListNameEnglish = "Application Information";

            public static class DisplayFields
            {
                public const string Name = "Tiêu đề";
                public const string Description = "Mô tả";
                public const string Content = "Nội dung";
                public const string Activate = "Kích hoạt";
                public const string FromDate = "Từ ngày";
                public const string ToDate = "Tới ngày";
                public const string Author = "Người biên soạn";
            }

            public static class EnglishFields
            {
                public const string Name = "Title";
                public const string Description = "Description";
                public const string Content = "Content";
                public const string Activate = "Activate";
                public const string FromDate = "From date";
                public const string ToDate = "To date";
                public const string Author = "Author ";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string Description = "Description";
                public const string Content = "Content";
                public const string Activate = "Activate";
                public const string FromDate = "FromDate";
                public const string ToDate = "ToDate";
                public const string Author = "AuthorPublish";
            }
        }

        public static class CareerResult
        {
            public static string ListName = "Kết quả tuyển dụng";
            public static string ListNameEnglish = "Career Result";

            public static class DisplayFields
            {
                public const string Name = "Tiêu đề";
                public const string Description = "Mô tả";
                public const string Content = "Nội dung";
                public const string Activate = "Kích hoạt";
                public const string FromDate = "Từ ngày";
                public const string ToDate = "Tới ngày";
                public const string Author = "Người biên soạn";
            }

            public static class EnglishFields
            {
                public const string Name = "Title";
                public const string Description = "Description";
                public const string Content = "Content";
                public const string Activate = "Activate";
                public const string FromDate = "From date";
                public const string ToDate = "To date";
                public const string Author = "Author ";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string Description = "Description";
                public const string Content = "Content";
                public const string Activate = "Activate";
                public const string FromDate = "FromDate";
                public const string ToDate = "ToDate";
                public const string Author = "AuthorPublish";
            }
        }

        public static class CVDocument
        {
            public static string ListName = "Mẫu thông tin ứng viên";
            public static string ListNameEnglish = "CV Document";

            public static class DisplayFields
            {
                public const string Name = "Tên tài liệu";
                public const string Type = "Phân loại";
                public const string DocumentDate = "Ngày phát hành";
                public const string Description = "Mô tả";
                public const string Activate = "Kích hoạt";
            }

            public static class EnglishFields
            {
                public const string Name = "Document name";
                public const string Type = "Document type";
                public const string DocumentDate = "Document date";
                public const string Description = "Description";
                public const string Activate = "Active";
            }

            public static class InternalFields
            {
                public const string Type = "DocumentType";
                public const string DocumentDate = "DocumentDate";
                public const string Description = "Description";
                public const string Activate = "Active";
            }
        }

        #endregion Recruitment

        #region Setting

        public static class Setting
        {
            public static string ListName = "Cài đặt";
            public static string ListNameEnglish = "Settings";

            public static class DisplayFields
            {
                public const string CompanyName = "Tên công ty";
                public const string CompanyNameEn = "Tên quốc tế";
                public const string Address = "Địa chỉ";
                public const string SubAddress = "Chi nhánh";
                public const string Mobile = "Số điện thoại";
                public const string Hotline = "Hotline";
                public const string Email = "Địa chỉ email";
                public const string Facebook = "Facebook";
                public const string Youtube = "Youtube";
                public const string Twitter = "Twitter";

                public const string Logo = "Logo";
                public const string LogoFooter = "Logo footer";
                public const string BanerAboutUs = "Banner về NAPAS";
                public const string BanerNews = "Banner tin tức";
                public const string BanerProduct = "Banner sản phẩm dịch vụ";
                public const string BanerCustomer = "Banner khách hàng";
                public const string BanerPartner = "Banner cổ đông";
                public const string BanerUserGuide = "Banner hướng dẫn sửa dụng DV";
                public const string BanerDocument = "Banner tài liệu";
                public const string BanerCeare = "Banner tuyển dụng";
                public const string BanerTermCondition = "Banner điều khoản sửa dụng";
                public const string BanerHotline = "Banner hotline";
            }

            public static class EnglishFields
            {
                public const string CompanyName = "Comapny name";
                public const string CompanyNameEn = "Tên công ty";
                public const string Address = "Adress";
                public const string SubAddress = "Adress branch";
                public const string Mobile = "Mobile";
                public const string Hotline = "Hotline";
                public const string Email = "Email";
                public const string Facebook = "Facebook";
                public const string Youtube = "Youtube";
                public const string Twitter = "Twitter";

                public const string Logo = "Logo";
                public const string LogoFooter = "Logo footer";
                public const string BanerAboutUs = "Banner About NAPAS";
                public const string BanerNews = "Banner news";
                public const string BanerProduct = "Banner product service";
                public const string BanerCustomer = "Banner customers";
                public const string BanerPartner = "Banner partners";
                public const string BanerUserGuide = "Banner user guid";
                public const string BanerDocument = "Banner document";
                public const string BanerCeare = "Banner ceare";
                public const string BanerTermCondition = "Banner codition term";
                public const string BanerHotline = "Banner hotline";
            }

            public static class InternalFields
            {
                public const string CompanyName = "ComapnyName";
                public const string CompanyNameEn = "ComapnyNameEn";
                public const string Address = "Adress";
                public const string SubAddress = "AdressBranch";
                public const string Mobile = "Mobile";
                public const string Hotline = "Hotline";
                public const string Email = "Email";
                public const string Facebook = "Facebook";
                public const string Youtube = "Youtube";
                public const string YoutubeChanel = "YoutubeChanel";
                public const string Twitter = "Twitter";

                public const string Logo = "Logo";
                public const string LogoFooter = "LogoFooter";
                public const string BanerAboutUs = "BannerAboutNAPAS";
                public const string BanerNews = "BannerNews";
                public const string BanerProduct = "BannerProductService";
                public const string BanerCustomer = "BannerCustomers";
                public const string BanerPartner = "BannerPartners";
                public const string BanerUserGuide = "BannerUserGuid";
                public const string BanerDocument = "BannerDocument";
                public const string BanerCeare = "BannerCeare";
                public const string BanerTermCondition = "BannerCoditionTerm";
                public const string BanerHotline = "BannerHotline";
                public const string VideoDescription = "VideoDescription";
            }
        }

        public static class Slider
        {
            public static string ListName = "Slider";
            public static string ListNameEnglish = "Slider";

            public static class DisplayFields
            {
                public const string Slogan = "Slogan";
                public const string Description = "Mô tả";
                public const string Banner1366 = "Ảnh 1366";
                public const string Banner1024 = "Ảnh 1024";
                public const string Banner480 = "Ảnh 480";
                public const string LinkToContent = "Url";
                public const string Order = "STT";
                public const string Active = "Kích hoạt";
                public const string Slider = "Slider mẫu";
            }

            public static class EnglishFields
            {
                public const string Slogan = "Slogan";
                public const string Description = "Description";
                public const string Banner1366 = "Image 1366";
                public const string Banner1024 = "Image 1024";
                public const string Banner480 = "Image 480";
                public const string LinkToContent = "Url";
                public const string Order = "Order ";
                public const string Active = "Active";
                public const string Slider = "Slider template";
            }

            public static class InternalFields
            {
                public const string Slogan = "Slogan";
                public const string Description = "Description";
                public const string Banner1366 = "Image1366";
                public const string Banner1024 = "Image1024";
                public const string Banner480 = "Image480";
                public const string LinkToContent = "Url";
                public const string Order = "MyOrder";
                public const string Active = "Active";
                public const string Slider = "Slider";
                public const string FromDate = "FromDate";
                public const string ToDate = "ToDate";
            }
        }

        #endregion Setting

        #region AboutNapas

        public static class OrganizationChart
        {
            public static string ListName = "Sơ đồ tổ chức";
            public static string ListNameEnglish = "Organization Chart";

            public static class DisplayFields
            {
                public const string Name = "Tiêu đề";
                public const string Description = "Mô tả";
                public const string Image = "Ảnh";
                public const string Activate = "Kích hoạt";
            }

            public static class EnglishFields
            {
                public const string Name = "Title";
                public const string Description = "Description";
                public const string Image = "Image";
                public const string Activate = "Activate";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string Description = "Description";
                public const string Image = "Image";
                public const string Activate = "Activate";
            }
        }

        public static class OrganizationBroad
        {
            public static string ListName = "Cơ cấu phòng ban";
            public static string ListNameEnglish = "OrganizationDivision";

            public static class DisplayFields
            {
                public const string Name = "Tiêu đề";
                public const string Division = "Phòng ban";
                public const string PersonName = "Họ và tên";
                public const string Duty = "Chức vụ";
                public const string Level = "Vị trí";
                public const string Order = "So TT";
                public const string History = "Quá trình công tác";
                public const string Image = "Ảnh";
                public const string Activate = "Kích hoạt";
            }

            public static class EnglishFields
            {
                public const string Name = "Title";
                public const string Division = "Division";
                public const string PersonName = "Name";
                public const string Duty = "Duty";
                public const string Level = "Level";
                public const string Order = "Order";
                public const string History = "History";
                public const string Image = "Image";
                public const string Activate = "Activate";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string Division = "Division";
                public const string PersonName = "Name";
                public const string Duty = "Duty";
                public const string Level = "Level";
                public const string Order = "myOrder";
                public const string History = "History";
                public const string Image = "Image";
                public const string Activate = "Activate";
            }

            public static StringCollection GroupColection = new StringCollection() { "1", "2", "3", "4", "5", "6", "7" };
        }

        public static class OrgNameVn
        {
            public static string GeneralAssembly = "Đại hộ cổ đông";
            public static string ExecutiveBoard = "Ban kiểm soát";
            public static string ExecutiveCommittee = "Ban điều hành";
        }

        public static class OrgNameEn
        {
            public static string GeneralAssembly = "Board of Directors";
            public static string ExecutiveBoard = "Supervisory Board";
            public static string ExecutiveCommittee = "Executive Board";
        }

        #endregion AboutNapas

        #region Milestones and achievements

        public static class MilestonesAchievements
        {
            public static string ListName = "Các mốc lịch sử";
            public static string ListNameEnglish = "Milestones and achievements";

            public static class DisplayFields
            {
                public const string Name = "Tiêu đề";
                public const string Year = "Năm";
                public const string Content = "Nội dung";
                public const string Activate = "Kích hoạt";
            }

            public static class EnglishFields
            {
                public const string Name = "Title";
                public const string Year = "Year";
                public const string Content = "Content";
                public const string Activate = "Active";
            }

            public static class InternalFields
            {
                public const string Name = "Title";
                public const string Year = "Year";
                public const string Content = "Content";
                public const string Activate = "Active";
            }
        }

        #endregion Milestones and achievements
    }
}