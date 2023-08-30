using System;
using System.Collections.Generic;

#nullable disable

namespace Projekat.Models
{
    public partial class Meni
    {
        public Meni()
        {
            StavkaMenijas = new HashSet<StavkaMenija>();
        }

        public int SifrM { get; set; }
        public int? Sifr { get; set; }

        public virtual Restoran SifrNavigation { get; set; }
        public virtual ICollection<StavkaMenija> StavkaMenijas { get; set; }
    }
}
