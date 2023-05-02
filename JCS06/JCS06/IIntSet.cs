namespace JCS06;

public interface IIntSet<T> : IEnumerable<T>
{
    void Add(T item);
    public bool Contains(T item);
    void Remove(T n);
    int Size(); 
    IIntSet<T> Union(IntSet<T> other);
    IIntSet<T> Intersection(IntSet<T> other);
    IIntSet<T> Subtrack(IntSet<T> other);
    bool AreAqual(IntSet<T> other);
    bool IsSubsetOf(IntSet<T> other);
    bool IsEmpty();
    void Print();
}