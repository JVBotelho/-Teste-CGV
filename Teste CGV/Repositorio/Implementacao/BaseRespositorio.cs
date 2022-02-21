using Dominio.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using Repositorio.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Repositorio.Implementacao
{
    public class BaseRespositorio<T> : IDisposable, IBaseRepositorio<T> where T : class
    {
        protected MySqlContext context = new MySqlContext();

        private SafeHandle _safeHandle = new SafeFileHandle(IntPtr.Zero, true);
        public void Add(T item)
        {
            context.Set<T>().Add(item);
            context.SaveChanges();
        }

        public void Delete(T item)
        {
            context.Set<T>().Remove(item);
            context.SaveChanges();
        }

        public void Dispose()
        {
            _safeHandle.Dispose();
        }

        public IEnumerable<T> GetAll() => context.Set<T>().ToList();

        public T GetbyId(Guid id) => context.Set<T>().Find(id);

        public void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
