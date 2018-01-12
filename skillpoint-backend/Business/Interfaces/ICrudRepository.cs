using System.Collections.Generic;

namespace Business.Repositories.Interfaces
{
    public interface ICrudRepository<T, in TCreatingModel, ID>
    {
        void Create(TCreatingModel entity);

        IReadOnlyList<T> GetAll();

        T GetById(ID id);

        void Update(TCreatingModel entity, ID id);

        void Delete(ID id);
    }
}
