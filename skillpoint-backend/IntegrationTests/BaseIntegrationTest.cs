using Data.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

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

        protected void RunOnDatabase(Action<DatabaseContext> databaseAction)
        {
            RunOnSqlServer(databaseAction);
        }

        private void RunOnSqlServer(Action<DatabaseContext> databaseAction)
        {
            var connectionString = @"Server = .\SQLEXPRESS; Database = Skillpoint.Dev; Trusted_Connection = true";
            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(connectionString)
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
