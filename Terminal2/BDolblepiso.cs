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
    public partial class BDolblepiso : Form
    {
        System.Windows.Forms.Button[] arreglo = new System.Windows.Forms.Button[72];
        public BDolblepiso()
        {
            InitializeComponent();
        }
        int s = 1;
        private Conexion obDatos;
        MySqlConnection cn;
        private void BDolblepiso_Load(object sender, EventArgs e)
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
            leitodoblepiso.Visible = true;
            cargarleitodoblepiso();
        }
       
        void cargarleitodoblepiso()
        {
            int p = 0;
            int x = 190;
            int y = 95;
            for (p=0; p <12; p++)
            {
                arreglo[p] = new Button();
                arreglo[p].Size = new System.Drawing.Size(40, 40);
                //arreglo[i].BackColor = Color.Red;
                arreglo[p].Image = Image.FromFile(@"C:\Users\MELO\Desktop\Proyecto BD\Terminal2\Terminal2\Resources\libre.png");
                arreglo[p].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                arreglo[p].Location = new System.Drawing.Point(x, y);
                arreglo[p].Text = "";
                arreglo[p].Click += new System.EventHandler(this.buttons_Click);
                this.Controls.AddRange(new System.Windows.Forms.Control[] { arreglo[p] });
                x = x + 45;
            }
            y = y + 80;
            x = 190;
            for (p=12; p < 24; p++)
            {
                arreglo[p] = new Button();
                arreglo[p].Size = new System.Drawing.Size(40, 40);
                //arreglo[i].BackColor = Color.Red;
                arreglo[p].Image = Image.FromFile(@"C:\Users\MELO\Desktop\Proyecto BD\Terminal2\Terminal2\Resources\libre.png");
                arreglo[p].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                arreglo[p].Location = new System.Drawing.Point(x, y);
                arreglo[p].Text = "";
                arreglo[p].Click += new System.EventHandler(this.buttons_Click);
                this.Controls.AddRange(new System.Windows.Forms.Control[] { arreglo[p] });
                x = x + 45;
            }
            y = y + 45;
            x = 190;
            for (p=24; p <36; p++)
            {
                arreglo[p] = new Button();
                arreglo[p].Size = new System.Drawing.Size(40, 40);
                //arreglo[i].BackColor = Color.Red;
                arreglo[p].Image = Image.FromFile(@"C:\Users\MELO\Desktop\Proyecto BD\Terminal2\Terminal2\Resources\libre.png");
                arreglo[p].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                arreglo[p].Location = new System.Drawing.Point(x, y);
                arreglo[p].Text = "";
                arreglo[p].Click += new System.EventHandler(this.buttons_Click);
                this.Controls.AddRange(new System.Windows.Forms.Control[] { arreglo[p] });
                x = x + 45;
            }
            y = y + 124;
            x = 190;
            for (p=36; p <48; p++)
            {
                arreglo[p] = new Button();
                arreglo[p].Size = new System.Drawing.Size(40, 40);
                //arreglo[i].BackColor = Color.Red;
                arreglo[p].Image = Image.FromFile(@"C:\Users\MELO\Desktop\Proyecto BD\Terminal2\Terminal2\Resources\libre.png");
                arreglo[p].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                arreglo[p].Location = new System.Drawing.Point(x, y);
                arreglo[p].Text = "";
                arreglo[p].Click += new System.EventHandler(this.buttons_Click);
                this.Controls.AddRange(new System.Windows.Forms.Control[] { arreglo[p] });
                x = x + 45;
            }
            y = y + 80;
            x = 190;
            for (p=48; p < 60; p++)
            {
                arreglo[p] = new Button();
                arreglo[p].Size = new System.Drawing.Size(40, 40);
                //arreglo[i].BackColor = Color.Red;
                arreglo[p].Image = Image.FromFile(@"C:\Users\MELO\Desktop\Proyecto BD\Terminal2\Terminal2\Resources\libre.png");
                arreglo[p].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                arreglo[p].Location = new System.Drawing.Point(x, y);
                arreglo[p].Text = "";
                arreglo[p].Click += new System.EventHandler(this.buttons_Click);
                this.Controls.AddRange(new System.Windows.Forms.Control[] { arreglo[p] });
                x = x + 45;
            }
            y = y + 45;
            x = 190;
            for (p=60; p <72; p++)
            {
                arreglo[p] = new Button();
                arreglo[p].Size = new System.Drawing.Size(40, 40);
                //arreglo[i].BackColor = Color.Red;
                arreglo[p].Image = Image.FromFile(@"C:\Users\MELO\Desktop\Proyecto BD\Terminal2\Terminal2\Resources\libre.png");
                arreglo[p].BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
                arreglo[p].Location = new System.Drawing.Point(x, y);
                arreglo[p].Text = "";
                arreglo[p].Click += new System.EventHandler(this.buttons_Click);
                this.Controls.AddRange(new System.Windows.Forms.Control[] { arreglo[p] });
                x = x + 45;
            }
        }
        private void buttons_Click(Object sender1, EventArgs e1)
        {
            Button btn = sender1 as Button;
            btn.Text = s.ToString() ;
            btn.Image = Image.FromFile(@"C:\Users\MELO\Desktop\Proyecto BD\Terminal2\Terminal2\Resources\seleccionado.png");
            s = s + 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            obDatos = new Conexion();
            string emp = "insert into empleado(ci,nombre,apellidos,cargo,telefono) values('" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','"+label9.Text+"','"+textBox6.Text+"')";
            if (obDatos.insertar(emp))
            {
                MessageBox.Show("Registro insertado");
            }
            else
            {
                MessageBox.Show("error al insertar");
            }
            emp= "insert into empleado(ci,nombre,apellidos,cargo,telefono) values('" + textBox10.Text + "','" + textBox9.Text + "','" + textBox8.Text + "','" + label10.Text + "','" + textBox7.Text + "')";
            if (obDatos.insertar(emp))
            {
                MessageBox.Show("Registro insertado");
            }
            else
            {
                MessageBox.Show("error al insertar");
            }
            emp = "insert into empleado(ci,nombre,apellidos,cargo,telefono) values('" + textBox14.Text + "','" + textBox13.Text + "','" + textBox12.Text + "','" + label17.Text + "','" + textBox11.Text + "')";
            if (obDatos.insertar(emp))
            {
                MessageBox.Show("Registro insertado");
            }
            else
            {
                MessageBox.Show("error al insertar");
            }
            string bus = "insert into bus(placa,nombre,id_conductor,id_relevo,id_ayudante) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + label10.Text + "','" + textBox14.Text + "')";
            if (obDatos.insertar(bus))
            {
                MessageBox.Show("Registro insertado");
            }
            else
            {
                MessageBox.Show("error al insertar");
            }
            int n = 0;
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "select count(n) from asiento";
            comando.Connection =cn;
            MySqlDataReader reader;
            reader = comando.ExecuteReader();
            if (reader.Read())
            {
                n = Convert.ToInt32(reader[0].ToString())+2;
            }
            else
            {

            }
            string det="";
            reader.Close();
            for (int i = 0; i <= 71; i++)
            {
                if ((i >= 0 && i <= 11) || (i >= 24 && i <= 35) || (i >= 36 && i <= 47) || (i >= 60 && i <= 72))
                {
                    det = "v";
                }
                else
                {
                    det = "p";
                }
                string asiento = "insert into asiento(n,numero,detalle,x,y,id_bus) values('" + n + "','" + arreglo[i].Text + "','" + det + "','" + arreglo[i].Left.ToString() + "','" + arreglo[i].Top.ToString()+"','"+ textBox1.Text+ "')";
                if (obDatos.insertar(asiento))
                {
                    MessageBox.Show("Registro insertado");
                }
                else
                {
                    MessageBox.Show("error al insertar");
                }
                n = n + 1;
            }
        }
    }
}
