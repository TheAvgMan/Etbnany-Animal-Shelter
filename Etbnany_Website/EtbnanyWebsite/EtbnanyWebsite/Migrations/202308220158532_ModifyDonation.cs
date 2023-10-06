namespace EtbnanyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDonation : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Donations");
            AddPrimaryKey("dbo.Donations", new[] { "ProductId", "UserId" });
            DropColumn("dbo.Donations", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Donations", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Donations");
            AddPrimaryKey("dbo.Donations", "Id");
        }
    }
}
