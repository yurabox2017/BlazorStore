using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorStore.Merchant.Paypal
{
    public class Paypal
    {
        public static PayPalConfig GetPayPalConfig()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                                                    .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            return new PayPalConfig()
            {
                AuthToken = configuration["PayPal:AuthToken"],
                PostUrl = configuration["PayPal:PostUrl"],
                Business = configuration["PayPal:Business"],
                ReturnUrl = configuration["PayPal:ReturnUrl"]
            };
        }
    }
}
