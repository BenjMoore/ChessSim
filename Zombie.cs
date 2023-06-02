using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance5
{
        public class Zombie : Piece
        {
            public string ZombiePiece = "Z";
            private int[] Cell_AR_Z;

            public int[,] BoardBounds { get; }

            public Zombie(bool isWhite, string typePiece, int[,] boardBounds, int[] cellAR_Z)
            {
                // Call the base constructor to set the Piece properties
                isWhite = true;
                typePiece = ZombiePiece;
                BoardBounds = boardBounds;

                // Set the Zombie-specific properties
                this.ZombiePiece = "Z";

                // Initialize the Cell_AR variable
                this.Cell_AR_Z = cellAR_Z;
            }

            public Zombie(bool isWhite, char typePiece, int[,] boardBounds)
            {
                this.isWhite = isWhite;
                this.typePiece = typePiece;
                BoardBounds = boardBounds;
            }

            public void Move(int[] boardBounds)
            {
                int x = Cell_AR_Z[0];
                int y = Cell_AR_Z[1];
                // Get the current position of the Zombie piece
                int[] currentPosition = Cell_AR_Z;

                // Find the usable positions for the next move
                int[][] usablePositions = new int[][]
                {
            new int[] { currentPosition[0] + 1, currentPosition[1] + 1 },
            new int[] { currentPosition[0] + 1, currentPosition[1] },
            new int[] { currentPosition[0] + 1, currentPosition[1] - 1 }
                };

                // Try each usable position in turn, stopping when a valid move is found
                foreach (int[] newPosition in usablePositions)
                {
                    // Check if the new position is within the board bounds
                    if (newPosition[0] >= boardBounds[0] || newPosition[1] >= boardBounds[1])
                    {
                        // Skip this position and try the next one
                        continue;
                    }

                    // Check if there is a piece at the new position
                    bool isOccupied = Board.IsOccupied(newPosition[0], newPosition[2]); // TODO: replace with actual check for occupied position
                if (isOccupied)
                    {
                        // Skip this position and try the next one
                        continue;
                    }

                    // Move the Zombie piece to the new position
                    Cell_AR_Z = newPosition;
                    Console.WriteLine($"Moved Zombie to position ({newPosition[0]}, {newPosition[1]})");
                    break; // Stop trying positions once a valid move is found
                }
            }

            public string GetZombie() { return TypePiece; }
        public int[] GetZombieCoords()
        {
            int x = Cell_AR_Z[0];
            int y = Cell_AR_Z[1];
            int[] TotalCoords = { Cell_AR_Z[0], Cell_AR_Z[1] };
            { return TotalCoords; };
        }
        public bool ZombieWhite()
            {
                if (IsWhite) return true;
                else return false;
            }
        }
    }



