using System;
using System.Collections.Generic;
using System.Text;

namespace Super_Mario_Suika
{
    internal class Config
    {
        public static List<int> MejoresPuntuaciones = new List<int> { 0, 0, 0, 0, 0 };
        private static string rutaArchivo = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "records.txt");
        public const int AnchoPantalla = 500;
        public const int AltoPantalla = 800;
        public const int IntervaloMs = 16;
        public const int Cooldown = 30;
        public static readonly float[] RadiosPorNivel = new float[]
        {
            30f, 35f, 40f, 50f, 65f, 70f, 80f, 90f, 100f, 110f
        };
        public const float FuerzaGravedad = 0.5f;
        public const float Friccion = 0.005f;
        public const float Rebote = 0.2f;
        public const float LineaGameOverY = 150f;

        public static void GuardarRecords()
        {
            try
            {
                List<string> lineas = new List<string>();
                foreach (int record in MejoresPuntuaciones)
                {
                    lineas.Add(record.ToString());
                }

                File.WriteAllLines(rutaArchivo, lineas);
            }
            catch (Exception) {}
        }

        public static void CargarRecords()
        {
            try
            {
                if (!File.Exists(rutaArchivo)) return;

                string[] lineas = File.ReadAllLines(rutaArchivo);
                MejoresPuntuaciones.Clear();

                for (int i = 0; i < lineas.Length; i++)
                {
                    if (int.TryParse(lineas[i], out int resultado))
                    {
                        MejoresPuntuaciones.Add(resultado);
                    }
                }
                while (MejoresPuntuaciones.Count < 5)
                {
                    MejoresPuntuaciones.Add(0);
                }
            }
            catch (Exception) { }
        }
    }
}