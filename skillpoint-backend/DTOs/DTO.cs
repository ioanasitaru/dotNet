using System;
using CreatingModels;

namespace DTOs
{
    public abstract class DTO<T> : CreatingModel<T>
    {
        public Guid Id;
    }
}
