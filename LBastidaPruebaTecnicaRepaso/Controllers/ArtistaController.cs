using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LBastidaPruebaTecnicaRepaso.Controllers
{
    public class ArtistaController : Controller
    {
        // GET: Artista
        public ActionResult GetAll()
        {
            ML.Artista artista = new ML.Artista();
            ML.Result result = BL.Artista.GetAllEF();
            artista.Artistas = result.Objects;

            
            return View(artista);
        }

        [HttpGet]
        public ActionResult Form(int? IdArtista)
        {
            ML.Artista artista = new ML.Artista();
            if(IdArtista != null)
            {
                ML.Result result = BL.Artista.GetById(IdArtista.Value);
                if (result.Correct)
                {
                    artista = (ML.Artista)result.Object;
                }
            }
            return View(artista);
        }

        [HttpPost]
        public ActionResult Form(ML.Artista artista)
        {
            if(artista.IdArtista == 0)
            {
                ML.Result result = BL.Artista.AddEF(artista);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Artista agregado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Error al agregar el artista";
                }
            }
            else
            {
                ML.Result result = BL.Artista.UpdateEF(artista);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Artista actualizado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Error al actualizar el artista";
                }
            }
            return PartialView("Modal");
        }

        public ActionResult Delete(int IdArtista)
        {
            ML.Result result = BL.Artista.DeleteEF(IdArtista);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Artista Eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar artista ";
            }
            return PartialView("Modal");
        }
    }
}