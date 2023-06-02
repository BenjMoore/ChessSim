using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance5
{
    public class Board
    {
        public int[,] boardArray;
        public bool[,] isOccupied;
        public Piece[,] pieces;

        public Board(int[,] boardBounds)
        {
            int rows = boardBounds.GetLength(0);
            int columns = boardBounds.GetLength(1);
            boardArray = new int[rows, columns];
            boardArray = new int[rows, columns];
            isOccupied = new bool[rows, columns];
            pieces = new Piece[rows, columns];
        }

        public void SetCell(int x, int y, int value)
        {
            boardArray[x, y] = value;
        }

        public int GetCell(int x, int y)
        {
            return boardArray[x, y];
        }

        public string PrintBoard()
        {
            for (int i = 0; i < boardArray.GetLength(0); i++)
            {
                for (int j = 0; j < boardArray.GetLength(1); j++)
                {
                    Console.Write($"{boardArray[i, j]} ");
                }
                Console.WriteLine();
            }
            return null;
        }

        public bool IsOccupied(int x, int y)
        {
            return isOccupied[x, y];
        }

        public void SetOccupied(int x, int y, bool value)
        {
            isOccupied[x, y] = value;
        }
        public bool AddPiece(Piece piece)
        {
            int[] position = piece.pos;
            if (IsValidPosition(position) && pieces[position[0], position[1]] == null)
            {
                pieces[position[0], position[1]] = piece;
                SetOccupied(position[0], position[1], true);
                return true;
            }

            return false;
        }

        private bool IsValidPosition(int[] position)
        {
            int row = position[0];
            int col = position[1];
            int numRows = pieces.GetLength(0);
            int numCols = pieces.GetLength(1);

            return row >= 0 && row < numRows && col >= 0 && col < numCols;
        }
    }
}
