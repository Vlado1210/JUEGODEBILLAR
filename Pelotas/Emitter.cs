using Pelotas.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pelotas
{
    public class Emitter
    {
        public int PosX, PosY;
        public int Size;

        public Emitter(int posX, int posY, int size)
        {
            this.PosX = posX;
            this.PosY = posY;
            this.Size = size;
        }

        public int x
        {
            set { PosX = value; }
        }

        public int y
        {
            set { PosY = value; }
        }


    }
}