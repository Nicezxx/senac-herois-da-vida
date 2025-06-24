using System;

namespace JogoConsole
{
    
    
        class GuerraEspacial
        {
            static char[,] mapa;
            static int altura = 20;
            static int largura = 50;
            static int playerX = 25;
            static int playerY = 15;
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



