using CaWorkshop.Application.TodoLists.Queries.GetTodoLists;

namespace CaWorkshop.Application.UnitTests.TodoLists.Queries.GetTodoLists;

[Collection(nameof(ReadOnlyCollection))]
public class GetTodoListsQueryTests
{
    private readonly TestFixture _fixture;

    // Test Setup
    public GetTodoListsQueryTests(TestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public async Task Handle_ReturnsCorrectVmAndListCount()
    {
        // Arrange
        var query = new GetTodoListsQuery();
        var handler = new GetTodoListsQueryHandler(_fixture.Context, _fixture.Mapper);

        // Act
        var result = await handler.Handle(query, CancellationToken.None);

        // Assert
        result.Should().BeOfType<TodosVm>();
        result.Lists.Should().HaveCount(1);
        result.Lists.First().Items.Should().HaveCount(4);
    }
}
