using System;
using System.Collections.Generic;

namespace Business.Services.Interfaces
{
    public interface ICrudService<T>
    {
        T Create(T entity);
        void Update(T entity);
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Delete(Guid id);
    }
}
