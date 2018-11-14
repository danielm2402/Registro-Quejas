using System;
using BibliotecaQuejas.CapaCoordinacion;
using BibliotecaQuejas.CapaDominio;
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
    public partial class iRegistrar : Form
    {
        public iRegistrar()
        {
            InitializeComponent();
            dataGridView1.DataSource = clsSQLITE.TablaCliente();
            dataGridView2.DataSource = clsSQLITE.TablaRemitente();
            
        }
        
        private void iRegistrar_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                long varCedula = Convert.ToInt64(this.textBox1.Text);
                string varNombre = this.textBox2.Text;
                long varTelefono = Convert.ToInt64(this.textBox3.Text);
                string varCorreo = this.textBox4.Text;
                string varDireccion = this.textBox5.Text;
                string varMunicipio = this.textBox6.Text;


                clsControlador.AddCliente(varCedula, varNombre, varTelefono, varCorreo, varDireccion, varMunicipio);
                MessageBox.Show(clsControlador.atrMensajeResultado);
                dataGridView1.DataSource = clsSQLITE.TablaCliente();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }
            

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int varId = Convert.ToInt32(this.textBox7.Text);
                string varNombre = this.textBox11.Text;
                string varContrato =Convert.ToString(comboBox2.SelectedItem);
                string varTipo = Convert.ToString(comboBox1.SelectedItem);
                string varCorreo = this.textBox8.Text;
         
                clsControlador.AddRemitente(varId, varNombre, varContrato, varTipo, varCorreo);
                MessageBox.Show(clsControlador.atrMensajeResultado);
                dataGridView2.DataSource = clsSQLITE.TablaRemitente();
            }
            catch (Exception er)
            {

                MessageBox.Show(er.Message);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
