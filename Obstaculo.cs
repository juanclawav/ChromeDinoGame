using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace Juego
{
    class Obstaculo
    {
        private double alto;
        private double ancho;
        private double x;
        private double y;
        private double dx;
        private double XMax;

        private int aleatorio;

        private bool colision;

        private Random r = new Random();

        private Image i3;
        private Image i4;
        private Image i5;
        private Image o;


        public Obstaculo(double XMax, double y, double v,int id, Random r)
        {
            this.XMax = XMax;
            this.x = XMax+ (500 *( 1+id));
            this.y = y;
            colision = false;
            this.aleatorio = r.Next(0,3);
            switch (aleatorio)
            {
                case 0:
                    this.alto = 45;
                    this.ancho = 25;
                    break;
                case 1:
                    this.alto = 45;
                    this.ancho = 50;
                    break;
                case 2:
                   this.alto = 35;
                    this.ancho = 55;
                    this.y = 200;
                    break;
            }
            dx = v;
            i3 = Properties.Resources.obstacle_1;
            i4 = Properties.Resources.obstacle_2;
            i5 = Properties.Resources.PTE;
            o = null;

        }

        public void Dibujar(Graphics graphics)
        {
            switch (aleatorio)
            {
                case 0:
                    o = i3;
                    break;
                case 1:
                    o = i4;
                    break;
                case 2:
                    o = i5;
                    break;
            }
            graphics.DrawImage(o,                       // Imagen
            (int)(x - (ancho / 2)), (int)(y - (alto / 2)),    // Coord. sup. izquierda
            (int)(ancho), (int)(alto));
        }

        public void Mover()
        {
            x += dx;
        }
        public void Acelerar(int s)
        {
            if (s % 100 == 0 && s > 300)
                this.dx = dx - 0.2;
        }
        public void Colision(double xP, double yP, double anP, double alP)
        {
            if (xP + (anP / 2) >= this.x - (this.ancho / 2) && xP - (anP / 2) <= this.x + (this.ancho / 2) && yP + (alP / 2) >= this.y - (this.alto / 2) && yP - (alP / 2) < this.y + (this.alto / 2))
            {
                colision = true;
            }

        }
        public bool GetColision()
        {
        return colision;
            }

    }
}
