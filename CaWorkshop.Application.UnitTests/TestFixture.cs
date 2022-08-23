using AutoMapper;
using CaWorkshop.Infrastructure.Data;

namespace CaWorkshop.Application.UnitTests;


[CollectionDefinition(nameof(ReadOnlyCollection))]
public class ReadOnlyCollection : ICollectionFixture<TestFixture> { }

public class TestFixture : IDisposable
{
    private readonly DbContextFactory _contextFactory;

    // Fixture Setup
    public TestFixture()
    {
        _contextFactory = new DbContextFactory();

        Context = _contextFactory.Create();
        Mapper = MapperFactory.Create();
    }

    public ApplicationDbContext Context { get; }

    public IMapper Mapper { get; }

    // Fixture Cleanup
    public void Dispose()
    {
        _contextFactory.Dispose();
    }
}
