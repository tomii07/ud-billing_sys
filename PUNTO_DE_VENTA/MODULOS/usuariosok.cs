using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PUNTO_DE_VENTA_CODIGO369_CSHARP

{
    public partial class usuariosok : Form
    {
        public usuariosok()
        {
            InitializeComponent();
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Cargar_estado_de_iconos()
        {
            try
            {
                foreach (DataGridViewRow row in dataListado.Rows)
                {
                    try
                    {
                        string Icono = Convert.ToString(row.Cells["Nombre_de_icono"].Value);

                        if (Icono == "1") pictureBox3.Visible = false;
                        if (Icono == "2") pictureBox4.Visible = false;
                        if (Icono == "3") pictureBox5.Visible = false;
                        if (Icono == "4") pictureBox6.Visible = false;
                        if (Icono == "5") pictureBox7.Visible = false;
                        if (Icono == "6") pictureBox8.Visible = false;
                        if (Icono == "7") pictureBox9.Visible = false;
                        if (Icono == "8") pictureBox10.Visible = false;

                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public bool Validar_mail(string mail)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(mail);
                return addr.Address == mail;
            }
            catch
            {
                return false;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs ev)
        {
            if (txtNombre.Text != "")
            {
                if (Validar_mail(txtCorreo.Text))
                {
                    if (txtRol.Text != "")
                    {
                        if (!lblAnuncioIcono.Visible)
                        {
                            try
                            {
                                SqlConnection con = new SqlConnection();
                                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                                con.Open();

                                SqlCommand cmd = new SqlCommand();
                                cmd = new SqlCommand("insertar_usuario", con);
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@nombres", txtNombre.Text);
                                cmd.Parameters.AddWithValue("@Login", txtLogin.Text);
                                cmd.Parameters.AddWithValue("@Password", txtPass.Text);

                                cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                                cmd.Parameters.AddWithValue("@Rol", txtRol.Text);

                                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                                ICONO.Image.Save(ms, ICONO.Image.RawFormat);

                                cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                                cmd.Parameters.AddWithValue("@Nombre_de_icono", lblnumeroIcono.Text);
                                cmd.Parameters.AddWithValue("@Estado", "ACTIVO");

                                cmd.ExecuteNonQuery();

                                con.Close();

                                Mostrar();

                                panel4.Visible = false;

                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Elija un Icono", "Registro", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Elija un rol", "Registro", MessageBoxButtons.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Dirección de correo no válida... El correo debe tener el formato: nombre@dominio.com, por favor ingrese una dirección válida.");
                    txtCorreo.Focus();
                    txtCorreo.SelectAll();
                }
            }
            else
            {
                MessageBox.Show("Aseguresé de haber llenado todos los campos correctamente.", "Registro", MessageBoxButtons.OK);
            }
        }

        private void Mostrar()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("mostrar_usuario", con);
                da.Fill(dt);
                dataListado.DataSource = dt;
                con.Close();

                dataListado.Columns[1].Visible = false;
                dataListado.Columns[5].Visible = false;
                dataListado.Columns[6].Visible = false;
                dataListado.Columns[7].Visible = false;
                dataListado.Columns[8].Visible = false;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            CONEXION.Tamaño_automatico_de_datatable.Multilinea(ref dataListado);
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox3.Image;
            lblnumeroIcono.Text = "1";
            lblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void LblAnuncioIcono_Click(object sender, EventArgs e)
        {
            Cargar_estado_de_iconos();
            panelICONO.Visible = true;
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox4.Image;
            lblnumeroIcono.Text = "2";
            lblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox5.Image;
            lblnumeroIcono.Text = "3";
            lblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox6.Image;
            lblnumeroIcono.Text = "4";
            lblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox7.Image;
            lblnumeroIcono.Text = "5";
            lblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox8.Image;
            lblnumeroIcono.Text = "6";
            lblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void PictureBox9_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox9.Image;
            lblnumeroIcono.Text = "7";
            lblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void FlowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PictureBox10_Click(object sender, EventArgs e)
        {
            ICONO.Image = pictureBox10.Image;
            lblnumeroIcono.Text = "8";
            lblAnuncioIcono.Visible = false;
            panelICONO.Visible = false;
        }

        private void Usuariosok_Load(object sender, EventArgs e)
        {
            panel4.Visible = false;
            panelICONO.Visible = false;
            Mostrar();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            lblAnuncioIcono.Visible = true;
            txtNombre.Text = "";
            txtLogin.Text = "";
            txtPass.Text = "";
            txtCorreo.Text = "";
            btnGuardar.Visible = true;
            btnGuardarCambios.Visible = false;
        }

        private void Datalistado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Datalistado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            lblId_usuario.Text = dataListado.SelectedCells[1].Value.ToString();
            txtNombre.Text = dataListado.SelectedCells[2].Value.ToString();
            txtLogin.Text = dataListado.SelectedCells[3].Value.ToString();

            txtPass.Text = dataListado.SelectedCells[4].Value.ToString();

            ICONO.BackgroundImage = null;
            byte[] b = (Byte[])dataListado.SelectedCells[5].Value;
            MemoryStream ms = new MemoryStream(b);
            ICONO.Image = Image.FromStream(ms);

            lblAnuncioIcono.Visible = false;

            lblnumeroIcono.Text = dataListado.SelectedCells[6].Value.ToString();
            txtCorreo.Text = dataListado.SelectedCells[7].Value.ToString();
            txtRol.Text = dataListado.SelectedCells[8].Value.ToString();
            panel4.Visible = true;
            btnGuardar.Visible = false;
            btnGuardarCambios.Visible = true;
        }

        private void BtnVolver_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void BtnGuardarCambios_Click(object sender, EventArgs ev)
        {
            if (txtNombre.Text != "")
            {
                try
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                    con.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd = new SqlCommand("editar_usuario", con);

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@idUsuario", lblId_usuario.Text);
                    cmd.Parameters.AddWithValue("@nombres", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@Login", txtLogin.Text);
                    cmd.Parameters.AddWithValue("@Password", txtPass.Text);
                    cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                    cmd.Parameters.AddWithValue("@Rol", txtRol.Text);

                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    ICONO.Image.Save(ms, ICONO.Image.RawFormat);

                    cmd.Parameters.AddWithValue("@Icono", ms.GetBuffer());
                    cmd.Parameters.AddWithValue("@Nombre_de_icono", lblnumeroIcono.Text);

                    cmd.ExecuteNonQuery();

                    con.Close();

                    Mostrar();

                    panel4.Visible = false;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        private void ICONO_Click(object sender, EventArgs e)
        {
            Cargar_estado_de_iconos();
            panelICONO.Visible = true;
        }

        private void DataListado_CellClick(object sender, DataGridViewCellEventArgs ev)
        {
            if (ev.ColumnIndex == this.dataListado.Columns["Eli"].Index)
            {
                DialogResult result;
                result = MessageBox.Show("¿Desea eliminar este Usuario?", "Eliminando registros", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    SqlCommand cmd;
                    try
                    {
                        foreach (DataGridViewRow row in dataListado.SelectedRows)
                        {
                            int onekey = Convert.ToInt32(row.Cells["idUsuario"].Value);
                            string usuario = Convert.ToString(row.Cells["Login"].Value);
                            try
                            {
                                SqlConnection con = new SqlConnection();
                                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                                con.Open();

                                cmd = new SqlCommand("eliminar_usuario", con);
                                cmd.CommandType = CommandType.StoredProcedure;

                                cmd.Parameters.AddWithValue("@idUsuario", onekey);
                                cmd.Parameters.AddWithValue("@Login", usuario);

                                cmd.ExecuteNonQuery();

                                con.Close();
                            }
                            catch (Exception e)
                            {
                                MessageBox.Show(e.Message);
                            }
                        }
                        Mostrar();
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.Message);
                    }
                }
            }
        }

        private void PictureBox11_Click(object sender, EventArgs e)
        {
            dlg.InitialDirectory = "";
            dlg.Filter = "Imagenes|*.jpg;*.png";
            dlg.FilterIndex = 2;
            dlg.Title = "Cargador de Imagenes ADA";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ICONO.BackgroundImage = null;
                ICONO.Image = new Bitmap(dlg.FileName);
                ICONO.SizeMode = PictureBoxSizeMode.Zoom;
                lblnumeroIcono.Text = Path.GetFileName(dlg.FileName);
                lblAnuncioIcono.Visible = false;
                panelICONO.Visible = false;
            }
        }

        private void OpenFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
        private void Buscar_usuario()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlDataAdapter da;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = CONEXION.CONEXIONMAESTRA.conexion;
                con.Open();

                da = new SqlDataAdapter("buscar_usuario", con);
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.AddWithValue("@Letra", txtBuscar.Text);
                da.Fill(dt);
                dataListado.DataSource = dt;
                con.Close();

                dataListado.Columns[1].Visible = false;
                dataListado.Columns[5].Visible = false;
                dataListado.Columns[6].Visible = false;
                dataListado.Columns[7].Visible = false;
                dataListado.Columns[8].Visible = false;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            CONEXION.Tamaño_automatico_de_datatable.Multilinea(ref dataListado);
        }

        public void Numeros(TextBox CajaTexto, KeyPressEventArgs e)
        {
            if (Char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
            else if (Char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            Buscar_usuario();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
