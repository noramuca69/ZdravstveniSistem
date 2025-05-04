namespace ZdravstveniSistem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pacients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Priimek = c.String(),
                        DatumRojstva = c.DateTime(nullable: false),
                        Spol = c.String(),
                        TelefonskaStevilka = c.String(),
                        Email = c.String(),
                        Naslov = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Obisks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DatumObiska = c.DateTime(nullable: false),
                        RazlogObiska = c.String(),
                        Diagnoza = c.String(),
                        Opombe = c.String(),
                        PacientId = c.Int(nullable: false),
                        ZdravnikId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pacients", t => t.PacientId, cascadeDelete: true)
                .ForeignKey("dbo.Zdravniks", t => t.ZdravnikId, cascadeDelete: true)
                .Index(t => t.PacientId)
                .Index(t => t.ZdravnikId);
            
            CreateTable(
                "dbo.Recepts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ImeZdravila = c.String(),
                        Doziranje = c.String(),
                        DneviJemanja = c.Int(nullable: false),
                        Navodila = c.String(),
                        ObiskId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Obisks", t => t.ObiskId, cascadeDelete: true)
                .Index(t => t.ObiskId);
            
            CreateTable(
                "dbo.Zdravniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ime = c.String(),
                        Priimek = c.String(),
                        Specializacija = c.String(),
                        Email = c.String(),
                        TelefonskaStevilka = c.String(),
                        LetoZaposlitve = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Obisks", "ZdravnikId", "dbo.Zdravniks");
            DropForeignKey("dbo.Recepts", "ObiskId", "dbo.Obisks");
            DropForeignKey("dbo.Obisks", "PacientId", "dbo.Pacients");
            DropIndex("dbo.Recepts", new[] { "ObiskId" });
            DropIndex("dbo.Obisks", new[] { "ZdravnikId" });
            DropIndex("dbo.Obisks", new[] { "PacientId" });
            DropTable("dbo.Zdravniks");
            DropTable("dbo.Recepts");
            DropTable("dbo.Obisks");
            DropTable("dbo.Pacients");
        }
    }
}
