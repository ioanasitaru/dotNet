using System;
using System.Collections.Generic;
using System.Text;
using CreatingModels;

namespace DTOs
{
    public abstract class DTO<T> : CreatingModel<T>
    {
        public Guid Id;
    }
}
