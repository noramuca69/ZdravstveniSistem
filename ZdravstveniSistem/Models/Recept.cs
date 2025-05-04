namespace ZdravstveniSistem.Models
{
    public class Recept
    {
        public int Id { get; set; }
        public string ImeZdravila { get; set; }
        public string Doziranje { get; set; }
        public int DneviJemanja { get; set; }
        public string Navodila { get; set; }

        public int ObiskId { get; set; }
        public virtual Obisk Obisk { get; set; }
    }
}