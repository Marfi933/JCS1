namespace JCS09;

public class IntMatrix
{
    private int _rows;
    private int _columns;
    private int [,] _matrix;
    public IntMatrix(int rows, int columns)
    {
        if (columns > 0 && rows > 0)
        {
            this._rows = rows;
            this._columns = columns;
            _matrix = new int[rows, columns];
        }
        // create a matrix with empty array, which cant be used
        else
        {
            this._rows = 0;
            this._columns = 0;
            _matrix = new int[0, 0];
        }
    }

    public int NRows()
    {
        return _rows;
    }

    public int NColumns()
    {
        return _columns;
    }

    private bool CheckIndexes(int x, int y)
    {
        return (x < _rows && y < _columns);
    }

    public int GetVal(int x, int y)
    {
        if (CheckIndexes(x, y))
        {
            return _matrix[x,y];
        }
        return Int32.MaxValue;
    }

    public void SetVal(int x, int y, int val)
    {
        if (CheckIndexes(x,y))
        {
            _matrix[x, y] = val;
        }
        // Nothing do here
        return;
    }

    public int NonZero()
    {
        int count = 0;

        foreach (int element in _matrix)
        {
            if (element > 0) count++;
        }

        return count;
    }

    public int SumOfVals()
    {
        int sum = 0;

        foreach (int element in _matrix)
        {
            sum += element;
        }

        return sum;
    }

    public IntMatrix AddMatrix(IntMatrix mat)
    {
        if (_rows != mat.NRows() && _columns != mat.NColumns())
        {
            Console.WriteLine($"matrix {this} rows:{_rows}, columns:{_columns} != matrix {mat}, rows:{mat.NRows()}, columns:{mat.NColumns()}");
            return this;
        }
        IntMatrix resultMatrix = new IntMatrix(_rows, _columns);
        
        for (int row = 0; row < _rows; row++)
        {
            for (int column = 0; column < _columns; column++)
            {
                resultMatrix.SetVal(row, column, this.GetVal(row, column) + mat.GetVal(row, column));
            }
        }

        return resultMatrix;
    }

    public IntMatrix MulMatrix(IntMatrix mat){
        if (_columns != mat.NRows() || _rows != mat.NColumns())
        {
            Console.WriteLine($"matrix {this} rows:{_rows}, columns:{_columns} != matrix {mat}, rows:{mat.NRows()}, columns:{mat.NColumns()}");
            return this;
        }
        IntMatrix resultMatrix = new IntMatrix(_rows, mat.NColumns());

        for (int i = 0; i < _rows; i++)
        {
            for (int j = 0; j < mat.NColumns(); j++)
            {
                int sum = 0;
                for (int k = 0; k < _columns; k++)
                {
                    sum += this.GetVal(i, k) * mat.GetVal(k, j);
                }
                resultMatrix.SetVal(i, j, sum);
            }
        }

        return resultMatrix;
    }

    public void Print(){
        for (int row = 0; row < _rows; row++)
        {
            for (int column = 0; column < _columns; column++)
            {
                Console.Write($"{_matrix[row, column]} ");
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
    
    public bool Contains(int val)
    {
        foreach (int element in _matrix)
        {
            if (element == val) return true;
        }

        return false;
    }

    public static IntMatrix operator + (IntMatrix mat1, IntMatrix mat2)
    {
        return mat1.AddMatrix(mat2);
    }
    
    public static IntMatrix operator * (IntMatrix mat1, IntMatrix mat2)
    {
        return mat1.MulMatrix(mat2);
    }
    
    public static bool operator != (IntMatrix mat1, IntMatrix mat2)
    {
        return !(mat1 == mat2);
    }
    
    public static bool operator == (IntMatrix mat1, IntMatrix mat2)
    {
        if (mat1.NRows() != mat2.NRows() || mat1.NColumns() != mat2.NColumns()) return false;
        for (int row = 0; row < mat1.NRows(); row++)
        {
            for (int column = 0; column < mat1.NColumns(); column++)
            {
                if (mat1.GetVal(row, column) != mat2.GetVal(row, column)) return false;
            }
        }

        return true;
    }

    public static bool operator < (IntMatrix mat1, IntMatrix mat2)
    {
        if (mat1.NRows() != mat2.NRows() || mat1.NColumns() != mat2.NColumns()) return false;
        for (int row = 0; row < mat1.NRows(); row++)
        {
            for (int column = 0; column < mat1.NColumns(); column++)
            {
                if (mat1.GetVal(row, column) >= mat2.GetVal(row, column)) return false;
            }
        }

        return true;
    }

    public static bool operator >(IntMatrix mat1, IntMatrix mat2)
    {
        for (int row = 0; row < mat1.NRows(); row++)
        {
            for (int column = 0; column < mat1.NColumns(); column++)
            {
                if (mat1.GetVal(row, column) <= mat2.GetVal(row, column)) return false;
            }
        }
        
        return true;
    }
    
    public static bool operator >= (IntMatrix mat1, IntMatrix mat2) {
        return !(mat1 < mat2);
    }
    
    public static bool operator <= (IntMatrix mat1, IntMatrix mat2) {
        return !(mat1 > mat2);
    }
    
    public static IntMatrix operator - (IntMatrix mat1, IntMatrix mat2) {
        if (mat1.NRows() != mat2.NRows() || mat1.NColumns() != mat2.NColumns()) return mat1;
        for (int row = 0; row < mat1.NRows(); row++)
        {
            for (int column = 0; column < mat1.NColumns(); column++)
            {
                mat1.SetVal(row, column, mat1.GetVal(row, column) - mat2.GetVal(row, column));
            }
        }

        return mat1;
    }

    public static IntMatrix operator ++(IntMatrix mat1){
        for (int row = 0; row < mat1.NRows(); row++)
        {
            for (int column = 0; column < mat1.NColumns(); column++)
            {
                mat1.SetVal(row, column, mat1.GetVal(row, column) + 1);
            }
        }
        
        return mat1;
    }
    
    public static IntMatrix operator --(IntMatrix mat1){
        for (int row = 0; row < mat1.NRows(); row++)
        {
            for (int column = 0; column < mat1.NColumns(); column++)
            {
                mat1.SetVal(row, column, mat1.GetVal(row, column) - 1);
            }
        }
        
        return mat1;
    }
}