using System;
using System.Collections.Generic;

#nullable disable

namespace Projekat.Models
{
    public partial class Vlasnik
    {
        public Vlasnik()
        {
            Radniks = new HashSet<Radnik>();
            Restorans = new HashSet<Restoran>();
        }

        public int SifrV { get; set; }
        public long Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prz { get; set; }
        public long BrTel { get; set; }

        public virtual ICollection<Radnik> Radniks { get; set; }
        public virtual ICollection<Restoran> Restorans { get; set; }
    }
}
