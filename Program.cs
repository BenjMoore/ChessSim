using System.Collections.Generic;
using System;
using System.Diagnostics.Metrics;

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

            int inPlay = rnd.Next(pieceOptions.Count);
            Console.WriteLine(pieceOptions[inPlay]);

            

        }

        static Random rnd = new Random();
        public string[] piecesInPlay; 
        static string[] ReadBoardState()
        {
            var filePath = Directory.GetFiles(@"D:\Downloads\Github\imogenasses\DefaultBoard", "*.txt", SearchOption.AllDirectories);
            List<string> printedBoards = new List<string>(); // Store the printed boards

            foreach (string file in filePath)
            {
                string[] lines = File.ReadAllLines(file);
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
                        Piece piece = CreatePieceFromSymbol(pieceSymbol, i, j, boardBounds);
                        if (piece != null)
                        {
                            object value = board.AddPiece(piece);
                            Console.WriteLine(piece);
                            List<String> piecesInPlay = new List<String>();



                        }
                    }
                }

                // Print the board with the pieces
                string printedBoard = board.PrintBoard();
                printedBoards.Add(printedBoard);
            }

            return printedBoards.ToArray();
        }





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

