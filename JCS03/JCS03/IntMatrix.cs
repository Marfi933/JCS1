namespace JCS03;

public class IntMatrix
{
    private int rows;
    private int columns;
    private int [,] matrix;
    public IntMatrix(int rows, int columns)
    {
        if (columns > 0 && rows > 0)
        {
            this.rows = rows;
            this.columns = columns;
            matrix = new int[rows, columns];
        }
        // create a matrix with empty array, which cant be used
        else
        {
            this.rows = 0;
            this.columns = 0;
            matrix = new int[0, 0];
        }
    }

    public int NRows()
    {
        return rows;
    }

    public int NColumns()
    {
        return columns;
    }

    private bool CheckIndexes(int x, int y)
    {
        return (x < rows && y < columns);
    }

    public int GetVal(int x, int y)
    {
        if (CheckIndexes(x, y))
        {
            return matrix[x,y];
        }
        return Int32.MaxValue;
    }

    public void SetVal(int x, int y, int val)
    {
        if (CheckIndexes(x,y))
        {
            matrix[x, y] = val;
        }
        // Nothing do here
        return;
    }

    public int NonZero()
    {
        int count = 0;

        foreach (int element in matrix)
        {
            if (element > 0) count++;
        }

        return count;
    }

    public int SumOfVals()
    {
        int sum = 0;

        foreach (int element in matrix)
        {
            sum += element;
        }

        return sum;
    }

    public IntMatrix AddMatrix(IntMatrix mat)
    {
        if (rows != mat.NRows() && columns != mat.NColumns())
        {
            Console.WriteLine($"matrix {this} rows:{rows}, columns:{columns} != matrix {mat}, rows:{mat.NRows()}, columns:{mat.NColumns()}");
            return this;
        }
        IntMatrix resultMatrix = new IntMatrix(rows, columns);
        
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                resultMatrix.SetVal(row, column, this.GetVal(row, column) + mat.GetVal(row, column));
            }
        }

        return resultMatrix;
    }

    public IntMatrix MulMatrix(IntMatrix mat){
        if (columns != mat.NRows() || rows != mat.NColumns())
        {
            Console.WriteLine($"matrix {this} rows:{rows}, columns:{columns} != matrix {mat}, rows:{mat.NRows()}, columns:{mat.NColumns()}");
            return this;
        }
        IntMatrix resultMatrix = new IntMatrix(rows, mat.NColumns());

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < mat.NColumns(); j++)
            {
                int sum = 0;
                for (int k = 0; k < columns; k++)
                {
                    sum += this.GetVal(i, k) * mat.GetVal(k, j);
                }
                resultMatrix.SetVal(i, j, sum);
            }
        }

        return resultMatrix;
    }

    public void Print(){
        for (int row = 0; row < rows; row++)
        {
            for (int column = 0; column < columns; column++)
            {
                Console.Write($"{matrix[row, column]} ");
            }
            Console.WriteLine();
        }
    }
    public static IntMatrix Ones(int nRows, int nCols)
    {
        IntMatrix resultMatrix = new IntMatrix(nRows, nCols);
        for (int row = 0; row < nRows; row++)
        {
            for (int column = 0; column < nCols; column++)
            {
                resultMatrix.SetVal(row, column, 1);   
            }
        }

        return resultMatrix;
    }
}