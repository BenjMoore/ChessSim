using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance5
{
    public class General : Piece
    {

        public string GeneralPiece = "G";
        public int[] Cell_AR_G;

        public int[,] BoardBounds { get; }

        public General(bool isWhite, string typePiece, int[,] boardBounds, int[] cellAR_G)
        {
            // Call the base constructor to set the Piece properties
            isWhite = true;
            typePiece = GeneralPiece;
            BoardBounds = boardBounds;

            // Set the Zombie-specific properties
            this.GeneralPiece = "G";

            // Initialize the Cell_AR variable
            this.Cell_AR_G = cellAR_G;
        }

        public General(bool isWhite, char typePiece, int[,] boardBounds)
        {
            this.isWhite = isWhite;
            this.typePiece = typePiece;
            BoardBounds = boardBounds;
        }

        public void Move(int[] boardBounds)
        {
            // Get the current position of the Zombie piece
            int[] currentPosition = Cell_AR_G;
            int x = Cell_AR_G[0];
            int y = Cell_AR_G[1];

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
                Cell_AR_G = newPosition;
                Console.WriteLine($"Moved General to position ({newPosition[0]}, {newPosition[1]})");
                break; // Stop trying positions once a valid move is found
            }
        }

        public string GetGeneral() { return TypePiece; }
        public bool GeneralWhite()
        {
            if (IsWhite) return true;
            else return false;
        }
    }
}

