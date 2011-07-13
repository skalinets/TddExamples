using System.Collections.Generic;
using System.Linq;

namespace Business
{
    public interface IDataStorage
    {
        IQueryable<T> GetTable<T>() where T : class;

        void InsertAllOnSubmit<T>(IEnumerable<T> entities) where T : class;

        void InsertOnSubmit<T>(T entity) where T : class;

        void Attach<T>(T entity) where T : class;

        void SubmitChanges();

        void DeleteOnSubmit<T>(T entity) where T : class;

        void DeleteAllOnSubmit<T>(IEnumerable<T> entities) where T : class;
    }
}