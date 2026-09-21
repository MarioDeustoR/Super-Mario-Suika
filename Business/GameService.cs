using Super_Mario_Suika.Presentation;
using System.Collections.Generic;
using System.Configuration;

namespace Super_Mario_Suika
{
    public class GameService
    {
        private GameData partida;
        private Random random;

        public GameService(GameData partida)
        {
            this.partida = partida;
            this.random = new Random();
        }

        public void GenerarNuevaFruta(int nivel, float x, float y)
        {
            if (nivel >= 0 && nivel < Config.RadiosPorNivel.Length)
            {
                float radio = Config.RadiosPorNivel[nivel];
                Seta nuevaSeta = new Seta(nivel, x, y, radio);
                partida.SetasEnJuego.Add(nuevaSeta);
            }
        }

        public void ActualizarFisicas()
        {
            if (partida.IsGameOver) return;

            if (partida.FramesEspera > 0)
            {
                partida.FramesEspera--;
                if (partida.FramesEspera == 0)
                {
                    InicializarLanzador(partida.UltimaPosicionRatonX);
                }
            }

            foreach (Seta seta in partida.SetasEnJuego)
            {
                seta.VelocidadY += Config.FuerzaGravedad;
                if (seta.VelocidadY > 15f) seta.VelocidadY = 15f;
                seta.Y += seta.VelocidadY;

                seta.X += seta.VelocidadX;
                seta.VelocidadX = seta.VelocidadX * (1f - Config.Friccion);
            }

            for (int i = 0; i < 4; i++)
            {
                Colisiones();

                foreach (Seta seta in partida.SetasEnJuego)
                {
                    if (seta.X - seta.Radio <= 0)
                    {
                        seta.X = seta.Radio;
                        seta.VelocidadX = -seta.VelocidadX * Config.Rebote;
                    }
                    if (seta.X + seta.Radio >= Config.AnchoPantalla)
                    {
                        seta.X = Config.AnchoPantalla - seta.Radio;
                        seta.VelocidadX = -seta.VelocidadX * Config.Rebote;
                    }
                    if (seta.Y + seta.Radio >= Config.AltoPantalla)
                    {
                        seta.Y = Config.AltoPantalla - seta.Radio;

                        if (Math.Abs(seta.VelocidadY) < 1f)
                            seta.VelocidadY = 0f;
                        else
                            seta.VelocidadY = -seta.VelocidadY * Config.Rebote;
                    }
                }
            }

            ComprobarGameOver();
        }

        public void Colisiones()
        {
            List<Seta> setasEliminar = new List<Seta>();
            List<Seta> setasCrear = new List<Seta>();

            for (int i = 0; i < partida.SetasEnJuego.Count; i++)
            {
                for (int j = i + 1; j < partida.SetasEnJuego.Count; j++)
                {
                    Seta setaA = partida.SetasEnJuego[i];
                    Seta setaB = partida.SetasEnJuego[j];
                    bool estanEliminadas = setasEliminar.Contains(setaA) || setasEliminar.Contains(setaB);

                    if (estanEliminadas == false)
                    {
                        float distanciaX = setaB.X - setaA.X;
                        float distanciaY = setaB.Y - setaA.Y;
                        float distanciaAlCuadrado = (distanciaX * distanciaX) + (distanciaY * distanciaY);
                        float sumaRadios = setaA.Radio + setaB.Radio;
                        float sumaRadiosAlCuadrado = sumaRadios * sumaRadios;

                        if (distanciaAlCuadrado < sumaRadiosAlCuadrado)
                        {
                            if (setaA.Nivel == setaB.Nivel)
                            {
                                setasEliminar.Add(setaA);
                                setasEliminar.Add(setaB);

                                int nuevoNivel = setaA.Nivel + 1;

                                if (nuevoNivel < Config.RadiosPorNivel.Length)
                                {
                                    float medioX = (setaA.X + setaB.X) / 2f;
                                    float medioY = (setaA.Y + setaB.Y) / 2f;

                                    Seta nuevaSeta = new Seta(nuevoNivel, medioX, medioY, Config.RadiosPorNivel[nuevoNivel]);
                                    setasCrear.Add(nuevaSeta);

                                    partida.Puntuacion += (nuevoNivel) * 2;
                                    partida.ReproducirSonidoFusion = true;
                                }
                            }
                            else
                            {
                                float distanciaExacta = (float)Math.Sqrt(distanciaAlCuadrado);
                                // Math.Sqrt es una instrucción matemática que calcula la raíz cuadrada de un número
                                // Lo he usado para calcular de forma más precisa la distancia exacta entre 2 setas
                                // Así las colisiones son más precisas y se evita que al cochar las setas vibren o se atraviesen

                                if (distanciaExacta > 0)
                                {
                                    float solapamiento = sumaRadios - distanciaExacta;
                                    float normalX = distanciaX / distanciaExacta;
                                    float normalY = distanciaY / distanciaExacta;

                                    setaA.X -= normalX * (solapamiento / 2f);
                                    setaA.Y -= normalY * (solapamiento / 2f);
                                    setaB.X += normalX * (solapamiento / 2f);
                                    setaB.Y += normalY * (solapamiento / 2f);

                                    float velRelativaX = setaA.VelocidadX - setaB.VelocidadX;
                                    float velRelativaY = setaA.VelocidadY - setaB.VelocidadY;

                                    float velocidadEnLaNormal = (velRelativaX * normalX) + (velRelativaY * normalY);

                                    if (velocidadEnLaNormal > 0)
                                    {
                                        float impulso = -(1f + 0.1f) * velocidadEnLaNormal;

                                        impulso /= 2f;

                                        setaA.VelocidadX += impulso * normalX;
                                        setaA.VelocidadY += impulso * normalY;

                                        setaB.VelocidadX -= impulso * normalX;
                                        setaB.VelocidadY -= impulso * normalY;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            foreach (Seta s in setasEliminar)
            {
                partida.SetasEnJuego.Remove(s);
            }
            foreach (Seta s in setasCrear)
            {
                partida.SetasEnJuego.Add(s);
            }
        }

        public void InicializarLanzador(float posicionX)
        {
            int nivelAleatorio = random.Next(0, 5);
            float radio = Config.RadiosPorNivel[nivelAleatorio];
            float posicionY = Config.LineaGameOverY + radio + 10f;

            partida.SetaEnLanzador = new Seta(nivelAleatorio, posicionX, posicionY, radio);
            LimitarPosicionLanzador();
        }

        public void MoverLanzador(float x)
        {
            partida.UltimaPosicionRatonX = x;

            if (partida.SetaEnLanzador != null)
            {
                partida.SetaEnLanzador.X = x;
                LimitarPosicionLanzador();
            }
        }

        private void LimitarPosicionLanzador()
        {
            float radio = partida.SetaEnLanzador.Radio;

            if (partida.SetaEnLanzador.X - radio < 0)
            {
                partida.SetaEnLanzador.X = radio;
            }
            if (partida.SetaEnLanzador.X + radio > Config.AnchoPantalla)
            {
                partida.SetaEnLanzador.X = Config.AnchoPantalla - radio;
            }
        }

        public void SoltarSeta()
        {
            if (partida.IsGameOver) return;

            if (partida.SetaEnLanzador != null && partida.FramesEspera == 0)
            {
                partida.SetasEnJuego.Add(partida.SetaEnLanzador);
                partida.SetaEnLanzador = null;
                partida.FramesEspera = Config.Cooldown;
            }
        }

        private void ComprobarGameOver()
        {
            foreach (Seta seta in partida.SetasEnJuego)
            {

                if (seta.Y - seta.Radio <= Config.LineaGameOverY)
                {
                    if (!partida.IsGameOver)
                    {
                        partida.IsGameOver = true;
                        GuardarPuntuacionSiEsRecord();
                    }
                    break;
                }
            }
        }

        public void GuardarPuntuacionSiEsRecord()
        {
            Config.MejoresPuntuaciones.Add(partida.Puntuacion);
            Config.MejoresPuntuaciones.Sort((a, b) => b.CompareTo(a));
            if (Config.MejoresPuntuaciones.Count > 5)
            {
                Config.MejoresPuntuaciones.RemoveAt(5);
            }
        }
    }
}