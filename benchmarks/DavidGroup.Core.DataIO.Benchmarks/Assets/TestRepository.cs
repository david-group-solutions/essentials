using DavidGroup.Core.DataIO.Repositories;

namespace DavidGroup.Core.DataIO.Benchmarks.Assets;

public class TestRepository(TestDbContext context) : BaseRepository<TestEntity, int>(context);