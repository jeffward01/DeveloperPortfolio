namespace Port.Net.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectImages",
                c => new
                    {
                        ProjectImageId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        ImageUrl = c.String(),
                        FeaturedImage = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectImageId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        ProjectId = c.Int(nullable: false, identity: true),
                        ProjectName = c.String(),
                        ShortDesc = c.String(),
                        ProjectSummary = c.String(),
                        RepoUrl = c.String(),
                        FeaturedProject = c.Boolean(nullable: false),
                        BlockchainProject = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProjectId);
            
            CreateTable(
                "dbo.ProjectTechnologies",
                c => new
                    {
                        ProjectTechnologyId = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        TechnologyName = c.String(),
                    })
                .PrimaryKey(t => t.ProjectTechnologyId)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectTechnologies", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectImages", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectTechnologies", new[] { "ProjectId" });
            DropIndex("dbo.ProjectImages", new[] { "ProjectId" });
            DropTable("dbo.ProjectTechnologies");
            DropTable("dbo.Projects");
            DropTable("dbo.ProjectImages");
        }
    }
}
