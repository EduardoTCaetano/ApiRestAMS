using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apidotnet.Interface
{
    public interface LivroInterface<T> where T : class
    {
        void Add (T entity);
        void Update (T entity);
        void Delete (T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(string id);
        Task<bool> Save();
    }
}