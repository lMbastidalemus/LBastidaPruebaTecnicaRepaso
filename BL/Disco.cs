using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Disco
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DL.LBastidaPruebaTecnicaRepasoEntities context = new DL.LBastidaPruebaTecnicaRepasoEntities())
                {
                    var query = context.GetAllDisco().ToList();
                    if(query != null)
                    {
                        result.Objects = new List<object>().ToList();
                        foreach(var registro in query)
                        {
                            ML.Disco disco = new ML.Disco();
                            disco.IdDisco = registro.IdDisco;
                            disco.Titulo = registro.Titulo;
                            disco.Duracion = registro.Duracion;
                            disco.Anio = registro.Anio;
                            disco.Distribuidora = registro.Distribuidora;
                            disco.Ventas = registro.Ventas;
                            disco.Disponibilidad = registro.Disponibilidad;
                            disco.Artista = new ML.Artista();
                            disco.Artista.IdArtista = registro.IdArtista;
                            disco.Artista.NombreArtistico = registro.NombreArtistico;
                            disco.GeneroMusical = new ML.GeneroMusical();
                            disco.GeneroMusical.IdGeneroMusical = registro.IdGeneromusical;
                            disco.GeneroMusical.Nombre = registro.NombreGeneroMusical;
                            result.Objects.Add(disco);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
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

        public static ML.Result Delete(int IdDisco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaRepasoEntities context = new DL.LBastidaPruebaTecnicaRepasoEntities())
                {
                    var query = context.DeleteDisco(IdDisco);
                    if(query > 0)
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

        public static ML.Result GetById(int IdDisco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaRepasoEntities context = new DL.LBastidaPruebaTecnicaRepasoEntities())
                {
                    var query = context.GetByIdDisco(IdDisco).SingleOrDefault();
                    if(query != null)
                    {
                        ML.Disco disco = new ML.Disco();
                        disco.IdDisco = query.IdDisco;
                        disco.Titulo = query.Titulo;
                        disco.Duracion = query.Duracion;
                        disco.Anio = query.Anio;
                        disco.Distribuidora = query.Distribuidora;
                        disco.Ventas = query.Ventas;
                        disco.Disponibilidad = query.Disponibilidad;
                        disco.Artista = new ML.Artista();
                        disco.GeneroMusical = new ML.GeneroMusical();
                        disco.Artista.IdArtista = int.Parse(query.IdArtista.ToString());
                        disco.GeneroMusical.IdGeneroMusical = int.Parse(query.IdGeneromusical.ToString());
                        result.Object = disco;
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

        public static ML.Result Update(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaRepasoEntities context = new DL.LBastidaPruebaTecnicaRepasoEntities())
                {
                    var query = context.UpdateDisco(disco.IdDisco, disco.Titulo, disco.Duracion, disco.Anio, disco.Distribuidora, disco.Ventas, disco.Disponibilidad, disco.Artista.IdArtista, disco.GeneroMusical.IdGeneroMusical);
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

        public static ML.Result Add(ML.Disco disco)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.LBastidaPruebaTecnicaRepasoEntities context = new DL.LBastidaPruebaTecnicaRepasoEntities())
                {
                    var query = context.ADDDisco(disco.Titulo, disco.Duracion, disco.Anio, disco.Distribuidora, disco.Ventas, disco.Disponibilidad, disco.Artista.IdArtista, disco.GeneroMusical.IdGeneroMusical);
                    if(query > 0)
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

       
    }
}
