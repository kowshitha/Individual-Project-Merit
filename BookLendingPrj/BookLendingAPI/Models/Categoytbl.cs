using System;
using System.Collections.Generic;

#nullable disable

namespace BookLendingAPI.Models
{
    public partial class Categoytbl
    {
        public Categoytbl()
        {
            Booktbls = new HashSet<Booktbl>();
        }

        public int Id { get; set; }
        public string Category { get; set; }

        public virtual ICollection<Booktbl> Booktbls { get; set; }
    }
}
