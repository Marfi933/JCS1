namespace JCP5;

public interface IIntPriorityQueue {
bool IsEmpty();
void InsertWithPriority(int value, int priority);
bool PopNextValue(out int val);
bool PeekNextValue(out int val);
}
