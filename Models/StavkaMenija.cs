using System;
using System.Collections.Generic;

#nullable disable

namespace Projekat.Models
{
    public partial class StavkaMenija
    {
        public StavkaMenija()
        {
            Sadrzis = new HashSet<Sadrzi>();
        }

        public int SifrSm { get; set; }
        public string Naz { get; set; }
        public int Cen { get; set; }
        public int? SifrM { get; set; }

        public virtual Meni SifrMNavigation { get; set; }
        public virtual ICollection<Sadrzi> Sadrzis { get; set; }
    }
}
