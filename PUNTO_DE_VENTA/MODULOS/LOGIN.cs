using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
namespace PUNTO_DE_VENTA_CODIGO369_CSHARP.MODULOS
{
    public partial class LOGIN : Form
    {
        int contador;
        public LOGIN()
        {
            InitializeComponent();
        }
        public void DIBUJARusuarios()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("select * from USUARIO2 WHERE Estado = 'ACTIVO'", con);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                Label b = new Label();
                Panel p1 = new Panel();
                PictureBox I1 = new PictureBox();

                b.Text = rdr["Login"].ToString();
                b.Name = rdr["idUsuario"].ToString();
                b.Size = new System.Drawing.Size(175, 25);
                b.Font = new System.Drawing.Font("Microsoft Sans Serif", 13);    
                b.BackColor = Color.FromArgb(20, 20, 20);
                b.ForeColor = Color.White;
                b.Dock = DockStyle.Bottom;
                b.TextAlign = ContentAlignment.MiddleCenter;
                b.Cursor = Cursors.Hand;

                p1.Size = new System.Drawing.Size(155, 167);
                p1.BorderStyle = BorderStyle.None;         
                p1.BackColor = Color.FromArgb(20, 20, 20);
                

                I1.Size = new System.Drawing.Size(175, 132);
                I1.Dock = DockStyle.Top;
                I1.BackgroundImage = null;
                byte[] bi = (Byte[])rdr["Icono"];
                MemoryStream ms = new MemoryStream(bi);
                I1.Image = Image.FromStream(ms);
                I1.SizeMode = PictureBoxSizeMode.Zoom;
                I1.Tag = rdr["Login"].ToString();
                I1.Cursor = Cursors.Hand;

                p1.Controls.Add(b);
                p1.Controls.Add(I1);
                b.BringToFront();
                flowLayoutPanel1 .Controls.Add(p1);

                b.Click += new EventHandler(mieventoLabel);
                I1.Click += new EventHandler(miEventoImagen);
            }
            con.Close();


        }
        private void miEventoImagen(System.Object sender, EventArgs e)
        {
            txtlogin.Text = ((PictureBox)sender).Tag.ToString();
            panel2.Visible = true;
            panel1.Visible = false;
        }
        
        private void mieventoLabel (System.Object sender, EventArgs e)
        {
            txtlogin.Text = ((Label)sender).Text;
            panel2.Visible = true;
            panel1.Visible = false;
        }
        private void LOGIN_Load(object sender, EventArgs e)
        {
            DIBUJARusuarios();
            panel2.Visible = false;
        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {

        }

        private void txtpaswwor_TextChanged(object sender, EventArgs e)
        {
            Iniciar_sesion_correcto();
        }
        private void Iniciar_sesion_correcto()
        {
            cargarusuarios();
            contar();
         

            if (contador > 0) 
            {
                CAJA.APERTURA_DE_CAJA  formulario_apertura_de_caja = new CAJA.APERTURA_DE_CAJA();

                this.Hide();
                formulario_apertura_de_caja.ShowDialog();
               


            }

        }

        private void contar()
        {
            int x;
         
            x = datalistado.Rows.Count;
            contador= (x);
          
        }
        private void cargarusuarios()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("validar_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@password", txtpaswwor .Text);
                da.SelectCommand.Parameters.AddWithValue("@login", txtlogin .Text);

                da.Fill(dt);
                datalistado.DataSource = dt;
                con.Close();

             

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

          

        }
    }
}
