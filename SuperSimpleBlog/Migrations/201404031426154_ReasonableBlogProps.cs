namespace SuperSimpleBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReasonableBlogProps : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPost",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        BodyText = c.String(),
                        PostDate = c.DateTime(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfile", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            //CreateTable(
            //    "dbo.UserProfile",
            //    c => new
            //        {
            //            UserId = c.Int(nullable: false, identity: true),
            //            UserName = c.String(),
            //        })
            //    .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.BlogPost", new[] { "UserId" });
            DropForeignKey("dbo.BlogPost", "UserId", "dbo.UserProfile");
            //DropTable("dbo.UserProfile");
            DropTable("dbo.BlogPost");
        }
    }
}
