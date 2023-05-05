using LocalMarketer.DataAccess;
using LocalMarketer.DataAccess.CQRS;

namespace Tests
{
        /// <summary>
        /// Base Class for test classes.
        /// </summary>
        public class TestsBase : IDisposable
        {                  
                /// <summary>
                /// String with 51 characters for tests.
                /// </summary>
                internal static readonly string String51charactersLong = new ('a', 51);

                /// <summary>
                /// String with 50 characters for tests.
                /// </summary>
                internal static readonly string String50charactersLong = new ('a', 50);

                /// <summary>
                /// String with 350 characters for tests.
                /// </summary>
                internal static readonly string String350charactersLong = new ('a', 350);

                /// <summary>
                /// String with 351 characters for tests.
                /// </summary>
                internal static readonly string String351charactersLong = new ('a', 351);

                /// <summary>
                /// String with 2 characters for tests.
                /// </summary>
                internal static readonly string String2charactersLong = new ('a', 2);

                /// <summary>
                /// String with 2 characters for tests.
                /// </summary>
                internal static readonly string String101charactersLong = new ('a', 101);

                /// <summary>
                /// String with 2 characters for tests.
                /// </summary>
                internal static readonly string String3charactersLong = new ('a', 3);

                /// <summary>
                /// String with 2 characters for tests.
                /// </summary>
                internal static readonly string String100charactersLong = new ('a', 100);

                private InMemorySqliteConnection connection;

                private bool disposedValue;

                /// <summary>
                /// Gets memory context.
                /// </summary>
                public LocalMarketerDbContext MemoryContext { get; private set; }
                public QueryExecutor QueryExecutor { get; private set; }

                public CommandExecutor CommandExecutor { get; private set; }

                /// <summary>
                /// Disposing method.
                /// </summary>
                public void Dispose()
                {
                        this.Dispose(disposing: true);
                        GC.SuppressFinalize(this);
                }

                /// <summary>
                /// Initializes connection and context for tests.
                /// </summary>
                [SetUp]
                protected void Initial()
                {
                        this.connection = new InMemorySqliteConnection();
                        this.MemoryContext = this.connection.CreateContext();
                        this.QueryExecutor = new QueryExecutor(this.MemoryContext);
                        this.CommandExecutor = new CommandExecutor(this.MemoryContext);
                }

                /// <summary>
                /// Disposes connection.
                /// </summary>
                /// <param name="disposing">Is disposing.</param>
                protected virtual void Dispose(bool disposing)
                {
                        if (!this.disposedValue)
                        {
                                if (disposing)
                                {
                                        this.connection.Dispose();
                                }

                                this.disposedValue = true;
                        }
                }
        }
}
