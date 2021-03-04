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

        public DateTime CreateAt { get; private set; }
        public DateTime UpdateAt { get; private set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public bool IsRemoved { get; private set; }
        public virtual List<Movie> Movies { get; set; }

        /// <summary>
        /// Marca o genero como removido.
        /// </summary>
        public virtual void SetAsRemoved() {
            SetLastModification();
            IsRemoved = true; 
        }

        /// <summary>
        /// Atualiza a data de Modificação.
        /// </summary>
        public virtual void SetLastModification() => UpdateAt = DateTime.UtcNow;

    }
}
