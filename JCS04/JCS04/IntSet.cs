namespace JCS04;

public class IntSet
{
    private int[] set;
    private int capacity = 10;
    private int index = 0;
    public IntSet()
    {
        this.set = new int[capacity];
    }

    int Size()
    {
        return capacity;
    }

    public bool Contains(int element)
    {
        for (var i = 0; i < index; i++)
        {
            var el = set[i];
            if (element == el) return true;
        }

        return false;
    }

    public bool IsEmpty()
    {
        return index == 0;
    }
    
    // timecomplexity: O(n^2)
    private void Sort()
    {
        int temp;
        for (int i = 0; i < index; i++)
        {
            for (int j = i + 1; j < index; j++)
            {
                if (set[i] > set[j])
                {
                    temp = set[i];
                    set[i] = set[j];
                    set[j] = temp;
                }
            }
        }
    }
    public void Print()
    {
        for (var i = 0; i < index; i++)
        {
            var el = set[i];
            Console.Write($"{el}, ");
        }
        Console.WriteLine();
    }
    private void ResizeSet(int cap)
    {
        int[] tmpArr = new int[cap];

        for (int i = 0; i < capacity; i++)
        {
            tmpArr[i] = set[i];
        }

        set = tmpArr;
        capacity = cap;
    }

    public void Add(int n)
    {
        if (Contains(n))
        {
            //Console.WriteLine($"Element {n}: is already in set!");
            return;
        }
        else if (index+1 == capacity-1)
        {
            ResizeSet(capacity*2);
        }

        set[index++] = n;
    }

    public void Remove(int n)
    {
        if (!Contains(n) || index == 0)
        {
            //Console.WriteLine($"Element {n}: is not in set!");
            return;
        }

        Sort();

        for (int i = 0; i < index-1; i++)
        {
            if (set[i] == n)
            {
                for (int j = i; j < index-1; j++)
                {
                    set[j] = set[j + 1];
                }
                index--;
                break;
            }
        }
        
        // set is filled by 25% max than decrease capacity
        if (capacity / 4 == index)
        {
            ResizeSet(capacity/4);
        }
    }

    public IntSet Union(IntSet other)
    {
        IntSet newSet = new IntSet();
        
        for (int i = 0; i < index; i++)
        {
            newSet.Add(set[i]);
        } 
        
        for (int i = 0; i < other.index; i++)
        {
            newSet.Add(other.set[i]);
        }
        newSet.Sort();
        return newSet;
    }

    public IntSet Intersection(IntSet other)
    {
        IntSet newSet = new IntSet();
        int maxIndex = index <= other.index ? index : other.index;

        for (int i = 0; i < maxIndex; i++)
        {
            if (maxIndex == index)
            {
                int n = set[i];
                if (other.Contains(n)) newSet.Add(n);
            }
            else
            {
                int n = other.set[i];
                if (Contains(n)) newSet.Add(n);
            }
           
        }
        newSet.Sort();
        return newSet;
    }
    
    public IntSet IntersectionSort(IntSet other)
    {
        IntSet newSet = new IntSet();
        
        int maxIndex = index <= other.index ? index : other.index;
        
        Sort();
        other.Sort();
        
        for (int i = 0; i < maxIndex; i++)
        {
            if(set[i] == other.set[i]) newSet.Add(set[i]);
        }
        newSet.Sort();
        return newSet;
    }
    
    public IntSet Subtract(IntSet other)
    {
        IntSet newSet = new IntSet();

        for (int i = 0; i < index; i++)
        {
            newSet.Add(set[i]);
        } 
        
        for (int i = 0; i < other.index; i++)
        {
            int el = other.set[i];
            if (Contains(el)) newSet.Remove(el);
        }
        
        newSet.Sort();
        return newSet;
    }

    public bool AreAqual(IntSet other)
    {
        if (other.index != index) return false;
        for (var i = 0; i < index; i++)
        {
            var el = set[i];
            if (!other.Contains(el)) return false;
        }

        return true;
    }

    public bool IsSubsetOf(IntSet other)
    {
        if (other.index > index) return false;

        for (int i = 0; i < other.index; i++)
        {
            if (!Contains(other.set[i])) return false;
        }

        return true;
    }
}