using eKnjiznica.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKnjiznica.Data.EF
{
    public class MyContext:IdentityDbContext<ApplicationUser>
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);



         


            modelBuilder.Entity<Orders>()

               .HasOne(so => so.ApplicationUser)

               .WithMany()

               .HasForeignKey(so => so.ApplicationUserId)

               .OnDelete(DeleteBehavior.Restrict);

        


        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Books> Books { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<TransactionTypes> TransactionTypes { get; set; }
        public DbSet<UserCredit> UserCredits { get; set; }
    }
}
