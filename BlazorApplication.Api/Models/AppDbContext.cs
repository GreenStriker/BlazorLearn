using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blazor.Models;
namespace BlazorApplication.Api.Models
{
    public class AppDbContext : DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 
        }

        public DbSet<Employe> Employes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employe>().HasData( new Employe
            {
                EmployeID = 1,
               Name = "moukh",
                Age = 18,
                Salary = 10000

            });
        }
    }
}
