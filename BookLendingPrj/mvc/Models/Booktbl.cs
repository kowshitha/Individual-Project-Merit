using System;
using System.Collections.Generic;

#nullable disable

namespace mvc.Models
{
    public partial class Booktbl
    {
        public int BId { get; set; }
        public string Bookname { get; set; }
        public int? Cid { get; set; }

        public virtual Categoytbl CidNavigation { get; set; }
    }
}
