using System;
using System.Collections.Generic;

namespace TopArtistasRegionSpotifyAppWeb.Models;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? Estatus { get; set; }

    public virtual ICollection<Artistum> ArtistumIdUsuarioCreaNavigations { get; set; } = new List<Artistum>();

    public virtual ICollection<Artistum> ArtistumIdUsuarioModificaNavigations { get; set; } = new List<Artistum>();

    public virtual ICollection<Pai> PaiIdUsuarioCreaNavigations { get; set; } = new List<Pai>();

    public virtual ICollection<Pai> PaiIdUsuarioModificaNavigations { get; set; } = new List<Pai>();
}
