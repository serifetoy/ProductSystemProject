using System;

namespace ProductProject.Models.Entities
{
    public abstract class BaseEntity<T>
    {
        public T Id { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
