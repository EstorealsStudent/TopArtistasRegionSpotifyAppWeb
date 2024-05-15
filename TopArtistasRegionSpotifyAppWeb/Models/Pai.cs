using System;
using System.Collections.Generic;

namespace TopArtistasRegionSpotifyAppWeb.Models;

public partial class Pai
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? IdUsuarioCrea { get; set; }

    public DateTime? FechaCrea { get; set; }

    public int? IdUsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public bool? Estatus { get; set; }

    public virtual ICollection<Artistum> Artista { get; set; } = new List<Artistum>();

    public virtual Usuario? IdUsuarioCreaNavigation { get; set; }

    public virtual Usuario? IdUsuarioModificaNavigation { get; set; }
}
