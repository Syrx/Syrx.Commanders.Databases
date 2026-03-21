
namespace Syrx.Commanders.Databases.Tests.Unit.DatabaseCommanderTests
{
    public class QueryAsyncMultimap
    {
        [Fact]
        public async Task QueryAsyncDisposesConnectionWhenExecutionFails()
        {
            var method = nameof(QueryAsyncDisposesConnectionWhenExecutionFails);
            var setting = new CommandSetting
            {
                CommandText = "select 1",
                ConnectionAlias = "test"
            };

            var reader = new Mock<IDatabaseCommandReader>();
            reader
                .Setup(x => x.GetCommand(typeof(QueryAsyncMultimap), method))
                .Returns(setting);

            var connection = new Mock<IDbConnection>(MockBehavior.Strict);
            connection.SetupGet(x => x.State).Returns(ConnectionState.Open);
            connection.Setup(x => x.CreateCommand()).Throws(new InvalidOperationException("Unit test"));
            connection.Setup(x => x.Dispose());

            var connector = new Mock<IDatabaseConnector>();
            connector
                .Setup(x => x.CreateConnection(setting))
                .Returns(connection.Object);

            var sut = new DatabaseCommander<QueryAsyncMultimap>(reader.Object, connector.Object);

            await ThrowsAnyAsync<Exception>(() => sut.QueryAsync<int>(method: method));

            connection.Verify(x => x.Dispose(), Times.Once);
        }
    }
}
