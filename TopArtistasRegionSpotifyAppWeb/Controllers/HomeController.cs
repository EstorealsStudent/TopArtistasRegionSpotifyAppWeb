using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TopArtistasRegionSpotifyAppWeb.Models;
using TopArtistasRegionSpotifyAppWeb.Models.ViewModels;


namespace TopArtistasRegionSpotifyAppWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly TopArtistasRegionContext _DBContext;

        public HomeController(TopArtistasRegionContext Context)
        {
            _DBContext = Context;
        }

        public IActionResult Index()
        {
            List<Artistum> lista = _DBContext.Artista.Include(c=>c.Opais).ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Artista_Detalle(int id)
        {
            ArtistaVM oArtistaVm = new ArtistaVM()
            {
                oArtista = new Artistum(),
                oListaPais = _DBContext.Pais.Select(Pais => new SelectListItem(){
                    Text=Pais.Nombre,
                    Value=Pais.Id.ToString()

                }).ToList()
            };
            if (id != 0)
            {
                oArtistaVm.oArtista = _DBContext.Artista.Find(id);
            }

            return View(oArtistaVm);
        }
        [HttpPost]
        public IActionResult Artista_Detalle(ArtistaVM oArtistaVm)
        {
            if (oArtistaVm.oArtista.IdPais == null)
            {
                ModelState.AddModelError("oArtista.IdPais", "El campo País es obligatorio.");
                // Recarga la lista de países para mostrarla nuevamente en la vista
                oArtistaVm.oListaPais = _DBContext.Pais.Select(Pais => new SelectListItem()
                {
                    Text = Pais.Nombre,
                    Value = Pais.Id.ToString()
                }).ToList();
                return View(oArtistaVm);
            }


            if (oArtistaVm.oArtista.Id == 0)
            {
                oArtistaVm.oArtista.IdUsuarioCrea = 1;
                _DBContext.Artista.Add(oArtistaVm.oArtista);
            }
            else
            {
                oArtistaVm.oArtista.IdUsuarioModifica = 1;
                _DBContext.Artista.Update(oArtistaVm.oArtista);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]

        public IActionResult Eliminar(int id)
        {
            Artistum oEmpleado = _DBContext.Artista.Include(c => c.Opais).Where(e => e.Id == id).FirstOrDefault();

            return View(oEmpleado);
        }

        [HttpPost]
        public IActionResult Eliminar(Artistum oartista)
        {
            _DBContext.Artista.Remove(oartista);
            _DBContext.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

    }
}
