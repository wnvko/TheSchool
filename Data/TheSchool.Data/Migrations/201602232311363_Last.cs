namespace TheSchool.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class Last : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Votes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    VoterId = c.String(maxLength: 128),
                    NewsId = c.Int(nullable: false),
                    CreatedOn = c.DateTime(nullable: false),
                    ModifiedOn = c.DateTime(),
                    IsDeleted = c.Boolean(nullable: false),
                    DeletedOn = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.News", t => t.NewsId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.VoterId)
                .Index(t => t.VoterId)
                .Index(t => t.NewsId)
                .Index(t => t.IsDeleted);

            this.CreateTable(
                "dbo.News",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Title = c.String(),
                    Content = c.String(),
                    AuthorId = c.String(maxLength: 128),
                    CreatedOn = c.DateTime(nullable: false),
                    ModifiedOn = c.DateTime(),
                    IsDeleted = c.Boolean(nullable: false),
                    DeletedOn = c.DateTime(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.AuthorId)
                .Index(t => t.AuthorId)
                .Index(t => t.IsDeleted);

            this.AddColumn("dbo.AspNetUsers", "IsTeacher", c => c.Boolean(nullable: false));
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.Votes", "VoterId", "dbo.AspNetUsers");
            this.DropForeignKey("dbo.Votes", "NewsId", "dbo.News");
            this.DropForeignKey("dbo.News", "AuthorId", "dbo.AspNetUsers");
            this.DropIndex("dbo.News", new[] { "IsDeleted" });
            this.DropIndex("dbo.News", new[] { "AuthorId" });
            this.DropIndex("dbo.Votes", new[] { "IsDeleted" });
            this.DropIndex("dbo.Votes", new[] { "NewsId" });
            this.DropIndex("dbo.Votes", new[] { "VoterId" });
            this.DropColumn("dbo.AspNetUsers", "IsTeacher");
            this.DropTable("dbo.News");
            this.DropTable("dbo.Votes");
        }
    }
}
