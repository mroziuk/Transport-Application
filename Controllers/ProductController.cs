using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transport.Repository;

namespace Transport.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult GridDefault()
        {
            var model = ProductRepository.GetAll();
            return View(model);
        }
    }
}