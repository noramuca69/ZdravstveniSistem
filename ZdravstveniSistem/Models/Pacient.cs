using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace ZdravstveniSistem.Models
{
    public class Pacient
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public DateTime DatumRojstva { get; set; }
        public string Spol { get; set; }
        public string TelefonskaStevilka { get; set; }
        public string Email { get; set; }
        public string Naslov { get; set; }

        public virtual ICollection<Obisk> Obiski { get; set; }
    }
}