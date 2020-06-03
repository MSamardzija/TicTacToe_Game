using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak4IKSOKS
{
    class Program
    {
        static char[,] playfield =
        {
            {'1', '2', '3' },
            {'4', '5', '6' },
            {'7', '8', '9' }
        };

        static int turns = 0;

        static void Main(string[] args)
        {
            int player = 2;
            int input = 0;
            bool inputCorrect = true;

            do
            {
                if (player == 2)
                {
                    player = 1;
                    ReplaceNumber(player, input);
                }
                else if (player == 1)
                {
                    player = 2;
                    ReplaceNumber(player, input);
                }
                SetField();

                #region
                //Proovera da li imamo pobednika ili je nereseno
                char[] playerChars = { 'X', 'O' };

                foreach (char playerChar in playerChars)
                {
                    if (((playfield[0, 0] == playerChar) && (playfield[0, 1] == playerChar) && (playfield[0, 2] == playerChar))
                        || ((playfield[1, 0] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[1, 2] == playerChar))
                        || ((playfield[2, 0] == playerChar) && (playfield[2, 1] == playerChar) && (playfield[2, 2] == playerChar))
                        || ((playfield[0, 0] == playerChar) && (playfield[1, 0] == playerChar) && (playfield[2, 0] == playerChar))
                        || ((playfield[0, 1] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[2, 1] == playerChar))
                        || ((playfield[0, 2] == playerChar) && (playfield[1, 2] == playerChar) && (playfield[2, 2] == playerChar))
                        || ((playfield[0, 0] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[2, 2] == playerChar))
                        || ((playfield[2, 0] == playerChar) && (playfield[1, 1] == playerChar) && (playfield[0, 2] == playerChar)))
                    {
                        if (playerChar == 'X')
                        {
                            Console.WriteLine();
                            Console.WriteLine("Player 1 has won the game !");
                        }
                        else if (playerChar == 'O')
                        {
                            Console.WriteLine();
                            Console.WriteLine("Player 1 has won the game !");
                        }
                        Console.WriteLine("Please press any key to reset the game !");
                        Console.ReadKey();
                        ResetTheGame();
                        break;
                    }
                    else if (turns == 10)
                    {
                        Console.WriteLine("DRAW     DRAW      DRAW");
                        Console.WriteLine("Please press any key to reset the game !");
                        Console.ReadKey();
                        ResetTheGame();
                        break;

                    }
                }
                #endregion

                #region
                //Testiranje da li je polje prethodno zauzeto
                do
                {
                    Console.WriteLine("\n Player {0} Choose your field! ", player);
                    try
                    {
                        input = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Please enter number between 1-9");
                    }
                    if ((input == 1) && (playfield[0, 0] == '1'))
                        inputCorrect = true;
                    else if ((input == 2) && (playfield[0, 1] == '2'))
                        inputCorrect = true;
                    else if ((input == 3) && (playfield[0, 2] == '3'))
                        inputCorrect = true;
                    else if ((input == 4) && (playfield[1, 0] == '4'))
                        inputCorrect = true;
                    else if ((input == 5) && (playfield[1, 1] == '5'))
                        inputCorrect = true;
                    else if ((input == 6) && (playfield[1, 2] == '6'))
                        inputCorrect = true;
                    else if ((input == 7) && (playfield[2, 0] == '7'))
                        inputCorrect = true;
                    else if ((input == 8) && (playfield[2, 1] == '8'))
                        inputCorrect = true;
                    else if ((input == 9) && (playfield[2, 2] == '9'))
                        inputCorrect = true;
                    else
                    {
                        Console.WriteLine("Please enter another field");
                        inputCorrect = false;
                    }
                } while (!inputCorrect);
                #endregion
            } while (true);
        }

        //Funcija za restartovanje igre
        public static void ResetTheGame()
        {

            char[,] playfieldOriginal =
            {
                {'1', '2', '3' },
                {'4', '5', '6' },
                {'7', '8', '9' }
            };
            playfield = playfieldOriginal;
            SetField();
            turns = 0;
        }
        //Funkcija za upis  na polje
        public static void ReplaceNumber(int p, int i)
        {
            char playerSing = ' ';

            if (p == 1)
                playerSing = 'X';
            else if (p == 2)
                playerSing = 'O';

            switch (i)
            {
                case 1: playfield[0, 0] = playerSing; break;
                case 2: playfield[0, 1] = playerSing; break;
                case 3: playfield[0, 2] = playerSing; break;
                case 4: playfield[1, 0] = playerSing; break;
                case 5: playfield[1, 1] = playerSing; break;
                case 6: playfield[1, 2] = playerSing; break;
                case 7: playfield[2, 0] = playerSing; break;
                case 8: playfield[2, 1] = playerSing; break;
                case 9: playfield[2, 2] = playerSing; break;

            }
        }
        //Funkcija za prikaz
        static void SetField()
        {
            Console.Clear();
            Console.WriteLine(" \t| \t|");
            Console.WriteLine("    " + playfield[0, 0] + "   |   " + playfield[0, 1] + "   |    " + playfield[0, 2]);
            Console.WriteLine("________|_______|________");
            Console.WriteLine("     " + "   |    " + "   |   ");
            Console.WriteLine("    " + playfield[1, 0] + "   |   " + playfield[1, 1] + "   |    " + playfield[1, 2]);
            Console.WriteLine("________|_______|________");
            Console.WriteLine("     " + "   |    " + "   |   ");
            Console.WriteLine("    " + playfield[2, 0] + "   |   " + playfield[2, 1] + "   |    " + playfield[2, 2]);
            Console.WriteLine("     " + "   |    " + "   |   ");
            turns++;
        }

    }
}