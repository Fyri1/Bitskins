using System;
using System.Collections.Generic;

using Leaf.xNet;
using Newtonsoft.Json;
using Bitskins.blyad;
using System.Threading;
using OtpNet;
using System.Globalization;

namespace Bitskins
{
    class BitApi
    {
        private string _apiKey;

        
        public BitApi(string apiKey) //
        {
            _apiKey = apiKey;
        }
        private const string _apiUrl = "https://bitskins.com/"; //пацанский сайт

        public List<Item> GetItems(int minPrise, int maxPrise)
        {
            
                using (var request = new HttpRequest())
                {

                    request.AddHeader("Authorization", _apiKey);
                    request.AddHeader("Content-type", "application/json");

                    var otpKeyBytes = Base32Encoding.ToBytes("OEFXH53L4HECOPC3");
                    var totp = new Totp(otpKeyBytes);
                    var twoFactorCode = totp.ComputeTotp();
                    int res = Convert.ToInt32(twoFactorCode);

                    var responseStr = request.Post(_apiUrl + "api/v1/get_inventory_on_sale/?api_key=ff275896-465a-4be6-a895-4f94836bf895&min_price=" + minPrise + "&max_price=" + maxPrise + "&code=" + res + "&per_page=24&app_id=730").ToString();


                    Data response = JsonConvert.DeserializeObject<Data>(responseStr);

                    return response.GetItrmsResponse.Items;


                }
          

        }


        // заменить ссыль 
        public List<Item> Buy( string Ids, float price)
        {
            using (var request = new HttpRequest())
            {
                request.AddHeader("Token", _apiKey);
                request.AddHeader("Content-type", "application/json");
                var IdsSrt = JsonConvert.SerializeObject(Ids);
               

                var otpKeyBytes = Base32Encoding.ToBytes("OEFXH53L4HECOPC3");
                var totp = new Totp(otpKeyBytes);
                var twoFactorCode = totp.ComputeTotp();
                int res = Convert.ToInt32(twoFactorCode);

                var responsetr = "api/v1/buy_item?api_key=ff275896-465a-4be6-a895-4f94836bf895&allow_trade_delayed_purchases=true&code=" + res + "&item_ids=" + Ids + "&prices=" + price.ToString(CultureInfo.InvariantCulture);
                
                    var responseStr = request.Post(_apiUrl + responsetr).ToString();
             

                //var response = JsonConvert.DeserializeObject<GetItemsResponse>(responseStr);
                return null;

            }

        }
    }
}
