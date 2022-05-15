using Ampliacion_FrayGuillermo.Models.Conection;
using Ampliacion_FrayGuillermo.Models.Entities;
using System.Data.SqlClient;

namespace Ampliacion_FrayGuillermo.Models
{
    public class clsGestoraPlantas
    {
        private static clsMiConexion miConexion = new clsMiConexion();
        /// <summary>
        /// <head>public static int editarPlanta(clsPlanta oPlanta)</head>
        /// <descripcion>funcion que asigna un precio a una planta pasada por parametros</descripcion>
        /// <precondicion>NONE</precondicion>
        /// <postcondicion></postcondicion>
        /// </summary>
        /// <returns>int</returns>
        public static int editarPlanta(clsPlanta oPlanta)
        {
            int columnasAfectadas = 0;
            SqlCommand comando = new SqlCommand();
            comando.Parameters.AddWithValue("@id", oPlanta.id);
            comando.Parameters.AddWithValue("@idCategoria", oPlanta.idCategoria);
            comando.CommandText = "UPDATE plantas SET idCategoria = @idCategoria Where IdPlanta = @id";
            try
            {
                miConexion.getConnection();
                comando.Connection = miConexion.connection;
                columnasAfectadas = comando.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally 
            {
                miConexion.closeConnection(ref miConexion.connection);
            }
            return columnasAfectadas;
        }

        /// <summary>
        /// <head>public static int editarPlantasCategoria(int[] idPlantas, int idCategoria)</head>
        /// <descripcion>funcion que crea plantas y les asigna una categoria pasado por parametros</descripcion>
        /// <precondicion>NONE</precondicion>
        /// <postcondicion></postcondicion>
        /// </summary>
        /// <returns>int</returns>
        public static int editarPlantasCategoria(int[] idPlantas, int idCategoria) 
        {
            int columnasAfectadas = 0;
            for (int i = 0; i < idPlantas.Length; i++) {
                clsPlanta oPlanta = clsListadoPlantas.getPlanta(idPlantas[i]);
                oPlanta.idCategoria = idCategoria;
                columnasAfectadas =+ editarPlanta(oPlanta);
            }
            return columnasAfectadas;
        }
    }
}
