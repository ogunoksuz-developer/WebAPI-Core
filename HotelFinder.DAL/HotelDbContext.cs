using System;
using System.Collections.Generic;
using System.Text;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace HotelFinder.DAL
{
    public class HotelDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=MYCOMPUTER\\SQLEXPRESS;Database=HotelDb;Trusted_Connection=True;");
        }

        public DbSet<Hotel> Hotels { get; set; }
    }
}
