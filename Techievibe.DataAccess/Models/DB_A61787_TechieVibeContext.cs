using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Techievibe.DataAccess.Models
{
    public partial class DB_A61787_TechieVibeContext : DbContext
    {
        public IConfiguration _configuration;
        public DB_A61787_TechieVibeContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public DB_A61787_TechieVibeContext(DbContextOptions<DB_A61787_TechieVibeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BlogPostCategories> BlogPostCategories { get; set; }
        public virtual DbSet<BlogPosts> BlogPosts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Data Source=sql5053.site4now.net;Initial Catalog=DB_A61787_TechieVibe;Persist Security Info=True;User ID=DB_A61787_TechieVibe_admin;Password=Y6s35AnW1ubE;");
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlogPostCategories>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BlogPosts>(entity =>
            {
                entity.HasKey(e => e.PostId);

                entity.Property(e => e.PostAuthor)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.PostBody).IsRequired();

                entity.Property(e => e.PostDate).HasColumnType("datetime");

                entity.Property(e => e.PostTitle)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.PostCategory)
                    .WithMany(p => p.BlogPosts)
                    .HasForeignKey(d => d.PostCategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_BlogPosts_BlogPostCategories");
            });
        }
    }
}
