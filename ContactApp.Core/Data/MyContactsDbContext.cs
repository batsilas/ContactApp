using ContactApp.Core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Core.Data
{
    public class MyContactsDbContext : DbContext
    {
        public MyContactsDbContext(DbContextOptions<MyContactsDbContext> options)
             : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<Contact>()
                .ToTable("Contact");

            modelBuilder
                .Entity<PhoneNumber>()
                .ToTable("PhoneNumber");

        }

    }
}
