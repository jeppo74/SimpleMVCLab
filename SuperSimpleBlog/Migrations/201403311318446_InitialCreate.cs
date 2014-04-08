namespace SuperSimpleBlog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            //CreateTable(
            //    "dbo.BlogPost",
            //    c => new
            //        {
            //            Id = c.Int(nullable: false, identity: true),
            //            Subject = c.String(),
            //            BodyText = c.String(),
            //            UserName = c.String(),
            //        })
            //    .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            //DropTable("dbo.BlogPost");
        }
    }
}
