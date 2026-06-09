using DavidGroup.Core.DataIO.Entities;

namespace DavidGroup.Core.DataIO.Benchmarks.Assets;

public class TestEntity : Entity<int>
{
    public string Name { get; set; } = null!;
    public int Year { get; set; }
}