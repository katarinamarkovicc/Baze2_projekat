using System;
using System.Collections.Generic;

#nullable disable

namespace Projekat.Models
{
    public partial class Jelo
    {
        public Jelo()
        {
            Namirnicas = new HashSet<Namirnica>();
            Narucujes = new HashSet<Narucuje>();
        }

        public int SifrJ { get; set; }
        public int UkCen { get; set; }
        public int UkGram { get; set; }
        public string Naz { get; set; }

        public virtual ICollection<Namirnica> Namirnicas { get; set; }
        public virtual ICollection<Narucuje> Narucujes { get; set; }
    }
}
