using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SBContactManager.Models
{
    public class Contact
    {
        //EF Core will configure the Database to generate the value below.
        public int ContactId { get; set; }
        [Required(ErrorMessage ="Please enter your first name.")] //Making the field required.
        //Property to store the first name.
        public string FirstName { get; set; } 
        [Required(ErrorMessage ="Please enter your last name.")] //Making the field required.
        //Property to store the last name.
        public string LastName { get; set; }
        [Required(ErrorMessage ="Please enter a phone number.")] //Making the field required.
        //Property to store a Phone number and validating if it's an long/large number.
        public long? Phone { get; set; }
        [Required(ErrorMessage ="Please enter an email address.")] //Making the field required.
        //Property to store an email address.
        public string Email { get; set; }

        //Adding Category property to the Contact Class. Making the property name required.
        [Required(ErrorMessage = "Please enter a Category.")]
        public Category Category { get; set; }
        //Specifying a foreign key property when adding a Category property. The foreign key here indicates the property thats the primary key in the related class.
        public string CategoryId { get; set; }

        //Read only property named Slug
        public string Slug =>
            FirstName?.Replace(' ', '-').ToLower() + '-' + Phone?.ToString();
    }
}
