namespace Port.Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedemailtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emails",
                c => new
                    {
                        EmailId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(),
                        Message = c.String(),
                    })
                .PrimaryKey(t => t.EmailId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Emails");
        }
    }
}
