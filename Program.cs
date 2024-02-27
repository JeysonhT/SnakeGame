using System.Diagnostics;

namespace snakeGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("\n");
            Tablero tablero = new Tablero(15, 30);

            Serpiente serpiente = new Serpiente(10, 10);

            Manzana manzana = new Manzana(0, 0);

            bool haComido = false;

            do
            {
                Console.Clear();

                tablero.Dibujar();
    
                serpiente.Morir(tablero);

                if (serpiente.estaViva)
                {
                    serpiente.Moverse(haComido);
                    //Comprueba si se come la manzana
                    haComido = serpiente.Comer(manzana, tablero);

                    serpiente.iniciar();

                    //Se comprueba si el tablero contiene ya una manzana
                    if (!tablero.ContieneManzana)
                    {
                        manzana = Manzana.crearManzana(serpiente, tablero);
                    }

                    manzana.dibujarManzana();
                    //Actualizamos el movimiento de la serpiente cada 250 ms
                    var sw = Stopwatch.StartNew();
                    while (sw.ElapsedMilliseconds <= 250)
                    {
                        serpiente.direccion = MoverSnake(serpiente.direccion);
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(tablero.Alto / 2, tablero.Ancho / 2);
                    Console.WriteLine($"Game over\n tu puntaje es: {serpiente.puntos}");
                    Console.ResetColor();
                }



            } while (serpiente.estaViva);

            Console.ReadKey();
        }

        static Direccion MoverSnake(Direccion actual)
        {
            //De esta manera Controlamos la Serpiente por teclado
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow && actual != Direccion.ABAJO)
                {
                    return Direccion.ARRIBA;
                }
                else if (key == ConsoleKey.DownArrow && actual != Direccion.ARRIBA)
                {
                    return Direccion.ABAJO;
                }
                else if (key == ConsoleKey.LeftArrow && actual != Direccion.DERECHA)
                {
                    return Direccion.IZQUIERDA;
                }
                else if (key == ConsoleKey.RightArrow && actual != Direccion.IZQUIERDA)
                {
                    return Direccion.DERECHA;
                }
            }

            //retorna la direccion actual del serpiente el cual cambia cada 250 ms
            return actual;
        }
    }
}
