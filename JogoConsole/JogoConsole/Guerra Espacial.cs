using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoConsole
{
    internal class Guerra_Espacial
    {
        class GuerraEspacial
        {
            static char[,] mapa;
            static int altura = 10;
            static int largura = 20;
            static int playerx = 1;
            static int playery = 1;
            static bool jogando = true;

            static void Main()

            {

                Console.Clear();

                Jogar();



            }
            static void Jogar()
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
                            mapa[x, y] = '#'; // paredes
                        }
                        else
                        {
                            mapa[x, y] = ' '; // espaço vazio
                        }
                    }
                }

                mapa[playerx, playery] = '@'; // posição do jogador
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
                int x = playerx;
                int y = playery;

                switch (tecla)
                {
                    case ConsoleKey.W: // cima
                        y--;
                        break;
                    case ConsoleKey.S: // baixo
                        y++;
                        break;
                    case ConsoleKey.A: // esquerda
                        x--;
                        break;
                    case ConsoleKey.D: // direita
                        x++;
                        break;

                }

                if (mapa[x, y] != '#')
                {
                    mapa[playerx, playery] = ' ';
                    mapa[x, y] = '@';
                    playerx = x;
                    playery = y;

                }
            }

        }
    
