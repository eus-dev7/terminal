using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminal2
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();
        }
        private Conexion obDatos;
        private void Principal_Load(object sender, EventArgs e)
        {
            label4.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
            obDatos = new Conexion();
            obDatos.consultar("select * from salidashoy ", "salidashoy");
            this.dataGridView1.DataSource = obDatos.ds.Tables["salidashoy"];
            this.dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            VBoleto boleto = new VBoleto();
            int filaseleccionada = dataGridView1.CurrentRow.Index;
            boleto.lblidsalida.Text = Convert.ToString(dataGridView1.Rows[filaseleccionada].Cells[0].Value);
            boleto.lblfecha.Text = Convert.ToString(dataGridView1.Rows[filaseleccionada].Cells[2].Value);
            boleto.lblhora.Text = Convert.ToString(dataGridView1.Rows[filaseleccionada].Cells[3].Value);
            boleto.lblidvendedor.Text = lbl_civendedor.Text;
            boleto.lblvendedor.Text = lblusuario.Text;
            boleto.nombrebus.Text = Convert.ToString(dataGridView1.Rows[filaseleccionada].Cells[4].Value);
            boleto.ShowDialog();
        }

        private void busNormalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BNormal bus = new BNormal();
            bus.ShowDialog();
        }

        private void busCamaLeitoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BLeito bus = new BLeito();
            bus.ShowDialog();
        }

        private void busCamaDoblePisoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BDolblepiso bus = new BDolblepiso();
            bus.ShowDialog();
        }

    }
}
