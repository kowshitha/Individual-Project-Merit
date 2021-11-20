using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MvcbkLending.Models
{
    public partial class UserTable
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter your Email")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Choose Category")]
        public string Catergory { get; set; }
        [Required(ErrorMessage = "Choose Book")]
        public string Bookname { get; set; }
        [DataType(DataType.Date)]
        public DateTime Returndate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Lendeddate { get; set; }
        public int? Cost { get; set; }
        public string Bookreqno { get; set; }
    }
}
