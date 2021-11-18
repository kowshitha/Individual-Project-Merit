using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MvcBookLend.Models
{
    public partial class UserTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Catergory { get; set; }
        public string Bookname { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Returndate { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Lendeddate { get; set; }
        public string Bookreqno { get; set; }
        public int? Cost { get; set; }
    }
}
