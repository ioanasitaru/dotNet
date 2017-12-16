using System;
using System.Collections.Generic;
using System.Text;
using CreatingModels;
using Data.Domain.Entities;
using DTOs;

namespace Business.Repositories.Interfaces
{
    public interface ICrudRepository<T, in TCreatingModel, TDTO>
    {
        T Create(TCreatingModel entity);

        IReadOnlyList<T> GetAll();

        T GetById(Guid id);

        void Update(TDTO entity);

        void Delete(Guid id);
    }
}
