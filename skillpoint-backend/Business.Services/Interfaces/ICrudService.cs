using System;
using System.Collections.Generic;
using CreatingModels;
using DTOs;

namespace Business.Services.Interfaces
{
    public interface ICrudService<T>
    {
        void Create(CreatingModel<T> entity);
        void Update(CreatingModel<T> entity);
        IEnumerable<DTO<T>> GetAll();
        DTO<T> GetById(Guid id);
        void Delete(Guid id);
    }
}
