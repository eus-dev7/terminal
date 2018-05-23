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
    public partial class BLeito : Form
    {
        System.Windows.Forms.Button[] arreglo = new System.Windows.Forms.Button[50];
        public BLeito()
        {
            InitializeComponent();
        }

        private void BLeito_Load(object sender, EventArgs e)
        {
            rectangleShape1.Visible = true;
            cargarleito();
        }
        void cargarleito()
        {
            int x = 160;
            int y = 64;
            for (int p = 0; p < 14; p++)
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
            y = y + 85;
            x = 160;
            for (int p = 0; p < 14; p++)
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
            x = 160;
            for (int p = 0; p < 14; p++)
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
            MessageBox.Show(btn.Text);
            btn.Image = Image.FromFile(@"C:\Users\MELO\Desktop\Proyecto BD\Terminal2\Terminal2\Resources\seleccionado.png");
        }
    }
}
