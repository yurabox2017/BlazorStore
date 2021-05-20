using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;

namespace BlazorStore.Merchant.Paypal
{
    public class PDTHolder
    {
        public double GrossTotal { get; set; }
        public int InvoiceNumber { get; set; }
        public string PaymentStatus { get; set; }
        public string PayerFirstName { get; set; }
        public double PaymentFee { get; set; }
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

        public static PDTHolder Success(string txt)
        {
            var payPalConfig = Paypal.GetPayPalConfig();
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            authToken = payPalConfig.AuthToken;
            txToken = txt;
            query = string.Format($"cmd=_notify-synch&tx={txToken}&at={authToken}");
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

                for (i = 1; i < stringArray.Length - 1; i++)
                {
                    var array1 = stringArray[i].Split('=');
                    sKey = array1[0];
                    sValue = HttpUtility.UrlDecode(array1[1]);
                    switch (sKey)
                    {
                        case "mc_gross":
                            ph.GrossTotal = double.Parse(sValue, CultureInfo.InvariantCulture);
                            break;
                        case "invoice":
                            ph.InvoiceNumber = Convert.ToInt32(sValue);
                            break;
                        case "payment_status":
                            ph.PaymentStatus = sValue;
                            break;
                        case "first_name":
                            ph.PayerFirstName = sValue;
                            break;
                        case "mc_fee":
                            ph.PaymentFee = double.Parse(sValue, CultureInfo.InvariantCulture);
                            break;
                        case "business":
                            ph.BusinesEmail = sValue;
                            break;
                        case "payer_email":
                            ph.PayerEmail = sValue;
                            break;
                        case "Tx_Token":
                            ph.TxToken = sValue;
                            break;
                        case "last_name":
                            ph.PayerLastName = sValue;
                            break;
                        case "receiver_email":
                            ph.ReceiverEmail = sValue;
                            break;
                        case "item_name":
                            ph.ItemName = sValue;
                            break;
                        case "mc_currency":
                            ph.Currency = sValue;
                            break;
                        case "txn_id":
                            ph.TransactionId = sValue;
                            break;
                        case "custom":
                            ph.Custom = sValue;
                            break;
                        case "subscr_id":
                            ph.SubscriberId = sValue;
                            break;
                    }
                }

                return ph;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
