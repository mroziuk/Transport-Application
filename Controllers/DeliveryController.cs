using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Transport.Repository;

namespace Transport.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Delivery
        public ActionResult Index()
        {
            var model = DeliveryRepository.GetAll();
            //var model = UnitOfWork.context.Customers.ToList();
            return View(model);
        }
        [Route("Delivery/Add")]
        public ActionResult Add()
        {
            var address = UnitOfWork.context.Addresses.FirstOrDefault();
            var customer = UnitOfWork.context.Customers.FirstOrDefault();
            UnitOfWork.context.Deliveries.InsertOnSubmit(new Delivery { Address = address, Customer = customer, CreateTime=DateTime.Now, DeliveryStatus="ordered", PaymentStatus="paid"});
            UnitOfWork.context.SubmitChanges();
            return Content("succesfully added:");
        }
    }
}