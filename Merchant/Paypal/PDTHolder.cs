using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace BlazorStore.Merchant.Paypal
{
    public class PDTHolder
    {
        public double GrossTotal { get; set; }
        public int InvoiceNumber { get; set; }
        public string PaymentStatus { get; set; }
        public string PayerFirstName { get; set; }
        public double PaymentFree { get; set; }
        public string BusinesEmail { get; set; }
        public string PayerEmail { get; set; }
        public string TxToken { get; set; }
        public string PayerLastName { get; set; }
        public string ReceiverEmail { get; set; }
        public string ItemName { get; set; }
        public string Currency { get; set; }
        public string TransactionId { get; set; }
        public string SubscriberId { get; set; }
        public string Custom { get; set; }
        private static string authToken, txToken, query, strResponse;

        public PDTHolder Success(string txt)
        {
            var payPalConfig = Paypal.GetPayPalConfig();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            authToken = payPalConfig.AuthToken;
            txToken = txt;
            query = string.Format($"cmd=_notify-sync&tx={txToken}&at={authToken}");
            var url = payPalConfig.PostUrl;

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = query.Length;

            StreamWriter strOut = new StreamWriter(request.GetRequestStream(), System.Text.Encoding.ASCII);
            strOut.Write(query);
            strOut.Close();

            StreamReader strIn = new StreamReader(request.GetResponse().GetResponseStream());
            strResponse = strIn.ReadToEnd();
            strIn.Close();
            if (strResponse.StartsWith("SUCCESS"))
                return PDTHolder.Parse(strResponse);

            return null;
        }
        /// <summary>
        /// ToDo
        /// </summary>
        /// <param name="postData"></param>
        /// <returns></returns>
        private static PDTHolder Parse(string postData)
        {
            string sKey, sValue;

            var ph = new PDTHolder();
            try
            {
                string[] stringArray = postData.Split('\n');
                int i;
                return ph;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
