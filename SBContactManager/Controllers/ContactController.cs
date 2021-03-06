    using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SBContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBContactManager.Controllers
{
    public class ContactController : Controller
    {
        //Private property context of the ContactContext type.
        private ContactContext context { get; set; }

        //Constructor of the ContactController.cs class to accept ContactContext objects and assign it to the context property.
        //This way other methods in this class can access the ContactContext object.
        //The constructor works because of the dependency injection code in the Startup.cs file.

        public ContactController(ContactContext ctx)
        {
            context = ctx;
        }

        /// <summary>
        /// Detail() is an action method that uses a parameter named id to get the Contact object that corresponds to the id from the database.
        /// Database here is a list of contacts in the context
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Detail(int id)
        {
            //id are the unique identifiers.
            //id is only going to be returned once.
            //If the user enters the same id the value will be auto set to default value of null.
            //Passing the list of Contact object to the View for a display.
            var contact = context.Contacts
                .Include(c => c.Category)   
                .FirstOrDefault(c => c.CategoryId == id); 
            return View(contact);
        }

        //NOTE: The ContactController has 3 action methods. Add(), Edit() and Delete()
        //Edit() and Delete() actions have overloads that handle both the GET and POST requests.
        //Add() action only handles GET requests as Add and Edit action methods both use Contacts/Edit View path.

        //GET request, here both the Edit and Add action sets a ViewBag property Action and Pass the Contact object to the view.
        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";

            //Code to display relative data to the Add and Edit Pages.
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();

            //Pass the Contact object to the view. 
            //To be able to use the same view as Edit option both the Edit() and Add() actions passes Edit as the first argument to the view.
            //Hence, add action displays same view as Edit Action.
            return View("Edit", new Contact());
        }

        //GET request, here both the Edit and Add action sets a ViewBag property Action and Pass the Contact object to the view. 
        [HttpGet]
        public IActionResult Edit( int id)
        {
            ViewBag.Action = "Edit";

            //Code to display relative data to the Add and Edit Pages.
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            var contact = context.Contacts
                          .Include(c => c.Category)  
                          .FirstOrDefault(c => c.CategoryId == id); 
            //Pass the Contact object to the view.
            //To be able to use the same view as Edit option both the Edit() and Add() actions passes Edit as the first argument to the view. 
            return View("Edit", new Contact());

        }

        //Code to check the value of the ContactId property of the Contact object it receives from the view. 
        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            //If the value is 0, it is a new Contact.
            string action = (contact.ContactId == 0) ? "Add" : "Edit";
            if (ModelState.IsValid)
            {
                if (action == "Add") {
                    //Middleware to add datetime by the database.
                    contact.DateAdded = DateTime.Now;
                    //If the contact is new the code below passes the value to the Add() method of the Contact property.
                    context.Contacts.Add(contact);
                }
                else //If the action is Edit then, 
                {
                    //If the contact is existing one then the code rejects the user back to the Index() action method of the
                    //HomeController.cs class to display the Home View.
                    context.Contacts.Update(contact);
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            //If the Client does not enter a valid data for the model, below is the code to reset the Action property of the viewBag to Add or Edit.
            else
            {
                ViewBag.Action = action;

                //Code to display relative data to the Add and Edit Pages.
                ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();

                //Sending data user entered back to the client for a display.
                return View(contact);
            }
        }

        //Delete() action. This is for the GET request to receive the Contact object from the contact database using Id parameter.
        //The action below is possible becauseof the Delete lik in the Home/Index view species a value for the id argument.
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.Contacts
                            .Include(c => c.Category)
                            .FirstOrDefault(c => c.CategoryId == id);
            //receive the Contact object from the contact database using Id parameter and passing to view for a display.
            return View(contact);
        }

        //Delete() POST action. This action oasses the Contact object it receives from the view above to the Remove() method of the Contacts property.
        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            //Receives from the view above to the Remove() method of the Contacts property.
            context.Contacts.Remove(contact);
            //Save changes after removal request.
            context.SaveChanges();
            //Return user back to the Index() page.
            return RedirectToAction("Index", "Home");
        }
    }
}
