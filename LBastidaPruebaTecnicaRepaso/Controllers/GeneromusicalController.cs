using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LBastidaPruebaTecnicaRepaso.Controllers
{
    public class GeneromusicalController : Controller
    {
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.GeneroMusical generoMusical = new ML.GeneroMusical();
            ML.Result result = BL.GeneroMusical.GetAll();
            generoMusical.Generos = result.Objects;
            return View(generoMusical);
        }

        [HttpGet]
        public ActionResult Form(int? IdGeneroMusical)
        {
            
            ML.GeneroMusical generoMusical = new ML.GeneroMusical();
            

            if (IdGeneroMusical != null)
            {
                ML.Result result = BL.GeneroMusical.GetById(IdGeneroMusical.Value);
              
                if (result.Correct)
                {
                    generoMusical = (ML.GeneroMusical)result.Object;
                    generoMusical.Generos = result.Objects;
                }
            }
           
           
            return View(generoMusical);
        }

        [HttpPost]
        public ActionResult Form(ML.GeneroMusical generoMusical)
        {
            if(generoMusical.IdGeneroMusical == 0)
            {
                ML.Result result = BL.GeneroMusical.Add(generoMusical);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Genero musical agregado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Error al agregar el genero musical";
                }
            }
            else
            {
                ML.Result result = BL.GeneroMusical.Update(generoMusical);
                if (result.Correct)
                {
                    ViewBag.Mensaje = "Genero musical actualizado correctamente";
                }
                else
                {
                    ViewBag.Mensaje = "Error al actualizar el genero musical";
                }
            }
           
            return PartialView("Modal");
        }

        public ActionResult Delete(int IdGeneroMusical)
        {
            ML.Result result = BL.GeneroMusical.Delete(IdGeneroMusical);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Genero musical eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar el genero musical";
            }
            return PartialView("Modal");
        }
    }
}