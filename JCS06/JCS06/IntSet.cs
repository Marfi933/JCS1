using System.Collections;

namespace JCS06;

public class IntSet<T> : IIntSet<T>
{
    private int _index;
    private T[] _array;
    private int _capacity = 10;
    
    public IntSet()
    {
        _array = new T[_capacity];
        _index = 0;
    }
    
    public IEnumerator<T> GetEnumerator()
    {
        return new IntSetEnumator<T>(_array, _index);
    }
    
    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void ResizeSet()
    {
        T[] nextData = new T[_capacity * 2];
        _array.CopyTo(nextData, 0);
        _array = nextData;
    }
    
    public void Add(T item)
    {
        if (Contains(item))
        {
            return;
        }
        
        if (_index == _capacity-1)
        {
            ResizeSet();
        }
        _array[_index] = item;
        _index++;
    }
    
    public bool Contains(T element)
    {
        for (var i = 0; i < _index; i++)
        {
            if (_array[i]!.Equals(element)) return true;
        }

        return false;
    }
    
    public void Remove(T n)
    {
        if (!Contains(n) || _index == 0)
        {
            //Console.WriteLine($"Element {n}: is not in set!");
            return;
        }

        for (int i = 0; i < _index; i++)
        {
            if (_array[i]!.Equals(n))
            {
                for (int j = i; j < _index - 1; j++)
                {
                    _array[j] = _array[j + 1];
                }

                _index--;
                break;
            }
        }
    }

    
    public int Size()
    {
        return _capacity;
    }
    
    public void Print()
    {
        foreach (var el in this)
        {
            Console.Write(el+", ");
        }
        Console.WriteLine();
    }
    
    public IIntSet<T> Union(IntSet<T> other)
    {
        IntSet<T> union = new IntSet<T>();
        foreach (var item in this)
        {
            union.Add(item);
        }
        foreach (var item in other)
        {
            union.Add(item);
        }
        return union;
    }
    
    public IIntSet<T> Intersection(IntSet<T> other)
    {
        IntSet<T> intersection = new IntSet<T>();
        foreach (var item in this)
        {
            if (other.Contains(item))
            {
                intersection.Add(item);
            }
        }
        return intersection;
    }

    public IIntSet<T> Subtrack(IntSet<T> other)
    {
        IntSet<T> subtrack = new IntSet<T>();
        foreach (var item in this)
        {
            if (!other.Contains(item))
            {
                subtrack.Add(item);
            }
        }
        return subtrack;
    }

    public bool AreAqual(IntSet<T> other)
    {
        if (_index != other._index) return false;

        for (int i = 0; i < other._index; i++)
        {
            if (!Contains(other._array[i])) return false;
        }
        return true;
    }
    
    public bool IsSubsetOf(IntSet<T> other)
    {
        if (other._index > _index) return false;

        foreach (var item in other)
        {
            if (!other.Contains(item)) return false;
        }

        return true;
    }
    
    public bool IsEmpty()
    {
        return _index == 0;
    }

}

public class IntSetEnumator<T> : IEnumerator<T>
{
    private T[] _array;
    private int _pos = -1;
    private int _realSize;
    public IntSetEnumator(T[] array,int realSize)
    {
        this._array = array;
        this._realSize = realSize;
    }
    public T Current => _array[_pos];

    object IEnumerator.Current => _array[_pos];

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        _pos++;
        return _pos < _realSize;
    }

    public void Reset()
    {
        _pos = -1;
    }
}


