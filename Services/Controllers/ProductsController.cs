using DAL;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Services.Controllers
{
    public class ProductsController : ApiController
    {
        // GET: api/Products
        public List<DAL.Models.Items> Get()
        {
            using (ShopDB dbContext = new ShopDB())
            {
                var model = dbContext.Items.ToList();
                return model;
            }
        }

        // GET: api/Products/5
        public DAL.Models.Items Get(int id)
        {
            using (ShopDB dbContext = new ShopDB())
            {
                var model = dbContext.Items.FirstOrDefault(itm => itm.id == id);
                return model;
            }
        }

        [HttpPost]
        // POST: api/Products
        public void Post(List<DAL.Models.Shop> shopList)
        {            
            using (ShopDB dbContext = new ShopDB())
            {
                foreach (DAL.Models.Shop _shop in shopList)
                {
                    dbContext.Shop.Add(_shop);
                }
                dbContext.SaveChanges();
            }
        }
    }
}
