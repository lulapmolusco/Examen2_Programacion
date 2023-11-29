using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Ex2R.CLASES
{
    public class cUsuarios
    {
        public static int IDUsuario { get; set; }
        public static string Nombre { get; set; }
        public static string CorreoE { get; set; }
        public static string Telefono { get; set; }

        public cUsuarios(int usuarioID, string nombre, string correoE, string telefono)
        {
            Nombre = nombre;
            CorreoE = correoE;
            Telefono = telefono;
        }

        public cUsuarios() 
        {
            
        }

        public static int INSERTAR_USUARIO(string nombre, string correoE, string telefono)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = ConexBD.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("INSERTAR_USUARIO", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", Nombre));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", CorreoE));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONO", Telefono));


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
        public static int BORRAR_USUARIOS_ID(int UsuarioID)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = ConexBD.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BORRAR_USUARIOS_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", UsuarioID));

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
        public static int ACTUALIZAR_USUARIO_ID(int ID, string nombre, string CorreoE, int telefono)
        {
            int retorno = 0;

            SqlConnection Conexion = new SqlConnection();
            try
            {
                using (Conexion = ConexBD.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ACTUALIZAR_USUARIO_ID", Conexion)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@ID", ID));
                    cmd.Parameters.Add(new SqlParameter("@NOMBRE", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CORREO", CorreoE));
                    cmd.Parameters.Add(new SqlParameter("@TELEFONO", telefono));

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