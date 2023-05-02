using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace JCS09
{
    public class Dama
    {
        
        /* Proč je konstruktor nad sloty + proč rovnou nepřiřazuje hodnoty v konstruktoru, ale vytváří si proměnnou a potom hned ji přiřadí, hůře čitelné */
        public Dama()
        {
            int[,] board = new int[8, 8];
            this.board = board;

            int white = 11;
            this.white = white;

            int black = 21;
            this.black = black;

            int who_is_playing = 1;
            this.who_is_playing = who_is_playing;

            int rest_of_whites = 0;
            this.rest_of_whites = rest_of_whites;

            int rest_of_blacks = 0;
            this.rest_of_blacks = rest_of_blacks;
        }

        private int[,] board;
        private int white;
        private int black;
        private int who_is_playing;
        private int rest_of_whites;
        private int rest_of_blacks;

        /* Větvení by mohlo být o dost lépe vymyšlené */
        public int[,] GetBoard() //Základní vytvoření boardu, které běží pod grafickou stránkou boardu a díky ní se i tvoří.
        {
            for (int row_index = 0; row_index < 8; row_index++)
            {
                for (int column_index = 0; column_index < 8; column_index++)
                    //white
                    if (row_index == 0 || row_index == 2)
                    {
                        if (column_index % 2 == 0)
                        {
                            board[row_index, column_index] = (int)CheckersPiece.none;
                        }

                        else
                        {
                            var basic_white = CheckersPiece.basic | CheckersPiece.white;
                            board[row_index, column_index] = (int)basic_white;
                        }

                    }

                    else if (row_index == 1)
                    {
                        if (column_index % 2 == 0)
                        {
                            var basic_white = CheckersPiece.basic | CheckersPiece.white;
                            board[row_index, column_index] = (int)basic_white;
                        }

                        else
                        {
                            board[row_index, column_index] = (int)CheckersPiece.none;
                        }

                    }

                    //black

                    else if (row_index == 5 || row_index == 7)
                    {
                        if (column_index % 2 == 0)
                        {
                            var basic_black = CheckersPiece.basic | CheckersPiece.black;
                            board[row_index, column_index] = (int)basic_black;
                        }

                        else
                        {
                            board[row_index, column_index] = (int)CheckersPiece.none;
                        }
                    }

                    else if (row_index == 6)
                    {
                        if (column_index % 2 == 0)
                        {
                            board[row_index, column_index] = (int)CheckersPiece.none;
                        }

                        else
                        {
                            var basic_black = CheckersPiece.basic | CheckersPiece.black;
                            board[row_index, column_index] = (int)basic_black;
                        }
                    }

                    //none
                    else
                    {
                        var none = CheckersPiece.none;
                        board[row_index, column_index] = (int)none;
                    }

            }
            return board;
        }

        [Flags]
        public enum CheckersPiece //White +10 and black +20
        {
            none = 0X0,
            basic = 0X1,
            lady = 0X2,

            white = 0XA,
            black = 0X14
        }
        /* Proč plete vypsání boardu s logikou hry. Špatná čitelnost kódu -> zbytečně moc velké metody. Bylo by lepší, kdyby si to rozdělil -1*/ 
        public string Print_Graphic_Board_And_Check_End() //Zobrazování boardu, ohraničení a check jestli není už hra u konce.
        {
            int color_of_board = 1; //pro zabarvení šachovnice

            Console.WriteLine();
            for (int row_index = -2; row_index < 10; row_index++)
            {
                for (int column_index = -2; column_index < 10; column_index++)
                {
                    if (row_index > -1 && row_index < 8)
                    {
                        if (column_index > 0 && column_index < 8)
                        {
                            if (color_of_board % 2 != 0)
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                            }

                            else
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                            }


                            if (board[row_index, column_index] == 0)
                            {
                                Console.Write("  ");
                            }

                            else if (board[row_index, column_index] == white)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write("O ");
                                Console.ResetColor();
                                rest_of_whites += 1; //Přičítání kolik je ještě bílých kamenů
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write("O ");
                                Console.ResetColor();
                                rest_of_blacks += 1; //Přičítání kolik je ještě černých kamenů
                            }

                            Console.ResetColor();
                            color_of_board += 1;
                        }

                        else if (column_index == 0)
                        {
                            if (color_of_board % 2 != 0)
                            {
                                Console.BackgroundColor = ConsoleColor.White;
                            }

                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Magenta;
                            }

                            if (board[row_index, column_index] == 0)
                            {
                                Console.Write("   ");

                            }

                            else if (board[row_index, column_index] == white)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(" O ");
                                Console.ResetColor();
                                rest_of_whites += 1; //Přičítání kolik je ještě bílých kamenů
                            }

                            else
                            {
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.Write(" O ");
                                Console.ResetColor();
                                rest_of_blacks += 1; //Přičítání kolik je ještě černých kamenů
                            }
                            Console.ResetColor();
                        }

                        else if (column_index == -2 || column_index == 9)
                        {
                            Console.Write(row_index);
                        }

                        else
                        {
                            Console.Write("|");
                        }

                    }

                    else if (row_index == -2 || row_index == 9) //border
                    {
                        if (column_index == -2 || column_index == 8 || column_index == 9)
                        {
                            Console.Write(" ");
                        }

                        else if (column_index == -1)
                        {
                            Console.Write("  ");
                        }

                        else
                        {
                            Console.Write(column_index + " ");
                        }
                    }

                    else
                    {
                        if (column_index > 0 && column_index < 8)
                        {
                            Console.Write("- ");
                        }

                        else if (column_index == 0)
                        {
                            Console.Write(" - ");
                        }

                        else
                        {
                            Console.Write(" ");
                        }
                    }
                }
                Console.WriteLine();
            }

            //End check
            if (rest_of_blacks == 0)
            {
                return "black";
            }

            else if (rest_of_whites == 0)
            {
                return "white";
            }

            else
            {
                return "none";
            }
        }
    
        public void Start() //Start celé hry
        {
            Console.Write("Do you want start"); //Otázka jestli chceme danou hru zapnout
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(" Checkers");
            Console.ResetColor();
            Console.Write("? (Yes / No)\n");
            string answer_start = Console.ReadLine();
            
            /* Možná by bylo lepší určit více */
            if (answer_start == "Yes" || answer_start == "yes") // Odpověď: ano = Vytvoří se board a zapne se hra
            {
                /* Proč prostě hned nepředpokládá, že začíná bílý hráč, když je to v pravidlech? Play by mohlo být bez board. Board by se bral ze slotu. Nemusel by mít žádný paramaetry */
                int[,] board = GetBoard(); 
                Play(board, who_is_playing);
            }

            else if (answer_start == "No" || answer_start == "no") // Odpověď: ne = Napíše se text a vypne se program
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("So have a great day, Bye!");
                Console.ResetColor();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red; // Odpověď: random text, protože jsou tací co neumí psát = Znovu se zapne start
                Console.WriteLine("Write a better answer! (Yes / No)");
                Console.ResetColor();
                Start();
            }
        }

        private void Play(int[,] checkers_board, int who_is_playing) //Tělo celé hry do kterého se vracíme po každém jednom tahu.
        {
            int[] piece = new int[2]; //Vytvoření pole pro kámen
            if (Print_Graphic_Board_And_Check_End() == "none") //Check kdo vyhrál nebo jestli se v dané hře ještě pokračuje
            {
                piece = Choose_piece(who_is_playing, checkers_board); //Vytvoření kamene s kterým budeme pohybovat
                Choose_move(who_is_playing, checkers_board, piece); //Vybrání si souřadnic kam budeme chtít s kamenem hýbat
                who_is_playing += 1; //Mění se hráč
                Play(checkers_board, who_is_playing); //Zapnutí nového tahu
            }

            else if (Print_Graphic_Board_And_Check_End() == "black")
            {
                Console.WriteLine("\nWhite wins!\nThank you for playing checkers!");
            }

            else
            {
                Console.WriteLine("\nBlack wins!\nThank you for playing checkers!");
            }

        }

        private int[] Choose_piece(int who_is_playing, int[,] board) //Fuknce na vybrání kamene se kterým chceme pohnout
        {
            int[] piece = new int[2];

            if (who_is_playing % 2 != 0) //Check kdo je na tahu
            {
                Console.WriteLine("\nWhite is playing!\nChoose your checkers piece (coordinates e.g. 1,2):");
            }
            else
            {
                Console.WriteLine("\nBlack is playing!\nChoose your checkers piece (coordinates e.g. 1,2):");
            }

            string coordinates_piece = Console.ReadLine();
            
            /* Hodně nečitelný kód.  */
            if (coordinates_piece.Contains(",") == true) //Check jestli dané souřadnice jsou správně napsané
            {
                string firstPart = coordinates_piece.Split(',')[0];
                string secondPart = coordinates_piece.Split(',')[1];
                bool isFirstPartInt = Int32.TryParse(firstPart, out _);
                bool isSecondPartInt = Int32.TryParse(secondPart, out _);

                if (firstPart.Length == 1 && secondPart.Length == 1 && isFirstPartInt == true && isSecondPartInt == true)
                {
                    int x_piece = Int32.Parse(firstPart);
                    int y_piece = Int32.Parse(secondPart);
                    piece[0] = x_piece;
                    piece[1] = y_piece;

                    if (board[x_piece, y_piece] == 11 && who_is_playing % 2 != 0)
                    {
                        return piece;
                    }

                    else if (board[x_piece, y_piece] == 21 && who_is_playing % 2 == 0)
                    {
                        return piece;
                    }

                    else
                    {
                        Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                        return Choose_piece(who_is_playing, board);
                    }
                }
            }
            Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
            return Choose_piece(who_is_playing, board);
        }

        private void Choose_move(int who_is_playing, int[,] board, int[] piece)
        {
            Console.WriteLine("\nChoose your move (coordinates e.g. 1,2):");
            string coordinates_move = Console.ReadLine();
            if (coordinates_move.Contains(",") == true)
            {
                string firstPart = coordinates_move.Split(',')[0];
                string secondPart = coordinates_move.Split(',')[1];
                bool isFirstPartInt = Int32.TryParse(firstPart, out _);
                bool isSecondPartInt = Int32.TryParse(secondPart, out _);

                if (firstPart.Length == 1 && secondPart.Length == 1 && isFirstPartInt == true && isSecondPartInt == true)
                {
                    int x_piece_move = Int32.Parse(firstPart);
                    int y_piece_move = Int32.Parse(secondPart);
                    int[][] unskippable_moves = unskippable_move(board, who_is_playing);

                    if (!(check_move_with_unskippable_moves(unskippable_moves, x_piece_move, y_piece_move)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nYou missed your right move... We must delete it!");
                        Console.ResetColor();
                        deleting_pieces_if_you_choose_bad_move(board, unskippable_moves, x_piece_move, y_piece_move);
                        if (!(check_piece_with_unskippable_moves(unskippable_moves, piece)))
                        {
                            Check_and_make_move(who_is_playing, board, piece, x_piece_move, y_piece_move);
                        }
                    }

                    else
                    {
                        Check_and_make_move(who_is_playing, board, piece, x_piece_move, y_piece_move);
                    }
                }

                else
                {
                    Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                    Choose_move(who_is_playing, board, piece);
                }
            }
            else
            {
                Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                Choose_move(who_is_playing, board, piece);
            }
        } //Funkce na vybrání pohybu a zkontrolování jestli jsou dané souřadnice napsány správně

        private int[][] unskippable_move(int[,] board, int who_is_playing) //Check jestli je někde na celém boardu možnost přeskoku a naplní se němi pole, které vracíme
        {
            int[][] unskippable_moves = new int[2][];
            unskippable_moves[0] = Enumerable.Repeat(int.MaxValue, 10).ToArray();
            unskippable_moves[1] = Enumerable.Repeat(int.MaxValue, 10).ToArray();
            int quantity_of_u_m = 0;

            for (int row_index = 0; row_index < 8; row_index++)
            {
                for (int column_index = 0; column_index < 8; column_index++)
                {
                    if (!((row_index == 0 || row_index == 1) && board[row_index, column_index] == 21) || ((row_index == 6 || row_index == 7) && board[row_index, column_index] == 11))
                    {
                        if (column_index > 1 && column_index < 6) //middle of board
                        {
                            if (board[row_index, column_index] == 11 && who_is_playing % 2 != 0) //white
                            {
                                if (board[row_index + 1, column_index - 1] == 21 && board[row_index + 2, column_index - 2] == 0) //left
                                {
                                    unskippable_moves[0][quantity_of_u_m] = row_index + 2;
                                    unskippable_moves[0][quantity_of_u_m + 1] = column_index - 2;
                                    unskippable_moves[1][quantity_of_u_m] = row_index;
                                    unskippable_moves[1][quantity_of_u_m + 1] = column_index;
                                    quantity_of_u_m += 2;
                                }

                                if (board[row_index + 1, column_index + 1] == 21 && board[row_index + 2, column_index + 2] == 0) //right
                                {
                                    unskippable_moves[0][quantity_of_u_m] = row_index + 2;
                                    unskippable_moves[0][quantity_of_u_m + 1] = column_index + 2;
                                    unskippable_moves[1][quantity_of_u_m] = row_index;
                                    unskippable_moves[1][quantity_of_u_m + 1] = column_index;
                                    quantity_of_u_m += 2;
                                }
                            }

                            else if (board[row_index, column_index] == 21 && who_is_playing % 2 == 0) //black
                            {
                                if (board[row_index - 1, column_index - 1] == 11 && board[row_index - 2, column_index - 2] == 0) //left
                                {
                                    unskippable_moves[0][quantity_of_u_m] = row_index - 2;
                                    unskippable_moves[0][quantity_of_u_m + 1] = column_index - 2;
                                    unskippable_moves[1][quantity_of_u_m] = row_index;
                                    unskippable_moves[1][quantity_of_u_m + 1] = column_index;
                                    quantity_of_u_m += 2;
                                }

                                if (board[row_index - 1, column_index + 1] == 11 && board[row_index - 2, column_index + 2] == 0) //right
                                {
                                    unskippable_moves[0][quantity_of_u_m] = row_index - 2;
                                    unskippable_moves[0][quantity_of_u_m + 1] = column_index + 2;
                                    unskippable_moves[1][quantity_of_u_m] = row_index;
                                    unskippable_moves[1][quantity_of_u_m + 1] = column_index;
                                    quantity_of_u_m += 2;
                                }
                            }
                        }

                        else if (column_index == 0) //leftside of board
                        {
                            if (board[row_index, column_index] == 11 && who_is_playing % 2 != 0) //white
                            {
                                if (board[row_index + 1, column_index + 1] == 21 && board[row_index + 2, column_index + 2] == 0) //right
                                {
                                    unskippable_moves[0][quantity_of_u_m] = row_index + 2;
                                    unskippable_moves[0][quantity_of_u_m + 1] = column_index + 2;
                                    unskippable_moves[1][quantity_of_u_m] = row_index;
                                    unskippable_moves[1][quantity_of_u_m + 1] = column_index;
                                    quantity_of_u_m += 2;
                                }
                            }

                            else if (board[row_index, column_index] == 21 && who_is_playing % 2 == 0) //black
                            {
                                if (board[row_index - 1, column_index + 1] == 11 && board[row_index - 2, column_index + 2] == 0) //right
                                {
                                    unskippable_moves[0][quantity_of_u_m] = row_index - 2;
                                    unskippable_moves[0][quantity_of_u_m + 1] = column_index + 2;
                                    unskippable_moves[1][quantity_of_u_m] = row_index;
                                    unskippable_moves[1][quantity_of_u_m + 1] = column_index;
                                    quantity_of_u_m += 2;
                                }
                            }
                        }

                        else if (column_index == 1) //leftside of board 2
                        {
                            if (board[row_index, column_index] == 11 && who_is_playing % 2 != 0) //white
                            {
                                if (board[row_index + 1, column_index + 1] == 21 && board[row_index + 2, column_index + 2] == 0) //right
                                {
                                    unskippable_moves[0][quantity_of_u_m] = row_index + 2;
                                    unskippable_moves[0][quantity_of_u_m + 1] = column_index + 2;
                                    unskippable_moves[1][quantity_of_u_m] = row_index;
                                    unskippable_moves[1][quantity_of_u_m + 1] = column_index;
                                    quantity_of_u_m += 2;
                                }
                            }

                            else if (board[row_index, column_index] == 21 && who_is_playing % 2 == 0) //black
                            {
                                if (board[row_index - 1, column_index + 1] == 11 && board[row_index - 2, column_index + 2] == 0) //right
                                {
                                    unskippable_moves[0][quantity_of_u_m] = row_index - 2;
                                    unskippable_moves[0][quantity_of_u_m + 1] = column_index + 2;
                                    unskippable_moves[1][quantity_of_u_m] = row_index;
                                    unskippable_moves[1][quantity_of_u_m + 1] = column_index;
                                    quantity_of_u_m += 2;
                                }
                            }
                        }

                        else if (column_index == 6) //rightside of board 2
                        {
                            if (board[row_index, column_index] == 11 && who_is_playing % 2 != 0) //white
                            {
                                if (board[row_index + 1, column_index + 1] == 21 && board[row_index + 2, column_index + 2] == 0) //right
                                {
                                    unskippable_moves[0][quantity_of_u_m] = row_index + 2;
                                    unskippable_moves[0][quantity_of_u_m + 1] = column_index + 2;
                                    unskippable_moves[1][quantity_of_u_m] = row_index;
                                    unskippable_moves[1][quantity_of_u_m + 1] = column_index;
                                    quantity_of_u_m += 2;
                                }
                            }

                            else if (board[row_index, column_index] == 21 && who_is_playing % 2 == 0) //black
                            {
                                if (board[row_index - 1, column_index + 1] == 11 && board[row_index - 2, column_index + 2] == 0) //right
                                {
                                    unskippable_moves[0][quantity_of_u_m] = row_index - 2;
                                    unskippable_moves[0][quantity_of_u_m + 1] = column_index + 2;
                                    unskippable_moves[1][quantity_of_u_m] = row_index;
                                    unskippable_moves[1][quantity_of_u_m + 1] = column_index;
                                    quantity_of_u_m += 2;
                                }
                            }
                        }

                        else //rightside of board
                        {
                            if (board[row_index, column_index] == 11 && who_is_playing % 2 != 0) //white
                            {
                                if (board[row_index + 1, column_index - 1] == 21 && board[row_index + 2, column_index - 2] == 0) //left
                                {
                                    unskippable_moves[0][quantity_of_u_m] = row_index + 2;
                                    unskippable_moves[0][quantity_of_u_m + 1] = column_index - 2;
                                    unskippable_moves[1][quantity_of_u_m] = row_index;
                                    unskippable_moves[1][quantity_of_u_m + 1] = column_index;
                                    quantity_of_u_m += 2;
                                }
                            }

                            else if (board[row_index, column_index] == 21 && who_is_playing % 2 == 0) //black
                            {
                                if (board[row_index - 1, column_index - 1] == 11 && board[row_index - 2, column_index - 2] == 0) //left
                                {
                                    unskippable_moves[0][quantity_of_u_m] = row_index - 2;
                                    unskippable_moves[0][quantity_of_u_m + 1] = column_index - 2;
                                    unskippable_moves[1][quantity_of_u_m] = row_index;
                                    unskippable_moves[1][quantity_of_u_m + 1] = column_index;
                                    quantity_of_u_m += 2;
                                }
                            }
                        }
                    }
                }
            }
            return unskippable_moves;
        }

        private static bool check_move_with_unskippable_moves(int[][] unskippable_moves, int x_move, int y_move) //Porovnání pohybu co chceme udělat s polem přeskoků, které musíme udělat
        {
            for (int row_index = 0; row_index < 10; row_index += 2)
            {
                if (unskippable_moves[0][row_index] == x_move && unskippable_moves[0][row_index + 1] == y_move)
                {
                    return true;
                }
            }

            if (unskippable_moves[0][0] == int.MaxValue)
            {
                return true;
            }

            return false;
        }

        private bool check_piece_with_unskippable_moves(int[][] unskippable_moves, int[]piece) //Porovnání kamene s kterým chceme hýbat s polem přeskoků
        {
            for (int row_index = 0; row_index < 10; row_index += 2)
            {
                if (unskippable_moves[1][row_index] == piece[0] && unskippable_moves[1][row_index + 1] == piece[1])
                {
                    return true;
                }
            }

            if (unskippable_moves[0][0] == int.MaxValue)
            {
                return true;
            }

            return false;
        }

        private void deleting_pieces_if_you_choose_bad_move(int[,] board, int[][] unskippable_moves, int x_move, int y_move) //Vymazání možných přeskoků, které jsem měl uskutečnit
        {

            for (int row_index = 0; row_index < 10; row_index += 2)
            {
                if (unskippable_moves[1][row_index] != int.MaxValue || unskippable_moves[1][row_index + 1] != int.MaxValue)
                {
                    board[unskippable_moves[1][row_index], unskippable_moves[1][row_index + 1]] = 0;
                }
            }
        }

        private void Check_and_make_move(int who_is_playing, int[,] board, int[] piece, int x_piece_move, int y_piece_move) //Check pohybu vůči celému boardu a jeho hranám + nasledné přepsaní hodnoty z místa kde kámen bereme a přepsání hodnoty kam kámen vkládáme
        {
            if (board[x_piece_move, y_piece_move] != 0)
            {
                Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                piece = Choose_piece(who_is_playing, board);
                Choose_move(who_is_playing, board, piece);
            }

            else
            {
                if (who_is_playing % 2 != 0) //white
                {
                    if (piece[1] != 0 && piece[1] != 7)
                    {
                        if ((piece[0] + 1 == x_piece_move && piece[1] - 1 == y_piece_move) || (piece[0] + 2 == x_piece_move && piece[1] - 2 == y_piece_move)) //left
                        {
                            if (board[piece[0] + 1, piece[1] - 1] == 0) //empty move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] + 1, piece[1] - 1] = white;
                            }

                            else if (board[piece[0] + 1, piece[1] - 1] == black && board[piece[0] + 2, piece[1] - 2] == 0) //delete enemy piece and move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] + 1, piece[1] - 1] = 0;
                                board[piece[0] + 2, piece[1] - 2] = white;
                            }

                            else
                            {
                                Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                                piece = Choose_piece(who_is_playing, board);
                                Choose_move(who_is_playing, board, piece);
                            }
                        }

                        else if (piece[0] + 1 == x_piece_move && piece[1] + 1 == y_piece_move || piece[0] + 2 == x_piece_move && piece[1] + 2 == y_piece_move) //right
                        {
                            if (board[piece[0] + 1, piece[1] + 1] == 0) //empty move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] + 1, piece[1] + 1] = white;
                            }

                            else if (board[piece[0] + 1, piece[1] + 1] == black && board[piece[0] + 2, piece[1] + 2] == 0) //delete enemy piece and move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] + 1, piece[1] + 1] = 0;
                                board[piece[0] + 2, piece[1] + 2] = white;
                            }

                            else
                            {
                                Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                                piece = Choose_piece(who_is_playing, board);
                                Choose_move(who_is_playing, board, piece);
                            }
                        }

                        else
                        {
                            Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                            piece = Choose_piece(who_is_playing, board);
                            Choose_move(who_is_playing, board, piece);
                        }


                    }

                    else if (piece[1] == 0)
                    {
                        if (piece[0] + 1 == x_piece_move && piece[1] + 1 == y_piece_move || piece[0] + 2 == x_piece_move && piece[1] + 2 == y_piece_move) //right
                        {
                            if (board[piece[0] + 1, piece[1] + 1] == 0) //empty move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] + 1, piece[1] + 1] = white;
                            }

                            else if (board[piece[0] + 1, piece[1] + 1] == black && board[piece[0] + 2, piece[1] + 2] == 0) //delete enemy piece and move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] + 1, piece[1] + 1] = 0;
                                board[piece[0] + 2, piece[1] + 2] = white;
                            }

                            else
                            {
                                Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                                piece = Choose_piece(who_is_playing, board);
                                Choose_move(who_is_playing, board, piece);
                            }
                        }

                        else
                        {
                            Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                            piece = Choose_piece(who_is_playing, board);

                            Choose_move(who_is_playing, board, piece);
                        }
                    }

                    else
                    {
                        if (piece[0] + 1 == x_piece_move && piece[1] - 1 == y_piece_move || piece[0] + 2 == x_piece_move && piece[1] - 2 == y_piece_move) //left
                        {
                            if (board[piece[0] + 1, piece[1] - 1] == 0) //empty move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] + 1, piece[1] - 1] = white;
                            }

                            else if (board[piece[0] + 1, piece[1] - 1] == black && board[piece[0] + 2, piece[1] - 2] == 0) //delete enemy piece and move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] + 1, piece[1] - 1] = 0;
                                board[piece[0] + 2, piece[1] - 2] = white;
                            }

                            else
                            {
                                Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                                piece = Choose_piece(who_is_playing, board);
                                Choose_move(who_is_playing, board, piece);
                            }
                        }

                        else
                        {
                            Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                            piece = Choose_piece(who_is_playing, board);

                            Choose_move(who_is_playing, board, piece);
                        }
                    }
                }

                else //black
                {
                    if (piece[1] != 0 && piece[1] != 7)
                    {
                        if (piece[0] - 1 == x_piece_move && piece[1] - 1 == y_piece_move || piece[0] - 2 == x_piece_move && piece[1] - 2 == y_piece_move) //left
                            if (board[piece[0] - 1, piece[1] - 1] == 0) //empty move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] - 1, piece[1] - 1] = black;
                            }

                            else if (board[piece[0] - 1, piece[1] - 1] == 11 && board[piece[0] - 2, piece[1] - 2] == 0) //delete enemy piece and move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] - 1, piece[1] - 1] = 0;
                                board[piece[0] - 2, piece[1] - 2] = black;
                            }

                            else
                            {
                                Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                                piece = Choose_piece(who_is_playing, board);
                                Choose_move(who_is_playing, board, piece);
                            }

                        else if (piece[0] - 1 == x_piece_move && piece[1] + 1 == y_piece_move || piece[0] - 2 == x_piece_move && piece[1] + 2 == y_piece_move) //right
                        {
                            if (board[piece[0] - 1, piece[1] + 1] == 0) //empty move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] - 1, piece[1] + 1] = black;
                            }

                            else if (board[piece[0] - 1, piece[1] + 1] == white && board[piece[0] - 2, piece[1] + 2] == 0) //delete enemy piece and move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] - 1, piece[1] + 1] = 0;
                                board[piece[0] - 2, piece[1] + 2] = black;
                            }

                            else
                            {
                                Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                                piece = Choose_piece(who_is_playing, board);
                                Choose_move(who_is_playing, board, piece);
                            }
                        }

                        else
                        {
                            Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                            piece = Choose_piece(who_is_playing, board);
                            Choose_move(who_is_playing, board, piece);
                        }


                    }

                    else if (piece[1] == 0)
                    {
                        if (piece[0] - 1 == x_piece_move && piece[1] + 1 == y_piece_move || piece[0] - 2 == x_piece_move && piece[1] + 2 == y_piece_move) //right
                        {
                            if (board[piece[0] - 1, piece[1] + 1] == 0) //empty move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] - 1, piece[1] + 1] = black;
                            }

                            else if (board[piece[0] - 1, piece[1] + 1] == white && board[piece[0] - 2, piece[1] + 2] == 0) //delete enemy piece and move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] - 1, piece[1] + 1] = 0;
                                board[piece[0] - 2, piece[1] + 2] = black;
                            }

                            else
                            {
                                Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                                piece = Choose_piece(who_is_playing, board);
                                Choose_move(who_is_playing, board, piece);
                            }
                        }

                        else
                        {
                            Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                            piece = Choose_piece(who_is_playing, board);
                            Choose_move(who_is_playing, board, piece);
                        }
                    }

                    else
                    {
                        if (piece[0] - 1 == x_piece_move && piece[1] - 1 == y_piece_move || piece[0] - 2 == x_piece_move && piece[1] - 2 == y_piece_move)
                        {
                            if (board[piece[0] - 1, piece[1] - 1] == 0) //empty move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] - 1, piece[1] - 1] = black;
                            }

                            else if (board[piece[0] - 1, piece[1] - 1] == white && board[piece[0] - 2, piece[1] - 2] == 0) //delete enemy piece and move
                            {
                                board[piece[0], piece[1]] = 0;
                                board[piece[0] - 1, piece[1] - 1] = 0;
                                board[piece[0] - 2, piece[1] - 2] = black;
                            }

                            else
                            {
                                Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                                piece = Choose_piece(who_is_playing, board);
                                Choose_move(who_is_playing, board, piece);
                            }
                        }

                        else
                        {
                            Console.WriteLine("\nYou wrote the coordinates wrong .. Try it again!");
                            piece = Choose_piece(who_is_playing, board);

                            Choose_move(who_is_playing, board, piece);
                        }
                    }
                }
            }
        }
    }
}