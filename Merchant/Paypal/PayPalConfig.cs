﻿namespace BlazorStore.Merchant.Paypal
{
    public class PayPalConfig
    {
        public string AuthToken { get; set; }
        public string PostUrl { get; set; }
        public string Business { get; set; }
        public string ReturnUrl { get; set; }
    }
}