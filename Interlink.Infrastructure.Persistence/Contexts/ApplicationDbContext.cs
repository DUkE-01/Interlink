using Microsoft.EntityFrameworkCore;
using Interlink.Core.Domain.Entities;

namespace Interlink.Infrastructure.Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSets de las entidades
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentReply> CommentReplies { get; set; }
        public DbSet<DirectMessage> DirectMessages { get; set; }
        public DbSet<Search> Searches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            #region tables

            modelBuilder.Entity<Post>()
                .ToTable("Posts");

            modelBuilder.Entity<Comment>()
                .ToTable("Comment");

            modelBuilder.Entity<CommentReply>()
                .ToTable("Comment Reply");

            modelBuilder.Entity<DirectMessage>()
                .ToTable("Direct Message");

            modelBuilder.Entity<User>()
                .ToTable("Users");

            #endregion

            #region User Relationships


            modelBuilder.Entity<User>()
                .HasMany(u => u.SentMessages)
                .WithOne(dm => dm.Sender)
                .HasForeignKey(dm => dm.SenderId)
                .OnDelete(DeleteBehavior.Restrict); 

           
            modelBuilder.Entity<User>()
                .HasMany(u => u.ReceivedMessages)
                .WithOne(dm => dm.Receiver)
                .HasForeignKey(dm => dm.ReceiverId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Post Relationships

            
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region Comment Relationships


            modelBuilder.Entity<Comment>()
     .HasOne(c => c.Post)
     .WithMany(p => p.Comments)
     .HasForeignKey(c => c.PostId)
     .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
    .HasOne(c => c.User)
    .WithMany(u => u.Comments)
    .HasForeignKey(c => c.UserId)
    .OnDelete(DeleteBehavior.NoAction);

            #endregion

            #region Property Configurations

            modelBuilder.Entity<User>().
               Property(user => user.Username)
               .IsRequired();

            modelBuilder.Entity<User>().
              Property(user => user.PasswordHash)
              .IsRequired();

            modelBuilder.Entity<User>().
              Property(user => user.Email)
              .IsRequired();

            modelBuilder.Entity<User>().
               Property(user => user.ProfilePicture)
               .IsRequired();

            modelBuilder.Entity<User>().
               Property(user => user.CreatedAt)
               .IsRequired();

            #endregion

        }
    }
}
