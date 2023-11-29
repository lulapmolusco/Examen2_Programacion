using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Ex2R.CLASES
{
    public class cTecnicos
    {
        public int IDTecnico { get; set; }
        public string Nombre { get; set; }
        public string Especialidad { get; set; }

        public cTecnicos(int IDtecnico, string nombre, string especialidad)
        {
            IDTecnico = IDtecnico;
            Nombre = nombre;
            Especialidad = especialidad;
        }

        public cTecnicos(string nombre, string especialidad)
        {
            Nombre = nombre;
            Especialidad = especialidad;
        }

        public cTecnicos() { }

        public static int INSERTAR_TECNICO(string nombre, string especialidad)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = ConexBD.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_TENICO", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@ESPECIALIDAD", especialidad));


                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conexion.Close();
            }

            return retorno;

        }
        public static int BORRAR_TECNICOS_ID(int IDTecnico)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = ConexBD.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_TECNICOS_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", IDTecnico));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conexion.Close();
            }

            return retorno;

        }
        public static int ACTUALIZAR_TECNICO_ID(int ID, string nombre, string especialidad)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = ConexBD.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_TECNICO_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@ESPECIALIDAD", especialidad));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conexion.Close();
            }

            return retorno;

        }
    }
}