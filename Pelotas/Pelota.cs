using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pelotas
{
    public class Pelota
    {
        int index;
        Size space;
        public Color c;
        // Variables de posición
        public float x;
        public float y;


        // Variables de velocidad
        public float vx;
        public float vy;

        // Variable de radio
        public float radio, radiob;


        // Constructor
        public Pelota(Random rand,Size size, int index, Emitter emitter)
        {
            this.radio  = rand.Next(20, 20);
            this.x      = rand.Next(450 ,470);
            this.y      = rand.Next(300,380 );           
            c           = Color.FromArgb(rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            // Velocidades iniciales
            this.vx = /*rand.Next(0,0);*/rand.Next(0,0);
            this.vy = /*rand.Next(0,0);*/rand.Next(0,0);

            this.index = index;
            space = size;
        }
  
        // Método para actualizar la posición de la pelota en función de su velocidad
        public void Update(float deltaTime, List<Pelota> balls,Emitter emitter)
        {
            for (int b = index + 1; b < balls.Count; b++)
            {
                CollisionMAMALONA(balls[b], balls[1], emitter);
            }

            if ((x - radio) <= 0 || (x + radio) >= space.Width)
            {
                if (x - radio <= 0)
                    x = radio + 3;
                else
                    x = space.Width - radio-3;
                    
                vx *= -.5f;
                vy *= .75f;
            }
            if ((y - radio) <= 0 || (y + radio) >= space.Height)
            {
                if (y - radio<=  0)
                    y = radio + 3;
                else
                    y = space.Height - radio-3;

                vx *=  .75f;
                vy *= -.55f;
            }

            this.x += this.vx * deltaTime;
            this.y += this.vy * deltaTime;
        }

        public void Collisionfake(Pelota otraPelota, Pelota bolablanca, Emitter emitter)
        {
            float distancia = (float)Math.Sqrt(Math.Pow((otraPelota.x - this.x), 2) + Math.Pow((otraPelota.y - this.y), 2));

            if (distancia < (this.radio + otraPelota.radio))//ESTO SIGNIFICA COLISIÓN...
            {
                // Calculamos las velocidades finales de cada pelota en función de su masa y velocidad inicial
                float masaTotal = this.radio + otraPelota.radio;
                float masaRelativa = this.radio / masaTotal;
                float angulo = (float)Math.Atan2(otraPelota.y - this.y, otraPelota.x - this.x);
                float factorDeReduccion = 0.07f;

                float v1fx = this.vx - masaRelativa * (this.vx - otraPelota.vx) * (float)Math.Cos(angulo) * factorDeReduccion;
                float v1fy = this.vy - masaRelativa * (this.vy - otraPelota.vy) * (float)Math.Sin(angulo) * factorDeReduccion;

                float v2fx = otraPelota.vx - masaRelativa * (otraPelota.vx - this.vx) * (float)Math.Cos(angulo) * factorDeReduccion;
                float v2fy = otraPelota.vy - masaRelativa * (otraPelota.vy - this.vy) * (float)Math.Sin(angulo) * factorDeReduccion;



                // Actualizamos las velocidades de las pelotas
                this.vx = -v1fx;     // -----AQUI CAMBIAMOS EL ANGULO---------
                this.vy = -v1fy;     // -----AQUI CAMBIAMOS EL ANGULO--------------
                otraPelota.vx = -v2fx;//-----AQUI CAMBIAMOS EL ANGULO----------------------
                otraPelota.vy = -v2fy;//-----AQUI CAMBIAMOS EL ANGULO----------------------
                //this.vx = v1fx;     // -----AQUI CAMBIAMOS EL ANGULO---------
                //this.vy = v1fy;     // -----AQUI CAMBIAMOS EL ANGULO--------------
                //otraPelota.vx = v2fx;//-----AQUI CAMBIAMOS EL ANGULO----------------------
                //otraPelota.vy = v2fy;

                //


                // Movemos las pelotas para evitar que se superpongan

                float distanciaOverlap = (this.radio + otraPelota.radio) - distancia;
                float dx = (this.x - otraPelota.x) / distancia;
                float dy = (this.y - otraPelota.y) / distancia;

                this.x += dx * distanciaOverlap / 2f;
                this.y += dy * distanciaOverlap / 2f;

                otraPelota.x -= dx * distanciaOverlap / 2f;
                otraPelota.y -= dy * distanciaOverlap / 2f;
            }



            float distanciataco = (float)Math.Sqrt(Math.Pow((emitter.PosX - otraPelota.x), 2) + Math.Pow((emitter.PosY - otraPelota.y), 2));

            if (distanciataco < (otraPelota.radio + emitter.Size))
            {

                float masaTotaltaco = otraPelota.radio + emitter.Size;
                float masaRelativataco = otraPelota.radio / masaTotaltaco;


                float angulotaco = (float)Math.Atan2(emitter.PosY - otraPelota.y, emitter.PosX - otraPelota.x);
                float factorDeReducciontaco = 0.007f;

                float v1fx1 = otraPelota.vx - masaRelativataco * (otraPelota.vx - 100) * (float)Math.Cos(angulotaco) * factorDeReducciontaco;
                float v1fy1 = otraPelota.vy - masaRelativataco * (otraPelota.vy - 100) * (float)Math.Sin(angulotaco) * factorDeReducciontaco;

                

                

                float v2fx1 = 10 - masaRelativataco * (10 - otraPelota.vx) / 10000;
                float v2fy1 = 10 - masaRelativataco * (10 - otraPelota.vy) / 10000;


                otraPelota.vx = v1fx1;
                otraPelota.vy = v1fy1;

                float distanciaOverlaptaco = (otraPelota.radio + emitter.Size) - distanciataco;
                float dx = (otraPelota.x - emitter.PosX) / distanciataco;
                float dy = (otraPelota.y - emitter.PosY) / distanciataco;

                otraPelota.x += dx * distanciaOverlaptaco / 2f;
                otraPelota.y += dy * distanciaOverlaptaco / 2f;


            }


        }



        // Método para manejar colisiones entre pelotas
        public void Collision(Pelota otraPelota,Pelota bolablanca, Emitter emitter)
        {
            float distancia = (float)Math.Sqrt(Math.Pow((otraPelota.x - this.x), 2) + Math.Pow((otraPelota.y - this.y), 2));

            if (distancia < (this.radio + otraPelota.radio))//ESTO SIGNIFICA COLISIÓN...
            {
                // Calculamos las velocidades finales de cada pelota en función de su masa y velocidad inicial
                float masaTotal = this.radio + otraPelota.radio;
                float masaRelativa = this.radio / masaTotal;

                float v1fx = this.vx - masaRelativa * (this.vx - otraPelota.vx) / 10;
                float v1fy = this.vy - masaRelativa * (this.vy - otraPelota.vy) / 10;

                float v2fx = otraPelota.vx - masaRelativa * (otraPelota.vx - this.vx) / 10;
                float v2fy = otraPelota.vy - masaRelativa * (otraPelota.vy - this.vy) / 10;

                // Actualizamos las velocidades de las pelotas
                this.vx = -v1fx;     // -----AQUI CAMBIAMOS EL ANGULO---------
                this.vy = -v1fy;     // -----AQUI CAMBIAMOS EL ANGULO--------------
                otraPelota.vx = -v2fx;//-----AQUI CAMBIAMOS EL ANGULO----------------------
                otraPelota.vy = -v2fy;//-----AQUI CAMBIAMOS EL ANGULO----------------------
                //this.vx = v1fx;     // -----AQUI CAMBIAMOS EL ANGULO---------
                //this.vy = v1fy;     // -----AQUI CAMBIAMOS EL ANGULO--------------
                //otraPelota.vx = v2fx;//-----AQUI CAMBIAMOS EL ANGULO----------------------
                //otraPelota.vy = v2fy;

                //


                // Movemos las pelotas para evitar que se superpongan

                float distanciaOverlap = (this.radio + otraPelota.radio) - distancia;
                float dx = (this.x - otraPelota.x) / distancia;
                float dy = (this.y - otraPelota.y) / distancia;

                this.x += dx * distanciaOverlap / 2f;
                this.y += dy * distanciaOverlap / 2f;

                otraPelota.x -= dx * distanciaOverlap / 2f;
                otraPelota.y -= dy * distanciaOverlap / 2f;
            }



            float distanciataco = (float)Math.Sqrt(Math.Pow((emitter.PosX - bolablanca.x), 2) + Math.Pow((emitter.PosY - bolablanca.y), 2));

            if (distanciataco < (bolablanca.radio + emitter.Size))
            {

                float masaTotaltaco = bolablanca.radio + emitter.Size;
                float masaRelativataco = bolablanca.radio / masaTotaltaco;

                float v1fx = bolablanca.vx - masaRelativataco * (bolablanca.vx - 10) / 100;
                float v1fy = bolablanca.vy - masaRelativataco * (bolablanca.vy - 10) / 100;

                float v2fx = 10 - masaRelativataco * (10 - bolablanca.vx) / 100;
                float v2fy = 10 - masaRelativataco * (10 - bolablanca.vy) / 100;


                bolablanca.vx = v1fx;
                bolablanca.vy = v1fy;

                float distanciaOverlaptaco = (bolablanca.radio + emitter.Size) - distanciataco;
                float dx = (bolablanca.x - emitter.PosX) / distanciataco;
                float dy = (bolablanca.y - emitter.PosY) / distanciataco;

                bolablanca.x += dx * distanciaOverlaptaco / 2f;
                bolablanca.y += dy * distanciaOverlaptaco / 2f;


            }


        }

        public void CollisionMAMALONA(Pelota otraPelota, Pelota bolablanca, Emitter emitter)
        {
            float distanciaX = otraPelota.x - this.x;
            float distanciaY = otraPelota.y - this.y;
            float distancia = (float)Math.Sqrt(distanciaX * distanciaX + distanciaY * distanciaY);

            if (distancia < (this.radio + otraPelota.radio))//ESTO SIGNIFICA COLISIÓN...
            {
                // Calculamos las velocidades finales de cada pelota en función de su masa y velocidad inicial
                float masaTotal = this.radio + otraPelota.radio;
                float masaRelativa = this.radio / masaTotal;

                // Componentes de velocidad en la dirección del choque
                float v1fParalela = ((this.vx * distanciaX) + (this.vy * distanciaY)) / distancia;
                float v2fParalela = ((otraPelota.vx * distanciaX) + (otraPelota.vy * distanciaY)) / distancia;

                // Componentes de velocidad en la dirección perpendicular al choque
                float v1fPerpendicular = ((this.vx * distanciaY) - (this.vy * distanciaX)) / distancia;
                float v2fPerpendicular = ((otraPelota.vx * distanciaY) - (otraPelota.vy * distanciaX)) / distancia;

                // Velocidades finales en la dirección del choque
                float v1fx = ((masaRelativa * (otraPelota.radio - this.radio) * v1fParalela) + ((1 + masaRelativa) * this.radio * v2fParalela)) / masaTotal;
                float v2fx = ((masaRelativa * (this.radio - otraPelota.radio) * v2fParalela) + ((1 + masaRelativa) * otraPelota.radio * v1fParalela)) / masaTotal;

                // Velocidades finales en la dirección perpendicular al choque
                float v1fy = v1fPerpendicular;
                float v2fy = v2fPerpendicular;

                // Actualizamos las velocidades de las pelotas
                this.vx = v1fx * distanciaX / distancia + v1fy * distanciaY / distancia;
                this.vy = v1fx * distanciaY / distancia - v1fy * distanciaX / distancia;

                otraPelota.vx = v2fx * distanciaX / distancia + v2fy * distanciaY / distancia;
                otraPelota.vy = v2fx * distanciaY / distancia - v2fy * distanciaX / distancia;

                // Movemos las pelotas para evitar que se superpongan
                float distanciaOverlap = (this.radio + otraPelota.radio) - distancia;
                float dx = (this.x - otraPelota.x) / distancia;
                float dy = (this.y - otraPelota.y) / distancia;

                this.x += dx * distanciaOverlap / 2f;
                this.y += dy * distanciaOverlap / 2f;

                otraPelota.x -= dx * distanciaOverlap / 2f;
                otraPelota.y -= dy * distanciaOverlap / 2f;
            }

            //float distanciataco = (float)Math.Sqrt(Math.Pow((emitter.PosX - bolablanca.x), 2) + Math.Pow((emitter.PosY - bolablanca.y), 2));

            float distanciaXtaco = emitter.PosX - bolablanca.x;
            float distanciaYtaco = emitter.PosY - bolablanca.y;
            float distanciataco = (float)Math.Sqrt(distanciaXtaco * distanciaXtaco + distanciaYtaco * distanciaYtaco);


            //NO ORGINALES 
            /* float distanciaXtaco = bolablanca.x - emitter.PosX;
             float distanciaYtaco = bolablanca.y - emitter.PosX;

             float distanciataco = (float)Math.Sqrt(distanciaXtaco * distanciaXtaco + distanciaYtaco * distanciaYtaco); */


            if (distanciataco < (bolablanca.radio + emitter.Size))
            {


                float v1fParalela = ((bolablanca.vx * distanciaXtaco) + (bolablanca.vy * distanciaYtaco)) / distanciataco;
                float v1fPerpendicular = ((bolablanca.vy * distanciaXtaco) - (bolablanca.vx * distanciaYtaco)) / distanciataco;
                float v2fParalela = (((float)0.2 * distanciaXtaco) + ((float)0.2 * distanciaYtaco)) / distanciataco;
                float v2fPerpendicular = (((float)0.2 * distanciaXtaco) - ((float)0.2 * distanciaYtaco)) / distanciataco;

                //bolablanca.vx = v1fParalela + v2fParalela;
                //bolablanca.vy = v1fPerpendicular + v2fPerpendicular;

                bolablanca.vx = v1fPerpendicular;
                bolablanca.vy = v2fParalela;

                float distanciaOverlaptaco = (bolablanca.radio + emitter.Size) - distanciataco;
                float dx = (bolablanca.x - emitter.PosX) / distanciataco;
                float dy = (bolablanca.y - emitter.PosY) / distanciataco;

                bolablanca.x += dx * distanciaOverlaptaco / 2f;
                bolablanca.y += dy * distanciaOverlaptaco / 2f;

                distanciaXtaco = 0;
                distanciaYtaco = 0;
                distanciataco = 0;
                v1fParalela = 0;
                v1fPerpendicular = 0;
                v2fParalela = 0;
                v2fPerpendicular = 0;
            }
        }
        public void CollisionMMLN(Pelota otraPelota, Pelota bolablanca, Emitter emitter)
        {
            float distanciaX = otraPelota.x - this.x;
            float distanciaY = otraPelota.y - this.y;
            float distancia = (float)Math.Sqrt(distanciaX * distanciaX + distanciaY * distanciaY);

            if (distancia < (this.radio + otraPelota.radio))//ESTO SIGNIFICA COLISIÓN...
            {
                // Calculamos las velocidades finales de cada pelota en función de su masa y velocidad inicial
                float masaTotal = this.radio + otraPelota.radio;
                float masaRelativa = this.radio / masaTotal;

                // Componentes de velocidad en la dirección del choque
                float v1fParalela = ((this.vx * distanciaX) + (this.vy * distanciaY)) / distancia;
                float v2fParalela = ((otraPelota.vx * distanciaX) + (otraPelota.vy * distanciaY)) / distancia;

                // Componentes de velocidad en la dirección perpendicular al choque
                float v1fPerpendicular = ((this.vx * distanciaY) - (this.vy * distanciaX)) / distancia;
                float v2fPerpendicular = ((otraPelota.vx * distanciaY) - (otraPelota.vy * distanciaX)) / distancia;

                // Velocidades finales en la dirección del choque
                float v1fx = ((masaRelativa * (otraPelota.radio - this.radio) * v1fParalela) + ((1 + masaRelativa) * this.radio * v2fParalela)) / masaTotal;
                float v2fx = ((masaRelativa * (this.radio - otraPelota.radio) * v2fParalela) + ((1 + masaRelativa) * otraPelota.radio * v1fParalela)) / masaTotal;

                // Velocidades finales en la dirección perpendicular al choque
                float v1fy = v1fPerpendicular;
                float v2fy = v2fPerpendicular;

                // Actualizamos las velocidades de las pelotas
                this.vx = v1fx * distanciaX / distancia + v1fy * distanciaY / distancia;
                this.vy = v1fx * distanciaY / distancia - v1fy * distanciaX / distancia;

                otraPelota.vx = v2fx * distanciaX / distancia + v2fy * distanciaY / distancia;
                otraPelota.vy = v2fx * distanciaY / distancia - v2fy * distanciaX / distancia;

                // Movemos las pelotas para evitar que se superpongan
                float distanciaOverlap = (this.radio + otraPelota.radio) - distancia;
                float dx = (this.x - otraPelota.x) / distancia;
                float dy = (this.y - otraPelota.y) / distancia;

                this.x += dx * distanciaOverlap / 2f;
                this.y += dy * distanciaOverlap / 2f;

                otraPelota.x -= dx * distanciaOverlap / 2f;
                otraPelota.y -= dy * distanciaOverlap / 2f;
            }

            //float distanciataco = (float)Math.Sqrt(Math.Pow((emitter.PosX - bolablanca.x), 2) + Math.Pow((emitter.PosY - bolablanca.y), 2));
            float distanciaXtaco = emitter.PosX - bolablanca.x;
            float distanciaYtaco = emitter.PosY - bolablanca.y;
            float distanciataco = (float)Math.Sqrt(distanciaXtaco * distanciaXtaco + distanciaYtaco * distanciaYtaco);

            if (distanciataco < (bolablanca.radio + emitter.Size))
            {

                float masaTotaltaco = bolablanca.radio + emitter.Size;
                float masaRelativataco = bolablanca.radio / masaTotaltaco;
                // Componentes de velocidad en la dirección del choque
                float v1fParalela = ((bolablanca.vx * distanciaXtaco) + (bolablanca.vy * distanciaYtaco)) / distanciataco;
                float v2fParalela = ((5 * distanciaXtaco) + (5 * distanciaYtaco)) / distanciataco;
                //AQUI HAY QUE VER QUE PEDO
                // Componentes de velocidad en la dirección perpendicular al choque
                float v1fPerpendicular = ((bolablanca.vx * distanciaYtaco) - (bolablanca.vy * distanciaXtaco)) / distanciataco;
                float v2fPerpendicular = ((5 * distanciaYtaco) - (5 * distanciaXtaco)) / distanciataco;
                //HAY QUE VER QUE PEDO
                /*float v1fx = bolablanca.vx - masaRelativataco * (bolablanca.vx - 10) / 100;
                float v1fy = bolablanca.vy - masaRelativataco * (bolablanca.vy - 10) / 100;*/

                float v1fx = ((masaRelativataco * (otraPelota.radio - this.radio) * v1fParalela) + ((1 + masaRelativataco) * this.radio * v2fParalela)) / masaTotaltaco;
                //float v2fx = ((masaRelativataco * (this.radio - otraPelota.radio) * v2fParalela) + ((1 + masaRelativataco) * otraPelota.radio * v1fParalela)) / masaTotaltaco;

                // Velocidades finales en la dirección perpendicular al choque
                float v1fy = v1fPerpendicular;
                //float v2fytaco = v2fPerpendicular;

                //float v2fx = 10 - masaRelativataco * (10 - bolablanca.vx) / 100;
                //float v2fy = 10 - masaRelativataco * (10 - bolablanca.vy) / 100;


                bolablanca.vx = v1fx;
                bolablanca.vy = v1fy;

                float distanciaOverlaptaco = (bolablanca.radio + emitter.Size) - distanciataco;
                float dx = (bolablanca.x - emitter.PosX) / distanciataco;
                float dy = (bolablanca.y - emitter.PosY) / distanciataco;

                bolablanca.x += dx * distanciaOverlaptaco / 2f;
                bolablanca.y += dy * distanciaOverlaptaco / 2f;


            }
        }


    }


}
