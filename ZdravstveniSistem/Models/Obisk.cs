using System.Collections.Generic;
using System;

namespace ZdravstveniSistem.Models
{
    public class Obisk
    {
        public int Id { get; set; }
        public DateTime DatumObiska { get; set; }
        public string RazlogObiska { get; set; }
        public string Diagnoza { get; set; }
        public string Opombe { get; set; }

        public int PacientId { get; set; }
        public virtual Pacient Pacient { get; set; }

        public int ZdravnikId { get; set; }
        public virtual Zdravnik Zdravnik { get; set; }

        public virtual ICollection<Recept> Recepti { get; set; }
    }
}