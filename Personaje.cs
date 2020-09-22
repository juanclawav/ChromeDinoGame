using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Juego
{
    class Personaje
    {
        private double x;
        private double y;
        private double XMax;
        private double YMax;
        private double Yi;
        private double alto;
        private double ancho;
        private double altoMax;
        private double ancho1;
        private double alto1;

        private Image i;
        private Image ii;
        private Image i1;
        private Image i2;

        private bool parado;
        private bool muerto;

        private double dy;

        public Personaje(double XMax, double YMax, double x, double y, double Yi)
        {
            this.XMax = XMax;
            this.YMax = YMax;
            this.x = x;
            this.y = y;
            this.Yi = Yi;
            alto = 60;
            alto1 = 60;
            ancho1 = 50;
            ancho = 50;
            dy = 0;
            altoMax = 110;
            i = Properties.Resources.corre0;
            ii = Properties.Resources.corre1;
            i1 = Properties.Resources.AG;
            i2 = Properties.Resources.dead;
            parado = true;
            muerto = false;


        }
        public void Dibujar(Graphics graphics, int s)
        {
            if (muerto == true)
            {
                graphics.DrawImage(i2,                       // Imagen
              (int)(x - (ancho1 / 2)), (int)(y - (alto1 / 2)),    // Coord. sup. izquierda
              (int)(ancho1), (int)(alto1));
            }
            else if (parado == false && muerto == false)
            {
                graphics.DrawImage(i1,                       // Imagen
               (int)(x - (ancho / 2)), (int)(y - (alto / 2)),    // Coord. sup. izquierda
               (int)(ancho), (int)(alto));
            }

            else if (parado == true && (s / 5) % 2 == 0)
            { graphics.DrawImage(i,                       // Imagen
               (int)(x - (ancho / 2)), (int)(y - (alto / 2)),    // Coord. sup. izquierda
               (int)(ancho), (int)(alto));
            }
            else if (parado == true && (s / 5) % 2 != 0)
            {
                graphics.DrawImage(ii,                       // Imagen
                 (int)(x - (ancho / 2)), (int)(y - (alto / 2)),    // Coord. sup. izquierda
                 (int)(ancho), (int)(alto));
            }

        }
        private void Mover()
        {
            if (parado == true && muerto == false)
            {
                Saltar();
                Rebotar();
                Parar();
            }
        }
        private void Saltar()
        {
            if (y >= Yi - altoMax)
            {
                y = y - dy;
            }
        }
        private void Rebotar()
        {
            if (y <= Yi - altoMax)
                this.dy = -dy;
        }
        private void Parar()
        {
            if (y >= Yi && parado == true)
                y = Yi;

        }
        public void Normal()
        {
            alto = alto1;
            ancho = ancho1;
            y = Yi;
        }
        public void DesplazarseKey()
        {
            Mover();
        }
        public void CambiaDY(double dy)
        {
            this.dy = dy;

        }
        public void Agacharse()
        {
            if (muerto == false)
                this.y = Yi + (alto1 / 4);
            alto = alto1 / 2;
            ancho = ancho1 * 3 / 2;
            parado = false;

        }
        public void Colision(bool Colision)
        { if (Colision==true)
                Matar();
        }
        public void Matar()
        {
            Normal();
            muerto = true;
        }
        public bool IsMuerto()
        {
            return muerto;
        }
        public double GetX()
        {
            return x;
        }
        public double GetY()
        {
            return y;
        }
        public double GetAlto()
        {
            return alto;
        }
        public double GetAncho()
        {
            return ancho;
        }
        public void CambiaParado()
        {
            parado = !parado;

        }
    }

}
