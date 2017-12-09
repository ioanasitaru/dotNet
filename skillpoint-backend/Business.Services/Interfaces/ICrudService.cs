using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Services.Interfaces
{
    public interface ICrudService<T>
    {
        void Save(T entity);
        IEnumerable<T> GetAll();
        T GetById(Guid id);
        void Delete(Guid id);
    }
}
