// See https://aka.ms/new-console-template for more information
using System.IO;

Console.WriteLine("***** DirectoryInfo Demo *****\n");

DirectoryInfo dir1 = new DirectoryInfo(".");
DirectoryInfo dir2 = new DirectoryInfo(@"C:\Windows");
DirectoryInfo dir3 = new DirectoryInfo(
    @"C:\Users\jkemp\OneDrive\Visual Studio 2017\Projects\ProCSharp10_2\DirectoryInfoDemo\Testing");
dir3.Create();

ShowDirectoryInfo(dir1);
ShowDirectoryInfo(dir2);
ShowDirectoryInfo(dir3);

string profilePics = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), "Profile Pics");
DirectoryInfo profilePicsDir = new DirectoryInfo(profilePics);
ShowDirectoryInfo(profilePicsDir);
Console.WriteLine();
DisplayFiles(profilePicsDir);
Console.WriteLine();
DirectoryInfo appDir = new(".");
ModifyDirectory(appDir);
Console.WriteLine();
DemoDirectoryType();
Console.WriteLine();
DisplayDriveInfo();
Console.WriteLine();

Console.WriteLine("Press <Enter> to quit");
Console.ReadLine();

static void DemoDirectoryType()
{
    string[] drives = Directory.GetLogicalDrives();
    Console.WriteLine("Available drives:");
    foreach (string drive in drives)
    {
        Console.WriteLine($" -> {drive}");
    }

    Console.WriteLine("Press <Enter> to delete directories");
    Console.ReadLine();
    try
    {
        Directory.Delete("MyFolder");
        Directory.Delete("MyFolder2", true);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}
static void DisplayDriveInfo()
{
    DriveInfo[] drives = DriveInfo.GetDrives();
    foreach (DriveInfo drive in drives)
    {
        Console.WriteLine($"Drive name: {drive.Name}");
        Console.WriteLine($"Total size: {drive.TotalSize / 1_073_741_824:0.0##} GB");
        Console.WriteLine($"Volume label: {drive.VolumeLabel}");
        Console.WriteLine($"Drive type: {drive.DriveType}");
        Console.WriteLine($"Free space: {drive.AvailableFreeSpace / 1_073_741_824:0.0##} GB");
        Console.WriteLine($"Drive format: {drive.DriveFormat}");
        Console.WriteLine($"Is drive ready? {drive.IsReady}");
        Console.WriteLine($"Root directory: {drive.RootDirectory}");
    }
}
static void DisplayFiles(DirectoryInfo dir)
{
    Console.WriteLine("--> Files\n");
    FileInfo[] files = dir.GetFiles().OrderBy(file => file.Name).Select(file => file).ToArray();
    Console.WriteLine($"Found {files.Length} files found");
    foreach (FileInfo file in files)
    {
        Console.WriteLine("-------------------------");
        Console.WriteLine($"File name: {file.Name}");
        Console.WriteLine($"File size: {file.Length}");
        Console.WriteLine($"Creation: {file.CreationTime}");
        Console.WriteLine($"Attributes: {file.Attributes}");
        Console.WriteLine($"Last accessed: {file.LastAccessTime}");
    }
    Console.WriteLine("-------------------------");
}
static void ModifyDirectory(DirectoryInfo dir)
{
    _ = dir.CreateSubdirectory("MyFolder");
    DirectoryInfo newDir = dir.CreateSubdirectory($"MyFolder2{Path.DirectorySeparatorChar}Data");
    Console.WriteLine($"New folder is: {newDir}");
}
static void ShowDirectoryInfo(DirectoryInfo dir)
{
    Console.WriteLine("-> Directory Info\n");

    Console.WriteLine($"Full name: {dir.FullName}");
    Console.WriteLine($"Name: {dir.Name}");
    Console.WriteLine($"Parent: {dir.Parent}");
    Console.WriteLine($"Creation: {dir.CreationTime}");
    Console.WriteLine($"Attributes: {dir.Attributes}");
    Console.WriteLine($"Root: {dir.Root}");

    Console.WriteLine("=================");
}
