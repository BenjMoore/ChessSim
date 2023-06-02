using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance5
{
    public class Miner : Piece
    {
        public string MinerPiece = "M";
        private int[] Cell_AR_M;

        public int[,] BoardBounds { get; }

        public Miner(bool isWhite, string typePiece, int[,] boardBounds, int[] cellAR_M)
        {
            // Call the base constructor to set the Piece properties
            isWhite = true;
            typePiece = MinerPiece;
            BoardBounds = boardBounds;


            // Set the Sentenial-specific properties
            MinerPiece = "M";

            // Initialize the Cell_AR variable
            Cell_AR_M = cellAR_M;
        }

        public Miner(bool isWhite, char typePiece, int[,] boardBounds)
        {
            this.isWhite = isWhite;
            this.typePiece = typePiece;
            BoardBounds = boardBounds;
        }

        void Move(int[] newPos)
        {
            int currPosx = Cell_AR_M[0];
            int currPosy = Cell_AR_M[1];
            int newposx = newPos[0];
            int newposy = newPos[1];

            if (newposx == currPosx || newposy == currPosy)
            {
                // Check if there are any pieces blocking the Sentenial's path
                int minX = Math.Min(currPosx, newposx);
                int maxX = Math.Max(currPosx, newposx);
                int minY = Math.Min(currPosy, newposy);
                int maxY = Math.Max(currPosy, newposy);

                for (int i = minX; i <= maxX; i++)
                {
                    for (int j = minY; j <= maxY; j++)
                    {
                        if (i != currPosx || j != currPosy)
                        {
                            int[] pos = new int[] { i, j };
                            bool isOccupied = Board.IsOccupied(pos[0], pos[1]);

                            if (isOccupied)
                            {
                                Console.WriteLine("Can't move there, another piece is blocking the way.");
                                return;
                            }
                        }
                    }
                }
                // need something that moves the letter on the board. 
            }
            else
            {
                Console.WriteLine("Invalid move for Miner.");
            }
        }

        public string GetMiner() { return TypePiece; }
        public bool MinerWhite()
        {
            if (IsWhite) return true;
            else return false;
        }
    }
}
