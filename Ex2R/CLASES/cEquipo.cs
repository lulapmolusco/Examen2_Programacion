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
            : this(0, tipoEquipo, modelo, IDusuario) { }

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

        public static int Agregar(string tipoEquipo, string modelo, int IDusuario)
        {
            SqlParameter[] parametros =
            {
            new SqlParameter("@TIPOEQUIPO", tipoEquipo),
            new SqlParameter("@MODELO", modelo),
            new SqlParameter("@IDUSUARIO", IDusuario)
                    };

            return EjecutarProcedimientoAlmacenado("INSERTAR_EQUIPO", parametros);
        }

        public static int Borrar(int IDequipo)
        {
            SqlParameter[] parametros =
            {
            new SqlParameter("@IDEQUIPO", IDequipo)
                    };

            return EjecutarProcedimientoAlmacenado("BORRAR_EQUIPO", parametros);
        }

        private static List<cEquipo> ConsultarEquipos(string nombreProcedimiento, SqlParameter[] parametros)
        {
            List<cEquipo> equipos = new List<cEquipo>();

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
                                cEquipo equipo = new cEquipo(
                                            reader.GetInt32(0),
                                            reader.GetString(1),
                                            reader.IsDBNull(2) ? null : reader.GetString(2),
                                            reader.IsDBNull(3) ? 0 : reader.GetInt32(3)
                                        );
                                equipos.Add(equipo);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    
                }
            }

            return equipos;
        }

        public static List<cEquipo> ConsultaFiltro(int IDequipo)
        {
            SqlParameter[] parametros =
            {
            new SqlParameter("@IDEQUIPO", IDequipo)
                     };

            return ConsultarEquipos("CONSULTAR_FILTRO_EQUIPOS", parametros);
        }

        public static List<cEquipo> ObtenerEquipos()
        {
            return ConsultarEquipos("CONSULTAR_EQUIPOS", new SqlParameter[0]);
        }
    }
      
}