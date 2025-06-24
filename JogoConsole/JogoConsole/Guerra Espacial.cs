using System;
using System.Reflection.PortableExecutable;

namespace JogoConsole
{


    class GuerraEspacial
    {
        static int vida = 3;
        static char[,] mapa;
        static int altura = 20;
        static int largura = 50;
        static int playerX = 25;
        static int playerY = 15;
        static int inimigoX = 10;
        static int inimigoY = 5;
        static int tiroY = 0;
        static int tiroX = 0;
        static bool jogando = true;

        public static void Main()

        {

            Console.Clear();

            Jogar();



        }
        public static void Jogar()
        {
            iniciarmapa();


            while (jogando)
            {
                Console.Clear();
                DesenhandoMapa();
                var tecla = Console.ReadKey(true).Key;
                AtualizarPosicao(tecla);

                if (vida < 1)
                {
                    jogando = false;
                }


            }

        }

        static void iniciarmapa()
        {
            mapa = new char[largura, altura];
            for (int x = 0; x < largura; x++)
            {
                for (int y = 0; y < altura; y++)
                {
                    if (x == 0 || x == largura - 1 || y == 0 || y == altura - 1)
                    {
                        mapa[x, y] = '/'; // paredes
                    }
                    else
                    {
                        mapa[x, y] = ' '; // espaço vazio
                    }
                }
            }

            mapa[tiroX, tiroY] = '.';
            mapa[inimigoX, inimigoY] = 'X';
            mapa[playerX, playerY] = '^'; // posição do jogador
        }

        static void DesenhandoMapa()
        {

            for (int y = 0; y < altura; y++)
            {
                for (int x = 0; x < largura; x++)
                {

                    Console.Write(mapa[x, y]);
                }
                Console.WriteLine();
            }
        }

        static void AtualizarPosicao(ConsoleKey tecla)
        {
            int tempX = playerX;
            int tempY = playerY;
            int troY = tiroY;

            switch (tecla)
            {
                case ConsoleKey.A: // esuqerda
                    tempX--;
                    break;
                case ConsoleKey.S: // baixo
                    tempY++;
                    break;
                case ConsoleKey.D: // direita
                    tempX++;
                    break;
                case ConsoleKey.W: // cima-
                    tempY--;
                    break;
                case ConsoleKey.E: // atirar
                    troY++;
                    break;

            }

            int eniX = inimigoX;
            int eniY = inimigoY+1;

            Random random = new Random();  

            if (eniY < altura)
            { 
                inimigoY++;
                mapa[inimigoX, inimigoY - 1] = ' ';
                mapa[inimigoX, inimigoY] = 'X';
            } else {
                mapa[inimigoX, inimigoY] = '/';
                vida--;
                inimigoY = 5;
                inimigoX = random.Next(2,largura);

            }







            if (mapa[tempX, tempY] != '/')
                {
                    mapa[playerX, playerY] = ' ';
                    mapa[tempX, tempY] = '^';
                    playerX = tempX;
                    playerY = tempY;

                }
      

        }
    }
}



