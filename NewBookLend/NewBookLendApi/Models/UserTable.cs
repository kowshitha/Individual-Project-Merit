using System;
using System.Collections.Generic;

#nullable disable

namespace NewBookLendApi.Models
{
    public partial class UserTable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Catergory { get; set; }
        public string Bookname { get; set; }
        public DateTime Returndate { get; set; }
        public DateTime? Lendeddate { get; set; }
        public int? Cost { get; set; }
        public string Bookreqno { get; set; }
    }
}
