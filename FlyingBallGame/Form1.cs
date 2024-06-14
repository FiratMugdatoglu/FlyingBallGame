using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlyingBallGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int yerX = 5, yerY = 5, can = 3;
        
        private void CarpmaOlayı()
        {
            //label3 carpma
            if(ball.Top<=label3.Bottom)
            {
                yerY = yerY * -1;
                
            }

            //kontrole çarpma olayı
            if(ball.Bottom>=control.Top && ball.Left>=control.Left&&ball.Right<=control.Right)
            {
                yerY=yerY * -1;

            }else if(ball.Right>=label4.Left){
                //sağ kenara çarpma olayı
                yerX = yerX * -1;

            }else if (ball.Left <= label1.Right)
            {
                //sol kenara çarpma olayı
                yerX = yerX * -1;
            }
        }

        private void yanmaOlayı(object sender,EventArgs e)
        {
           
            if (ball.Top >= label4.Bottom)
            {
                if (can > 0)
                {
                    timer1.Stop();
                    can--;
                    MessageBox.Show("Yandınız kalan can: " + can);
                    Form1_Load(sender, e);

                }
                if(can==0)
                {
                    timer1.Stop();
                    MessageBox.Show("Yandınız Game Over" ,"", MessageBoxButtons.OK);
                }
            }

            label2.Text = can.ToString();
        }

        private void topBasa()
        {
            ball.Location=new Point(188 , 202);
        }

        private void control_MouseMove(object sender, MouseEventArgs e)
        {
            control.Left = e.X;
        }

      
        private void timer1_Tick(object sender, EventArgs e)
        {
            CarpmaOlayı();
            yanmaOlayı(sender,e);
            ball.Location = new Point(ball.Location.X+yerX,ball.Location.Y+yerY);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            topBasa();
            timer1.Enabled = true;
            
        }
    }
}
