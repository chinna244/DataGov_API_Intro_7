﻿using Microsoft.EntityFrameworkCore;
using DataGov_API_Intro_7.Models;
namespace DataGov_API_Intro_7.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        { }
        public DbSet<Stations> Fuel_Stations { get; set; }


        
    }
}
