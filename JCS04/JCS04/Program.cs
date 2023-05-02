using JCS04;

IntSet set = new IntSet();
IntSet set2 = new IntSet();
IntSet set3 = new IntSet();

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

IntSet intersection = set.Intersection(set2);
IntSet union = set.Union(set2);
IntSet intersectionSort = set.IntersectionSort(set2);
IntSet subtract = set2.Subtract(set);

intersection.Print();
union.Print();
intersectionSort.Print();
subtract.Print();

Console.WriteLine(set.AreAqual(set));
Console.WriteLine(set.AreAqual(set2));
Console.WriteLine(set.AreAqual(set3));
Console.WriteLine(set2.IsSubsetOf(set));
Console.WriteLine(set.IsSubsetOf(set2));