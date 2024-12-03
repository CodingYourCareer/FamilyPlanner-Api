using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using FamilyPlanner_Api.Models.Users;

namespace FamilyPlanner_Api.Data;

public class FamilyDbContext : DbContext
{
    public FamilyDbContext(DbContextOptions<FamilyDbContext> options) : base(options) { }

    public virtual DbSet<User> Users { get; set; }
}
