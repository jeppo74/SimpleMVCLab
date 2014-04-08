using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuperSimpleBlog.Models
{
    
    public class BlogPostContext : UsersContext //DbContext
    {
        public BlogPostContext()
            : base() //base("DefaultConnection")
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }
    }

    [Table("BlogPost")]
    public class BlogPost
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Subject { get; set; }
        public string BodyText { get; set; }
        public DateTime? PostDate { get; set; }

        [ForeignKeyAttribute("User")]
        public int UserId { get; set; }
        public virtual UserProfile User { get; set; }

    }

}