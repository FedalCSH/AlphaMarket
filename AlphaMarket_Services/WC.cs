using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace AlphaMarket_Services
{
    public static class WC
    {
        private const string imagePath = @"/images/product/";
        public static string ImagePath => imagePath;
        public const string SessionCart = "ShoppingCartSession";
        public const string SessionInquiryId = "InquirySession";
        public const string AdminRole = "Admin";
        public const string CustomerRole = "Customer";
        public static string EmailAdmin = "userrootovich@yahoo.com";
        public static string CategoryName = "CategoryName";
        public static string ApplicationTypeName = "ApplicationTypeName";
        public static string Success = "Success";
        public static string Error = "Error";
    }
}
