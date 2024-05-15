using System;
using System.Collections.Generic;

namespace TopArtistasRegionSpotifyAppWeb.Models;

public partial class Artistum
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? IdPais { get; set; }

    public int? IdUsuarioCrea { get; set; }

    public DateTime? FechaCrea { get; set; }

    public int? IdUsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public bool? Estatus { get; set; }

    public virtual Pai? Opais { get; set; }

    public virtual Usuario? OUsuarioCrea { get; set; }

    public virtual Usuario? OUsuarioModifica { get; set; }
}
