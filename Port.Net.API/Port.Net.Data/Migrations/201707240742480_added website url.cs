namespace Port.Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedwebsiteurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ProjectUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "ProjectUrl");
        }
    }
}
