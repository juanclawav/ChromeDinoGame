using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Obstaculos
    {
        private double XMax;
        private double y;
        private double v;
        private Obstaculo[] obstaculos;
        private int c;
        private bool colision;
        public Obstaculos(double XMax, double y, double v,Random r)
        {
            c = 200;
            this.XMax = XMax;
            this.y = y;
            this.v = v;
            obstaculos = new Obstaculo[c];
            colision = false;
            for (int i = 0; i < c; i++)
            {
                obstaculos[i] = new Obstaculo(XMax, y,v,i,r);
            }
        }
        public void Dibujar(Graphics graphics)
        {
            for (int i = 0; i < c; i++)
            {
                obstaculos[i].Dibujar(graphics);
            }
        }
        public void Mover()
        {
            for (int i = 0; i < c; i++)
            {
                obstaculos[i].Mover();
            }
        }
        public void Acelerar(int s)
        {
            for (int i = 0; i < c; i++)
            {
                obstaculos[i].Acelerar(s);
            }
        }
        public void Colision(double xP, double yP, double anP, double alP)
        {
            for (int i = 0; i < c; i++)
            {
                obstaculos[i].Colision(xP,yP, anP,alP);
                if (obstaculos[i].GetColision()==true)
                { colision = true; }
            }
        }
        public bool GetColision()
        {
            return colision;
        }
       

    }
}
