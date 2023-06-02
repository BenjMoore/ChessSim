using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance5
{
    public class Catapult : Piece
    {
            public string CatapultPiece = "C";
            private int[] Cell_AR_C;

        public int[,] BoardBounds { get; }

        public Catapult(bool isWhite, string typePiece, int[,] boardBounds, int[] cellAR_C)
            {
                // Call the base constructor to set the Piece properties
                isWhite = true;
                typePiece = CatapultPiece;
                BoardBounds = boardBounds;

                // Set the Zombie-specific properties
                this.CatapultPiece = "C";

                // Initialize the Cell_AR variable
                this.Cell_AR_C = cellAR_C;
            }

        public Catapult(bool isWhite, char typePiece, int[,] boardBounds)
        {
            this.isWhite = isWhite;
            this.typePiece = typePiece;
            BoardBounds = boardBounds;
        }

        public void Move(int[] boardBounds)
            {
                int x = Cell_AR_C[0];
                int y = Cell_AR_C[1];
                // Get the current position of the Night piece
                int[] currentPosition = Cell_AR_C;

                // Find the usable positions for the next move
                int[][] usablePositions = new int[][]
                {
                new int[] { currentPosition[0] + 2, currentPosition[1] + 1 },
                new int[] { currentPosition[0] + 2, currentPosition[1] - 1 },
                new int[] { currentPosition[0] + 1, currentPosition[1] + 2 },
                new int[] { currentPosition[0] + 1, currentPosition[1] - 2 },
                new int[] { currentPosition[0] - 1, currentPosition[1] + 2 },
                new int[] { currentPosition[0] - 1, currentPosition[1] - 2 },
                new int[] { currentPosition[0] - 2, currentPosition[1] + 1 },
                new int[] { currentPosition[0] - 2, currentPosition[1] - 1 }
                };

                // Try each usable position in turn, stopping when a valid move is found
                foreach (int[] newPosition in usablePositions)
                {
                    // Check if the new position is within the board bounds
                    if (newPosition[0] < 0 || newPosition[0] >= boardBounds[0] || newPosition[1] < 0 || newPosition[1] >= boardBounds[1])
                    {
                        // Skip this position and try the next one
                        continue;
                    }

                    // Check if there is a piece at the new position
                    bool isOccupied = false; // TODO: replace with actual check for occupied position
                    if (isOccupied)
                    {
                        // Skip this position and try the next one
                        continue;
                    }

                    // Move the Night piece to the new position
                    Cell_AR_C = newPosition;
                    Console.WriteLine($"Moved Catapult to position ({newPosition[0]}, {newPosition[1]})");
                    break; // Stop trying positions once a valid move is found
                }
            }

            public string GetCatapult() { return TypePiece; }
            public bool CatapultWhite()
            {
                if (IsWhite) return true;
                else return false;
            }
        }
    }





