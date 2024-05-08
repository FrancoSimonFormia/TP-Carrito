using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class NegocioMarca
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.settearConsulta("select Id, Descripcion from MARCAS");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.id = (int)datos.Lector["Id"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
             
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregar(Marca nuevaMarca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string valores = "values('" + nuevaMarca.descripcion + "')";
                datos.settearConsulta("insert into MARCAS (Descripcion) " + valores);
                datos.ejecutarAccion();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public int UltimoIdmarcaRegistrada()
        {
            AccesoDatos datos = new AccesoDatos();
            int UltimoIdMarca = -1;
            try
            {
                datos.settearConsulta("SELECT IDENT_CURRENT('MARCAS') AS UltimoID");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    UltimoIdMarca = Convert.ToInt32(datos.Lector["UltimoID"]);
                }

                return UltimoIdMarca;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.settearConsulta("update MARCAS set Descripcion = '" + marca.descripcion + "' where Id = " + marca.id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(Marca marca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.settearConsulta("delete from MARCAS where Id = " + marca.id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }



        
    }
}
