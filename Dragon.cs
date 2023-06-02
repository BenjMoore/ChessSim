using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance5
{
    public class Dragon : Piece
    {
        public string DragonPiece = "D";
        private int[] Cell_AR_D;

        public new int[,] BoardBounds { get; }

        public Dragon(bool isWhite, string typePiece, int[,] boardBounds, int[] cellAR_D)
        {
            // Call the base constructor to set the Piece properties
            isWhite = true;
            typePiece = DragonPiece;
            BoardBounds = boardBounds;


            // Set the Sentenial-specific properties
            DragonPiece = "M";

            // Initialize the Cell_AR variable
            Cell_AR_D = cellAR_D;
        }

        public Dragon(bool isWhite, char typePiece, int[,] boardBounds)
        {
            this.isWhite = isWhite;
            this.typePiece = typePiece;
            BoardBounds = boardBounds;
        }

        public void Move(int[] boardBounds)
        {
            int x = Cell_AR_D[0];
            int y = Cell_AR_D[1];
            // Get the current position of the Queen piece
            int[] currentPosition = Cell_AR_D;

            // Find the usable positions for the next move
            List<int[]> usablePositions = new List<int[]>();
            for (int i = 0; i < boardBounds[0]; i++)
            {
                if (i != currentPosition[0])
                {
                    usablePositions.Add(new int[] { i, currentPosition[1] });
                }
            }
            for (int i = 0; i < boardBounds[1]; i++)
            {
                if (i != currentPosition[1])
                {
                    usablePositions.Add(new int[] { currentPosition[0], i });
                }
            }
            for (int i = currentPosition[0] - 1, j = currentPosition[1] - 1; i >= 0 && j >= 0; i--, j--)
            {
                usablePositions.Add(new int[] { i, j });
            }
            for (int i = currentPosition[0] + 1, j = currentPosition[1] + 1; i < boardBounds[0] && j < boardBounds[1]; i++, j++)
            {
                usablePositions.Add(new int[] { i, j });
            }
            for (int i = currentPosition[0] - 1, j = currentPosition[1] + 1; i >= 0 && j < boardBounds[1]; i--, j++)
            {
                usablePositions.Add(new int[] { i, j });
            }
            for (int i = currentPosition[0] + 1, j = currentPosition[1] - 1; i < boardBounds[0] && j >= 0; i++, j--)
            {
                usablePositions.Add(new int[] { i, j });
            }

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
                bool isOccupied = Board.IsOccupied(newPosition[0], newPosition[2]);
                if (isOccupied)
                {
                    // Skip this position and try the next one
                    continue;
                }

                // Move the Queen piece to the new position
                Cell_AR_D = newPosition;
                Console.WriteLine($"Moved Dragon to position ({newPosition[0]}, {newPosition[1]})");
                break; // Stop trying positions once a valid move is found
            }
        }

        public string GetDragon() { return TypePiece; }
        public int[] GetDragonCoords()
        {
            int x = Cell_AR_D[0];
            int y = Cell_AR_D[1];
            int[] TotalCoords = { Cell_AR_D[0], Cell_AR_D[1] };
            { return TotalCoords; };
        }
        public bool DragonWhite()
        {
            if (IsWhite) return true;
            else return false;
        }
    }
}
