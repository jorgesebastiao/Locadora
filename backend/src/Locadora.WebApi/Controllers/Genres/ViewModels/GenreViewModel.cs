using System;

namespace Locadora.WebApi.Controllers.Genres.ViewModels
{
    public class GenreViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime UpdateAt { get;  set; }
    }
}
