﻿using System.Collections.Generic;

namespace Business.Services.Interfaces
{
    public interface ICrudService<T, in TCreatingModel, TDTO, ID>
    {
        void Create(TCreatingModel entity);
        void Update(TCreatingModel entity, ID id);
        IEnumerable<TDTO> GetAll();
        TDTO GetById(ID id);
        void Delete(ID id);
    }
}
