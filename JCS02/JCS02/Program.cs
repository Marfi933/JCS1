bool IsPrime (uint n)
{
    if (n <= 2) return true;
    else
    {
        for (int i = 2; i < n; i++)
        {
            if (n % i == 0) return false;
        }
    }

    return true;
}

void Sieve (uint n)
{
    string output = "";
    for (uint i = 1; i <= n; i++)
    {
        if (IsPrime(i))
        {
            if (i != n && i!=1)
            {
                output += ", ";
            }

            output += i;
        }
    }
    
    Console.WriteLine(output);
}

void PrintSquare (int n)
{
    string output = "";
    for (int row = 0; row < n; row++)
    {
        for (int j = 0; j < n; j++)
        {
            if (row == 0 || row == n - 1)
            {
                output += "*";
            }
            else
            {
                if (j == 0 || j == n - 1)
                {
                    output += '*';
                }
                else
                {
                    output += ' ';
                }
            }
        }

        output += '\n';
    }
    Console.WriteLine(output);
}

void PrintCross (int n)
{
    string output = "";
    // mid is middle row index
    int mid = ((n - 1) / 2) + 1;
    for (int row = 1; row <= n; row++)
    {
        for (int j = 1; j <= n; j++)
        {
            if (row == mid)
            {
                output += '*';
            }

            else
            {
                if (mid == j)
                {
                    output += '*';
                }
                else
                {
                    output += ' ';
                }
            }
        }

        output += '\n';
    }

    Console.WriteLine(output);
}

void Square (int n)
{
    if (n % 2 == 0)
    {
        PrintSquare(n);
        return; // similiar like brake in loop
    }
    PrintCross(n);
}

uint NumberofOccurences (string str, char c)
{
    uint count = 0;
    foreach (var ch in str)
    {
        if (ch == c) count++;
    }

    return count;
}

string StringTimes(string str, uint n)
{
    string output = "";
    for (int i = 0; i < n; i++)
    {
        output += str;
        if (i != n - 1)
        {
             output += ", ";
        }
    }

    return output;
}

Sieve(60);
Square(5);
Square(4);
Console.WriteLine(NumberofOccurences("Retezec", 'e'));
Console.WriteLine(StringTimes("Retezec", 5));

