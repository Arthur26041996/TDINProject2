using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                App_Code.Service svc = new App_Code.Service();
                int id = svc.BuyBook(collection.Get("book"), collection.Get("clientName"), collection.Get("email"), collection.Get("address"), Int32.Parse(collection.Get("quantity")));

                return RedirectToAction("Details", id);
            }
            catch
            {
                return View();
            }
        }
    }
}
