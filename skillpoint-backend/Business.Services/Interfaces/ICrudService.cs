using System;
using System.Collections.Generic;
using CreatingModels;
using DTOs;

namespace Business.Services.Interfaces
{
    public interface ICrudService<T, in TCreatingModel, TDTO>
    {
        void Create(TCreatingModel entity);
        void Update(TDTO entity);
        IEnumerable<TDTO> GetAll();
        TDTO GetById(Guid id);
        void Delete(Guid id);
    }
}
