using Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace IntegrationTests
{
    public abstract class BaseIntegrationTest
    {

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

        protected virtual bool UseSqlServer => false;

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
            var connectionString = @"Server = .\SQLEXPRESS01; Database = Skillpoint.Dev; Trusted_Connection = true";
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
                .UseInMemoryDatabase("Skillpoint")
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
