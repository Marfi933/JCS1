namespace JCS07;
using System.Text;

public static class StaticMethods
{
    public static string UpperAfterSpace(this string s)
    {
        int countChars = s.Length;
        bool spaceFound = true;
        char replaceChar;
        StringBuilder sb = new StringBuilder(countChars);
        
        foreach (var c in s)
        {
            if (spaceFound)
            {
                replaceChar = Char.ToUpper(c);
                spaceFound = false;
            }
            
            else if (c == ' ')
            {
                spaceFound = true;
                replaceChar = c;
            }
            
            else replaceChar = c;
            
            sb.Append(replaceChar);
        }
        
        return sb.ToString();
    }

    public static ChessPiece[,] GetBoard(this ChessPiece board)
    {
        ChessPiece[,] newBoard = new ChessPiece[8, 8];
        newBoard[0, 0] = ChessPiece.BlackRook;
        newBoard[0, 1] = ChessPiece.BlackKnight;
        newBoard[0, 2] = ChessPiece.BlackBishop;
        newBoard[0, 3] = ChessPiece.BlackQueen;
        newBoard[0, 4] = ChessPiece.BlackKing;
        newBoard[0, 5] = ChessPiece.BlackBishop;
        newBoard[0, 6] = ChessPiece.BlackKnight;
        newBoard[0, 7] = ChessPiece.BlackRook;
        
        for (int i = 0; i < 8; i++)
        {
            newBoard[1, i] = ChessPiece.BlackPawn;
            newBoard[6, i] = ChessPiece.WhitePawn;
        }
        
        for (int i = 0; i < 8; i++)
        {
            for (int j = 2; j < 6; j++)
            {
                newBoard[j, i] = ChessPiece.Empty;
            }
        }
        
        newBoard[7, 0] = ChessPiece.WhiteRook;
        newBoard[7, 1] = ChessPiece.WhiteKnight;
        newBoard[7, 2] = ChessPiece.WhiteBishop;
        newBoard[7, 3] = ChessPiece.WhiteQueen;
        newBoard[7, 4] = ChessPiece.WhiteKing;
        newBoard[7, 5] = ChessPiece.WhiteBishop;
        newBoard[7, 6] = ChessPiece.WhiteKnight;
        newBoard[7, 7] = ChessPiece.WhiteRook;

        return newBoard;
    }
    
    public static void PrintBoard(this ChessPiece board)
    {
        ChessPiece [,] newBoard = board.GetBoard();
        
        for (int i = 0; i < 8; i++)
        {
                for (int j = 0; j < 8; j++)
                {
                    Console.Write(newBoard[i, j] + " ");
                }
                Console.WriteLine();
        }
    }
    
}
