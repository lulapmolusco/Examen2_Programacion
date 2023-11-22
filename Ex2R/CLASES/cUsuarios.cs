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
        public int IDUsuario { get; set; }
        public string Nombre { get; set; }
        public string CorreoE { get; set; }
        public string Telefono { get; set; }

        public cUsuarios()
        {
            Nombre = string.Empty;
            CorreoE = string.Empty;
            Telefono = string.Empty;
        }

        public cUsuarios(int IDusuario, string nombre, string correoE, string telefono)
            : this()
        {
            IDUsuario = IDusuario;
            Nombre = nombre;
            CorreoE = correoE;
            Telefono = telefono;
        }

        public cUsuarios(string nombre, string correoE, string telefono)
            : this(0, nombre, correoE, telefono) { }

        private static int EjecutarProcedimientoAlmacenado(string nombreProcedimiento, SqlParameter[] parametros)
        {
            int retorno = 0;

            using (SqlConnection Conn = ConexBD.obtenerConexion())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(nombreProcedimiento, Conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parametros);
                        retorno = cmd.ExecuteNonQuery();
                    }
                }
                catch (SqlException ex)
                {
                    retorno = -1;
                }
            }

            return retorno;
        }

        public static int Agregar(string nombre, string correoE, string telefono)
        {
            SqlParameter[] parametros =
            {
            new SqlParameter("@NOMBRE", nombre),
            new SqlParameter("@CORREO", correoE),
            new SqlParameter("@TELEFONO", telefono)
        };

            return EjecutarProcedimientoAlmacenado("INSERTAR_USUARIO", parametros);
        }

        public static int Borrar(int IDusuario)
        {
            SqlParameter[] parametros =
            {
            new SqlParameter("@IDUSUARIO", IDusuario)
        };

            return EjecutarProcedimientoAlmacenado("BORRAR_USUARIO", parametros);
        }

        private static List<cUsuarios> ConsultarUsuarios(string nombreProcedimiento, SqlParameter[] parametros)
        {
            List<cUsuarios> usuarios = new List<cUsuarios>();

            using (SqlConnection Conn = ConexBD.obtenerConexion())
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(nombreProcedimiento, Conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddRange(parametros);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cUsuarios usuario = new cUsuarios(
                                    reader.GetInt32(0),
                                    reader.GetString(1),
                                    reader.IsDBNull(2) ? null : reader.GetString(2),
                                    reader.IsDBNull(3) ? null : reader.GetString(3)
                                );
                                usuarios.Add(usuario);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    
                }
            }

            return usuarios;
        }

        public static List<cUsuarios> ConsultaFiltro(int IDusuario)
        {
            SqlParameter[] parametros =
            {
            new SqlParameter("@IDUSUARIO", IDusuario)
        };

            return ConsultarUsuarios("CONSULTAR_FILTRO_USUARIOS", parametros);
        }

        public static List<cUsuarios> ObtenerUsuarios()
        {
            return ConsultarUsuarios("CONSULTAR_USUARIOS", new SqlParameter[0]);
        }
    }

}