using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Security;
using Transport.Repository;
using Transport.ViewModels;

namespace Transport.Controllers
{
    public class DeliveryController : Controller
    {
        // GET: Delivery
        [Authorize(Roles ="admin,user")]
        public ActionResult Index()
        {
            List<Delivery> model;
            if(Roles.IsUserInRole("admin"))
            {
                model = DeliveryRepository.GetAll();
                return View("ForAdmin", model);
            }
            model = DeliveryRepository.GetByName(User.Identity.Name);
            return View(model);
        }

        [Authorize(Roles = "admin,user")]
        public ActionResult Add()
        {
            var model = new AddDeliveryViewModel();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "admin, user")]
        public ActionResult Add(AddDeliveryViewModel model)
        {
            //if customer Id == null -> its user
            if(Roles.IsUserInRole("user"))
            {
                model.CustomerId = UnitOfWork.context.Customers.First(c => c.Email.Equals(User.Identity.Name)).Id;
            }

            var addressFrom = UnitOfWork.context.Addresses.Where(a => a.Id == model.AddressFromId).FirstOrDefault();
            if(addressFrom == null) return Content("address dont exist");
            var addressTo = UnitOfWork.context.Addresses.Where(a => a.Id == model.AddressToId).FirstOrDefault();
            if(addressTo == null) return Content("address dont exist");
            var customer = UnitOfWork.context.Customers.Where(c => c.Id == model.CustomerId).FirstOrDefault();
            if(customer == null) return Content("customer dont exist");

            var deliveryStatus = string.IsNullOrEmpty(model.DeliveryStatus) ? "ordered" : model.DeliveryStatus;
            var paymentStatus = string.IsNullOrEmpty(model.PaymentStatus) ? "not paid" : model.PaymentStatus;

            UnitOfWork.context.Deliveries.InsertOnSubmit(
                new Delivery {
                    AddressFromId = model.AddressFromId,
                    AddressToId = model.AddressToId,
                    CustomerId = model.CustomerId,
                    CreateTime=DateTime.Now,
                    DeliveryStatus=deliveryStatus,
                    PaymentStatus=paymentStatus
                });
            UnitOfWork.context.SubmitChanges();

            return Content("success");
        }
        [Route("Delivery/Delete/{id}")]
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int id)
        {
            var item = UnitOfWork.context.Deliveries.FirstOrDefault(d => d.Id ==id);
            if(item == null) return Content("nie ma takiego elementu");
            UnitOfWork.context.Deliveries.DeleteOnSubmit(item);
            UnitOfWork.context.SubmitChanges();
            return RedirectToAction("Index");
        }
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int id)
        {
            var item = UnitOfWork.context.Deliveries.First(d => d.Id == id);
            var model = new EditDeliveryViewModel()
            {
                Id = item.Id,
                NewAddressFromId = item.AddressFromId,
                NewAddressToId = item.AddressToId,
                NewCustomerId = item.CustomerId,
                NewDeliveryStatus = item.DeliveryStatus,
                NewPaymentStatus = item.PaymentStatus
            };
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "admin")]
        public ActionResult Edit(EditDeliveryViewModel model)
        {
            // check if not null
            //int addressId = (model.NewAddressId == null || model.NewAddressId == 0) ? model.AddressId : (int)model.NewAddressId;
            //int customerId = (model.NewCustomerId == null || model.NewCustomerId == 0) ? model.CustomerId : (int)model.NewCustomerId;
            //var deliveryStatus = string.IsNullOrEmpty(model.NewDeliveryStatus) ? model.DeliveryStatus : model.NewDeliveryStatus;
            //var paymentStatus = string.IsNullOrEmpty(model.NewPaymentStatus) ? model.PaymentStatus : model.NewPaymentStatus;

            //var address = UnitOfWork.context.Addresses.Where(a => a.Id == addressId).FirstOrDefault();
            //if(address == null) return Content("address dont exist");
            //var customer = UnitOfWork.context.Customers.Where(c => c.Id == customerId).FirstOrDefault();
            //if(customer == null) return Content("customer dont exist");
            var oldItem = UnitOfWork.context.Deliveries.FirstOrDefault(d => d.Id == model.Id);
            var newItem = new Delivery()
            {
                Id = model.Id,
                AddressFromId = model.NewAddressFromId == null || model.NewAddressFromId == 0 ? oldItem.AddressFromId : (int)model.NewAddressFromId,
                AddressToId = model.NewAddressToId == null || model.NewAddressToId == 0 ? oldItem.AddressToId : (int)model.NewAddressToId,
                CustomerId = model.NewCustomerId == null || model.NewCustomerId == 0 ? oldItem.CustomerId : (int)model.NewCustomerId,
                DeliveryStatus = string.IsNullOrEmpty(model.NewDeliveryStatus) ? oldItem.DeliveryStatus : model.NewDeliveryStatus,
                PaymentStatus = string.IsNullOrEmpty(model.NewPaymentStatus) ? oldItem.PaymentStatus : model.NewPaymentStatus,
                CreateTime = DateTime.Now
            };
            var addressFrom = UnitOfWork.context.Addresses.Where(a => a.Id == newItem.AddressFromId).FirstOrDefault();
            var addressTo = UnitOfWork.context.Addresses.Where(a => a.Id == newItem.AddressToId).FirstOrDefault();
            if(addressFrom == null) return Content("address dont exist");
            if(addressTo == null) return Content("address dont exist");
            var customer = UnitOfWork.context.Customers.Where(c => c.Id == newItem.CustomerId).FirstOrDefault();
            if(customer == null) return Content("customer dont exist");

            UnitOfWork.context.Deliveries.DeleteOnSubmit(oldItem);
            UnitOfWork.context.Deliveries.InsertOnSubmit(newItem);
            UnitOfWork.context.SubmitChanges();
            return RedirectToAction("Index");
        }
        [Route("Delivery/ForAdmin")]
        public ActionResult ForAdmin()
        {
            var model = DeliveryRepository.GetAll();
            return View(model);
        }
    }
}