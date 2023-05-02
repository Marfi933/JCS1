double Discriminant(double a, double b, double c)
{
    double x = b * b - 4 * a * c;
    return x;
}

// print every number divided by 7
void PrintNumbersDividedBy7(int i)
{
    int j = 0;
    while (j < i)
    {
        if (j % 7 == 0 && j % 3 != 0)
        {
            Console.WriteLine(j);
        }
        j++;
    }
}

// Fibonacci numbers
uint Fib(uint n)
{
    if (n <= 1)
    {
        return n;
    }
    else
    {
        return Fib(n - 1) + Fib(n - 2);
    }
}

// sum of n natural numbers
uint SumNaturalNumbers(uint n)
{
    uint sum = 0;
    for (uint i = 0; i < n; i++)
    {
        sum += i;
        
        if (i == 25) Console.WriteLine($"The result for i=25 is: {sum}");
    }
    
    return sum;
}


Console.WriteLine(Discriminant(6, 11, 1));
Console.WriteLine("------------------------");
PrintNumbersDividedBy7(359);
Console.WriteLine("------------------------");
Console.WriteLine(Fib(4));
Console.WriteLine(SumNaturalNumbers(55));