using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Advance5
{
    public class Builder : Piece
    {
        public string BuilderPiece = "B";
        private int[] Cell_AR_B;

        public int[,] BoardBounds { get; }

        public Builder(bool isWhite, string typePiece, int[,] boardBounds, int[] cellAR_B)
        {
            // Call the base constructor to set the Piece properties
            isWhite = true;
            typePiece = BuilderPiece;
            BoardBounds = boardBounds;

            // Set the Zombie-specific properties
            this.BuilderPiece = "B";

            // Initialize the Cell_AR variable
            this.Cell_AR_B = cellAR_B;
        }

        public Builder(bool isWhite, char typePiece, int[,] boardBounds)
        {
            this.isWhite = isWhite;
            this.typePiece = typePiece;
            BoardBounds = boardBounds;
        }

        public void Move(int[] boardBounds)
        {
            // Get the current position of the Zombie piece
            int[] currentPosition = Cell_AR_B;
            int x = Cell_AR_B[0];
            int y = Cell_AR_B[1];

            // Find the usable positions for the next move
            int[][] usablePositions = new int[][]
            {
            new int[] { currentPosition[0] + 1, currentPosition[1] + 1 },
            new int[] { currentPosition[0] + 1, currentPosition[1] },
            new int[] { currentPosition[0] + 1, currentPosition[1] - 1 },
            new int[] { currentPosition[0], currentPosition[1] - 1 },
            new int[] { currentPosition[0], currentPosition[1] +1 },
            new int[] { currentPosition[0] -1, currentPosition[1] +1},
            new int[] { currentPosition[0] -1, currentPosition[1]},
            new int[] { currentPosition[0] -1, currentPosition[1] - 1}
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
                bool isOccupied = false; // TODO: replace with actual check for occupied position
                if (isOccupied)
                {
                    // Skip this position and try the next one
                    continue;
                }

                // Move the Zombie piece to the new position
                Cell_AR_B = newPosition;
                Console.WriteLine($"Moved Builder to position ({newPosition[0]}, {newPosition[1]})");
                break; // Stop trying positions once a valid move is found
            }
        }

        public string GetBuilder() { return TypePiece; }
        public bool BuilderWhite()
        {
            if (IsWhite) return true;
            else return false;
        }
    }
}

