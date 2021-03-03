using Locadora.Domain.DomainObjects;
using System;

namespace Locadora.Domain.Features.Rents
{
    public class Rent: Entity
    {
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string CustomerCpf { get; set; }

        public Rent()
        {
            CreateAt = DateTime.UtcNow;
            UpdateAt = CreateAt;
        }
    }
}
