using Locadora.Domain.DomainObjects;
using Locadora.Domain.Features.Genres;
using System;

namespace Locadora.Domain.Features.Movies
{
    public class Movie: Entity
    {
        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; private set; }
        public bool Active { get; set; }
        public string Name { get; set; }
        public bool IsRemoved { get; set; }
        public Guid GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public Movie()
        {
            CreateAt = DateTime.UtcNow;
            UpdateAt = CreateAt;
        }

        /// <summary>
        /// Marca o genero como removido.
        /// </summary>
        public virtual void SetAsRemoved() => IsRemoved = true;
    }
}
