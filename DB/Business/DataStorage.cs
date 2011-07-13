using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;

namespace Business
{
    public class DataStorage : IDataStorage
    {
        private readonly DataContext context;

        public DataStorage(DataContext context)
        {
            this.context = context;
        }

        #region IDataStorage Members

        public IQueryable<T> GetTable<T>() where T : class
        {
            return GetTableInternal<T>();
        }

        public void InsertAllOnSubmit<T>(IEnumerable<T> entities) where T : class
        {
            GetTableInternal<T>().InsertAllOnSubmit(entities);
        }

        public void InsertOnSubmit<T>(T entity) where T : class
        {
            GetTableInternal<T>().InsertOnSubmit(entity);
        }

        public void Attach<T>(T entity) where T : class
        {
            GetTableInternal<T>().Attach(entity);
        }

        public void SubmitChanges()
        {
            context.SubmitChanges();
        }

        public void DeleteOnSubmit<T>(T entity) where T : class
        {
            GetTableInternal<T>().DeleteOnSubmit(entity);
        }

        public void DeleteAllOnSubmit<T>(IEnumerable<T> entities) where T : class
        {
            GetTableInternal<T>().DeleteAllOnSubmit(entities);
        }

        #endregion

        private Table<T> GetTableInternal<T>() where T : class
        {
            return context.GetTable<T>();
        }
    }
}