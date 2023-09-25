using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LBastidaPruebaTecnicaRepaso.Controllers
{
    public class DiscoController : Controller
    {
        // GET: Disco
        public ActionResult GetAll()
        {
            ML.Disco disco = new ML.Disco();
            disco.Artista  = new ML.Artista();
            disco.GeneroMusical = new ML.GeneroMusical();

            ML.Result result = BL.Disco.GetAll();
            disco.Discos = result.Objects; 
            ML.Result resultArtista = BL.Artista.GetAllEF();
            disco.Artista.Artistas = resultArtista.Objects;
            ML.Result resultGenero = BL.GeneroMusical.GetAll();
            disco.GeneroMusical.Generos = resultGenero.Objects;
            
            
            return View(disco);
        }

        public ActionResult Form(int? IdDisco)
        {
            ML.Disco disco = new ML.Disco();
            disco.Artista = new ML.Artista();
            disco.GeneroMusical = new ML.GeneroMusical();
            ML.Result resultArtista = BL.Artista.GetAllEF();
            ML.Result resultGenero = BL.GeneroMusical.GetAll();
          
           

            if(IdDisco != null)
            {
                ML.Result result = BL.Disco.GetById(IdDisco.Value);
                if (result.Correct)
                {
                    disco = (ML.Disco)result.Object;
                    disco.Discos = result.Objects;
                    disco.Artista.Artistas = resultArtista.Objects;
                    disco.GeneroMusical.Generos = resultGenero.Objects;
                }
               

            }
            else
            {
                disco.Artista.Artistas = resultArtista.Objects;
                disco.GeneroMusical.Generos = resultGenero.Objects;
            }
            return View(disco);
        }

        [HttpPost]
        public ActionResult Form(ML.Disco disco)
        {
            if(disco.IdDisco == 0)
            {
                ML.Result result = BL.Disco.Add(disco);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Disco agregado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Error al agregar el disco";
                }
              
            }
            else
            {
                ML.Result result = BL.Disco.Update(disco);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Disco actualizado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Error al actualizar el disco";
                }
            }
            return PartialView("Modal");
        }
        public ActionResult Delete(int IdDisco)
        {
            ML.Result result = BL.Disco.Delete(IdDisco);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Disco eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar el disco";
            }
            return PartialView("Modal");

        }

      
    }
}