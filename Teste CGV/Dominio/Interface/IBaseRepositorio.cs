using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interface
{
    public interface IBaseRepositorio<T> where T : class
    {
        void Add(T item);
        T GetbyId(Guid id);
        IEnumerable<T> GetAll();
        void Update(T item);
        void Delete(T item);
        void Dispose();
    }
}
