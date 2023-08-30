using System;
using System.Collections.Generic;

#nullable disable

namespace Projekat.Models
{
    public partial class Sadrzi
    {
        public int SifrSm { get; set; }
        public int SifrG { get; set; }
        public int SifrJ { get; set; }

        public virtual Narucuje Sifr { get; set; }
        public virtual StavkaMenija SifrSmNavigation { get; set; }
    }
}
