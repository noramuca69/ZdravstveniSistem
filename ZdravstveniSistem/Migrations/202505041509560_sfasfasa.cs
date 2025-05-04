namespace ZdravstveniSistem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sfasfasa : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Obisks", "DatumObiska", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Pacients", "DatumRojstva", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pacients", "DatumRojstva", c => c.String());
            AlterColumn("dbo.Obisks", "DatumObiska", c => c.String());
        }
    }
}
