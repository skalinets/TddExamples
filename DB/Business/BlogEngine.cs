using System.Linq;

namespace Business
{
    public class BlogEngine
    {
        private readonly IDataStorage dataStorage;

        public BlogEngine(IDataStorage dataStorage)
        {
            this.dataStorage = dataStorage;
        }

        public void AddAuthor(Author author)
        {
            dataStorage.InsertOnSubmit(author);
            dataStorage.SubmitChanges();
        }


        public string GetTopOneAuthor()
        {
            return dataStorage.GetTable<Author>()
                .OrderByDescending(author => author.Posts.Count())
                .First().Name;
        }
    }
}