using JCS06;

IntSet<int> set = new IntSet<int>();
IntSet<int> set2 = new IntSet<int>();
IntSet<int> set3 = new IntSet<int>();

int[] arr = {1, 2, 3, 4, 3, 4, 2, 5, 6, 7, 8};
int[] arr2 = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 };
int[] arr3 = {1, 2, 3, 4, 3, 4, 2, 5, 6, 7, 10};

foreach (int el in arr)
{
    set.Add(el);
}

foreach (int el in arr2)
{
    set2.Add(el);
}

foreach (int el in arr3)
{
    set3.Add(el);
}

set.Print();
set.Remove(10);
set.Remove(20);

IIntSet<int> intersection = set.Intersection(set2);
IIntSet<int> union = set.Union(set2);
IIntSet<int> subtract = set2.Subtrack(set);

intersection.Print();
union.Print();
subtract.Print();

Console.WriteLine(set.AreAqual(set));
Console.WriteLine(set.AreAqual(set2));
Console.WriteLine(set.AreAqual(set3));
Console.WriteLine(set2.IsSubsetOf(set));
Console.WriteLine(set.IsSubsetOf(set2));

Console.WriteLine();

string [] str = {"Hello", "my", "name", "is", "Petr" };
string [] str2 = {"Hello", "my", "name", "is", "Petr", "and", "I", "am", "from", "Czechia" };
string [] str3 = {"Hello", "my", "name", "is", "Petr", "and", "I", "am", "from", "Czechia" };

IntSet<string> set4 = new IntSet<string>();
IntSet<string> set5 = new IntSet<string>();
IntSet<string> set6 = new IntSet<string>();


foreach (string el in str)
{
    set4.Add(el);
}

foreach (string el in str2)
{
    set5.Add(el);
}

foreach (string el in str3)
{
    set6.Add(el);
}

IIntSet<string> intersection2 = set4.Intersection(set5);
IIntSet<string> union2 = set4.Union(set5);
IIntSet<string> subtract2 = set5.Subtrack(set4);

intersection2.Print();
union2.Print();
subtract2.Print();

Console.WriteLine(set4.AreAqual(set4));
Console.WriteLine(set4.AreAqual(set5));
Console.WriteLine(set4.AreAqual(set6));

Console.WriteLine(set5.IsSubsetOf(set4));
Console.WriteLine(set4.IsSubsetOf(set5));
