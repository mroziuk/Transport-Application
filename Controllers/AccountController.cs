using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Transport.Repository;
using Transport.ViewModels;
using Transport.Models;
using System.Security.Claims;
using System.IdentityModel.Services;

namespace Transport.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Register()
        {
            Register model = new Register();
            return View(model);
        }
        [HttpPost]
        public ActionResult SaveRegisterDetails(Register registerDetails)
        {
            if(ModelState.IsValid)
            {
                Customer customer = new Customer
                {
                    FirstName = registerDetails.FirstName,
                    LastName = registerDetails.LastName,
                    Email = registerDetails.Email,
                    Password = registerDetails.Password,
                    Role = "user"
                };
                if(!ValidateNewCustomer(customer))
                {
                    return Content("email already used");
                }
                //TODO: add validation
                UnitOfWork.context.Customers.InsertOnSubmit(customer);
                UnitOfWork.context.SubmitChanges();

                ViewBag.Message = "User Details Saved";
                return View("Register", new Register());
            }
            else
            {
                return View("Register", registerDetails);
            }
        }
        private bool ValidateNewCustomer(Customer customer)
        {
            return
                !string.IsNullOrEmpty(customer.FirstName) &&
                !string.IsNullOrEmpty(customer.LastName) &&
                !string.IsNullOrEmpty(customer.Email) &&
                !string.IsNullOrEmpty(customer.Password) &&
                UnitOfWork.context.Customers.First(c => c.Email == customer.Email) == null;
        }
        public ActionResult Login()
        {
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                var returnUrl = this.ControllerContext.HttpContext.Request.QueryString["ReturnUrl"];
                //var isValidUser = IsValidUser(model);
                var isValidUser = Membership.ValidateUser(model.Email, model.Password);
                if(isValidUser)
                {
                    FormsAuthentication.SetAuthCookie(model.Email, false);
                    if(string.IsNullOrEmpty(returnUrl))
                        return RedirectToAction("Index", "Home");
                    return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("Failure", "Wrong Username and password!");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        public Customer IsValidUser(LoginViewModel model)
        {
            var user = UnitOfWork.context.Customers.Where(x => x.Email.Equals(model.Email) && x.Password.Equals(model.Password)).FirstOrDefault();
            return user;
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }
    }

    

}