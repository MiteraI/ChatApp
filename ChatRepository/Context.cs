using ChatRepository.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatRepository
{
    public class Context : DbContext
    {
        public DbSet<User> users { get; set; }
        public DbSet<Conversation> conversation { get; set; }
        public DbSet<Message> messages { get; set; }
        public DbSet<GroupMember> groups { get; set; }
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
                user.HasKey(user => user.UserId);

            });
            modelBuilder.Entity<Conversation>(conversation =>
            {
                conversation.HasKey(conversation => conversation.ConversationId);
            });
            modelBuilder.Entity<Message>(message =>
            {
                message.HasKey(message => message.MessageId);
            });
            modelBuilder.Entity<GroupMember>(group =>
            {

            });
        }
    }
}
