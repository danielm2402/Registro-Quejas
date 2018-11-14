using BibliotecaQuejas.CapaDominio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UXQuejas
{
    public partial class iConsulta : Form
    {
        public iConsulta()
        {
            InitializeComponent();
            dataGridView1.DataSource = clsSQLITE.TablaExcel();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblhora.Text = DateTime.Now.ToString("hh:mm:ss ");
            lblFecha.Text = DateTime.Now.ToLongDateString();
        }
    }
}
