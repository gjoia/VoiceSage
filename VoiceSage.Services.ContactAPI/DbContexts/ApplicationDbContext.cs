using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoiceSage.Services.ContactAPI.Models;

namespace VoiceSage.Services.ContactAPI.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ContactGroup> ContactGroups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ContactGroup>().HasKey(cg => new
            {
                cg.ContactId,
                cg.GroupId
            });
            modelBuilder.Entity<Group>().HasData(new Group
            {
                GroupId = 1,
                GroupName = "Testers",
                Description = "Testers Group"
            });
            modelBuilder.Entity<Group>().HasData(new Group
            {
                GroupId = 2,
                GroupName = "Players",
                Description = "Players Group"
            });
        }
    }

}
