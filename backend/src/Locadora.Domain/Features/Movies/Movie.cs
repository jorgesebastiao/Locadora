using Locadora.Domain.DomainObjects;
using Locadora.Domain.Features.Genres;
using System;

namespace Locadora.Domain.Features.Movies
{
    public class Movie: Entity
    {
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get; set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public bool Remove { get; set; }
        public Guid GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public Movie()
        {
            CreateAt = DateTime.UtcNow;
            UpdateAt = CreateAt;
        }
    }
}
