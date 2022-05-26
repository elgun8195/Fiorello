﻿using Fiorello_Web_Application.Models;
using Microsoft.EntityFrameworkCore;

namespace Fiorello_Web_Application.DAL
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions options):base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<PageIntro> PageIntros { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products   { get; set; }



    }
}
