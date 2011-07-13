using System.Linq;
using Business;
using Rhino.Mocks;
using Xunit;

namespace Tests
{
    public class BlogEngineTests
    {
        private readonly IDataStorage dataStorage;
        private readonly BlogEngine blogEngine;

        public BlogEngineTests()
        {
            dataStorage = MockRepository.GenerateStub<IDataStorage>();
            blogEngine = new BlogEngine(dataStorage);
        }

        [Fact]
        public void should_create_new_author_with_initial_post()
        {
            var author = new Author{Name = "Bob"};

            blogEngine.AddAuthor(author);

            dataStorage.AssertWasCalled(_ => _.InsertOnSubmit(author));
            dataStorage.AssertWasCalled(_ => _.SubmitChanges());
        }

        [Fact]
        public void should_return_name_of_author_having_highest_number_of_posts()
        {
            const string expectedName = "Name";
            var authors = CreateCollectionOfAuthorsWithOneLeader(expectedName);
            dataStorage.Stub(_ => _.GetTable<Author>()).Return(authors);

            var actual = blogEngine.GetTopOneAuthor();

            Assert.Equal(expectedName, actual);

        }

        private static IQueryable<Author> CreateCollectionOfAuthorsWithOneLeader(string expectedName)
        {
            var authors = (new[]
                               {
                                   CreateAuthorWithPosts("looser", 2), 
                                   CreateAuthorWithPosts(expectedName, 5), 
                                   CreateAuthorWithPosts("another looser", 4),
                               }).AsQueryable();
            return authors;
        }

        private static Author CreateAuthorWithPosts(string expectedName, int postCount)
        {
            var author = new Author {Name = expectedName};
            author.Posts
                .AddRange(Enumerable.Repeat(1, postCount)
                    .Select(i => new Post()));
            return author;
        }
    }
}