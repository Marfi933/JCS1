namespace JCS02_03;

public class PrintDirectoryInfo
{
    public void PrintDrives()
    {
        Console.WriteLine("Drive system in this computer:");
        Console.WriteLine("{0,-5}{1,-15}{2,-20}{3,-10}", "Name", "Type", "Size (bytes)", "Free space");
        DriveInfo [] driveInfo = DriveInfo.GetDrives();
        foreach (var di in driveInfo)
        {
            if (di.IsReady)
            {
                Console.WriteLine("{0,-5}{1,-15}{2,-20}{3,-10}", di.Name, di.DriveType ,di.TotalSize, di.AvailableFreeSpace);
            }
        }
    }
    
    public void PrintAllDirectories(string path)
    {
        try
        {
            if (path == "")
            {
                Console.WriteLine("Please enter a path. Path cannot be empty.");
                return;
            }
            DirectoryInfo di = new DirectoryInfo(path);
            if (di.Exists)
            {
                PrintDirectories(di);
                PrintFiles(di);
            }
            else if(path!="") {
                Console.WriteLine("Directory {0} not found. Please insert valid path.", path);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
    }
    
    public void PrintFiles(DirectoryInfo  di)
    {
        FileInfo[] fi = di.GetFiles();
        foreach (var f in fi)
        {
            if (f.Exists) Console.WriteLine("{0,-20}{1,-20}{2,-20}", f.CreationTime, f.Length, f.Name);
        }
    }
    
    public void PrintDirectories(DirectoryInfo di)
    {
        FileInfo[] fi = di.GetFiles();
        foreach (var f in fi)
        {
            if (f.Exists) Console.WriteLine("{0,-20}{1,-20}{2,-20}", f.CreationTime, "<dir>", f.Name);
        }
    }
}