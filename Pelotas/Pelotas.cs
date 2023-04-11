using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace Pelotas
{
    public partial class Pelotas : Form
    {
        static List<Pelota> balls;
        static Bitmap bmp;
        static Graphics g;
        static Emitter emitter;
        static Random rand = new Random();
        static float deltaTime;
        bool turno1 = true;
        bool turno2 = false;
        int poder;

        public Pelotas()
        {
            InitializeComponent();
        }

        private void Init()
        {
            if (PCT_CANVAS.Width == 0)
                return;

            balls = new List<Pelota>();
            bmp = new Bitmap(PCT_CANVAS.Width, PCT_CANVAS.Height);
            g = Graphics.FromImage(bmp);
            deltaTime = 1;
            PCT_CANVAS.Image = bmp;
            emitter = new Emitter(MousePosition.X, MousePosition.Y, 20);


           


            for (int b = 0; b < 8; b++)
                balls.Add(new Pelota(rand, PCT_CANVAS.Size, b, emitter));
            balls[1].x = 900;
        }

        private void Pelotas_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Pelotas_SizeChanged(object sender, EventArgs e)
        {
            Init();
        }



        private void TIMER_Tick(object sender, EventArgs e)
        {
            g.Clear(Color.DarkGreen);
            g.FillEllipse(new SolidBrush(Color.Black), -10, -10, 45, 45);
            g.FillEllipse(new SolidBrush(Color.Black), -10, 610, 45, 45);
            g.FillEllipse(new SolidBrush(Color.Black), 600, -10, 45, 45);
            g.FillEllipse(new SolidBrush(Color.Black), 1250, -10, 45, 45);
            g.FillEllipse(new SolidBrush(Color.Black), 1250, 610, 50, 50);
            g.FillEllipse(new SolidBrush(Color.Black), 600, 610, 45, 45);

            
            g.DrawImage(Resource1.palito, MousePosition.X, MousePosition.Y );

            if (balls[1].radio <= 1)
            {
                balls[1].x = rand.Next(PCT_CANVAS.Width);
                balls[1].y = rand.Next(PCT_CANVAS.Height);
                balls[1].radio = 20;
                balls[1].vx = 0;
                balls[1].vy = 0;


            }

            label1.Text ="vx:"+balls[1].vx + "vy:" +balls[1].vy ;

            for (int i = 0; i < balls.Count; i++)
            {
                if (balls[i].vx > 0)
                {
                    balls[i].vx -= (float)0.0001;
                }
                if (balls[i].vx < 0)
                {
                    balls[i].vx += (float)0.0001;
                }
                if (balls[i].vy > 0)
                {
                    balls[i].vy -= (float)0.0001;
                }
                if (balls[i].vy < 0)
                {
                    balls[i].vy += (float)0.0001;
                }
            }

            emitter.x = MousePosition.X - (emitter.Size / 2);
            emitter.y = MousePosition.Y - (emitter.Size/2);
            //PLAYER1 JUEGA CON LISAS (AMARILLAS)
            //PLAYER1 JUEGA CON LISAS (AMARILLAS)
            if (turno1 == true)
            {
                g.FillEllipse(new SolidBrush(Color.Yellow), MousePosition.X, MousePosition.Y, 17, 17);
                if (balls[3].radio < 5)
                {
                    if (balls[0].x > 0 && balls[4].x > 0 && balls[5].x > 0)
                    {
                        g.DrawImage(Resource1.WIN, 0, 0);
                    }
                    else
                    {
                        g.DrawImage(Resource1.lose, 0, 0);
                    }
                }
            }

            //PLAYER2 JUEGA CON RAYADAS (ROJAS)
            if (turno2 == true)
            {
                g.FillEllipse(new SolidBrush(Color.Red), MousePosition.X, MousePosition.Y, 17, 17);
                if (balls[3].radio < 2)
                {
                    if (balls[6].x > 0 && balls[7].x > 0 && balls[2].x > 0)
                    {
                        g.DrawImage(Resource1.WIN, 0, 0);
                    }
                    else
                    {
                        g.DrawImage(Resource1.lose, 0, 0);
                    }
                }
            }



            ImageAttributes atributosImagen = new ImageAttributes();

            Parallel.For(0, balls.Count, b =>//ACTUALIZAMOS EN PARALELO
            {
              Pelota P;
            balls[b].Update(deltaTime, balls, emitter);
            P = balls[b];
            });

            Pelota p;
            for (int b = 0; b < balls.Count; b++)//PINTAMOS EN SECUENCIA
            {
              p = balls[b];
                g.FillEllipse(new SolidBrush(p.c), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
                
            }
            //la blanca
            p = balls[1];
            g.FillEllipse(new SolidBrush(Color.White), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            //La negra
            p = balls[3];
            g.FillEllipse(new SolidBrush(Color.Black), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            //g.DrawImage((Resource1.negra), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);           
            //RAYADA 1
            p = balls[0];
            g.FillEllipse(new SolidBrush(Color.Red), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            //g.DrawImage((Resource1.rayada1), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            //RAYADA2
            p = balls[4];
            g.FillEllipse(new SolidBrush(Color.Red), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            //g.DrawImage((Resource1.pelota1), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            //RAYADA3
            p = balls[5];
            //g.DrawImage((Resource1._9), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            g.FillEllipse(new SolidBrush(Color.Red), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            //LISA1
            p = balls[6];
            g.FillEllipse(new SolidBrush(Color.Yellow), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            //g.DrawImage((Resource1.bola12), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            //LISA2
            p = balls[7];
            g.FillEllipse(new SolidBrush(Color.Yellow), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            //g.DrawImage((Resource1.bola11), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            //LISA3
            p = balls[2];
            g.FillEllipse(new SolidBrush(Color.Yellow), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);
            //g.DrawImage((Resource1._6), p.x - p.radio, p.y - p.radio, p.radio * 2, p.radio * 2);


            for (int i = 0; i < balls.Count; i++)
            {
                // Check if ball i hits any of the holes
                if ((balls[i].x + balls[i].radio >= 635 && balls[i].x + balls[i].radio <= 670) && (balls[i].y + balls[i].radio >= -10 && balls[i].y + balls[i].radio <= 50))
                {
                    balls[i].x = -1000;
                    balls[i].y = -3000;
                    balls[i].radio = 0;
                    balls[i].vx = 0;
                    balls[i].vy = 0;
                }
                else if ((balls[i].x + balls[i].radio >= -10 && balls[i].x + balls[i].radio <= 45) && (balls[i].y + balls[i].radio >= -10 && balls[i].y + balls[i].radio <= 50))
                {
                    balls[i].x = -1000;
                    balls[i].y = -3000;
                    balls[i].radio = 0;
                    balls[i].vx = 0;
                    balls[i].vy = 0;
                }
                else if ((balls[i].x + balls[i].radio >= 1255 && balls[i].x + balls[i].radio <= 1295) && (balls[i].y + balls[i].radio >= -10 && balls[i].y + balls[i].radio <= 50))
                {
                    balls[i].x = -1000;
                    balls[i].y = -3000;
                    balls[i].radio = 0;
                    balls[i].vx = 0;
                    balls[i].vy = 0;
                }
                else if ((balls[i].x + balls[i].radio >= 1255 && balls[i].x + balls[i].radio <= 1295) && (balls[i].y + balls[i].radio >= 630 && balls[i].y + balls[i].radio <= 675))
                {
                    balls[i].x = -1000;
                    balls[i].y = -3000;
                    balls[i].radio = 0;
                    balls[i].vx = 0;
                    balls[i].vy = 0;
                }
                else if ((balls[i].x + balls[i].radio >= 635 && balls[i].x + balls[i].radio <= 670) && (balls[i].y + balls[i].radio >= 630 && balls[i].y + balls[i].radio <= 675))
                {
                    balls[i].x = -1000;
                    balls[i].y = -3000;
                    balls[i].radio = 0;
                    balls[i].vx = 0;
                    balls[i].vy = 0;
                }
                else if ((balls[i].x + balls[i].radio >= -10 && balls[i].x + balls[i].radio <= 45) && (balls[i].y + balls[i].radio >= 630 && balls[i].y + balls[i].radio <= 675))
                {
                    balls[i].x = -1000;
                    balls[i].y = -3000;
                    balls[i].radio = 0;
                    balls[i].vx = 0;
                    balls[i].vy = 0;
                }
                
            }


            PCT_CANVAS.Invalidate();
            deltaTime += .1f;
        }

        private void firstplayer_Click(object sender, EventArgs e)
        {
            turno1 = true;
            turno2 = false;
        }

        private void secondplayer_Click(object sender, EventArgs e)
        {
            turno2 = true;
            turno1 = true;
        }

        private void PCT_CANVAS_Click(object sender, EventArgs e)
        {

        }
    }
}
