using System;
using static System.Console;

namespace oopsjava
{
    class Main_Program
    {
        public static void Main(string[] args)
        {
            Clear();
            int gameChoice; // choice for game
            Write(" Hello you have the following game options:\n");
            WriteLine(" 1: Tic tac toe \n 2: Nine men morris Aka Mills \n Please enter 1 or 2 for the game");
            WriteLine(" Press 3 for help");
            gameChoice = Convert.ToInt32(ReadLine());
            bool exit = true;// Validity 
            while (exit != false)
            {
                int playerChoice;// Player choice 
                if (gameChoice == 1)
                {
                    // tic- tac - toe
                    WriteLine(" Tic tac toe");
                    WriteLine(" Press 1 to play vs friend and 2 to play against computer");
                    playerChoice = Convert.ToInt32(ReadLine());
                    Tic_Tac_Toe_Game tic_Tac_Toe_ = new Tic_Tac_Toe_Game();
                    if (playerChoice == 1)
                    {
                        // Friend algorithm 
                        WriteLine(" Friend vs Friend");
                        tic_Tac_Toe_.playerVsPlayer();
                        break;
                    }
                    if (playerChoice == 2)
                    {
                        // Computer algorithm
                        WriteLine(" Computer algorithm");
                        tic_Tac_Toe_.playerVsRandom();
                        break;

                    }
                    else
                    {
                        WriteLine(" Invalid key entered. Press 1:Friend vs Friend \n 2: Computer algorithm or any key to exit");
                        playerChoice = Convert.ToInt32(ReadLine());
                        if (playerChoice != 1 || playerChoice != 2)
                        {
                            exit = false;
                            break;
                        }

                    }
                }

                if (gameChoice == 2)
                {
                    // Nine men morris
                    WriteLine(" Nine- men morris");
                    WriteLine(" Press 1 to play vs friend and 2 to play against computer");
                    playerChoice = Convert.ToInt32(ReadLine());
                    Nine_men_morris nine_Men_Morris = new Nine_men_morris();
                    if (playerChoice == 1)
                    {
                        // Friend algorithm 
                        WriteLine(" Friend vs Friend");
                        nine_Men_Morris.playerVsPlayer();
                        break;

                    }
                    if (playerChoice == 2)
                    {
                        // Computer algorithm
                        WriteLine(" Computer algorithm");
                        nine_Men_Morris.playerVsRandom_moves();
                        break;
                    }
                    else
                    {
                        WriteLine(" Invalid key entered. Press 1:Friend vs Friend \n 2: Computer algorithm or any key to exit ");
                        playerChoice = Convert.ToInt32(ReadLine());
                        if (playerChoice != 1 || playerChoice != 2)
                        {
                            exit = false;
                            break;
                        }
                    }
                }
                if (gameChoice == 3)
                {
                    Help helpobj = new Help();
                    helpobj.helpFunction();
                    exit = false;
                }
                else
                {
                    WriteLine(" Invalid key entered. Press 1:Tic tac toe \n 2: Nine men morris Aka Mills or 0 to exit ");
                    gameChoice = Convert.ToInt32(ReadLine());
                    if (gameChoice == 0)
                    {
                        exit = false;
                    }
                }
            }
        }

    }

    class Help
    {
        public void helpFunction()
        {
            WriteLine(" The commands are simple ");
            WriteLine(" The link for Tic tac toe game is https://en.wikipedia.org/wiki/Tic-tac-toe");
            WriteLine(" The link for Tic tac toe game is https://en.wikipedia.org/wiki/Nine_men%27s_morris");
            WriteLine(" The link for Tic tac toe game is https://en.wikipedia.org/wiki/Reversi");
        }
    }
    class Tic_Tac_Toe_Game
    {
        int[,] tic_tac_toe = new int[,] // Main array 
          {
                { 1,1,1},           // {1,2,3}
                { 1,1,1},           // {4,5,6}
                { 1,1,1}            // {7,8,9}
          };
        int current_player = 0;
        int player1_value = 0; int player2_value = 0; // o -100 x -200
        int[] position = new int[9];
        int enterposition = 0;//value from user
        int random_position;
        Toss tossobj = new Toss();
        Change_player changeplayerobj = new Change_player();
        Exit exitObj = new Exit();
        Game_win gamewinobj = new Game_win();
        public static void main()
        {

        }
        public void playerVsPlayer()
        {
            int winner = tossobj.toss();// Choosing to go first
            position[0] = 1;
            position[1] = 2;
            position[2] = 3;
            position[3] = 4;
            position[4] = 5;
            position[5] = 6;
            position[6] = 7;
            position[7] = 8;
            position[8] = 9;
            char player_1; char player_2;
            char x = 'x'; char o = 'o';

            if (winner == 1)
            {
                WriteLine(" Player 1 won the toss. \n Player 1 choose either x or o");
                player_1 = Convert.ToChar(ReadLine());
                if (player_1 == x)
                {
                    player_2 = o;
                    player1_value = 200;
                    player2_value = 100;
                }
                else

                {
                    player_2 = x;
                    player1_value = 100;
                    player2_value = 200;
                }
                WriteLine("Player 1 is {0} . Player 2 is {1}", player_1, player_2);
                current_player = 1;
            }
            else
            {
                WriteLine(" Player 2 won the toss. \n Player 2 choose either x or o");
                player_2 = Convert.ToChar(ReadLine());
                if (player_2 == x)
                {
                    player_1 = o;
                    player1_value = 100;
                    player2_value = 200;
                }
                else
                {
                    player_1 = x;
                    player1_value = 200;
                    player2_value = 100;
                }
                WriteLine("Player 1 is {0} . Player 2 is {1}", player_1, player_2);
                current_player = 2;
            }
            WriteLine(" Your board is set up ");
            display(tic_tac_toe, current_player);
            int counter = 0;
            do
            {
                playerVsPlayer_Moves();
                display(tic_tac_toe, current_player);
                if (gamewinobj.game_win(tic_tac_toe) == true)
                    win();
                current_player = changeplayerobj.changeplayer(current_player);
                counter++;
            } while (counter < 9);
            WriteLine(" Game draw");
        }
        private void display(int[,] arr, int currentplayer)
        {
            WriteLine(" Valid positions");
            for (int i = 0; i < 9; i++)
            {
                if (position[i] > 10)
                {
                    Write("-\t");
                    if (i == 2 || i == 5)
                        WriteLine();
                    continue;
                }
                Write("{0}\t", position[i]);
                if (i == 2 || i == 5)
                    WriteLine();
            }
            WriteLine();
            WriteLine("Player" + currentplayer);
            WriteLine("----------------------------");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arr[i, j] == 100)
                    {
                        Console.Write("O \t");
                    }
                    else if (arr[i, j] == 200)
                    {
                        Console.Write("X \t");
                    }
                    else
                    {
                        Console.Write("- \t");
                    }
                }
                Console.WriteLine();
            }
        }
        private void playerVsPlayer_Moves()
        {
            do
            {
                WriteLine("{0} Player enter postion", current_player);
                enterposition = Convert.ToInt32(ReadLine());
            } while (input_Validity(enterposition) != true);
            if (overlap_tic_tac_toe(enterposition, position) == true)
                playerVsPlayer_Moves();
            if (current_player == 1)
                position[enterposition - 1] = player1_value;
            else
                position[enterposition - 1] = player2_value;
            arrayValue();
            gamewinobj.game_win(tic_tac_toe);
        }
        private bool input_Validity(int postion)
        {
            bool error = true;
            if (postion > 0 && postion < 9)
                if (postion == 0)
                    exitObj.exit();
            return error;
        }
        private void win()
        {
            WriteLine("Game won");
            exitObj.exit();
        }
        private void arrayValue()
        {
            tic_tac_toe[0, 0] = position[0];
            tic_tac_toe[0, 1] = position[1];
            tic_tac_toe[0, 2] = position[2];
            tic_tac_toe[1, 0] = position[3];
            tic_tac_toe[1, 1] = position[4];
            tic_tac_toe[1, 2] = position[5];
            tic_tac_toe[2, 0] = position[6];
            tic_tac_toe[2, 1] = position[7];
            tic_tac_toe[2, 2] = position[8];
        }
        public void playerVsRandom()
        {
            position[0] = 1;
            position[1] = 2;
            position[2] = 3;
            position[3] = 4;
            position[4] = 5;
            position[5] = 6;
            position[6] = 7;
            position[7] = 8;
            position[8] = 9;
            WriteLine(" Player is X and Computer is 0");
            player1_value = 200;
            player2_value = 100;
            current_player = 1;
            WriteLine(" Your board is set up ");
            display(tic_tac_toe, current_player);
            int counter = 0;
            do
            {
                playerVsRandom_moves();
                display(tic_tac_toe, current_player);
                if (gamewinobj.game_win(tic_tac_toe) == true)
                    win();
                changeplayerobj.changeplayer(current_player);
                counter++;
            } while (counter < 9);
            WriteLine(" Game draw");
        }
        private void playerVsRandom_moves()
        {
            if (current_player == 1)
            {
                do
                {
                    WriteLine("{0} Player enter postion", current_player);
                    enterposition = Convert.ToInt32(ReadLine());
                } while (input_Validity(enterposition) != true);
                if (overlap_tic_tac_toe(enterposition, position) == true)
                    playerVsRandom_moves();
                position[enterposition - 1] = player1_value;
            }
            else
                random();
            arrayValue();
            gamewinobj.game_win(tic_tac_toe);
        }
        private int random()
        {
            var rand = new Random();
            random_position = rand.Next(1, 9);
            if (position[random_position - 1] == player1_value)
            {
                while (position[random_position - 1] == player1_value)
                {
                    random_position = rand.Next(1, 9);
                }
                position[random_position - 1] = player2_value;
            }
            else
                position[random_position - 1] = player2_value;
            return random_position;
        }
        public bool overlap_tic_tac_toe(int enterpostion, int[] position)
        {
            if (position[enterpostion - 1] == 100 || position[enterpostion - 1] == 200)
            {
                WriteLine(" You are trying to overlap a position");
                return true;
            }
            else
                return false;
        }
    }
    class Nine_men_morris
    {
        int[,] board = new int[,]
        {
            {0,100,100,0,100,100,0},//a - a7 a4 a1 (0,3,6)
            {100,0,100,0,100,0,100},//b- b2 b4 b6 (1,3,5)
            {100,100,0,0,0,100,100},//c c3 c4 c5(2,3,4)
            {0,0,0,100,0,0,0},//d d7 d6 d5 d1 d2 d3(0,1,2,4,5,6)
            {100,100,0,0,0,100,100},//e e3 e4 e5(2,3,4)
            {100,0,100,0,100,0,100},//f f2 f4 f6(1,3,5)
            {0,100,100,0,100,100,0}//g g7 g4 g1(0,3,6)           
        };
        int random_position;
        int black = 7; int white = 10;//black and white piece
        int white_piece_counter = 9; int black_piece_counter = 9;// 9 coins each 
        int player_1; int player_2;// player 1 and player 2 white or black value
        int playermill;// Storage of player who formed the mill
        int remove_position;
        int current_player = 1;//1 -player1 2- player 2        
        int[] position = new int[24];
        int enter_position;
        int[,] board_moves = new int[,]
        {
           {1,0,0,8,0,0,7},
           {0,9,0,16,0,15,0},
           {0,0,17,24,23,0,0},
           {2,10,18,0,22,14,6},
           {0,0,19,20,21,0,0},
           {0,11,0,12,0,13,0},
           {3,0,0,4,0,0,5},
        };
        int counter1 = 0; int counter2 = 0; int counter3 = 0; int counter4 = 0; int counter5 = 0; int counter6 = 0; int counter7 = 0; int counter8 = 0; int counter9 = 0;
        int counter10 = 0; int counter11 = 0; int counter12 = 0; int counter13 = 0; int counter14 = 0; int counter15 = 0; int counter16 = 0;
        Toss tossobj1 = new Toss();
        Change_player changeplayer0bj = new Change_player();
        Exit exitobj = new Exit();
        public static void main()
        {

        }
        public void playerVsPlayer()
        {

            int winner = tossobj1.toss();
            if (winner == 1)
            {
                WriteLine(" Player 1 won the toss. \n Player 1 is Yellow and Player 2 is Red. ");
                player_1 = 10;
                player_2 = 7;
                current_player = 1;
            }
            else
            {
                WriteLine(" Player 2 won the toss. \nPlayer 1 is Red and Player 2 is Yellow. ");
                player_1 = 7;
                player_2 = 10;
                current_player = 2;
            }
            WriteLine(" Your board is set up ");
            display(board, current_player);
            while (white_piece_counter != 2 || black_piece_counter != 2)
            {
                moves();
                display(board, current_player);
                current_player = changeplayer0bj.changeplayer(current_player);
            }

            if (white_piece_counter == 2)
                if (player_1 == 10)
                    WriteLine(" Player 2 Won");
                else
                    WriteLine(" Player 1 Won");
            if (black_piece_counter == 2)
                if (player_2 == 7)
                    WriteLine(" Player 1 Won");
                else
                    WriteLine(" Player 2 Won");
            exitobj.exit();

        }
        private void display(int[,] arr, int currentplayer)
        {
            WriteLine(" Valid positions");
            WriteLine();
            WriteLine("----------------------------");
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    if (board_moves[i, j] != 0)
                        Write("{0}\t\t", board_moves[i, j]);
                    if (board_moves[i, j] == 0)
                        Write("-\t\t");
                }
                WriteLine();
            }
            WriteLine();
            WriteLine(" Current Player is " + currentplayer);
            WriteLine();
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (arr[i, j] == 10)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Write("{0}\t\t", arr[i, j]);
                        continue;
                    }
                    if (arr[i, j] == 7)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Write("{0}\t\t", arr[i, j]);
                        continue;
                    }
                    if (arr[i, j] == 100)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Write("-\t\t");
                        continue;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Write("{0}\t\t", arr[i, j]);
                        continue;
                    }
                }
                WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;
            WriteLine(" Number of Yellow piece is {0} and the number of Red piece is {1}", white_piece_counter, black_piece_counter);
        }
        private void moves()
        {
            do
            {
                WriteLine();
                WriteLine(" Enter the position player {0}", current_player);
                enter_position = Convert.ToInt32(ReadLine());
            } while (enter_position <= 0 && enter_position > 25); // valid points only on board
            if (overlap_nine_men_morris(enter_position, position) == true)
                moves();
            if (current_player == 1)
            {
                if (player_1 == 10)
                {
                    position[enter_position - 1] = player_1;
                    white_piece_counter--;
                }
                else
                {
                    position[enter_position - 1] = player_1;
                    black_piece_counter--;
                }
            }
            if (current_player == 2)
            {
                if (player_2 == 10)
                {
                    position[enter_position - 1] = player_2;
                    white_piece_counter--;
                }
                else
                {
                    position[enter_position - 1] = player_2;
                    black_piece_counter--;
                }
            }
            array_Value();
            if (mill() == true)
            {
                WriteLine(" You formed a mill");
                remove_Piece();
            }
        }
        private void array_Value()
        {
            board[0, 0] = position[0]; //1
            board[3, 0] = position[1]; //2
            board[6, 0] = position[2]; //3
            board[6, 3] = position[3]; //4
            board[6, 6] = position[4]; //5
            board[3, 6] = position[5]; //...
            board[0, 6] = position[6];
            board[0, 3] = position[7];
            board[1, 1] = position[8];
            board[3, 1] = position[9];
            board[5, 1] = position[10];
            board[5, 3] = position[11];
            board[5, 5] = position[12];
            board[3, 5] = position[13];
            board[1, 5] = position[14];
            board[1, 3] = position[15];
            board[2, 2] = position[16];
            board[3, 2] = position[17];
            board[4, 2] = position[18];
            board[4, 3] = position[19];
            board[4, 4] = position[20];
            board[3, 4] = position[21];
            board[2, 4] = position[22];
            board[2, 3] = position[23]; //24
        }
        public bool overlap_nine_men_morris(int enter_position, int[] position)
        {
            if (position[enter_position - 1] == 10 || position[enter_position - 1] == 7)
            {
                WriteLine(" You are trying to overlap a position");
                return true;
            }
            else
                return false;
        }
        private bool mill()
        {
            int total;
            total = position[0] + position[1] + position[2];
            if (total == 30 && counter1 != 1)
            {
                playermill = white;
                counter1 = 1;
                return true;
            }
            if (total == 21 && counter1 != 1)
            {
                playermill = black;
                counter1 = 1;
                return true;
            }
            else
                counter1 = 0;
            total = 0;
            total = position[2] + position[3] + position[4];
            if (total == 30 && counter2 != 1)
            {
                playermill = white;
                counter2 = 1;
                return true;
            }
            if (total == 21 && counter2 != 1)
            {
                playermill = black;
                counter2 = 1;
                return true;
            }
            else
                counter2 = 0;
            total = 0;
            total = position[4] + position[5] + position[6];
            if (total == 30 && counter3 != 1)
            {
                playermill = white;
                counter3 = 1;
                return true;
            }
            if (total == 21 && counter3 != 1)
            {
                playermill = black;
                counter3 = 1;
                return true;
            }
            else
                counter3 = 0;
            total = 0;
            total = position[6] + position[7] + position[0];
            if (total == 30 && counter4 != 1)
            {
                playermill = white;
                counter4 = 1;
                return true;
            }
            if (total == 21 && counter4 != 1)
            {
                playermill = black;
                counter4 = 1;
                return true;
            }
            else
                counter4 = 0;
            total = 0;
            total = position[8] + position[9] + position[10];
            if (total == 30 && counter5 != 1)
            {
                playermill = white;
                counter5 = 1;
                return true;
            }
            if (total == 21 && counter5 != 1)
            {
                playermill = black;
                counter5 = 1;
                return true;
            }
            else
                counter5 = 0;
            total = 0;
            total = position[10] + position[11] + position[12];
            if (total == 30 && counter6 != 1)
            {
                playermill = white;
                counter6 = 1;
                return true;
            }
            if (total == 21 && counter6 != 1)
            {
                playermill = black;
                counter6 = 1;
                return true;
            }
            else
                counter6 = 0;
            total = 0;
            total = position[12] + position[13] + position[14];
            if (total == 30 && counter7 != 1)
            {
                playermill = white;
                counter7 = 1;
                return true;
            }
            if (total == 21 && counter7 != 1)
            {
                playermill = black;
                counter7 = 1;
                return true;
            }
            else
                counter7 = 0;
            total = 0;
            total = position[14] + position[15] + position[8];
            if (total == 30 && counter8 != 1)
            {
                playermill = white;
                counter8 = 1;
                return true;
            }
            if (total == 21 && counter8 != 1)
            {
                playermill = black;
                counter8 = 1;
                return true;
            }
            else
                counter8 = 0;
            total = 0;
            total = position[16] + position[17] + position[18];
            if (total == 30 && counter9 != 1)
            {
                playermill = white;
                counter9 = 1;
                return true;
            }
            if (total == 21 && counter9 != 1)
            {
                playermill = black;
                counter9 = 1;
                return true;
            }
            else
                counter9 = 0;
            total = 0;
            total = position[18] + position[19] + position[20];
            if (total == 30 && counter10 != 1)
            {
                playermill = white;
                counter10 = 1;
                return true;
            }
            if (total == 21 && counter10 != 1)
            {
                playermill = black;
                counter10 = 1;
                return true;
            }
            else
                counter10 = 0;
            total = 0;
            total = position[20] + position[21] + position[22];
            if (total == 30 && counter11 != 1)
            {
                playermill = white;
                counter11 = 1;
                return true;
            }
            if (total == 21 && counter11 != 1)
            {
                playermill = black;
                counter11 = 1;
                return true;
            }
            else
                counter11 = 0;
            total = 0;
            total = position[22] + position[23] + position[16];
            if (total == 30 && counter12 != 1)
                if (total == 30 && counter12 != 1)
                {
                    playermill = white;
                    counter12 = 1;
                    return true;
                }
            if (total == 21 && counter12 != 1)
            {
                playermill = black;
                counter12 = 1;
                return true;
            }
            else
                counter12 = 0;
            total = 0;
            total = position[7] + position[15] + position[23];
            if (total == 30 && counter13 != 1)
            {
                playermill = white;
                counter13 = 1;
                return true;
            }
            if (total == 21 && counter13 != 1)
            {
                playermill = black;
                counter13 = 1;
                return true;
            }
            else
                counter13 = 0;
            total = 0;
            total = position[1] + position[9] + position[17];
            if (total == 30 && counter14 != 1)
            {
                playermill = white;
                counter14 = 1;
                return true;
            }
            if (total == 21 && counter14 != 1)
            {
                playermill = black;
                counter14 = 1;
                return true;
            }
            else
                counter14 = 0;
            total = 0;
            total = position[5] + position[13] + position[21];
            if (total == 30 && counter15 != 1)
            {
                playermill = white;
                counter15 = 1;
                return true;
            }
            if (total == 21 && counter15 != 1)
            {
                playermill = black;
                counter15 = 1;
                return true;
            }
            else
                counter15 = 0;
            total = 0;
            total = position[3] + position[12] + position[20];
            if (total == 30 && counter16 != 1)
                if (total == 30 && counter16 != 1)
                {
                    playermill = white;
                    counter16 = 1;
                    return true;
                }
            if (total == 21 && counter16 != 1)
            {
                playermill = black;
                counter16 = 1;
                return true;
            }
            else
                counter16 = 0;
            total = 0;
            return false;
        }
        private void remove_Piece()
        {
            display(board, current_player);
            do
            {
                WriteLine(" You formed a MILL");
                WriteLine(" Enter a position to remove");
                remove_position = Convert.ToInt32(ReadLine());
                if (current_player == 1)
                {
                    if (playermill == white)
                    {
                        if (position[remove_position - 1] == black)
                            position[remove_position - 1] = 0;
                        else
                        {
                            WriteLine(" There is no opponent piece there");
                            remove_Piece();
                        }
                        black_piece_counter--;
                    }
                    else
                    {
                        if (position[remove_position - 1] == white)
                            position[remove_position - 1] = 0;
                        else
                        {
                            WriteLine(" There is no opponent piece there");
                            remove_Piece();
                        }
                        white_piece_counter--;
                    }
                }
                else
                {
                    if (playermill == white)
                    {
                        if (position[remove_position - 1] == black)
                            position[remove_position - 1] = 0;
                        else
                        {
                            WriteLine(" There is no opponent piece there");
                            remove_Piece();
                        }
                        black_piece_counter--;
                    }
                    else
                    {
                        if (position[remove_position] == white)
                            position[remove_position] = 0;
                        else
                        {
                            WriteLine(" There is no opponent piece there");
                            remove_Piece();
                        }
                        white_piece_counter--;
                    }
                }
            } while (remove_position < 0 && remove_position > 25);
            array_Value();
        }

        public void playerVsRandom_moves()
        {
            WriteLine(" Player is Yellow and Computer is Red");
            player_1 = 10;
            player_2 = 7;
            if (current_player == 1)
            {
                do
                {
                    WriteLine();
                    WriteLine(" Enter the position player {0}", current_player);
                    enter_position = Convert.ToInt32(ReadLine());
                } while (enter_position <= 0 && enter_position > 25); // valid points only on board
                if (overlap_nine_men_morris(enter_position, position) == true)
                    playerVsRandom_moves();
                position[enter_position - 1] = player_1;
                white_piece_counter--;
            }
            else
                random();
            array_Value();
            while (white_piece_counter != 2 || black_piece_counter != 2)
            {
                display(board, current_player);
                current_player = changeplayer0bj.changeplayer(current_player);
                playerVsRandom_moves();
            }
            if (white_piece_counter == 2)
                if (player_1 == 10)
                    WriteLine(" Computer Won");
                else
                    WriteLine(" Player 1 Won");
            if (black_piece_counter == 2)
                if (player_2 == 7)
                    WriteLine(" Player 1 Won");
                else
                    WriteLine(" Computer Won");
            exitobj.exit();
        }
        private int random()
        {
            var rand = new Random();
            random_position = rand.Next(1, 26);
            if (position[random_position - 1] == player_1)
            {
                while (position[random_position - 1] == player_1)
                {
                    random_position = rand.Next(1, 26);
                }
                position[random_position - 1] = player_2;
            }
            else
                position[random_position - 1] = player_2;
            black_piece_counter--;
            array_Value();
            display(board, current_player);
            return random_position;
        }
    }
    class Toss
    {
        public int toss()
        {
            int win;
            int player_choice_toss;
            int output_toss;
            WriteLine(" Player 1 choose Heads or tails.\n Press 1 for Heads and 2 for Tails.");
            player_choice_toss = Convert.ToInt32(ReadLine());
            do
            {
                if (player_choice_toss == 1)
                {
                    WriteLine(" Player 1 is Heads and player 2 is tails");
                    break;
                }
                if (player_choice_toss == 2)
                {
                    WriteLine(" Player 1 is Tails and player 2 is Heads");
                    break;
                }
                else
                {
                    WriteLine(" Please enter valid input. Player 1 choose Heads or tails.\n Press 1 for Heads and 2 for Tails.");
                    player_choice_toss = Convert.ToInt32(ReadLine());
                }
            } while (player_choice_toss <= 1 || player_choice_toss >= 2);
            WriteLine("");
            var rng = new Random();
            if (rng.NextDouble() < 0.5)
            {
                Console.WriteLine("Heads!");
                output_toss = 1;
            }
            else
            {
                Console.WriteLine("Tails!");
                output_toss = 2;
            }
            if (player_choice_toss == output_toss)
                win = 1;

            else
                win = 2;
            return win;
        }
    }
    class Change_player
    {
        public int changeplayer(int current_player)
        {
            if (current_player == 1)
            {
                current_player = 2;
            }
            else
                current_player = 1;
            return current_player;
        }
    }
    class Exit
    {
        public void exit()
        {
            WriteLine("Game over");
            ReadKey();
        }
    }
    class Game_win
    {
        public bool game_win(int[,] tic_tac_toe)
        {
            //calculate sum of rows
            int sum = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    sum += tic_tac_toe[i, j];
                }
                if (sum == 300 || sum == 600)
                {

                    return true; ;
                }
                sum = 0;
            }

            //calculate sum of cols
            for (int i = 0; i < 3; i++)
            {
                sum = 0;
                for (int j = 0; j < 3; j++)
                {
                    sum += tic_tac_toe[j, i];
                }
                if (sum == 300 || sum == 600)
                {

                    return true; ;
                }
            }
            //calculate sum of diameter \
            sum = tic_tac_toe[1, 1] + tic_tac_toe[2, 2] + tic_tac_toe[0, 0];
            if (sum == 300 || sum == 600)
            {
                return true;

            }
            //calculate sum of sub diameter /
            sum = tic_tac_toe[0, 2] + tic_tac_toe[1, 1] + tic_tac_toe[2, 0];
            if (sum == 300 || sum == 600)
            {
                return true;

            }
            return false;
        }
    }
}
    

