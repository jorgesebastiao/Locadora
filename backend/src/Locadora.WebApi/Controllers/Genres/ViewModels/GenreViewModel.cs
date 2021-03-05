using System;

namespace Locadora.WebApi.Controllers.Genres.ViewModels
{
    public class GenreViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModification { get; set; }
    }
}
