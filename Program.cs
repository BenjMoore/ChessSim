using System.Collections.Generic;
using System;
using System.Diagnostics.Metrics;
using System.Security.Cryptography.X509Certificates;

namespace Advance5
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] lines = ReadBoardState();
            int[,] boardBounds = new int[,]
                {
                    { 9, 9 },
                    { lines.Length - 1, lines[0].Length - 1 }
                };

            int[] flattenedBounds = new int[2]
            {
                boardBounds.GetLength(0),
                boardBounds.GetLength(1)
            };

            Board board = new Board(boardBounds);
            for (int i = 0; i < lines.Length; i++)
            {
                for (int j = 0; j < lines[i].Length; j++)
                {
                    char pieceSymbol = lines[i][j];
                    Piece piece = CreatePieceFromSymbol(pieceSymbol, i, j, boardBounds);
                    if (piece != null)
                    {
                        object value = board.AddPiece(piece);
                    }
                }
            }

            // Print the board with the pieces
            board.PrintBoard();
           
            

        }

        public static bool IsUpper(string value)
        {
            // Consider string to be uppercase if it has no lowercase letters.
            for (int i = 0; i < value.Length; i++)
            {
                if (char.IsLower(value[i]))
                {
                    return false;
                }
            }
            return true;
        }
        static Random rnd = new Random();
      
        public List<String> piecesInPlay = new List<String>();
        static string[] ReadBoardState()
        {
            int pieceCounter = 0;
            int its = 1;

            string folder = @"D:\Downloads\Github\imogenasses\GameData\";

            // Filename

            string fileName = "PiecesInPlay.csv";

            // Fullpath

            string fullPaths = folder + fileName;

            var filePath = Directory.GetFiles(@"D:\Downloads\Github\imogenasses\DefaultBoard", "*.txt", SearchOption.AllDirectories);

            List<string> printedBoards = new List<string>(); // Store the printed boards
            int x = 0;
            foreach (string file in filePath)
            {
                
                string[] lines = File.ReadAllLines(file);
                string currentLine = lines[0];
               
                Console.WriteLine($"{file}:");
                Console.WriteLine(string.Join(Environment.NewLine, lines));
                Console.WriteLine();
                
               
                // Create the board object and add pieces
                int[,] boardBounds = new int[,]
                {
                    { 0, 0 },
                    { lines.Length - 1, lines[0].Length - 1 }
                };
                Board board = new Board(boardBounds);

                for (int i = 0; i < lines.Length; i++)
                {
                    for (int j = 0; j < lines[i].Length; j++)
                    {
                        char pieceSymbol = lines[i][j];
                        int yPiece = j;
                        int xPiece = i;
                        Piece piece = CreatePieceFromSymbol(pieceSymbol, i, j, boardBounds);
                        if (piece != null)
                        {
                            object value = board.AddPiece(piece);
                            Console.WriteLine(piece);

                            bool isBlack = Char.IsUpper(pieceSymbol);
                           
                           
                            using (StreamWriter writer = new StreamWriter(fullPaths,true))
                            {

                                if (isBlack)
                                {
                                    writer.WriteLine($"{piece},Black,{xPiece},{yPiece}");
                                }
                                else
                                {
                                    writer.WriteLine($"{piece},White,{j},{i}");

                                }
                                pieceCounter++;
                           
                            }
                           

                            // Read a file
                            string readText = File.ReadAllText(fullPaths);
                            Console.WriteLine(readText);





                        }
                    }
                }

                /*
            Bot

           determine whos turn it is
           select a random peice from the color whos turn it is

           check if the peice is obstructed
           if so:
               select a new peice 
           else:
               pick a usable move
               select a random usable move
               update the board state to the new game
               read the new board state and clear the old one.

            */

                bool isWhiteTurn = true;

                List<String> pieceOptions = new List<String>();

                pieceOptions.Add("General");
                pieceOptions.Add("Zombie");
                pieceOptions.Add("Senteniel");
                pieceOptions.Add("Miner");
                pieceOptions.Add("Jester");
                pieceOptions.Add("Dragon");
                pieceOptions.Add("Catapult");
                pieceOptions.Add("Builder");
                int plays = 0;
               // while (plays != 200)
                //{
                    int inPlay = rnd.Next(pieceOptions.Count);
                    Console.WriteLine(pieceOptions[inPlay]);
                    string InPlay = pieceOptions[inPlay];

                    // Print the board with the pieces
                    string printedBoard = board.PrintBoard();
                    printedBoards.Add(printedBoard);
                    if (InPlay == "Jester") 
                    {
                       
                    }
                    if (InPlay == "Zombie")
                    {

                    }
                    if (InPlay == "Senteniel")
                    {

                    }
                    if (InPlay == "Miner")
                    {

                    }
                    if (InPlay == "General")
                    {

                    }
                    if (InPlay == "Dragon")
                    {

                    }
                    if (InPlay == "Catapult")
                    {

                    }
                    if (InPlay == "General")
                    {

                    }

                    /*
                    using (var reader = new StreamReader(@"D:\Downloads\Github\imogenasses\GameData\PiecesInPlay.csv"))
                    {
                        List<string> WhiteP = new List<string>();
                        List<string> BlackP = new List<string>();
                        while (!reader.EndOfStream)
                        {
                            var classes = reader.ReadLine();
                            var values = classes.Split(',');

                            if (values[1] == "White")
                            {
                                if (isWhiteTurn == false) { continue; }
                                if (isWhiteTurn == true)
                                {
                                    // Change board to show new move

                                }
                            }
                            if (values[1] == "Black")
                            {
                                if (isWhiteTurn == true) { continue; }
                                if (isWhiteTurn == false)
                                {
                                    // change board to show new move


                                }
                            }

                        }
                    }
                //}
                isWhiteTurn = !isWhiteTurn;
                plays++;
                if (plays == 200) { break; }
                    */
            }
            
            x++;
            return printedBoards.ToArray();
        }





        /// Broken

        // Create a chess piece based on the symbol
        static Piece CreatePieceFromSymbol(char symbol, int row, int col, int[,] boardBounds)
        {
            bool isWhite = Char.IsUpper(symbol); // Assuming uppercase symbols represent white pieces
            switch (Char.ToUpper(symbol))
            {
                case 'G':
                    return new General(isWhite, "G", boardBounds, new int[] { row, col });
                case 'Z':
                    return new Zombie(isWhite, "Z", boardBounds, new int[] { row, col });
                case 'C':
                    return new Catapult(isWhite, "C", boardBounds, new int[] { row, col });
                case 'M':
                    return new Miner(isWhite, "M", boardBounds, new int[] { row, col });
                case 'J':
                    return new Jester(isWhite, "J", boardBounds, new int[] { row, col });
                case 'D':
                    return new Dragon(isWhite, "D", boardBounds, new int[] { row, col });
                case 'S':
                    return new Senteniel(isWhite, "S", boardBounds, new int[] { row, col });
                case 'B':
                    return new Builder(isWhite, "B", boardBounds, new int[] { row, col });
                default:
                    return null; // Invalid symbol, return null for empty squares
            }
           
        }
    }

}

