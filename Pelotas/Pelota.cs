﻿using System;
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
            this.vx = rand.Next(0,0);//((int)-radio, (int)radio);
            this.vy = rand.Next(0,0);//((int)-radio,(int)radio);

            this.index = index;
            space = size;
        }
  
        // Método para actualizar la posición de la pelota en función de su velocidad
        public void Update(float deltaTime, List<Pelota> balls,Emitter emitter)
        {
            for (int b = index + 1; b < balls.Count; b++)
            {
                Collision(balls[b], balls[1], emitter);
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



            float distanciataco = (float)Math.Sqrt(Math.Pow((emitter.PosX - bolablanca.x), 2) + Math.Pow((emitter.PosY - bolablanca.y), 2));

            if (distanciataco < (bolablanca.radio + emitter.Size))
            {

                float masaTotaltaco = bolablanca.radio + emitter.Size;
                float masaRelativataco = bolablanca.radio / masaTotaltaco;


                float angulotaco = (float)Math.Atan2(emitter.PosY - bolablanca.y, emitter.PosX - bolablanca.x);
                float factorDeReducciontaco = 0.07f;

                float v1fx1 = bolablanca.vx - masaRelativataco * (bolablanca.vx - 100) * (float)Math.Cos(angulotaco) * factorDeReducciontaco;
                float v1fy1 = bolablanca.vy - masaRelativataco * (bolablanca.vy - 100) * (float)Math.Sin(angulotaco) * factorDeReducciontaco;

                

                

                float v2fx1 = 10 - masaRelativataco * (10 - bolablanca.vx) / 100;
                float v2fy1 = 10 - masaRelativataco * (10 - bolablanca.vy) / 100;


                bolablanca.vx = v1fx1;
                bolablanca.vy = v1fy1;

                float distanciaOverlaptaco = (bolablanca.radio + emitter.Size) - distanciataco;
                float dx = (bolablanca.x - emitter.PosX) / distanciataco;
                float dy = (bolablanca.y - emitter.PosY) / distanciataco;

                bolablanca.x += dx * distanciaOverlaptaco / 2f;
                bolablanca.y += dy * distanciaOverlaptaco / 2f;


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
    }

}
