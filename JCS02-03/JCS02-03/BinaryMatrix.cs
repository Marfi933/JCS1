namespace JCS02_03;

public class BinaryMatrix
{
    byte [,] _matrix;

    public BinaryMatrix(int rows, int columns)
    {
        if (rows < 0 || columns < 0)
            throw new ArgumentOutOfRangeException("Rows and columns must be positive");
        _matrix = new byte[rows, columns];
    }
    
    public short N{ get { return (short)_matrix.GetLength(0); } }
    public short M{ get { return (short)_matrix.GetLength(1); } }

    public byte this[short row, short column]
    {
        get { return _matrix[row, column]; }
        set
        {
            if (value == 0 || value==1) 
                _matrix[row, column] = value;
            else
            throw new ArgumentOutOfRangeException("Value must be 0 or 1");
        }
    }

    public void WriteMatrix(string path)
    {
        try
        {
            using(BinaryWriter bw = new BinaryWriter(File.Create(@path)))
            {
                bw.Write(N); // write number of rows
                bw.Write(M); // write number of columns
                for (short i = 0; i < N; i++)
                    for (short j = 0; j < M; j++)
                        bw.Write(_matrix[i, j]);
                bw.Flush();
            }
        }
        
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    public static BinaryMatrix ReadMatrix(string path)
    {
        try
        {
            using (BinaryReader bw = new BinaryReader(File.OpenRead(@path)))
            { 
               var rows = bw.ReadInt16(); // read number of rows
               var columns = bw.ReadInt16(); // read number of columns
               BinaryMatrix bm = new BinaryMatrix(rows, columns);
               
               for (short i = 0; i < rows; i++)
               {
                    for (short j = 0; j < columns; j++)
                    {
                        bm[i, j] = bw.ReadByte();
                    }
               }

               return bm;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

        return null;
    }

    public void PrintMatrix()
    {
        for (short i = 0; i < N; i++)
        {
            for (short j = 0; j < M; j++)
            {
                Console.Write("{0} ", _matrix[i, j]);
            }
            Console.WriteLine();
        }
    }
}