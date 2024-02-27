namespace snakeGame
{
    public class Tablero
    {
        public readonly int Alto;
        public readonly int Ancho;

        public bool ContieneManzana;

        public Tablero(int _Alto, int _Ancho)
        {
            this.Alto = _Alto;
            this.Ancho = _Ancho;
            ContieneManzana = false;
        }

        public void Dibujar()
        {
            for (int i = 0; i <= Alto; i++)
            {
                //lateral derecho
                DibujarPosicion(Ancho, i, '|');

                //linea de izquierdo
                DibujarPosicion(0, i, '|');
            }

            for (int i = 0; i < Ancho; i++)
            {
                //Arriba 
                DibujarPosicion(i, 0, '_');
                //Abajo
                DibujarPosicion(i, Alto, '_');
            }
        }

        private void DibujarPosicion(int x, int y, char caracter)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(caracter);
        }
    }
}