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
            g.FillEllipse(new SolidBrush(Color.Black), 630, 610, 45, 45);
            g.FillEllipse(new SolidBrush(Color.Black), 1250, 610, 45, 45);
            g.FillEllipse(new SolidBrush(Color.Black), 1250, -10, 45, 45);
            g.FillEllipse(new SolidBrush(Color.Black), 630, -10, 45, 45);

            
            g.DrawImage(Resource1.palito, MousePosition.X, MousePosition.Y );

            label1.Text ="vx:"+balls[1].vx + "vy:" +balls[1].vy ;

            if (balls[1].vx > 0)
            {
                balls[1].vx -= (float)0.0001;
            }
            if (balls[1].vx < 0)
            {
                balls[1].vx += (float)0.0001;
            }
            if (balls[1].vy > 0)
            {
                balls[1].vy -= (float)0.0001;
            }
            if (balls[1].vy < 0)
            {
                balls[1].vy += (float)0.0001;
            }

            if (balls[0].vx > 0)
            {
                balls[0].vx -= (float)0.0001;
            }
            if (balls[0].vx < 0)
            {
                balls[0].vx += (float)0.0001;
            }
            if (balls[0].vy > 0)
            {
                balls[0].vy -= (float)0.0001;
            }
            if (balls[0].vy < 0)
            {
                balls[0].vy += (float)0.0001;
            }
            if (balls[2].vx > 0)
            {
                balls[2].vx -= (float)0.0001;
            }
            if (balls[2].vx < 0)
            {
                balls[2].vx += (float)0.0001;
            }
            if (balls[2].vy > 0)
            {
                balls[2].vy -= (float)0.0001;
            }
            if (balls[2].vy < 0)
            {
                balls[2].vy += (float)0.0001;
            }
            if (balls[3].vx > 0)
            {
                balls[3].vx -= (float)0.0001;
            }
            if (balls[3].vx < 0)
            {
                balls[3].vx += (float)0.0001;
            }
            if (balls[3].vy > 0)
            {
                balls[3].vy -= (float)0.0001;
            }
            if (balls[3].vy < 0)
            {
                balls[3].vy += (float)0.0001;
            }
            if (balls[4].vx > 0)
            {
                balls[4].vx -= (float)0.0001;
            }
            if (balls[4].vx < 0)
            {
                balls[4].vx += (float)0.0001;
            }
            if (balls[4].vy > 0)
            {
                balls[4].vy -= (float)0.0001;
            }
            if (balls[4].vy < 0)
            {
                balls[4].vy += (float)0.0001;
            }
            if (balls[5].vx > 0)
            {
                balls[5].vx -= (float)0.0001;
            }
            if (balls[5].vx < 0)
            {
                balls[5].vx += (float)0.0001;
            }
            if (balls[5].vy > 0)
            {
                balls[5].vy -= (float)0.0001;
            }
            if (balls[5].vy < 0)
            {
                balls[5].vy += (float)0.0001;
            }
            if (balls[6].vx > 0)
            {
                balls[6].vx -= (float)0.0001;
            }
            if (balls[6].vx < 0)
            {
                balls[6].vx += (float)0.0001;
            }
            if (balls[6].vy > 0)
            {
                balls[6].vy -= (float)0.0001;
            }
            if (balls[6].vy < 0)
            {
                balls[6].vy += (float)0.0001;
            }
            if (balls[7].vx > 0)
            {
                balls[7].vx -= (float)0.0001;
            }
            if (balls[7].vx < 0)
            {
                balls[7].vx += (float)0.0001;
            }
            if (balls[7].vy > 0)
            {
                balls[7].vy -= (float)0.0001;
            }
            if (balls[7].vy < 0)
            {
                balls[7].vy += (float)0.0001;
            }
            emitter.x = MousePosition.X - (emitter.Size / 2);
            emitter.y = MousePosition.Y - (emitter.Size/2);
            //PLAYER1 JUEGA CON LISAS (AMARILLAS)
            if (turno1 == true)
            {
              g.FillEllipse(new SolidBrush(Color.Wheat), MousePosition.X, MousePosition.Y, 17, 17);
                if (balls[3].radio < 5)
                {
                    if (balls[6].x > 0 && balls[7].x >0 && balls[2].x>0)
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
              g.FillEllipse(new SolidBrush(Color.Blue), MousePosition.X, MousePosition.Y, 17, 17);
                if (balls[3].radio < 5)
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


            //BALL[0] HITS THE TOP MIDDLE HOLE
            if ((balls[0].x + balls[0].radio  >= 635 && balls[0].x + balls[0].radio <= 670)  && (balls[0].y + balls[0].radio >= -10 && balls[0].y + balls[0].radio <= 50))
            {
                balls[0].x = -1000;
                balls[0].y = -3000;
                balls[0].radio = 0;
                balls[0].vx = 0;
                balls[0].vy = 0;
            }
            //BALL[0] HITS THE TOP LEFT HOLE
            if ((balls[0].x + balls[0].radio >= -10 && balls[0].x + balls[0].radio <= 45) && (balls[0].y + balls[0].radio >= -10 && balls[0].y + balls[0].radio <= 50))
            {
                balls[0].x = -1000;
                balls[0].y = -3000;
                balls[0].radio = 0;
                balls[0].vx = 0;
                balls[0].vy = 0;
            }
            //BALL[0] HITS THE TOP RIGHT HOLE
            if ((balls[0].x + balls[0].radio >= 1255 && balls[0].x + balls[0].radio <= 1295) && (balls[0].y + balls[0].radio >= -10 && balls[0].y + balls[0].radio <= 50))
            {
                balls[0].x = -1000;
                balls[0].y = -3000;
                balls[0].radio = 0;
                balls[0].vx = 0;
                balls[0].vy = 0;
            }
            //BALL[0] HITS THE BOTTOM RIGHT HOLE
            if ((balls[0].x + balls[0].radio >= 1255 && balls[0].x + balls[0].radio <= 1295) && (balls[0].y + balls[0].radio >= 630 && balls[0].y + balls[0].radio <= 675))
            {
                balls[0].x = -1000;
                balls[0].y = -3000;
                balls[0].radio = 0;
                balls[0].vx = 0;
                balls[0].vy = 0;
            }
            //BALL[0] HITS THE BOTTOM MIDDLE HOLE
            if ((balls[0].x + balls[0].radio >= 635 && balls[0].x + balls[0].radio <= 670) && (balls[0].y + balls[0].radio >= 630 && balls[0].y + balls[0].radio <= 675))
            {
                balls[0].x = -1000;
                balls[0].y = -3000;
                balls[0].radio = 0;
                balls[0].vx = 0;
                balls[0].vy = 0;
            }
            //BALL[0] HITS THE BOTTOM LEFT HOLE
            if ((balls[0].x + balls[0].radio >= -10 && balls[0].x + balls[0].radio <= 45) && (balls[0].y + balls[0].radio >= 630 && balls[0].y + balls[0].radio <= 675))
            {
                balls[0].x = -1000;
                balls[0].y = -3000;
                balls[0].radio = 0;
                balls[0].vx = 0;
                balls[0].vy = 0;
            }
            //WHITE BALL GOES THROUGH ANY HOLE
            if (((balls[1].x + balls[1].radio >= 635 && balls[1].x + balls[1].radio <= 670) && (balls[1].y + balls[1].radio >= -10 && balls[1].y + balls[1].radio <= 50))|| ((balls[1].x + balls[1].radio >= -10 && balls[1].x + balls[1].radio <= 45) && (balls[1].y + balls[1].radio >= -10 && balls[1].y + balls[1].radio <= 50))|| ((balls[1].x + balls[1].radio >= 1255 && balls[1].x + balls[1].radio <= 1295) && (balls[1].y + balls[1].radio >= -10 && balls[1].y + balls[1].radio <= 50))|| ((balls[1].x + balls[1].radio >= 1255 && balls[1].x + balls[1].radio <= 1295) && (balls[1].y + balls[1].radio >= 630 && balls[1].y + balls[1].radio <= 675))|| ((balls[1].x + balls[1].radio >= 635 && balls[1].x + balls[1].radio <= 670) && (balls[1].y + balls[1].radio >= 630 && balls[1].y + balls[1].radio <= 675))|| ((balls[1].x + balls[1].radio >= -10 && balls[1].x + balls[1].radio <= 45) && (balls[1].y + balls[1].radio >= 630 && balls[1].y + balls[1].radio <= 675)))
            {
                balls[1].x = rand.Next(PCT_CANVAS.Width);
                balls[1].y = rand.Next(PCT_CANVAS.Height);
                balls[1].vx = 0;
                balls[1].vy = 0;
            }
            //BLACK BALL GOES THROUGH ANY HOLE
            if (((balls[3].x + balls[3].radio >= 635 && balls[3].x + balls[3].radio <= 670) && (balls[3].y + balls[3].radio >= -10 && balls[3].y + balls[3].radio <= 50)) || ((balls[3].x + balls[3].radio >= -10 && balls[3].x + balls[3].radio <= 45) && (balls[3].y + balls[3].radio >= -10 && balls[3].y + balls[3].radio <= 50)) || ((balls[3].x + balls[3].radio >= 1255 && balls[3].x + balls[3].radio <= 1295) && (balls[3].y + balls[3].radio >= -10 && balls[3].y + balls[3].radio <= 50)) || ((balls[3].x + balls[3].radio >= 1255 && balls[3].x + balls[3].radio <= 1295) && (balls[3].y + balls[3].radio >= 630 && balls[3].y + balls[3].radio <= 675)) || ((balls[3].x + balls[3].radio >= 635 && balls[3].x + balls[3].radio <= 670) && (balls[3].y + balls[3].radio >= 630 && balls[3].y + balls[3].radio <= 675)) || ((balls[3].x + balls[3].radio >= -10 && balls[3].x + balls[3].radio <= 45) && (balls[3].y + balls[3].radio >= 630 && balls[3].y + balls[3].radio <= 675)))
            {
                for (int b = 0; b < balls.Count; b++)//PINTAMOS EN SECUENCIA
                {
                    balls[b].radio=0;
                    balls[b].x = -1000;
                    balls[b].y = -3000;
                    balls[b].vx = 0;
                    balls[b].vy = 0;

                }
            }
            //BALL [2] GOES THROUGH ANY HOLE
            if (((balls[2].x + balls[2].radio >= 635 && balls[2].x + balls[2].radio <= 670) && (balls[2].y + balls[2].radio >= -10 && balls[2].y + balls[2].radio <= 50)) || ((balls[2].x + balls[2].radio >= -10 && balls[2].x + balls[2].radio <= 45) && (balls[2].y + balls[2].radio >= -10 && balls[2].y + balls[2].radio <= 50)) || ((balls[2].x + balls[2].radio >= 1255 && balls[2].x + balls[2].radio <= 1295) && (balls[2].y + balls[2].radio >= -10 && balls[2].y + balls[2].radio <= 50)) || ((balls[2].x + balls[2].radio >= 1255 && balls[2].x + balls[2].radio <= 1295) && (balls[2].y + balls[2].radio >= 630 && balls[2].y + balls[2].radio <= 675)) || ((balls[2].x + balls[2].radio >= 635 && balls[2].x + balls[2].radio <= 670) && (balls[2].y + balls[2].radio >= 630 && balls[2].y + balls[2].radio <= 675)) || ((balls[2].x + balls[2].radio >= -10 && balls[2].x + balls[2].radio <= 45) && (balls[2].y + balls[2].radio >= 630 && balls[2].y + balls[2].radio <= 675)))
            {
                balls[2].x = -1000;
                balls[2].y = -3000;
                balls[2].radio = 0;
                balls[2].vx = 0;
                balls[2].vy = 0;
            }
            //BALL [4] GOES THROUGH ANY HOLE
            if (((balls[4].x + balls[4].radio >= 635 && balls[4].x + balls[4].radio <= 670) && (balls[4].y + balls[4].radio >= -10 && balls[4].y + balls[4].radio <= 50)) || ((balls[4].x + balls[4].radio >= -10 && balls[4].x + balls[4].radio <= 45) && (balls[4].y + balls[4].radio >= -10 && balls[4].y + balls[4].radio <= 50)) || ((balls[4].x + balls[4].radio >= 1255 && balls[4].x + balls[4].radio <= 1295) && (balls[4].y + balls[4].radio >= -10 && balls[4].y + balls[4].radio <= 50)) || ((balls[4].x + balls[4].radio >= 1255 && balls[4].x + balls[4].radio <= 1295) && (balls[4].y + balls[4].radio >= 630 && balls[4].y + balls[4].radio <= 675)) || ((balls[4].x + balls[4].radio >= 635 && balls[4].x + balls[4].radio <= 670) && (balls[4].y + balls[4].radio >= 630 && balls[4].y + balls[4].radio <= 675)) || ((balls[4].x + balls[4].radio >= -10 && balls[4].x + balls[4].radio <= 45) && (balls[4].y + balls[4].radio >= 630 && balls[4].y + balls[4].radio <= 675)))
            {
                balls[4].x = -1000;
                balls[4].y = -3000;
                balls[4].radio = 0;
                balls[4].vx = 0;
                balls[4].vy = 0;
            }

            //BALL [5] GOES THROUGH ANY HOLE
            if (((balls[5].x + balls[5].radio >= 635 && balls[5].x + balls[5].radio <= 670) && (balls[5].y + balls[5].radio >= -10 && balls[5].y + balls[5].radio <= 50)) || ((balls[5].x + balls[5].radio >= -10 && balls[5].x + balls[5].radio <= 45) && (balls[5].y + balls[5].radio >= -10 && balls[5].y + balls[5].radio <= 50)) || ((balls[5].x + balls[5].radio >= 1255 && balls[5].x + balls[5].radio <= 1295) && (balls[5].y + balls[5].radio >= -10 && balls[5].y + balls[5].radio <= 50)) || ((balls[5].x + balls[5].radio >= 1255 && balls[5].x + balls[5].radio <= 1295) && (balls[5].y + balls[5].radio >= 630 && balls[5].y + balls[5].radio <= 675)) || ((balls[5].x + balls[5].radio >= 635 && balls[5].x + balls[5].radio <= 670) && (balls[5].y + balls[5].radio >= 630 && balls[5].y + balls[5].radio <= 675)) || ((balls[5].x + balls[5].radio >= -10 && balls[5].x + balls[5].radio <= 45) && (balls[5].y + balls[5].radio >= 630 && balls[5].y + balls[5].radio <= 675)))
            {
                balls[5].x = -1000;
                balls[5].y = -3000;
                balls[5].radio = 0;
                balls[5].vx = 0;
                balls[5].vy = 0;
            }
            //BALL [6] GOES THROUGH ANY HOLE
            if (((balls[6].x + balls[6].radio >= 635 && balls[6].x + balls[6].radio <= 670) && (balls[6].y + balls[6].radio >= -10 && balls[6].y + balls[6].radio <= 50)) || ((balls[6].x + balls[6].radio >= -10 && balls[6].x + balls[6].radio <= 45) && (balls[6].y + balls[6].radio >= -10 && balls[6].y + balls[6].radio <= 50)) || ((balls[6].x + balls[6].radio >= 1255 && balls[6].x + balls[6].radio <= 1295) && (balls[6].y + balls[6].radio >= -10 && balls[6].y + balls[6].radio <= 50)) || ((balls[6].x + balls[6].radio >= 1255 && balls[6].x + balls[6].radio <= 1295) && (balls[6].y + balls[6].radio >= 630 && balls[6].y + balls[6].radio <= 675)) || ((balls[6].x + balls[6].radio >= 635 && balls[6].x + balls[6].radio <= 670) && (balls[6].y + balls[6].radio >= 630 && balls[6].y + balls[6].radio <= 675)) || ((balls[6].x + balls[6].radio >= -10 && balls[6].x + balls[6].radio <= 45) && (balls[6].y + balls[6].radio >= 630 && balls[6].y + balls[6].radio <= 675)))
            {
                balls[6].x = -1000;
                balls[6].y = -3000;
                balls[6].radio = 0;
                balls[6].vx = 0;
                balls[6].vy = 0;
            }
            //BALL [7] GOES THROUGH ANY HOLE
            if (((balls[7].x + balls[7].radio >= 635 && balls[7].x + balls[7].radio <= 670) && (balls[7].y + balls[7].radio >= -10 && balls[7].y + balls[7].radio <= 50)) || ((balls[7].x + balls[7].radio >= -10 && balls[7].x + balls[7].radio <= 45) && (balls[7].y + balls[7].radio >= -10 && balls[7].y + balls[7].radio <= 50)) || ((balls[7].x + balls[7].radio >= 1255 && balls[7].x + balls[7].radio <= 1295) && (balls[7].y + balls[7].radio >= -10 && balls[7].y + balls[7].radio <= 50)) || ((balls[7].x + balls[7].radio >= 1255 && balls[7].x + balls[7].radio <= 1295) && (balls[7].y + balls[7].radio >= 630 && balls[7].y + balls[7].radio <= 675)) || ((balls[7].x + balls[7].radio >= 635 && balls[7].x + balls[7].radio <= 670) && (balls[7].y + balls[7].radio >= 630 && balls[7].y + balls[7].radio <= 675)) || ((balls[7].x + balls[7].radio >= -10 && balls[7].x + balls[7].radio <= 45) && (balls[7].y + balls[7].radio >= 630 && balls[7].y + balls[7].radio <= 675)))
            {
                balls[7].x = -1000;
                balls[7].y = -3000;
                balls[7].radio = 0;
                balls[7].vx = 0;
                balls[7].vy = 0;
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

  
    }
}
