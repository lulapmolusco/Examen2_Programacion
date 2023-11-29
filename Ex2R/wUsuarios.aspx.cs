using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;

namespace Ex2R
{
    public partial class wUsuarios : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("SELECT *  FROM Usuarios"))
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
            int valor = CLASES.cUsuarios.INSERTAR_USUARIO(txtNombre.Text, txtCorreo.Text, txtTel.Text);

            if (valor > 0)
            {
                alertas("El usuario fue agregado con exito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al agregar el usuario");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            int valor = CLASES.cUsuarios.BORRAR_USUARIOS_ID(int.Parse(txtID.Text));

            if (valor > 0)
            {
                alertas("El usuario fue borrado con exito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al borrar el usuario");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int valor = CLASES.cUsuarios.ACTUALIZAR_USUARIO_ID(int.Parse(txtID.Text), txtNombre.Text, txtCorreo.Text, int.Parse(txtTel.Text));

            if (valor > 0)
            {
                alertas("El usuario fue actualizado con exito");
                LlenarGrid();
            }
            else
            {
                alertas("Error al actualizar el usuario");
            }
        }

        protected void Bconsulta_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(txtID.Text);
            string constr = ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Usuarios WHERE UsuarioID ='" + ID + "'"))


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