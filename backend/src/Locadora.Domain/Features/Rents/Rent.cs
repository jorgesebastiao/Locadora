using Locadora.Domain.DomainObjects;
using System;

namespace Locadora.Domain.Features.Rents
{
    public class Rent: Entity
    {
        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; private set; }
        public string CustomerCpf { get; set; }

        public Rent()
        {
            CreateAt = DateTime.UtcNow;
            UpdateAt = CreateAt;
        }
    }
}
