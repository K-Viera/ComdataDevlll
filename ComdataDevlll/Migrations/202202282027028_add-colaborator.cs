namespace ComdataDevlll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addcolaborator : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Collaborators",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Addres = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Salary = c.String(nullable: false),
                        Area = c.String(nullable: false),
                        entryDate = c.DateTime(nullable: false),
                        gender = c.String(nullable: false),
                        AplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AplicationUserId)
                .Index(t => t.AplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Collaborators", "AplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Collaborators", new[] { "AplicationUserId" });
            DropTable("dbo.Collaborators");
        }
    }
}
