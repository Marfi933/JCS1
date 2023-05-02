namespace JCS07;

public enum ChessPiece
{
    Empty = 0,
    Pawn = 0x1,
    Rook = 0x2,
    Knight = 0x4,
    Bishop = 0x8,
    Queen = 0x10,
    King = 0x20,
    White = 0x40,
    Black = 0x80,
    WhitePawn = Pawn | White,
    WhiteRook = Rook | White,
    WhiteKnight = Knight | White,
    WhiteBishop = Bishop | White,
    WhiteQueen = Queen | White,
    WhiteKing = King | White,
    BlackPawn = Pawn | Black,
    BlackRook = Rook | Black,
    BlackKnight = Knight | Black,
    BlackBishop = Bishop | Black,
    BlackQueen = Queen | Black,
    BlackKing = King | Black
}
