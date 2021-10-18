using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using System.Globalization;


namespace Bitskins.blyad
{


    class Data
    {
        [JsonProperty("data")] //айди паца 
       
        public GetItrmsResponse GetItrmsResponse;
    }


    class GetItrmsResponse
    {

        [JsonProperty("items")]
          public List<Item> Items;
    }

    class Item
    {
        [JsonProperty("item_id")] //айди паца 
        public string id;

        [JsonProperty("market_hash_name")]// ищим атребут с названием САМОГО ТОВАРА 
        public string Name;

        [JsonProperty("price")] //цену хуену 
        public float prise;

        public double marginItem;

    }
}
