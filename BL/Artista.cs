using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Artista
    {
        public static ML.Result AddEF(ML.Artista artista)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaRepasoEntities context = new DL.LBastidaPruebaTecnicaRepasoEntities())
                {
                    var query = context.AddArtista(artista.NombreArtistico, artista.Nombre, artista.ApellidoPaterno, artista.ApellidoMaterno, artista.FechaNacimiento);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al agregar el artista";
                    }
                }

            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result UpdateEF(ML.Artista artista)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaRepasoEntities context = new DL.LBastidaPruebaTecnicaRepasoEntities())
                {
                    var query = context.UpdateArtista(artista.IdArtista,artista.NombreArtistico, artista.Nombre, artista.ApellidoPaterno, artista.ApellidoMaterno, artista.FechaNacimiento);
                    if (query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al agregar el artista";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result DeleteEF(int IdArtista)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.LBastidaPruebaTecnicaRepasoEntities context = new DL.LBastidaPruebaTecnicaRepasoEntities())
                {
                    var query = context.deleteArtista(IdArtista);
                    if(query > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar el artista";
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaRepasoEntities context = new DL.LBastidaPruebaTecnicaRepasoEntities())
                {
                    var query = context.GetAllArtista();
                   
                    if(query != null)
                    {
                        result.Objects = new List<object>().ToList();
                      
                        foreach (var registro in query)
                        {
                            ML.Artista artista = new ML.Artista();
                            artista.IdArtista = registro.IdArtista;
                            artista.NombreArtistico = registro.NombreArtistico;
                            artista.Nombre = registro.Nombre;
                            artista.ApellidoPaterno = registro.ApellidoPaterno;
                            artista.ApellidoMaterno = registro.ApellidoMaterno;
                            artista.FechaNacimiento = registro.FechaNacimiento;
                            result.Objects.Add(artista);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al traer los datos";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result GetById(int IdArtista)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaRepasoEntities context = new DL.LBastidaPruebaTecnicaRepasoEntities())
                {
                    var query = context.GetByIdArtista(IdArtista).SingleOrDefault();
                    if(query != null)
                    {
                        ML.Artista artista = new ML.Artista();
                        artista.IdArtista = query.IdArtista;
                        artista.NombreArtistico = query.NombreArtistico;
                        artista.Nombre = query.NOmbre;
                        artista.ApellidoPaterno = query.ApellidoPaterno;
                        artista.ApellidoMaterno = query.ApellidoMaterno;
                        artista.FechaNacimiento = query.FechaNacimiento;
                        result.Object = artista;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
