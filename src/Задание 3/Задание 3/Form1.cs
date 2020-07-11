using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Задание_3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                webBrowser1.Navigate(new Uri(openFileDialog1.FileName));
                this.Size = new Size(1331, 650);
                y.Visible = true;
                x.Visible = true;
                submit.Visible = true;
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Фетисов Максим Андреевич, ПКсп-117. Вариант 9");
        }

        private void submit_Click(object sender, EventArgs e)
        {
            try
            {
                double X = (double)x.Value;
                double Y = (double)y.Value;
                if("page1.html" == openFileDialog1.SafeFileName)
                {
                    if ((Y == X * X || Y == -X * X || X == Y * Y || X == -Y * Y) && X <= 1 && X >= -1 && Y >= -1 && Y <= 1)
                    {
                        MessageBox.Show("Точка на границе");
                        status.Text = "Точка на границе";
                    }
                    else if ((Y > X*X && (X > Y*Y || -X > Y*Y)) || (-Y > X*X &&(X > Y*Y || -X > Y*Y)))
                    {
                        MessageBox.Show("Точка в области");
                        status.Text = "Точка в области";
                    }
                    else
                    {
                        MessageBox.Show("Точка не в области");
                        status.Text = "Точка не в области";
                    }
                }
                if ("page2.html" == openFileDialog1.SafeFileName)
                {
                    if (X * X + Y * Y == 36 && X > 0 && Y > 0 || X == 0 && Y <= 6 && Y >= 3 || Y == 0 && X <= 6 && X >= 3 || Y == -X + 3 && Y > 0 && X > 0)
                    {
                        MessageBox.Show("Точка на границе");
                        status.Text = "Точка на границе";
                    }
                    else if (X * X + Y * Y < 36 && X > 0 && Y > 0 && Y > -X + 3)
                    {
                        MessageBox.Show("Точка в области");
                        status.Text = "Точка в области";
                    }
                    else
                    {
                        MessageBox.Show("Точка не в области");
                        status.Text = "Точка не в области";
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                status.Text = ex.Message;
            }
        }
    }
}
