using System.Data.Common;
using DockerAPIPractice.Model;
using Microsoft.EntityFrameworkCore;

namespace DockerAPIPractice.Data;

public class NameDbContext : DbContext
{
    public NameDbContext(DbContextOptions<NameDbContext> options) : base(options)
    {
    }

    public DbSet<Names> Names { get; set; }
}