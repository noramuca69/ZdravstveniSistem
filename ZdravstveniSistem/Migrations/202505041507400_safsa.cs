namespace ZdravstveniSistem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class safsa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Obisks", "DatumObiska", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Obisks", "DatumObiska", c => c.DateTime(nullable: false));
        }
    }
}
