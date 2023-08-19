using System;

namespace Product.Api.ViewModels
{
    public class AuthViewModel
    {
        public class GetTokenOutput
        {
            public string RefreshToken { get; set; }
            public string AccessToken { get; set; }
            public DateTime ExpireDate { get; set; }
        }
    }
}