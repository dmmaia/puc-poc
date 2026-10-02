using Microsoft.EntityFrameworkCore;
using Nodo.Models;

namespace ProductManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Mentoria> Mentorias => Set<Mentoria>();
    }
}