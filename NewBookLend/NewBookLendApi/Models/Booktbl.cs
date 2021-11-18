using System;
using System.Collections.Generic;

#nullable disable

namespace NewBookLendApi.Models
{
    public partial class Booktbl
    {
        public int BId { get; set; }
        public string Bookname { get; set; }
        public string Cname { get; set; }

        public virtual Categoytbl CnameNavigation { get; set; }
    }
}
