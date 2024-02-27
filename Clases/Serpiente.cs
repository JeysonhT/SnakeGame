namespace snakeGame
{
    public class Serpiente
    {
        public List<Posicion> Cola { get; set; }
        public Direccion direccion { get; set; }

        public int puntos;

        public bool estaViva { get; set; }

        public Serpiente(int _x, int _y)
        {
            Posicion initPos = new Posicion(_x, _y);
            Cola = new List<Posicion>() { initPos };
            direccion = Direccion.ABAJO;
            puntos = 0;
            estaViva = true;
        }

        public void iniciar()
        {
            //Da inicio a la vida de la serpiente
            foreach (Posicion posicion in Cola)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Dibujarserpiente(posicion.x, posicion.y, 'x');
                Console.ResetColor();
            }
        }

        public void Morir(Tablero tablero)
        {

            Posicion newPosicion = Cola.First();
            estaViva = !((Cola.Count(a=> a.x == newPosicion.x && a.y == newPosicion.y)>1)
            || colicion(tablero, newPosicion));

        }

        //Comprobamos una colicion con el tablero
        private bool colicion(Tablero tablero, Posicion posicion)
        {
            return posicion.y == 0 || posicion.y == tablero.Alto
             || posicion.x == 0 || posicion.x == tablero.Ancho;
        }

        public void Moverse(bool haComido)
        {

            List<Posicion> NewQ = new List<Posicion>();
            NewQ.Add(ObtenerCola());
            NewQ.AddRange(Cola);

            if (!haComido)
            {
                NewQ.Remove(NewQ.Last());
            }
            Cola = NewQ;

        }

        private Posicion ObtenerCola()
        {
            int x = Cola.First().x;
            int y = Cola.First().y;

            switch (direccion)
            {
                case Direccion.ABAJO:
                    y += 1;
                    break;
                case Direccion.ARRIBA:
                    y -= 1;
                    break;
                case Direccion.DERECHA:
                    x += 1;
                    break;
                case Direccion.IZQUIERDA:
                    x -= 1;
                    break;
            }

            return new Posicion(x, y);
        }

        public bool Comer(Manzana manzana, Tablero tablero)
        {
            if (posicionEnCola(manzana.posicion.x, manzana.posicion.y))
            {
                puntos += 1;
                tablero.ContieneManzana = false;
                return true;
            }
            return false;
        }

        //verifica si la manzana esta dentro del cuerpo de la serpiente
        public bool posicionEnCola(int x, int y)
        {
            return Cola.Any(a => a.x == x && a.y == y);
        }

        private void Dibujarserpiente(int x, int y, char caracter)
        {
            Console.SetCursorPosition(x, y);
            Console.WriteLine(caracter);
        }

    }
}