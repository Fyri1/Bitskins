using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bitskins.blyad;

namespace Bitskins
{
    static class Program
    {

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            var array = new string[] { "miyaga" };
            var t = @"{""saleId"":[""ANlJqpYL"","",""]}";

            var deser = JsonConvert.SerializeObject(array);
            var api = new BitApi("ff275896-465a-4be6-a895-4f94836bf895"); // код с сайта
            var items = api.GetItems(120, 500);
           // api.Buy("EHdBG-Rzab");
        }
    }
}
