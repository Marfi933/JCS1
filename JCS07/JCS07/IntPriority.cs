using System.Text;

namespace JCP5;

public class IntPriority : IIntPriorityQueue
{
    private int[] _data;
    private int[] _priority;
    private int _capacity;
    private int _index = 0;
    

    public IntPriority(int capacity)
    {
        this._capacity = capacity;
        _data = new int[capacity];
        _priority = new int[capacity];
    }

    public bool IsEmpty()
    {
        return _index == 0;
    }
    
    public bool isFull()
    {
       return _index == _capacity-1;
    }

    private void ResizeArrays(int capacity)
    {
        int[] newData = new int[capacity * 2];
        int[] newPriority = new int[capacity * 2];
        
        for (int i = 0; i < _capacity; i++)
        {
            newData[i] = _data[i];
            newPriority[i] = _priority[i];
        }
        
        _capacity = capacity;
        _data = newData;
        _priority = newPriority;
    }
    
    public void InsertWithPriority(int value, int priority)
    {
        if (isFull()){
            ResizeArrays(_capacity*2);   
        }

        int locationIndex = 0;
        for (int i = 0; i < _index; i++)
        {
            if (_priority[i] < priority)
            {
                locationIndex = i;
                break;
            }
        }
        
        for (int i = _index; i > locationIndex; i--)
        {
            _data[i] = _data[i - 1];
            _priority[i] = _priority[i - 1];
        }

        _data[locationIndex] = value;
        _priority[locationIndex] = priority;
        _index++;
    }

    public bool PopNextValue(out int val)
    {
        if (IsEmpty())
        {
            throw new Exception("Queue is empty");
        }

        val = _data[0];
        //Remove the first element, and shift the rest of the array down
        for (int i = 0; i < _index; i++)
        {
            _data[i] = _data[i + 1];
            _priority[i] = _priority[i + 1];
        }
        
        if (_capacity / 4 == _index)
        {
            ResizeArrays(_capacity / 4);
        }
        
        _index--;
        return true;
    }

    public bool PeekNextValue(out int val)
    {
        if (IsEmpty())
        {
            val = Int32.MinValue;
            return false;
        }
        
        val = _data[0];
        return true;
    }
    
    private int GetCountDigits()
    {
        int count = 0;
        for (int i = 0; i < _index; i++)
        {
           int temp = _data[i];
           int temp2 = _priority[i];
              while (temp > 0)
              {
                temp /= 10;
                count++;
              }
              while (temp2 > 0)
              {
                    temp2 /= 10;
                    count++;
              }
        }
        return count;
    }   

    public override string ToString()
    {
        // data + priority + new line + length of "priority: " _index times + length of "data: " _index times + 2 (\r\n) * (_index-1) times
        int countOfChars = GetCountDigits() + _index + "priority: ".Length * _index + "value: ".Length * _index + 2 * (_index-1);
        StringBuilder output = new StringBuilder("", countOfChars);      
        for (int i = 0; i < _index; i++)
        { 
           if (i == _index - 1) output.Append("value: " + _data[i] + " priority: " + _priority[i]);
           
           else output.AppendFormat($"priority: {_priority[i]} value: {_data[i]}{Environment.NewLine}");
        }
        return output.ToString();
    }
}