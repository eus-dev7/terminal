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
    public partial class Contraseña : Form
    {
        public Contraseña()
        {
            InitializeComponent();
        }
        public static MySqlConnection cn;
        private void button1_Click(object sender, EventArgs e)
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
            //Recupra datos del vendedor.
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = "select ci,nombre,apellidos,contraseña,cargo from empleado where ci=" + textBox1.Text;
            comando.Connection = cn;
            MySqlDataReader reader;
            reader = comando.ExecuteReader();
            if (reader.Read())
            {
                //een este if se evalua.
                //1ª Si el usuario ingresado es igual al ID del vendedor recuperado
                //2ª Si la contraseña es igual ala contraseña del vendedor recuperado antes
                //entra
                //Sino se va al else.
                if (textBox1.Text == reader[0].ToString() && textBox2.Text == reader[3].ToString())
                {
                    //Sie entra muestra vienvenido al sistema.
                    MessageBox.Show("Bienvenido al sistema");
                    //LLamamos al form vendedor.
                    Principal Form_Vend = new Principal();
                    //en el form vendedor en el label del usuario muestro nombre y apellidos.
                    Form_Vend.lblusuario.Text = reader[1].ToString() + " " + reader[2].ToString();
                    //y aqui muestro el CI del usuario.
                    Form_Vend.lbl_civendedor.Text = reader[0].ToString();
                    //Luego aqui lanzo al formulario donde regisatraremos la nueva venta.
                    //Donnde yo le llame al formulario Vendedor();
                    this.Hide();
                    Form_Vend.ShowDialog();

                }
                //en este else muestra acceso denegado.
                else
                {
                    MessageBox.Show("Acceso denegado...!!!");
                    //Y limpio los textboxs1,2 del usuario y contraseña;
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
            else
            {
                MessageBox.Show("error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Cuando ago click en salir.
            try
            {
                this.Close();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

    }
}
