using System;
using System.Collections.Generic;
using System.Text;

namespace Super_Mario_Suika.Presentation
{
    public class Seta
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Radio { get; set; }
        public float VelocidadY { get; set; }
        public float VelocidadX { get; set; }
        public int Nivel { get; set; }
        public Seta(int nivel, float x, float y, float radio)
        {
            Nivel = nivel;
            X = x;
            Y = y;
            Radio = radio;
            VelocidadY = 0f;
            VelocidadX = 0f;
        }

        public float ObtenerDiametro()
        {
            return Radio * 2;
        }
    }
}