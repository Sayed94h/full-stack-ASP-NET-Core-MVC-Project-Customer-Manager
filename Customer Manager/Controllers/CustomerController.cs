using Customer_Manager.Data;
using Customer_Manager.Data.DataModels;
using Customer_Manager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;

namespace Customer_Manager.Controllers
{
    public class CustomerController : Controller
    {

        private AppDbContext _context;
        public CustomerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: CustomerController/ViewCustomerProfile/5
        public ActionResult ViewCustomerProfile(int id)
        {
            CustomerModel customer = _context.Customers.Where(e => e.ID == id).FirstOrDefault();
            CustomerViewModel viewModel = new CustomerViewModel();

            if (customer != null)
            {
                viewModel.Name = customer.Name;
                viewModel.Email = customer.Email;
                viewModel.Phone = customer.Phone;
                viewModel.Address = customer.Address;
                viewModel.Birthday = customer.Birthday;
                viewModel.JobTitle = customer.JobTitle;
                viewModel.ID = customer.ID;
                viewModel.CreatedDate = customer.CreatedDate;
                viewModel.IsAdmin = customer.IsAdmin;
                viewModel.IsActive = customer.IsActive;
            }
            else
            {
                viewModel = new CustomerViewModel()
                {
                    Name = "Tom Cruise",
                    Email = "tom.cruise@cruise.com",
                    Phone = "+1 345 786 547",
                    Address = "NYC, US",
                    CreatedDate = DateTime.Now,
                    IsActive = true,
                    IsAdmin = false,
                    Birthday = new DateTime(1975, 05, 29, 00, 30, 45),
                    ID = id,
                    JobTitle = "Actor"

                };
            }


            return View(viewModel);
        }

        public ActionResult NewCustomer()
        {
            return View();
        }

        // POST: CustomerController/NewCustomer
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewCustomer(CustomerModel newCustomer)
        {
            try
            {
                // access the database
                CustomerModel customer = new CustomerModel();
                customer = newCustomer;

                _context.Customers.Add(customer);
                _context.SaveChanges();

                return Redirect("/");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // GET: CustomerController/UpdateCustomer/5
        public ActionResult UpdateCustomer(int id)
        {
            CustomerModel customer = _context.Customers.FirstOrDefault(x => x.ID == id);
            return View(customer);
        }

        // POST: CustomerController/UpdateCustomer/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateCustomer(CustomerModel customer)
        {
            try
            {
                CustomerModel customerToUpdate = _context.Customers.FirstOrDefault(e => e.ID == customer.ID);
                if (customerToUpdate != null)
                {


                    if (customerToUpdate.Name != customer.Name)
                    {
                        customerToUpdate.Name = customer.Name;
                    }

                    if (customerToUpdate.Email != customer.Email)
                    {
                        customerToUpdate.Email = customer.Email;
                    }

                    if (customerToUpdate.Address != customer.Address)
                    {
                        customerToUpdate.Address = customer.Address;
                    }

                    if (customerToUpdate.Phone != customer.Phone)
                    {
                        customerToUpdate.Phone = customer.Phone;
                    }

                    if (customerToUpdate.JobTitle != customer.JobTitle)
                    {
                        customerToUpdate.JobTitle = customer.JobTitle;
                    }

                    if (customerToUpdate.Password != customer.Password)
                    {
                        customerToUpdate.Password = customer.Password;
                    }

                    if (customerToUpdate.IsActive != customer.IsActive)
                    {
                        customerToUpdate.IsActive = customer.IsActive;
                    }

                    if (customerToUpdate.Birthday != customer.Birthday)
                    {
                        customerToUpdate.Birthday = customer.Birthday;
                    }

                    if (customerToUpdate.IsAdmin != customer.IsAdmin)
                    {
                        customerToUpdate.IsAdmin = customer.IsAdmin;
                    }

                    customerToUpdate.ModifiedDate = DateTime.Now;

                    _context.SaveChanges();
                }

                return Redirect("/");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
        }

        // https://learn.microsoft.com/en-us/aspnet/core/security/anti-request-forgery?view=aspnetcore-7.0
        // POST: CustomerController/Delete/5
        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {

            try
            {
                CustomerModel customer = _context.Customers.FirstOrDefault(x => x.ID == id);
                if (customer != null)
                {
                    //_context.Customers.Remove(customer);
                    customer.IsDeleted = true;
                    customer.IsActive = false;
                    _context.SaveChanges();
                }

                RequestMsg requestMsg = new RequestMsg();
                requestMsg.Message = "Deleted Successfully";

                return Json(requestMsg);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                RequestMsg requestMsg = new RequestMsg();
                requestMsg.Message = "Could not delete the item.";
                return Json(requestMsg);
            }
        }
    }
}
