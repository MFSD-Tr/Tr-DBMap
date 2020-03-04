using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repository
{
    public interface IGenericRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(long ModelId);
        T Add(T model);
        T Delete(long ModelId);
        T Update(T model);
    }
}
