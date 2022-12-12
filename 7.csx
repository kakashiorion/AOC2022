var contents = File.ReadAllLines("7.txt");

class MyFile
{
    public int size;
    public string fileName;
    public MyDirectory parentDirectory;
    public MyFile(string fileName, int size, MyDirectory parentDirectory)
    {
        this.fileName = fileName;
        this.size = size;
        this.parentDirectory = parentDirectory;
    }
}

class MyDirectory
{
    public int size;
    public string directoryName;
    public MyDirectory parentDirectory;
    public List<MyDirectory> directories;
    public List<MyFile> files;
    public MyDirectory(string directoryName, int size, MyDirectory parentDirectory)
    {
        this.directoryName = directoryName;
        this.size = size;
        this.parentDirectory = parentDirectory;
        this.directories = new List<MyDirectory>();
        this.files = new List<MyFile>();
    }
    public void addFile(MyFile file)
    {
        files.Add(file);
    }
    public void addDirectory(MyDirectory directory)
    {
        directories.Add(directory);
    }
    public void updateSize()
    {
        int dirSizes = 0;
        directories.ForEach(delegate (MyDirectory d)
           {
               dirSizes += d.size;
           });
        size += dirSizes;
    }
    public void addSize(int fSize)
    {
        this.size += fSize;
    }
}

int smallTotal = 0;
const int smallLimit = 100000;
const int usedDiskSpace = 42143088;
const int totalDiskSpace = 70000000;
const int requiredDiskSpace = 30000000;
const int toBeDeleted = requiredDiskSpace - totalDiskSpace + usedDiskSpace;

var chosenSize = totalDiskSpace;

var currentDirectory = new MyDirectory("/", 0, null);
// Internal.Console.WriteLine("-/");
int depth = 0;
for (int i = 1; i < contents.Length; i++)
{
    if (contents[i].Split(' ')[0] == "$")
    {
        if (contents[i].Split(' ')[1] == "cd")
        {
            if (contents[i].Split(' ')[2] == "..")
            {
                depth--;
                currentDirectory.updateSize();
                if (currentDirectory.size < smallLimit)
                {
                    smallTotal += currentDirectory.size;
                }
                if (currentDirectory.size > toBeDeleted && currentDirectory.size < chosenSize)
                {
                    chosenSize = currentDirectory.size;
                }
                currentDirectory = currentDirectory.parentDirectory;
            }
            else
            {
                depth++;
                currentDirectory = currentDirectory.directories.Find(x => x.directoryName == contents[i].Split(' ')[2]);
                // Internal.Console.WriteLine(new string(' ', depth * 2) + "-" + currentDirectory.directoryName + " (d)");

            }
        }
        else
        {
            continue;
        }
    }
    else if (contents[i].Split(' ')[0] == "dir")
    {
        var newDirectory = new MyDirectory(contents[i].Split(' ')[1], 0, currentDirectory);
        currentDirectory.addDirectory(newDirectory);
    }
    else
    {
        var newFile = new MyFile(contents[i].Split(' ')[1], Convert.ToInt32(contents[i].Split(' ')[0]), currentDirectory);
        currentDirectory.addFile(newFile);
        currentDirectory.addSize(newFile.size);
        // Internal.Console.WriteLine(new string(' ', (depth + 1) * 2) + "-" + newFile.fileName + " (f," + newFile.size.ToString() + ")");
    }
}
currentDirectory = currentDirectory.parentDirectory;
currentDirectory.updateSize();

// Internal.Console.WriteLine("Outermost directory / " + currentDirectory.size.ToString());


Internal.Console.WriteLine("Small directory total: " + smallTotal);
/* part1: 1770595 */

Internal.Console.WriteLine("To be deleted: " + chosenSize.ToString());
/* part2: 2195372 */

