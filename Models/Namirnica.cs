using System;
using System.Collections.Generic;

#nullable disable

namespace Projekat.Models
{
    public partial class Namirnica
    {
        public int SifrN { get; set; }
        public int Gram { get; set; }
        public int Cen { get; set; }
        public string Naz { get; set; }
        public int? SifrJ { get; set; }

        public virtual Jelo SifrJNavigation { get; set; }
    }
}
