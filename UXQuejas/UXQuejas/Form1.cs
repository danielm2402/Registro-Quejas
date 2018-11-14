using System;
using BibliotecaQuejas.CapaDominio;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace UXQuejas
{
    public partial class Form1 : Form
    {
        Form iInicio = new iInicio();
        Form iRegistro = new iRegistrar();
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            AbrirFormHijo(new iInicio());
           

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnMaximizar.Visible = true ;
            btnRestaurar.Visible = false;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            AbrirFormHijo(iInicio);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(panel7.Visible == true)
            {
                panel7.Visible = false;
            }
            else
            {
                panel7.Visible = true;
            }
            
           
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void RelesaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]

        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void BarraTitulo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            RelesaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SubMenuEsta.Visible = true;
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SubMenuEsta.Visible = false;
            AbrirFormHijo(new iConsulta());
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AbrirFormHijo(object formhijo)
        {
            if(this.panelContenedor.Controls.Count>0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }
            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();  
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AbrirFormHijo(iRegistro);
           
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            AbrirFormHijo(new iRegistrarSolicitud());
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            
            try
            {
                string var = textBox1.Text;
                clsSQLITE.UbicacionBase(var);
                panel10.Visible = false;
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel10.Visible=true;
        }
    }
}
