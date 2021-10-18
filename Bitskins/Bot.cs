using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Bitskins.blyad;

namespace Bitskins
{
    class Bot
    {
        private BitApi _swapApi;
        private SteamApisBase _steamApi;

        public List<Item> kokon = new List<Item>();

        public Bot(string apiKeySwap, string apiKeySteam)
        {

            _steamApi = new SteamApisBase(apiKeySteam);
            _swapApi = new BitApi(apiKeySwap);
            _steamApi.Start(TimeSpan.FromSeconds(200));



        }



        public void Start(int minPrice, int maxPrice, int margin, int timeout )
        {


            Task.Run(() =>
            {
                while (true)
                {
                    var items = _swapApi.GetItems(minPrice, maxPrice);
                    foreach (var item in items)
                    {
                        var swapPrice = (int)((item.prise * 100));


                        if (!_steamApi.Items.ContainsKey(item.Name))
                        {
                            continue;
                        }
                        if (_steamApi.Items[item.Name].Prices.UnstableReason == SteamApisItem.UnstableReason.LowSales3months || _steamApi.Items[item.Name].Prices.UnstableReason == SteamApisItem.UnstableReason.NoSales3months)
                            continue;
                        var steamPrice = (int)(_steamApi.Items[item.Name].Prices.Safe * 100);
                        kokon.Add(item);
                        if (steamPrice == 0)
                            continue;
                        if (swapPrice == 0)
                            continue;

                        var marginItem = (1.0 - ((double)swapPrice / (double)steamPrice)) * 100.0; // пиздует расчет маржи 


                        if (marginItem >= margin)
                        {

                            _swapApi.Buy(item.id, item.prise);
                            item.marginItem = marginItem;

                        }
                        Thread.Sleep(timeout);


                    }

                }
            });
        }
    }
}
