using JCS09;

//Dama game = new Dama();
//game.Start();

int x =0;

Console.WriteLine(x);

var prvni = new IntMatrix(2, 2);
prvni.SetVal(0, 0, 2);
prvni.SetVal(0, 1, 4);
prvni.SetVal(1, 0, 6);
prvni.SetVal(1, 1, 8);
prvni.Print();
var druha = new IntMatrix(2, 2);
druha.SetVal(0, 0, 1);
druha.SetVal(0, 1, 3);
druha.SetVal(1, 0, 5);
druha.SetVal(1, 1, 7);
druha.Print();
var treti = prvni + druha;
treti.Print();
if (prvni + druha == treti) Console.WriteLine("Equal");
else Console.WriteLine("Not equal");
if (prvni != druha) Console.WriteLine("Not equal");
else Console.WriteLine("Equal");
if (prvni > druha) Console.WriteLine("first is greater");
else Console.WriteLine("first is not greater");
if (prvni < druha) Console.WriteLine("first is smaller");
else Console.WriteLine("first is not smaller");
if (prvni >= druha) Console.WriteLine("first is greater or equal");
else Console.WriteLine("first is not greater or equal");
if (prvni <= druha) Console.WriteLine("first is smaller or equal");
Console.WriteLine("first is not smaller or equal");

static int Add(int a, int b)
{
    return a + b;
}

static int Sub(int a, int b)
{
    return a - b;
}

static int Mul(int a, int b)
{
    return a * b;
}

static int Div(int a, int b)
{
    if (b == 0) throw new DivideByZeroException();
    return a / b;
}

static int[] MapMathOperation(int[] array, int[] array2, mathOperation op)
{
    if (array.Length != array2.Length) throw new Exception("Arrays must be same length");
    
    int[] result = new int[array.Length];
    for (int i = 0; i < array.Length; i++)
    {
        result[i] = op(array[i], array2[i]);
    }
    return result;
}

int[] a = { 1, 2, 3, 4, 5 };
int[] b = { 2, 3, 4, 5, 6 };
int[] c = MapMathOperation(a, b, Sub );
foreach (int i in c) Console.Write(i + " ");

delegate int mathOperation(int x, int y);

