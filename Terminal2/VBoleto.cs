using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using MySql.Data.MySqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminal2
{
    public partial class VBoleto : Form
    {
        System.Windows.Forms.Button[] arreglo = new System.Windows.Forms.Button[48];
        public VBoleto()
        {
            InitializeComponent();
        }
        private MySqlConnection cn;
        private Conexion obDatos;
        void cargar_asientos()
        {
            int x = 0;
            int y = 0;
            int p=0;
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "select a.numero,a.x,a.y from asiento a,salida s where s.id='"+lblidsalida.Text+"' and s.fecha=curdate() and a.N not in (select id_asiento from boleto )";
                comando.Connection = cn;
                MySqlDataReader reader;
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    x = Convert.ToInt32(reader[1].ToString());
                    y = Convert.ToInt32(reader[2].ToString());
                    //intialize new button 
                    arreglo[p] = new Button();
                    arreglo[p].Size = new System.Drawing.Size(40, 40);
                    //arreglo[i].BackColor = Color.Red;
                    arreglo[p].Image = Image.FromFile(@"C:\Users\MELO\Desktop\Proyecto BD\Terminal2\Terminal2\Resources\libre.png");
                    arreglo[p].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    arreglo[p].Location = new System.Drawing.Point(x, y);
                    arreglo[p].Text = reader[0].ToString();
                    arreglo[p].Click += new System.EventHandler(this.buttons_Click);
                    this.Controls.AddRange(new System.Windows.Forms.Control[] { arreglo[p] });
                    p++;
                }
                reader.Close();
                p = 0;
                comando.CommandText = "select a.numero,a.x,a.y from asiento a,salida s where s.id='" + lblidsalida.Text + "' and s.fecha=curdate() and a.N in (select id_asiento from boleto )";
                comando.Connection = cn;
                reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    x = Convert.ToInt32(reader[1].ToString());
                    y = Convert.ToInt32(reader[2].ToString());
                    //intialize new button 
                    arreglo[p] = new Button();
                    arreglo[p].Size = new System.Drawing.Size(40, 40);
                    arreglo[p].Image = Image.FromFile(@"C:\Users\MELO\Desktop\Proyecto BD\Terminal2\Terminal2\Resources\ocupado.png");
                    arreglo[p].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                    arreglo[p].Location = new System.Drawing.Point(x, y);
                    arreglo[p].Text = reader[0].ToString();
                    arreglo[p].Click += new System.EventHandler(this.buttons_Click);
                    this.Controls.AddRange(new System.Windows.Forms.Control[] { arreglo[p] });
                    p++;
                }
                reader.Close();
        }
        private void buttons_Click(Object sender1, EventArgs e1)
        {
            Button btn = sender1 as Button;
            asiento.Text = btn.Text;
            btn.Image = Image.FromFile(@"C:\Users\MELO\Desktop\Proyecto BD\Terminal2\Terminal2\Resources\seleccionado.png");
            IDasiento();
            cargar_asientos();
        }
        private void VBoleto_Load(object sender, EventArgs e)
        {
            
            //Cuando hago click en  ingresar.
            cn = new MySqlConnection();
            //Definir la cadena de coneccion.
            cn.ConnectionString = "SERVER=localhost;DATABASE=buses;UID=root;PASSWORD=;";
            //Abrir la conexion.
            try
            {
                cn.Open();
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
            int i;
            for (i = 1; i < 47; i++)
            {

            }
            cargar_asientos();
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "select costo,id_bus from salida where id='" + lblidsalida.Text + "'";
            comando.Connection = cn;
            MySqlDataReader reader;
            reader = comando.ExecuteReader();
            if (reader.Read())
            {
                Costo.Text = reader[0].ToString();
                placa.Text = reader[1].ToString();
            }
            else
            {

            }
            reader.Close();
            Boleto();
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText = "select id,nombre,apellidos from cliente where id='" + textBox1.Text + "'";
                comando.Connection = cn;
                MySqlDataReader reader;
                reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    textBox2.Text = reader[1].ToString();
                    textBox3.Text = reader[2].ToString();
                }
                else
                { 

                }
                reader.Close();
            }
        }
        void IDasiento()
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "select N from asiento where id_bus='"+placa.Text+"' and numero='"+asiento.Text+"'";
            comando.Connection = cn;
            MySqlDataReader reader;
            reader = comando.ExecuteReader();
            if (reader.Read())
            {
                IDAsiento.Text=reader[0].ToString();
            }
            else
            {
            }
            reader.Close();
        }
        void Boleto()
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "select count(id) from boleto where id_salida='"+lblidsalida.Text+"'";
            comando.Connection = cn;
            MySqlDataReader reader;
            reader = comando.ExecuteReader();
            if (reader.Read())
            {
                lblidboleto.Text = Convert.ToString(Convert.ToInt32(reader[0].ToString()) + 1);
            }
            else
            {
            }
            reader.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "select id,nombre,apellidos from cliente where id='" + textBox1.Text + "'";
            comando.Connection = cn;
            MySqlDataReader reader;
            reader = comando.ExecuteReader();
            if (reader.Read())
            {
                
            }
            else
            {
                obDatos = new Conexion();
                string cli = "insert into cliente(id,nombre,apellidos) values('"+textBox1.Text +"','"+textBox2.Text+"','"+textBox3.Text+"')";
                if (obDatos.insertar(cli))
                {
                    MessageBox.Show("Registro insertado");
                }
                else
                {
                    MessageBox.Show("error al insertar");
                }
            }
            reader.Close();
            obDatos = new Conexion();
            string bol = "insert into boleto(id,observacion,id_salida,id_empleado,id_cliente,id_asiento,id_bus) values('"+lblidboleto.Text+"','"+" "+"','"+lblidsalida.Text+"','"+lblidvendedor.Text+"','"+textBox1.Text+"','"+IDAsiento.Text+"','"+placa.Text+"')";
            if (obDatos.insertar(bol))
            {
                MessageBox.Show("Registro insertado");
            }
            else
            {
                MessageBox.Show("error al insertar");
            }
            
        }

    }
}
