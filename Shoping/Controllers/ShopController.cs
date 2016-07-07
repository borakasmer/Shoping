using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Shoping.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public async Task<ActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                var response = await client.GetAsync("http://localhost:15242/api/products");
                if (response.IsSuccessStatusCode)
                {
                    var model = JsonConvert.DeserializeObject<List<DAL.Models.Items>>(response.Content.ReadAsStringAsync().Result);
                    return View(model);
                }
                return View(new DAL.Models.Items());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken()]
        public async Task Buy(FormCollection collection)
        {
            if (collection.Count > 1)
            {
                List<DAL.Models.Shop> shopList = new List<DAL.Models.Shop>();
                using (HttpClient client = new HttpClient())
                {
                    for (int i = 1; i < collection.Count; i++)
                    {
                        DAL.Models.Shop _shop = new DAL.Models.Shop();
                        _shop.itemID = int.Parse(collection[i].ToString());
                        _shop.UserID = 1;
                        _shop.CreatedDateTime = DateTime.Now;
                        shopList.Add(_shop);
                    }
                    var model = JsonConvert.SerializeObject(shopList);
                    HttpContent content = new StringContent(model, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync("http://localhost:15242/api/products", content);
                }
            }
        }
    }
}