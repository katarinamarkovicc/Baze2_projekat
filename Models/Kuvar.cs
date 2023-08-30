using System;
using System.Collections.Generic;

#nullable disable

namespace Projekat.Models
{
    public partial class Kuvar
    {
        public Kuvar()
        {
            Pravis = new HashSet<Pravi>();
        }

        public int SifrR { get; set; }
        public int? SifrK { get; set; }

        public virtual Kuhinja SifrKNavigation { get; set; }
        public virtual Radnik SifrRNavigation { get; set; }
        public virtual ICollection<Pravi> Pravis { get; set; }
    }
}
