namespace snakeGame
{
    public class Manzana
    {
        public Posicion posicion { get; set; }

        public Manzana(int _x, int _y)
        {
            posicion = new Posicion(_x, _y);
        }

        //No se usa esta funcion de primeras ya que la manzana se pintara en 0,0
        public void dibujarManzana()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            PosicionarManzana(posicion.x, posicion.y, 'o');
            Console.ResetColor();
        }

        private void PosicionarManzana(int x, int y, char caracter)
        {
            //posiciona la manzana en el tablero
            Console.SetCursorPosition(x, y);
            Console.WriteLine(caracter);
        }

        //crea la manzana nueva cada vez que se la come la serpiente
        //y a la vez se verifica que esta no este en el cuerpo de la serpiente
        public static Manzana crearManzana(Serpiente serpiente, Tablero tablero)
        {
            bool manzanaBuena = false;

            int x = 0;
            int y = 0;

            do
            {
                Random random = new Random();
                x = random.Next(1, tablero.Ancho - 1);
                y = random.Next(1, tablero.Alto - 1);
                manzanaBuena = serpiente.posicionEnCola(x, y);

            } while (manzanaBuena);

            tablero.ContieneManzana = true;

            return new Manzana(x, y);
        }
    }
}