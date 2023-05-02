namespace Database;

public class ComparableMergeSort
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
    
    public static void Sort<T>(T[] arr) where T : IComparable<T>
    {
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
        Sort<T>(left);
        Sort<T>(right);
        Merge<T>(arr, left, right);
    }
}