namespace EtbnanyWebsite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedDataIntoProducts : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Products(price,name,image,stock) Values('5.00','Mug','Product1.jpeg', 100)");
            Sql("INSERT INTO Products(price,name,image,stock) Values('10.00','Dog Treats','Product2.jpeg', 100)");
            Sql("INSERT INTO Products(price,name,image,stock) Values('10.00','Dry Food','Product3.jpeg', 100)");
            Sql("INSERT INTO Products(price,name,image,stock) Values('7.00','Cat Bio Litter','Product4.jpeg', 100)");
            Sql("INSERT INTO Products(price,name,image,stock) Values('15.00','Dogs Diapers','Product5.jpeg', 100)");
            Sql("INSERT INTO Products(price,name,image,stock) Values('5.00','Mug','Product6.jpeg', 100)");

        }

        public override void Down()
        {
        }
    }
}
