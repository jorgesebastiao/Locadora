using System;

namespace Locadora.WebApi.Controllers.Movies.ViewModels
{
    public class MovieViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public string Genre { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModification { get; set; }
    }
}
