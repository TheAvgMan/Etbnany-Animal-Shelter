namespace EtbnanyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalDBVersion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adoptions",
                c => new
                    {
                        PetId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        message = c.String(),
                    })
                .PrimaryKey(t => t.PetId)
                .ForeignKey("dbo.Pets", t => t.PetId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.PetId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Pets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        type = c.String(),
                        age = c.String(),
                        gender = c.String(),
                        isAdopted = c.Boolean(nullable: false),
                        image = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        firstName = c.String(),
                        lastName = c.String(),
                        email = c.String(),
                        password = c.String(),
                        phone = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Donations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Double(nullable: false),
                        image = c.String(),
                        stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Enquiries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        message = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enquiries", "UserId", "dbo.Users");
            DropForeignKey("dbo.Donations", "UserId", "dbo.Users");
            DropForeignKey("dbo.Donations", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Adoptions", "UserId", "dbo.Users");
            DropForeignKey("dbo.Adoptions", "PetId", "dbo.Pets");
            DropIndex("dbo.Enquiries", new[] { "UserId" });
            DropIndex("dbo.Donations", new[] { "ProductId" });
            DropIndex("dbo.Donations", new[] { "UserId" });
            DropIndex("dbo.Adoptions", new[] { "UserId" });
            DropIndex("dbo.Adoptions", new[] { "PetId" });
            DropTable("dbo.Enquiries");
            DropTable("dbo.Products");
            DropTable("dbo.Donations");
            DropTable("dbo.Users");
            DropTable("dbo.Pets");
            DropTable("dbo.Adoptions");
        }
    }
}
