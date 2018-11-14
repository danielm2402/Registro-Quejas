using System;
using BibliotecaQuejas.CapaCoordinacion;
using BibliotecaQuejas.CapaDominio;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UXQuejas
{
    public partial class iRegistrarSolicitud : Form
    {
        public iRegistrarSolicitud()
        {
            InitializeComponent();
            dataGridView2.DataSource = clsSQLITE.TablaSolicitud();
           dataGridView1.DataSource = clsSQLITE.TablaPresenta();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int varCarp = Convert.ToInt32(this.textBox1.Text);
                string varConsecutivo = this.textBox17.Text;
                int varIDremitente = Convert.ToInt32(this.textBox9.Text);
                string varDepartamento = this.textBox2.Text;
                string varEstado = Convert.ToString(comboBox4.SelectedItem);
                string varTipo = Convert.ToString(comboBox2.SelectedItem);
                string varMedio = Convert.ToString(comboBox5.SelectedItem);
                string varMotivo = this.textBox5.Text;
                string varMedicamento = this.textBox7.Text;
                string varCapitaEvento = Convert.ToString(comboBox1.SelectedItem);
                string varMunicipioContrato = this.textBox10.Text;
                clsControlador.AddSolicitud(varCarp, varConsecutivo, varDepartamento, varEstado, varTipo, varMedio, varMotivo, varMedicamento, varCapitaEvento, varMunicipioContrato, varIDremitente);
                MessageBox.Show(clsControlador.atrMensajeResultado);
                dataGridView2.DataSource = clsSQLITE.TablaSolicitud();

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
                long varCedulaCliente = Convert.ToInt64(this.textBox12.Text);
                int varCarpSolicitud = Convert.ToInt32(this.textBox8.Text);
                string varFecha = this.textBox14.Text;
                string varEnvioRespuesta = Convert.ToString(comboBox3.SelectedItem);
                string varFechaEnvioRespuesta = this.textBox13.Text;
                string varEntregaMx = this.textBox11.Text;
                string varCumplimiento = Convert.ToString(comboBox6.SelectedItem);
                string varJustificacion = this.textBox6.Text;
                string varInformacionExtra = this.textBox4.Text;

                clsControlador.InsertarPresentacion(varCedulaCliente, varCarpSolicitud, varFecha, varEnvioRespuesta, varFechaEnvioRespuesta, varEntregaMx, varCumplimiento, varJustificacion, varInformacionExtra);
                MessageBox.Show(clsControlador.atrMensajeResultado);
                dataGridView1.DataSource = clsSQLITE.TablaPresenta();
                
            }
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }

        }
    }
}
