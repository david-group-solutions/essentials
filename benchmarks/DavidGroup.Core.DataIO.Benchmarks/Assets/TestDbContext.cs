using Microsoft.EntityFrameworkCore;

namespace DavidGroup.Core.DataIO.Benchmarks.Assets;

public class TestDbContext(DbContextOptions<TestDbContext> options)
    : DbContext(options)
{
    public DbSet<TestEntity> TestEntities { get; init; } = null!;
}