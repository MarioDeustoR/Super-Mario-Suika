using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Super_Mario_Suika.Presentation
{
    public partial class Bienvenida : Form
    {
        public Bienvenida()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.Paint += Bienvenida_Paint;
        }

        private void Jugar_Click(object sender, EventArgs e)
        {
            Partida ventanaJuego = new Partida();
            this.Hide();
            ventanaJuego.ShowDialog();
            this.Show();
            this.Invalidate();
        }

        private void Bienvenida_Paint(object sender, PaintEventArgs e)
        {
            Font fuenteTitulo = new Font("Arial", 16, FontStyle.Bold);
            Font fuenteLista = new Font("Arial", 16, FontStyle.Regular);
            Brush brochaTexto = new SolidBrush(Color.Black);
            e.Graphics.DrawString("TOP 5 RÉCORDS", fuenteTitulo, brochaTexto, 275, 20);

            for (int i = 0; i < Config.MejoresPuntuaciones.Count; i++)
            {
                string renglon = i+1 + "." + Config.MejoresPuntuaciones[i] + " Puntos";
                e.Graphics.DrawString(renglon, fuenteLista, brochaTexto, 320, 50 + (i * 30));
            }
        }
    }
}
