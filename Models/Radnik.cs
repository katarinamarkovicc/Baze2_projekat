using System;
using System.Collections.Generic;

#nullable disable

namespace Projekat.Models
{
    public partial class Radnik
    {
        public int SifrR { get; set; }
        public long Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prz { get; set; }
        public long BrTel { get; set; }
        public long Plt { get; set; }
        public int? SifrV { get; set; }

        public virtual Vlasnik SifrVNavigation { get; set; }
        public virtual Konobar Konobar { get; set; }
        public virtual Kuvar Kuvar { get; set; }
    }
}
