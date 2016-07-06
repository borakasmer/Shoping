using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shoping.Controllers
{
    public class ShopController : Controller
    {
        // GET: Shop
        public ActionResult Index()
        {
            using (ShopDB dbContext = new ShopDB())
            {
                var model = dbContext.Items.ToList();
                return View(model);
            }
        }
    }
}