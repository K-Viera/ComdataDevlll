namespace ComdataDevlll.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addIdentification : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Collaborators", "Identification", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Collaborators", "Identification");
        }
    }
}
