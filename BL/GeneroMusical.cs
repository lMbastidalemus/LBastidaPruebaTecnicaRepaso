using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class GeneroMusical
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaRepasoEntities context = new DL.LBastidaPruebaTecnicaRepasoEntities())
                {
                    var query = context.GetAllGenero();
                    
                    if(query != null)
                    {
                        result.Objects = new List<object>().ToList();
                  
                        foreach (var registro in query)
                        {
                            ML.GeneroMusical generoMusical = new ML.GeneroMusical();
                            generoMusical.IdGeneroMusical = registro.IdGeneroMusical;
                            generoMusical.Nombre = registro.Nombre;
                            result.Objects.Add(generoMusical);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al traer los generos musicales";
                    }
                    
                }

            }catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

        public static ML.Result Delete(int IdGeneroMusical)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaRepasoEntities context = new DL.LBastidaPruebaTecnicaRepasoEntities())
                {
                    var query = context.DeleteGenero(IdGeneroMusical);
                    if (query > 0)
                    {
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

        public static ML.Result Add(ML.GeneroMusical generoMusical)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaRepasoEntities context = new DL.LBastidaPruebaTecnicaRepasoEntities())
                {
                    var query = context.AddGenero(generoMusical.Nombre);
                    if (query > 0)
                    {
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

        public static ML.Result Update(ML.GeneroMusical generoMusical)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaRepasoEntities context = new DL.LBastidaPruebaTecnicaRepasoEntities())
                {
                    var query = context.UpdateGenero(generoMusical.IdGeneroMusical, generoMusical.Nombre);
                    if (query > 0)
                    {
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

        public static ML.Result GetById(int IdGeneromusical)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaRepasoEntities context = new DL.LBastidaPruebaTecnicaRepasoEntities())
                {
                    var query = context.GetById(IdGeneromusical).SingleOrDefault();
                    if (query != null)
                    {
                        
                            ML.GeneroMusical genero = new ML.GeneroMusical();
                            genero.IdGeneroMusical = query.IdGeneroMusical;
                            genero.Nombre = query.Nombre;
                            result.Object = genero;
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
