using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using dominio;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> list = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.settearConsulta("SELECT Id, Descripcion from Categorias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.ID = (int)datos.Lector["Id"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];

                    list.Add(aux);
                }

                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                throw e;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public void agregar(Categoria nuevo)
        {

            AccesoDatos datos = new AccesoDatos();
            string query = "INSERT INTO CATEGORIAS (Descripcion) " + "VALUES (@Descripcion)";

            try
            {

                datos.settearConsulta(query);
                datos.setearParametro("@Descripcion", nuevo.Descripcion);
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

        public void modificar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.settearConsulta("update Categorias set Descripcion = '" + categoria.Descripcion + "' where Id = " + categoria.ID);
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

        public void eliminar(Categoria categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.settearConsulta("delete Categorias where Id = " + categoria.ID);
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
