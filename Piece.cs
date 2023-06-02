using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advance5
{
    public abstract class Piece
        {
            public bool IsWhite { get; set; }
            public int[] pos = new int[] { -1, 1 };
            public int[] BoardBounds = new int[] { 9, 9 };
            public bool MoveComplete = false;
            public bool isOccupied = false;
            public bool isWhite;
            public char typePiece;

            public Board Board { get; set; }
            public string TypePiece { get; set; }
            public Piece CreatePieceFromSymbol(char pieceSymbol, int i, int x, int j, int[,] boardBounds)
            {
                Piece? piece = null;

                switch (pieceSymbol)
                {
                    case 'G':
                        piece = new General(isWhite, typePiece, boardBounds);
                        break;
                    case 'Z':
                        piece = new Zombie(isWhite, typePiece, boardBounds);
                        break;
                    case 'C':
                        piece = new Catapult(isWhite, typePiece, boardBounds);
                        break;
                    case 'M':
                        piece = new Miner(isWhite, typePiece, boardBounds);
                        break;
                    case 'J':
                        piece = new Jester(isWhite, typePiece, boardBounds);
                        break;
                    case 'D':
                        piece = new Dragon(isWhite, typePiece, boardBounds);
                        break;
                    case 'S':
                        piece = new Senteniel(isWhite, typePiece, boardBounds);
                        break;
                    case 'B':
                        piece = new Builder(isWhite, typePiece, boardBounds);
                        break;
                    default:
                        // Handle invalid piece symbol
                        break;
                }
                return piece;
            }

            public string GetPiece() { return TypePiece; }
            public bool PieceWhite()
            {
                if (IsWhite) return true;
                else return false;
            }

        }
    }

