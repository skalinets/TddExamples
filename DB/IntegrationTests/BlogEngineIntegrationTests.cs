using System;
using System.Data.SqlClient;
using System.Net.Configuration;
using Business;
using Microsoft.Practices.Unity;
using Xunit;
using Xunit.Extensions;

namespace IntegrationTests
{
    public class BlogEngineIntegrationTests
    {
        private readonly UnityContainer unityContainer;
        private readonly BlogEngine blogEngine;

        public BlogEngineIntegrationTests()
        {
            unityContainer = GetUnityContainer();
            blogEngine = unityContainer.Resolve<BlogEngine>();
        }

        [Fact]
        [AutoRollback]
        public void should_add_author_to_real_db()
        {
            blogEngine.AddAuthor(new Author{Name = "bob"});

            AssertSql("select count(*) from Author where Name = 'bob'", 1);
        }

        private static string GetConnectionStringFastAndDirty()
        {
            return new BlogDataContext().Connection.ConnectionString;
        }

        [Fact]
        public void should_return_author_with_highest_number_of_posts_from_real_db()
        {
            var actual = blogEngine.GetTopOneAuthor();

            Assert.Equal(@"Коля Козявкин", actual);
            
        }

        private static UnityContainer GetUnityContainer()
        {
            var unityContainer = new UnityContainer();
            RegisterDataStorageInContainer(unityContainer);
            return unityContainer;
        }

        private static void RegisterDataStorageInContainer(UnityContainer unityContainer)
        {
            var injectionConstructor = new InjectionConstructor(new BlogDataContext());
            unityContainer.RegisterType<IDataStorage, DataStorage>(injectionConstructor);
        }

        private static void AssertSql(string sql, int expected)
        {
            var connectionString = GetConnectionStringFastAndDirty();
            object scalar;
            using (var sqlConnection = new SqlConnection(connectionString))
            {
                SqlCommand sqlCommand = sqlConnection.CreateCommand();
                sqlCommand.CommandText = sql;
                sqlConnection.Open();
                scalar = sqlCommand.ExecuteScalar();
            }

            Assert.Equal(expected, scalar);
        }
    }
}