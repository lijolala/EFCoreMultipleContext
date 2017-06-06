using System;
using System.Collections.Generic;
using System.Text;

namespace ERS.Data.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
    }
}
