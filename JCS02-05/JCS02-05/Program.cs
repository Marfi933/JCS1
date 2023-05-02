using Database;

namespace JCS02_05;

public class Program
{
    private static void UniqueStudents(Student[] arr, int from, int to)
    {
        for (int i = from-1; i < to; i++)
        {
            if (i < arr.Length) Console.WriteLine(arr[i]);
        }
    }

    private static bool isUnique(IEnumerable<Student> students, Student student)
    {
        foreach (var s in students) 
            if (s.Equals(student)) return false;

        return true;
    }

    private static List<Student> MakeUnique(Student[] arr)
    {
        var uniqueStudents = new List<Student>();
        foreach (var student in arr)
            if (isUnique(uniqueStudents, student)) uniqueStudents.Add(student);
        return uniqueStudents;
    }
    
    private static void UniqueLinQ(Student[] students, int from, int to)
    {
        var s = students.GroupBy(p => new { p.Jmeno, p.Prijmeni })
            .Select(g => g.First())
            .OrderBy(p => p.Prijmeni)
            .ThenBy(p => p.Jmeno)
            .Skip(from - 1)
            .Take(to - from + 1);

        foreach (var student in s) Console.WriteLine(student);
    }

    private static void FirstStudentOf5YearOrBigger(Student[] students)
    {
        var s = students.Where(p => p.Rocnik >= 5)
            .OrderBy(p => p.Prijmeni)
            .ThenBy(p => p.Jmeno)
            .First();
        Console.WriteLine(s);   
    }
    
    private static int NumberOfInf_PVS(Student[] students)
    {
        return students.Count(p => p.OborKomb == "INF-PVS");
    }
    
    private static bool ExistsStudentName(Student[] students, string name)
    {
        return students.Any(p => p.Jmeno == name);
    }

    public static void Main(string[] args)
    {
        var students = ReadonlyDB.Students;
        ComparableMergeSort.Sort(students);
        Console.WriteLine("Unique students by simple way: ");
        UniqueStudents(students, 5, 15);
        Console.WriteLine("Unique students by LINQ: ");
        
        var studentsLINQ = ReadonlyDB.Students;
        UniqueLinQ(studentsLINQ, 5, 15);
        
        Console.WriteLine("First student of 5th year or bigger: ");
        FirstStudentOf5YearOrBigger(students);
        
        Console.WriteLine("Number of INF-PVS students: ");
        Console.WriteLine(NumberOfInf_PVS(students));
        
        Console.WriteLine("Exists student with name Lukáš: ");
        Console.WriteLine(ExistsStudentName(students, "Lukáš"));
        
    }
}