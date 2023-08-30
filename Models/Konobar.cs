using System;
using System.Collections.Generic;

#nullable disable

namespace Projekat.Models
{
    public partial class Konobar
    {
        public int SifrR { get; set; }

        public virtual Radnik SifrRNavigation { get; set; }
    }
}
