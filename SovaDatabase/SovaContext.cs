using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.EntityFrameworkCore;

namespace SovaDatabase
{
    public class SovaContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public DbSet<SovaUser> SovaUsers { get; set; }
        public DbSet<Posttype> Posttypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseMySql("server=localhost;database=stackoverflow_sample_universal;uid=Rmood;pwd=1234");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Posts Table
            modelBuilder.Entity<Post>().ToTable("posts");
            modelBuilder.Entity<Post>().Property(x => x.PostTypeId).HasColumnName("post_type_id");
            modelBuilder.Entity<Post>().Property(x => x.ParentId).HasColumnName("parent_id");
            modelBuilder.Entity<Post>().Property(x => x.AcceptedAnswerId).HasColumnName("accepted_answer_id");
            modelBuilder.Entity<Post>().Property(x => x.CreationDate).HasColumnName("creation_date");
            modelBuilder.Entity<Post>().Property(x => x.ClosedDate).HasColumnName("closed_date");
            modelBuilder.Entity<Post>().Property(x => x.UserId).HasColumnName("user_id");
            
            //Posttypes Table
            modelBuilder.Entity<Posttype>().ToTable("posttype");

            //SovaUsers Table
            modelBuilder.Entity<SovaUser>().ToTable("sovausers");
            modelBuilder.Entity<SovaUser>().Property(x => x.Id).HasColumnName("userid");
            modelBuilder.Entity<SovaUser>().Property(x => x.Nick).HasColumnName("nickname");
            modelBuilder.Entity<SovaUser>().Property(x => x.Birthday).HasColumnName("dateofbirth");
            modelBuilder.Entity<SovaUser>().Property(x => x.Private).HasColumnName("isprivate");
        }

    }
}
