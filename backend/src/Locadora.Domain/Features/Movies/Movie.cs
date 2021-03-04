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
        /// Marca o filme como removido.
        /// </summary>
        public virtual void SetAsRemoved()
        {
            SetLastModification();
            IsRemoved = true;
        }

        /// <summary>
        /// Atualiza a data de Modificação.
        /// </summary>
        public virtual void SetLastModification() => UpdateAt = DateTime.UtcNow;

        /// <summary>
        /// Atualiza o genero do filme.
        /// </summary>
        public virtual void SetGenre(Genre genre)
        {
            Genre = Genre;
            GenreId = genre.Id;
        }
    }
}
