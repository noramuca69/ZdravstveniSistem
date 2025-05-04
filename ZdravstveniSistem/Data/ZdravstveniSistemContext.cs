using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ZdravstveniSistem.Data
{
    public class ZdravstveniSistemContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ZdravstveniSistemContext() : base("name=ZdravstveniSistemContext")
        {
        }

        public System.Data.Entity.DbSet<ZdravstveniSistem.Models.Pacient> Pacients { get; set; }

        public System.Data.Entity.DbSet<ZdravstveniSistem.Models.Zdravnik> Zdravniks { get; set; }

        public System.Data.Entity.DbSet<ZdravstveniSistem.Models.Recept> Recepts { get; set; }

        public System.Data.Entity.DbSet<ZdravstveniSistem.Models.Obisk> Obisks { get; set; }
    }
}
