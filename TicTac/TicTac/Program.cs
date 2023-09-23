namespace TicTacToe
{
    class Program
    {
        static int turns = 0;
        private static char[,] playField =
        {
            { '1', '2', '3' },
            { '4', '5', '6' },
            { '7', '8', '9' }
        };
        static void Main(string[] args)
        {
            int player =  2;
            int input = 0;
            bool inputCorrect = true;
            do
            {
                if (player == 2)
                {
                    player = 1;
                    EnterXorO(player, input);
                    turns++;
                }
                else if (player == 1)
                {
                    player = 2;
                    EnterXorO(player,input);
                    turns++;
                }

                if (turns == 10)
                {
                    Console.WriteLine("Draw! Press Enter to Reset...");
                    Console.ReadKey();
                    reset();
                }
        
                
                SetField();
                CheckForWinner();
                do
                {
                    Console.Write($"Player {player}: Choose your field! (To exit type 'Exit'): ");
               
                    try
                    {
                        string? currentInput = Console.ReadLine();
                        if (currentInput.ToLower() == "exit")
                        {
                            Console.Write("Done! Press Enter to Exit...");
                            Console.ReadLine();
                            Environment.Exit(0);
                        }
                        else input = Convert.ToInt32(currentInput);

                    }
                    catch
                    {
                        Console.WriteLine("Please enter correct number!");
                    }
                

                    if (input == 1 && playField[0, 0] == '1') inputCorrect = true; 
                    else if (input == 2 && playField[0, 1] == '2') inputCorrect = true; 
                    else if (input == 3 && playField[0, 2] == '3') inputCorrect = true; 
                    else if (input == 4 && playField[1, 0] == '4') inputCorrect = true; 
                    else if (input == 5 && playField[1, 1] == '5') inputCorrect = true; 
                    else if (input == 6 && playField[1, 2] == '6') inputCorrect = true; 
                    else if (input == 7 && playField[2, 0] == '7') inputCorrect = true; 
                    else if (input == 8 && playField[2, 1] == '8') inputCorrect = true; 
                    else if (input == 9 && playField[2, 2] == '9') inputCorrect = true;
                    else
                    {
                        Console.WriteLine("\nIncorrect Input! Use Another Field");
                        inputCorrect = false;
                    }
                } while (!inputCorrect);
            } while (true);
        }

        public static void SetField()
        {
            Console.Clear();
            Console.WriteLine("     |     |     |\n" +
                              "  {0}  |  {1}  |  {2}  |\n" +
                              "_____|_____|_____|\n" +
                              "     |     |     |\n" +
                              "  {3}  |  {4}  |  {5}  |\n" +
                              "_____|_____|_____|\n" +
                              "     |     |     |\n" +
                              "  {6}  |  {7}  |  {8}  |\n" +
                              "_____|_____|_____|\n", 
                
                playField[0,0],playField[0,1],playField[0,2],playField[1,0],playField[1,1],playField[1,2],playField[2,0],playField[2,1],playField[2,2]);
        }


        public static void CheckForWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //horizontal check
                    if (playField[j, 0] == playField[j, 1] && playField[j, 1] == playField[j, 2])
                    {
                        string winner = "";
                        char player = playField[j, 0];
                        string[] playerNumber = new string[] { "1", "2" };
                        if (player == 'X') winner = playerNumber[0];
                        else winner = playerNumber[1];
                        Console.Write("Winner is Player {0}! Press Enter to Reset...", winner);
                        Console.ReadKey();
                        reset();
                        break;
                    }
                    //vertical check
                    else if (playField[0, j] == playField[1, j] && playField[1, j] == playField[2, j])
                    {
                        string winner = "";
                        char player = playField[0, j];
                        string[] playerNumber = new string[] { "1", "2" };
                        if (player == 'X') winner = playerNumber[0];
                        else winner = playerNumber[1];
                        Console.Write("Winner is Player {0}! Press Enter to Reset...", winner);
                        Console.ReadKey();
                        reset();
                        break;
                    }

                    //left to right diagonal2
                    else if (playField[0,0] == playField[1,1] && playField[1,1] == playField[2,2])
                    {
                        string winner = "";
                        char player = playField[0, 0];
                        string[] playerNumber = new string[] { "1", "2" };
                        if (player == 'X') winner = playerNumber[0];
                        else winner = playerNumber[1];
                        Console.Write("Winner is Player {0}! Press Enter to Reset...", winner);
                        Console.ReadKey();
                        reset();
                        break;
                    }
                    //right to left diagonal
                    else if (playField[0,2] == playField[1,1] && playField[1,1] == playField[2,0])
                    {
                        string winner = "";
                        char player = playField[0, 2];
                        string[] playerNumber = new string[] { "1", "2" };
                        if (player == 'X') winner = playerNumber[0];
                        else winner = playerNumber[1];
                        Console.Write("Winner is Player {0}! Press Enter to Reset...", winner);
                        Console.ReadKey();
                        reset();
                        break;
                    }
                }
            }
            

        }
        public static void EnterXorO(int player, int input)
        {
            char playerSign = ' ';
            if (player == 1) playerSign = 'X';
            else if (player == 2) playerSign = 'O';
            switch (input)
            {
                case 1: playField[0, 0] = playerSign; break;
                case 2: playField[0, 1] = playerSign; break;
                case 3: playField[0, 2] = playerSign; break;
                case 4: playField[1, 0] = playerSign; break;
                case 5: playField[1, 1] = playerSign; break;
                case 6: playField[1, 2] = playerSign; break;
                case 7: playField[2, 0] = playerSign; break;
                case 8: playField[2, 1] = playerSign; break;
                case 9: playField[2, 2] = playerSign; break;
            }
        }

        
        public static void reset()
        {
            playField = new char[,]
            {
                { '1', '2', '3' },
                { '4', '5', '6' },
                { '7', '8', '9' }
            };
            turns = 0;
            SetField();
        }
    }
}
