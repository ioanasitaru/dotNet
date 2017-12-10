using System;
using System.Collections.Generic;
using System.Text;

namespace IntegrationTests
{
    public abstract class BaseIntegrationTest
    {
        protected virtual bool UseSqlServer => true;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            DeleteDatabase();
            CreateDatabase();
        }

        [TestCleanup]
        public virtual void TestCleanup()
        {
            DeleteDatabase();
        }

        protected void RunOnDatabase(Action<DatabaseContext> databaseAction)
        {
            if (UseSqlServer)
            {
                RunOnSqlServer(databaseAction);
            }
            else
            {
                RunOnMemory(databaseAction);
            }
        }

        private void RunOnSqlServer(Action<DatabaseContext> databaseAction)
        {
            var connectionString = @"Server = .\SQLEXPRESS; Database = Organizations.Dev; Trusted_Connection = true";
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(connectionString)
                .Options;
            using (var context = new DatabaseContext(options))
            {
                databaseAction(context);
            }
        }

        private void RunOnMemory(Action<DatabaseContext> databaseAction)
        {
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseInMemoryDatabase("UsersRepositoriesList")
                .Options;

            using (var context = new DatabaseContext(options))
            {
                databaseAction(context);
            }
        }

        private void CreateDatabase()
        {
            RunOnDatabase(context => context.Database.EnsureCreated());
        }
        private void DeleteDatabase()
        {
            RunOnDatabase(context => context.Database.EnsureDeleted());
        }
    }
}
