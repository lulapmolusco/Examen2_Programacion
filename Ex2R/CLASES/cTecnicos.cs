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
            public int TecnicoID { get; set; }
            public string Nombre { get; set; }
            public string Especialidad { get; set; }

            public cTecnicos() { }

            public cTecnicos(int IDtecnico, string nombre, string especialidad)
            {
                IDTecnico = IDtecnico;
                Nombre = nombre;
                Especialidad = especialidad;
            }

            public cTecnicos(string nombre, string especialidad)
                : this(0, nombre, especialidad) { }

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

            public static int Agregar(string nombre, string especialidad)
            {
                SqlParameter[] parametros =
                {
            new SqlParameter("@NOMBRE", nombre),
            new SqlParameter("@ESPECIALIDAD", especialidad)
        };

                return EjecutarProcedimientoAlmacenado("INSERTAR_TECNICO", parametros);
            }

            public static int Borrar(int IDtecnico)
            {
                SqlParameter[] parametros =
                {
            new SqlParameter("@IDTECNICO", IDtecnico)
        };

                return EjecutarProcedimientoAlmacenado("BORRAR_TECNICO", parametros);
            }

            private static List<cTecnicos> ConsultarTecnicos(string nombreProcedimiento, SqlParameter[] parametros)
            {
                List<cTecnicos> tecnicos = new List<cTecnicos>();

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
                                cTecnicos tecnico = new cTecnicos(
                                        reader.GetInt32(0),
                                        reader.GetString(1),
                                        reader.GetString(2)
                                    );
                                    tecnicos.Add(tecnico);
                                }
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        
                    }
                }

                return tecnicos;
            }

            public static List<cTecnicos> ConsultaFiltro(int IDtecnico)
            {
                SqlParameter[] parametros =
                {
            new SqlParameter("@IDTECNICO", IDtecnico)
        };

                return ConsultarTecnicos("CONSULTAR_FILTRO_TECNICOS", parametros);
            }

            public static List<cTecnicos> ObtenerTecnicos()
            {
                return ConsultarTecnicos("CONSULTAR_TECNICOS", new SqlParameter[0]);
            }

    }
}