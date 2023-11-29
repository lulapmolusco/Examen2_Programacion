using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Ex2R.CLASES
{
    public class cEquipo
    {
        public int IDEquipo { get; set; }
        public string TipoEquipo { get; set; }
        public string Modelo { get; set; }
        public int IDUsuario { get; set; }

        public cEquipo() { }

        public cEquipo(int IDequipo, string tipoEquipo, string modelo, int IDusuario)
        {
            IDEquipo = IDequipo;
            TipoEquipo = tipoEquipo;
            Modelo = modelo;
            IDUsuario = IDusuario;
        }

        public cEquipo(string tipoEquipo, string modelo, int IDusuario)
        {
            TipoEquipo = tipoEquipo;
            Modelo = modelo;
            IDUsuario = IDusuario;
        }

        public static int INSERTAR_EQUIPO(string tipoEquipo, string modelo, int IDusuario)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = ConexBD.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_EQUIPO", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@TIPOEQUIPO", tipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@MODELO", modelo));
                    cmd.Parameters.Add(new SqlParameter("@IDUSUARIO", IDusuario));


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
        public static int BORRAR_EQUIPO_ID(int IDEquipo)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = ConexBD.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_EQUIPOS_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", IDEquipo));

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
        public static int ACTUALIZAR_EQUIPO_ID(string tipoEquipo, string modelo, int IDusuario)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = ConexBD.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_EQUIPO_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };

                    cmd.Parameters.Add(new SqlParameter("@TIPOEQUIPO", tipoEquipo));
                    cmd.Parameters.Add(new SqlParameter("@MODELO", modelo));
                    cmd.Parameters.Add(new SqlParameter("@IDUSUARIO", IDusuario));

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