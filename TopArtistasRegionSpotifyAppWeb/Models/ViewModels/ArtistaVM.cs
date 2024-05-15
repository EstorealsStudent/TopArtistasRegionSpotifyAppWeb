using Microsoft.AspNetCore.Mvc.Rendering;

namespace TopArtistasRegionSpotifyAppWeb.Models.ViewModels
{
    public class ArtistaVM
    {
        public Artistum oArtista { get; set; }

        public List<SelectListItem> oListaPais { get; set; }
    }
}
