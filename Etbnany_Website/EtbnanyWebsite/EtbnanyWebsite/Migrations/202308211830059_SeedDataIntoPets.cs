namespace EtbnanyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDataIntoPets : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Pets(name,type,age,gender,image,isAdopted) Values('Roy','dog','10 months','male','dog-1.jpg',0)");
            Sql("INSERT INTO Pets(name,type,age,gender,image,isAdopted) Values('Keane','dog','11 months','male','dog-2.jpg',0)");
            Sql("INSERT INTO Pets(name,type,age,gender,image,isAdopted) Values('Lucy','dog','1 year','female','dog-3.jpg',0)");
            Sql("INSERT INTO Pets(name,type,age,gender,image,isAdopted) Values('Catwafina','cat','9 months','male','cat-1.jpg',0)");
            Sql("INSERT INTO Pets(name,type,age,gender,image,isAdopted) Values('Coutinho','cat','8 months','male','cat-2.jpg',0)");
            Sql("INSERT INTO Pets(name,type,age,gender,image,isAdopted) Values('Sekseka','cat','2 years','female','cat-3.jpg',0)");

        }

        public override void Down()
        {
        }
    }
}
