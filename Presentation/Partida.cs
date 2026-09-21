using Super_Mario_Suika.Presentation;
using System;
using System.Configuration;
using System.Drawing;
using System.Media;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Super_Mario_Suika
{
    public partial class Partida : Form
    {
        private GameData partida;
        private GameService gameService;
        private System.Windows.Forms.Timer gameLoop;
        private Image[] imagenesSetas;
        private SoundPlayer musicaFondo;
        private SoundPlayer sonidoGameOver;
        private bool gameOverAudio = false;

        public Partida()
        {
            InitializeComponent();
            ConfigurarFormulario();
            CargarImagenes();
            InicializarJuego();
        }

        private void CargarImagenes()
        {
            imagenesSetas = new Image[10];
            string[] nombresArchivos = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j" };

            for (int i = 0; i < 10; i++)
            {
                string ruta = "Assets\\Objects\\" + nombresArchivos[i] + ".png";
                imagenesSetas[i] = Image.FromFile(ruta);
            }
        }

        private void ConfigurarFormulario()
        {
            this.ClientSize = new Size(Config.AnchoPantalla, Config.AltoPantalla);
            this.DoubleBuffered = true;
            this.Paint += Partida_Paint;
            this.MouseClick += Partida_MouseClick;
            this.MouseMove += Partida_MouseMove;
            this.FormClosing += Partida_FormClosing;
            this.KeyPreview = true;
            this.KeyDown += Partida_KeyDown;
        }

        private void InicializarJuego()
        {
            partida = new GameData();
            gameService = new GameService(partida);
            gameService.InicializarLanzador(Config.AnchoPantalla / 2f);
            gameLoop = new System.Windows.Forms.Timer();
            gameLoop.Interval = Config.IntervaloMs;
            gameLoop.Tick += GameLoop_Tick;
            musicaFondo = new SoundPlayer("Assets\\background-music.wav");
            musicaFondo.PlayLooping(); 
            sonidoGameOver = new SoundPlayer("Assets\\game-over-sound.wav");
            GameOver.Visible = false;
            gameLoop.Start();
        }

        private void GameLoop_Tick(object sender, EventArgs e)
        {
            gameService.ActualizarFisicas();

            Puntos.Text = partida.Puntuacion.ToString();

            if (partida.IsGameOver == true && gameOverAudio == false)
            {
                sonidoGameOver.Play();
                GameOver.Visible = true;
                gameOverAudio = true;
            }

            this.Invalidate();
        }

        private void Partida_Paint(object sender, PaintEventArgs e)
        {
            Pen penLinea = new Pen(Color.WhiteSmoke, 2);
            penLinea.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
            e.Graphics.DrawLine(penLinea, 0, Config.LineaGameOverY, Config.AnchoPantalla, Config.LineaGameOverY);

            foreach (Seta seta in partida.SetasEnJuego)
            {
                Image imagenSeta = imagenesSetas[seta.Nivel];
                e.Graphics.DrawImage(imagenSeta, seta.X - seta.Radio, seta.Y - seta.Radio, seta.ObtenerDiametro(), seta.ObtenerDiametro());
            }

            if (partida.SetaEnLanzador != null)
            {
                Image imagenLanzador = imagenesSetas[partida.SetaEnLanzador.Nivel];
                e.Graphics.DrawImage(imagenLanzador,
                            partida.SetaEnLanzador.X - partida.SetaEnLanzador.Radio,
                            partida.SetaEnLanzador.Y - partida.SetaEnLanzador.Radio,
                            partida.SetaEnLanzador.ObtenerDiametro(),
                            partida.SetaEnLanzador.ObtenerDiametro());
            }
        }

        private void Partida_MouseClick(object sender, MouseEventArgs e)
        {
            gameService.SoltarSeta();
        }

        private void Partida_MouseMove(object sender, MouseEventArgs e)
        {
            gameService.MoverLanzador(e.X);
        }

        private void Partida_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (partida != null && partida.IsGameOver == false)
            {
                gameService.GuardarPuntuacionSiEsRecord();
            }

            Config.GuardarRecords();

            if (gameLoop != null)
            {
                gameLoop.Stop();
            }
        }

        private void Partida_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.G)
            {
                if (partida != null && partida.IsGameOver == false)
                {
                    partida.IsGameOver = true;
                    gameService.GuardarPuntuacionSiEsRecord();
                }
            }
        }
    }
}