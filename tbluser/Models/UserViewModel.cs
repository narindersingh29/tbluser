using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace tbluser.Models
{
    public class UserViewModel
    {
        public int ID { get; set; }
       // [Display("First Name")]
        public string? FirstName { get; set; }
        //[Display("Last Name")]
        public string? LastName { get; set; }
       // [Display("Address")]
        public string? Address { get; set; }
       // [Display("Phone Number")]
        public string? PhoneNumber { get; set; }
      //  [Display("Email")]
        public string? EMail { get; set; }
       // [Display("Password")]
        public string? Password { get; set; }
    }
}
