namespace SuperSimpleBlog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SuperSimpleBlog.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SuperSimpleBlog.Models.BlogPostContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SuperSimpleBlog.Models.BlogPostContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            using(BlogPostContext bpc = new BlogPostContext())
            {

                BlogPost[] defaultPosts = {
                                                new BlogPost{ Id=1 , UserId=1, Subject="L�ksallad", BodyText="Hacka tomat och l�k i en sk�l. Salta och Peppra", PostDate=DateTime.Now }  
                                          ,     new BlogPost{ Id=2, UserId=1, Subject="Kebabsallad" ,BodyText="K�p en kebab, sl�ng bort br�det." , PostDate=DateTime.Now }
                                          };


                bpc.BlogPosts.AddOrUpdate(defaultPosts);
                bpc.SaveChanges();
                
                  
            }

        }
    }
}
