using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Ex2R
{
    public partial class wEquipos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarGrid();
            }
        }


        public void alertas(String texto)
        {
            string message = texto;
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Equipo"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            Gridview.DataSource = dt;
                            Gridview.DataBind();  
                        }
                    }
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int valor = CLASES.cEquipo.INSERTAR_EQUIPO(txtTipoE.Text, txtModelo.Text, int.Parse(txtID.Text));

            if (valor > 0)
            {
                alertas("El equipo fue agregado con exito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al agregar el equipo");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int valor = CLASES.cEquipo.BORRAR_EQUIPO_ID(int.Parse(txtID.Text));

            if (valor > 0)
            {
                alertas("El equipo fue borrado con exito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar el equipo");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int valor = CLASES.cEquipo.ACTUALIZAR_EQUIPO_ID(txtTipoE.Text, txtModelo.Text, int.Parse(txtID.Text));

            if (valor > 0)
            {
                alertas("El equipo fue actualizado con exito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al actualizar el equipo");
            }
        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Equipo WHERE EquipoID ='" + ID + "'"))


                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    using (DataTable dt = new DataTable())
                    {
                        sda.Fill(dt);
                        Gridview.DataSource = dt;
                        Gridview.DataBind();  
                    }
                }
            }
        }
    }
}