using System;
using System.Collections.Generic;

#nullable disable

namespace Projekat.Models
{
    public partial class Restoran
    {
        public Restoran()
        {
            Kuhinjas = new HashSet<Kuhinja>();
            Menis = new HashSet<Meni>();
            Stos = new HashSet<Sto>();
        }

        public int Sifr { get; set; }
        public string Naz { get; set; }
        public string Adr { get; set; }
        public string Mest { get; set; }
        public int SifrV { get; set; }

        public virtual Vlasnik SifrVNavigation { get; set; }
        public virtual ICollection<Kuhinja> Kuhinjas { get; set; }
        public virtual ICollection<Meni> Menis { get; set; }
        public virtual ICollection<Sto> Stos { get; set; }
    }
}
