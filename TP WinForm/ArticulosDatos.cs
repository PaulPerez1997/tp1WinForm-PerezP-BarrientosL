using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace TP_WinForm
{
    class ArticulosDatos
    {
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;//no se crea instancia
            try
            {
                //conexion a db sql
                conexion.ConnectionString = "server=.\\SQLEXPRESS;database=CATALOGO_DB;integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select id,Codigo,Nombre,Descripcion,ImagenUrl from ARTICULOS";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    //pasa a objeto
                    Articulo aux = new Articulo();
                    aux.ID = (int)lector["id"];
                    aux.Codigo = (string)lector["Codigo"];
                    aux.Nombre = (string)lector["Nombre"];
                    aux.Descripcion = (string)lector["Descripcion"];
                    aux.ImagenURL = (string)lector["ImagenUrl"];

                    lista.Add(aux); 
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
