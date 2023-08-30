using System;
using System.Collections.Generic;

#nullable disable

namespace Projekat.Models
{
    public partial class Gost
    {
        public Gost()
        {
            Narucujes = new HashSet<Narucuje>();
            Stos = new HashSet<Sto>();
        }

        public int SifrG { get; set; }
        public long Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prz { get; set; }
        public long BrTel { get; set; }

        public virtual ICollection<Narucuje> Narucujes { get; set; }
        public virtual ICollection<Sto> Stos { get; set; }
    }
}
