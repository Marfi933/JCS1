using System.Diagnostics;

class Program
{
    public static void Merge<T>(T[] arr, T[] left, T[] right) where T : IComparable<T>
    {
        int i = 0, j = 0, k = 0;
        while (i < left.Length && j < right.Length)
        {
            if (left[i].CompareTo(right[j]) < 0)
            {
                arr[k] = left[i];
                i++;
            }
            else
            {
                arr[k] = right[j];
                j++;
            }

            k++;
        }

        while (i < left.Length)
        {
            arr[k] = left[i];
            i++;
            k++;
        }

        while (j < right.Length)
        {
            arr[k] = right[j];
            j++;
            k++;
        }
    }

    public static void PrintArray<T>(T[] arr)
    {
        foreach (var item in arr)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }

    public static void ParallelMergeSort<T>(T[] arr, int depth) where T : IComparable<T>
    {
        //nothing to sort
        if (arr.Length <= 1)
        {
            return;
        }
        
        int center = arr.Length / 2;
        T[] left = new T[center];
        T[] right = new T[arr.Length - center];
        
        for (int i =0; i< center; i++)
        {
            left[i] = arr[i];
        }
        
        for (int i = center; i < arr.Length; i++)
        {
            right[i - center] = arr[i];
        }

        if (depth > 0)
        {
            depth--;
            Parallel.Invoke(
                () => ParallelMergeSort(left, depth),
                () => ParallelMergeSort(right, depth)
            );
        }
        else
        {
            ParallelMergeSort(left, depth);
            ParallelMergeSort(right, depth);
        }
        Merge(arr, left, right);
    }

    public static int[] RandomArray(int length)
    {
        int[] arr = new int[length];
        Random random = new Random();
        for (int i = 0; i < length; i++) {
            arr[i] = random.Next();
        }

        return arr;
    }

    public static void Main()
    {
        int[] arr = RandomArray(10000000);
        Console.WriteLine("depth = 0");
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        ParallelMergeSort(arr, 0);
        stopwatch.Stop();
        Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed.TotalMilliseconds);
        Console.WriteLine("depth = 0");
        arr = RandomArray(10000000);
        Console.WriteLine("depth = 1");
        stopwatch = new Stopwatch();
        stopwatch.Start();
        ParallelMergeSort(arr, 1);
        stopwatch.Stop();
        Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed.TotalMilliseconds);
        Console.WriteLine("depth = 1"); 
        arr = RandomArray(10000000);
        Console.WriteLine("depth = 2");
        stopwatch = new Stopwatch();
        stopwatch.Start();
        ParallelMergeSort(arr, 2);
        stopwatch.Stop();
        Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed.TotalMilliseconds);
        Console.WriteLine("depth = 2");
        arr = RandomArray(10000000);
        Console.WriteLine("depth = 10");
        stopwatch = new Stopwatch();
        stopwatch.Start();
        ParallelMergeSort(arr, 10);
        stopwatch.Stop();
        Console.WriteLine("Time elapsed: {0}", stopwatch.Elapsed.TotalMilliseconds);
        Console.WriteLine("depth = 10");
        Console.WriteLine("Done");
    }
}