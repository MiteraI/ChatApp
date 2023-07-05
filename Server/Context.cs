using Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Context : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Conversation> conversation { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<GroupMember> groups { get; set; }
        public DbSet<Profile> profiles { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true).Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("ChatApp"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.HasKey(u => u.UserId);
                user.Property(u => u.UserId).UseIdentityColumn(1, 1);
                user.Property(u => u.Name).IsRequired().HasMaxLength(128);
                user.HasIndex(u => u.Name).IsUnique();
                user.Property(u => u.Password).IsRequired().HasMaxLength(128);
            });

            modelBuilder.Entity<Conversation>(conversation =>
            {
                conversation.HasKey(c => c.ConversationId);
                conversation.Property(c => c.ConversationId).UseIdentityColumn(1, 1);
                conversation.Property(c => c.Title).IsRequired().HasMaxLength(128);
                conversation.HasMany(c => c.Messages)
                .WithOne(m => m.Conversation).HasForeignKey(c => c.ConversationId);
                conversation.HasMany(c => c.Groups)
                .WithOne(gm => gm.Conversation).HasForeignKey(c => c.ConversationId);
            });
            modelBuilder.Entity<Message>(message =>
            {
                message.HasKey(m => m.MessageId);
                message.Property(m => m.MessageId).UseIdentityColumn(1, 1);
                message.Property(m => m.MessageContent).IsRequired().HasMaxLength(256);
                message.Property(m => m.DateTime).IsRequired().HasMaxLength(128);
                message.HasOne(m => m.User).WithMany(u => u.Messages).HasForeignKey(u => u.UserId).IsRequired();
                message.HasOne(m => m.Conversation).WithMany(c => c.Messages).HasForeignKey(c => c.ConversationId).IsRequired();
            });
            modelBuilder.Entity<GroupMember>(groupMember =>
            {
                groupMember.HasKey(gm => new { gm.UserId, gm.ConversationId });
                groupMember.HasOne(gm => gm.User)
                    .WithMany(u => u.Groups)
                    .HasForeignKey(gm => gm.UserId)
                    .IsRequired();
                groupMember.HasOne(gm => gm.Conversation)
                    .WithMany(c => c.Groups)
                    .HasForeignKey(gm => gm.ConversationId)
                    .IsRequired();
            });
            modelBuilder.Entity<Profile>(profile =>
            {
                profile.HasKey(p => p.Id);
                profile.Property(p => p.Id).UseIdentityColumn(1, 1);
                profile.Property(p => p.Introduction).HasMaxLength(256);
                profile.HasOne(p => p.User)
                .WithOne(u => u.Profile)
                .HasForeignKey<Profile>(p => p.UserId);
            });
        }
    }
}
