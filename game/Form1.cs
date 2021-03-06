using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace game
{
    public partial class Form1 : Form
    {
        Random rand = new Random();
        int mouse_X, mouse_Y;
        
        //List<Sprites> list = new List<Sprites>();

        public Form1()
        {
            Graphics g = this.CreateGraphics();
            InitializeComponent();
            timer1.Start();
            timer1.Tick += Timer1_Tick;

            int rand_num;
            // Генерация карты
            for (int i = 0; i < 60; i++)
            {

                for (int z = 0; z < 60; z++)
                {
                    rand_num = rand.Next(0, 100);
                    if (rand_num <= 6)
                    {
                        Map.Add(new Ore(i, z));
                    }
                    else if (rand_num <= 8)
                    {
                        Map.Add(new Water(i, z));
                    }
                    else if (rand_num <= 12)
                    {
                        Map.Add(new Sand(i, z));
                    }
                    else
                    {
                        Map.Add(new Grass(i, z));
                    }

                }
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            //Invalidate();
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            mouse_X = e.X;
            mouse_Y = e.Y;
            Invalidate();
        }

        private void paint_vis(object sender, PaintEventArgs e)
        {
            //map.draw_map(e);


            Factory a = new Factory(mouse_X, mouse_Y);

            this.Font = new Font("Times New Roman", 30,
            FontStyle.Bold, GraphicsUnit.Pixel);

            a.draw_building(e);
        }
    }
}