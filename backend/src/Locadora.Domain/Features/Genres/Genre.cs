using Locadora.Domain.DomainObjects;
using Locadora.Domain.Features.Movies;
using System;
using System.Collections.Generic;

namespace Locadora.Domain.Features.Genres
{
    public  class Genre: Entity
    {
        public Genre()
        {
            CreateAt = DateTime.UtcNow;
            UpdateAt = CreateAt;
        }

        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool Remove { get; set; }
        public virtual List<Movie> Movies { get; set; }

    }
}
