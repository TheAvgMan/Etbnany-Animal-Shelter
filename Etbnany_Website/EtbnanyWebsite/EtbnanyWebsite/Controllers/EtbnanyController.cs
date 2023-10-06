using EtbnanyWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace EtbnanyWebsite.Controllers
{
    public class EtbnanyController : Controller
    {

        private EtbananyDBContext context = new EtbananyDBContext();
        private static User currentUser;


        [ActionName("SignIn")]
        [HttpGet]
        public ActionResult SignIn_get()
        {
            return View();
        }

        [ActionName("SignIn")]
        [HttpPost]
        public ActionResult SignIn_post(string email, string password)
        {
            var result = (from user in context.Users
                         where user.email == email && user.password == password
                         select user).ToList();

            if (result.Count == 0)
            {
                return RedirectToAction("SignIn");
            }

            currentUser = result[0];

            return RedirectToAction("home");
        }


        [ActionName("SignUp")]
        [HttpGet]
        public ActionResult SignUp_get()
        {
            return View();
        }

        [ActionName("SignUp")]
        [HttpPost]
        public ActionResult SignUp_post(string firstName, string lastName, string email, string password, string phone)
        {

            var result = (from user in context.Users
                          where user.email == email
                          select user).ToList();

            if (result.Count != 0)
            {
                return RedirectToAction("SignIn");
            }

            var newUser = new Models.User
            {
                firstName = firstName,
                lastName = lastName,
                email = email,
                password = password,
                phone = phone
            };

            context.Users.Add(newUser);
            context.SaveChanges();

            currentUser = newUser;

            return RedirectToAction("home");
        }


        public ActionResult Home()
        {
            return View(currentUser);
        }

        public ActionResult AboutUs()
        {
            return View(currentUser);
        }

        [ActionName("Adoption")]
        [HttpGet]
        public ActionResult Adoption_get()
        {

            /*retrieve all unadopted pets from pets table */
            var allPets = (from pet in context.Pets
                           where pet.isAdopted == false
                           select pet).ToList();

            ViewBag.allPets = allPets;

            return View(currentUser);
        }

        [ActionName("Adoption")]
        [HttpPost]
        public ActionResult Adoption_post(string message, int Id)
        {
            /*new adoption created*/
            var newAdoption = new Models.Adoption
            {
                PetId = Id,
                UserId = currentUser.Id,
                message = message
            };

            context.Adoptions.Add(newAdoption);

            /*updating adoption status of pet*/
            var pet = context.Pets.Find(Id);
            pet.isAdopted = true;

            
            context.SaveChanges();

            return RedirectToAction("home");
        }


        [ActionName("Donation")]
        [HttpGet]
        public ActionResult Donation_get()
        {
            /*retrieve all products from pets table */
            var allProducts = (from product in context.Products
                               where product.stock > 0
                               select product).ToList();

            ViewBag.allProducts = allProducts;

            return View(currentUser);
        }

        [ActionName("Donation")]
        [HttpPost]
        public ActionResult Donation_post(int Id, int quantity)
        {
            var product = context.Products.Find(Id);
            if (product.stock < quantity)
            {
                return RedirectToAction("Donation");
            }


            /*updating donated quantity of product from user*/
            var donation = context.Donations.Find(Id, currentUser.Id);
            if (donation != null) donation.quantity += quantity;

            else
            {
                /*new adoption created*/
                var newDonation = new Models.Donation
                {
                    ProductId = Id,
                    UserId = currentUser.Id,
                    quantity = quantity
                };

                context.Donations.Add(newDonation);
            }


            /*updating stock level of product*/
            product.stock -= quantity;

            context.SaveChanges();

            return RedirectToAction("home");
        }

        [ActionName("ContactUs")]
        [HttpGet]
        public ActionResult ContactUs_get()
        {
            return View(currentUser);
        }

        [ActionName("ContactUs")]
        [HttpPost]
        public ActionResult ContactUs_post(string message)
        {
            /*new adoption created*/
            var newEnquiry = new Models.Enquiry
            {
                UserId = currentUser.Id,
                message = message
            };

            context.Enquiries.Add(newEnquiry);
            context.SaveChanges();

            return RedirectToAction("home");
        }

        public ActionResult Profile()
        {
            // list of my adoptions
            if (context.Adoptions.Any())
            {
                /*retrieve my pets from pets table */
                var myPets = (
                              from pet in context.Pets
                              join adoption in context.Adoptions
                              on pet.Id equals adoption.PetId
                              select new MyPets
                              {
                                  name = pet.name,
                                  type = pet.type,
                                  age = pet.age,
                                  gender= pet.gender,
                                  image = pet.image
                              }).ToList();

                ViewBag.myPets = myPets;
            }
            else
            {
                ViewBag.myPets = null;
            }


            // list of my donations
            if (context.Donations.Any())
            {
                /*retrieve my products from products table */
                var myProducts = (
                              from product in context.Products
                              join donation in context.Donations
                              on product.Id equals donation.ProductId
                              select new MyProducts
                              {
                                  name = product.name,
                                  total = product.price * donation.quantity,
                                  image = product.image,
                                  quantity = donation.quantity
                              }).ToList();

                ViewBag.myProducts = myProducts;
            }
            else
            {
                ViewBag.myProducts = null;
            }

            return View(currentUser);
        }


    }
}