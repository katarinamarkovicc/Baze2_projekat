using System;
using System.Collections.Generic;

#nullable disable

namespace Projekat.Models
{
    public partial class Narucuje
    {
        public Narucuje()
        {
            Pravis = new HashSet<Pravi>();
            Sadrzis = new HashSet<Sadrzi>();
        }

        public int SifrG { get; set; }
        public int SifrJ { get; set; }

        public virtual Gost SifrGNavigation { get; set; }
        public virtual Jelo SifrJNavigation { get; set; }
        public virtual ICollection<Pravi> Pravis { get; set; }
        public virtual ICollection<Sadrzi> Sadrzis { get; set; }
    }
}
