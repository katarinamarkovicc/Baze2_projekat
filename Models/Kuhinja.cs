using System;
using System.Collections.Generic;

#nullable disable

namespace Projekat.Models
{
    public partial class Kuhinja
    {
        public Kuhinja()
        {
            Kuvars = new HashSet<Kuvar>();
        }

        public int SifrK { get; set; }
        public int Vel { get; set; }
        public int Kap { get; set; }
        public int? Sifr { get; set; }

        public virtual Restoran SifrNavigation { get; set; }
        public virtual ICollection<Kuvar> Kuvars { get; set; }
    }
}
