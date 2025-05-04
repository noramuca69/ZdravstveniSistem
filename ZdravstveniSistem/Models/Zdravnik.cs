using System.Collections.Generic;

namespace ZdravstveniSistem.Models
{
    public class Zdravnik
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Priimek { get; set; }
        public string Specializacija { get; set; }
        public string Email { get; set; }
        public string TelefonskaStevilka { get; set; }
        public int LetoZaposlitve { get; set; }

        public virtual ICollection<Obisk> Obiski { get; set; }
    }
}