using Super_Mario_Suika.Presentation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Super_Mario_Suika
{
    public class GameData
    {
        public List<Seta> SetasEnJuego { get; set; }
        public Seta SetaEnLanzador { get; set; }
        public int FramesEspera { get; set; }
        public float UltimaPosicionRatonX { get; set; }
        public int Puntuacion { get; set; }
        public bool IsGameOver { get; set; }
        public bool ReproducirSonidoFusion { get; set; }

        public GameData()
        {
            SetasEnJuego = new List<Seta>();
            SetaEnLanzador = null;
            FramesEspera = 0;
            UltimaPosicionRatonX = Config.AnchoPantalla / 2f;
            Puntuacion = 0;
            IsGameOver = false;
            ReproducirSonidoFusion = false;
        }
    }
}