using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SBContactManager.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SBContactManager.Controllers
{
    public class HomeController : Controller
    {
        //Private property context of the ContactContext type.
        private ContactContext context { get; set; }

        //Constructor of the HomeController.cs class to accept ContactContext objects and assign it to the context property.
        //This way other methods in this class can access the ContactContext object.
        //The constructor works because of the dependency injection code in the Startup.cs file.
        public HomeController(ContactContext ctx)
        {
            //Link on a homepage
            context = ctx;

        }


        /// <summary>
        /// the Index() action method uses the context property above to get a collection of Contact objects from the database.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            //Sorting the objects alphabetically by contact first name.
            //Using Include() method to add the related entiry according to the logic of the => expression.
            var contacts = context.Contacts
                            .Include(c => c.Category)
                            .OrderBy(c => c.FirstName).ToList();
            return View(contacts);
        }

    }
}
