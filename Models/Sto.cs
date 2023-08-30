using System;
using System.Collections.Generic;

#nullable disable

namespace Projekat.Models
{
    public partial class Sto
    {
        public int SifrS { get; set; }
        public int BrStol { get; set; }
        public bool Poj { get; set; }
        public int Sifr { get; set; }
        public int? SifrG { get; set; }

        public virtual Gost SifrGNavigation { get; set; }
        public virtual Restoran SifrNavigation { get; set; }
    }
}
