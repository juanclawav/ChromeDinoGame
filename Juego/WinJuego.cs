using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Juego
{
    public partial class WinJuego : Form
    {
        private Personaje personaje;
        private Obstaculos obstaculos;
        private int score;
        private bool KeyWisDown;
        private Random r;
        private bool Colision;
        public WinJuego()
        {
            r = new Random();
            InitializeComponent();
            personaje = new Personaje(pbCancha.Width, pbCancha.Height, 70, 240, 240);
            obstaculos = new Obstaculos(pbCancha.Width * 1, 248, -4.5,r);
            score = 0;
            KeyWisDown = false;
            Colision = obstaculos.GetColision();
        }

        private void pbCancha_Paint(object sender, PaintEventArgs e)
        {
            personaje.Dibujar(e.Graphics, score);
            obstaculos.Dibujar(e.Graphics);
        }


        private void timerAnimacion_Tick(object sender, EventArgs e)
        {
            score++;
            personaje.DesplazarseKey();
            obstaculos.Mover();
            obstaculos.Acelerar(score / 5);
            obstaculos.Colision(personaje.GetX(),personaje.GetY(),personaje.GetAlto(),personaje.GetAncho());
            Colision = obstaculos.GetColision();
            personaje.Colision(Colision);
            textBox1.Text = "Score: " + score / 5;
            pbCancha.Invalidate();

            if (personaje.IsMuerto() == true)
            { timerAnimacion.Stop();

                textBox2.Visible = true;
            }
            if (score/5 >= 1000)
            {
                timerAnimacion.Stop();
                textBox3.Visible = true;

            }
        }
        private void WinJuego_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                personaje.Agacharse();
            }
            if (e.KeyCode == Keys.W && personaje.IsMuerto() == false && KeyWisDown == false)
            {
                timerAnimacion.Start();
                    personaje.CambiaDY(5);
                    KeyWisDown = true;
            }
        }

        private void WinJuego_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.S)
            {
                personaje.CambiaParado();
                personaje.Normal();
            }

            if (e.KeyCode == Keys.W )
            {
                KeyWisDown = false;
            }
        }

        private void pbCancha_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void botonSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
    }
