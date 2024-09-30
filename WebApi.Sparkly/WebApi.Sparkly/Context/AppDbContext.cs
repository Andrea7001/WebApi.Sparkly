using System;
using Microsoft.EntityFrameworkCore;
using WebApi.Sparkly.Models;

namespace WebApi.Sparkly.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

         public DbSet<Cita> Citas { get; set; }
}
