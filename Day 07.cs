var reader = new StreamReader(@"C:\\Users\\radon\\Desktop\\input.txt");
string line = reader.ReadLine();
line = reader.ReadLine();
Tree<string> root = new Tree<string>("root");
Tree<string> current = root;

while (line != null)
{
    string[] strings = line.Split(' ');
    if (strings[0] == "$")
    {
        if (strings[1] == "cd")
        {
            if (strings[2] == "..")
            {
                current = current.Parent;
            }
            else
            {
                current = current.dirs.Find(x => x.Name == strings[2]);
            }
        }
    }
    else
    {
        if (strings[0] == "dir")
        {
            current.AddChild(strings[1]);
        }
        else
        {
            current.AddFile(int.Parse(strings[0]));
        }
    }
    line = reader.ReadLine();
}

int sum = 0;
root.GetSize(root);
Global.root = root.DirSize;
root.FindDirs(root);
foreach (var dir in Global.dirs)
{
    sum += dir.DirSize;
}
Console.WriteLine(sum);
Console.WriteLine(Global.mins.MinBy(x => x.DirSize).DirSize); 


static class Global
{
    public static List<Tree<string>> dirs = new List<Tree<string>>();
    public static List<Tree<string>> mins = new List<Tree<string>>();
    public static int root = 0;
}

class Tree<T>
{
    public List<Tree<T>> dirs = new List<Tree<T>>();
    public Tree<T> Parent { get; set; }
    public List<int> files { get; set; }
    public int DirSize { get; set; }
    public T Name { get; }


    public Tree(T name)
    {
        Name = name;
        files = new List<int>();
    }

    public void AddChild(T name)
    {
        Tree<T> dir = new Tree<T>(name) { Parent = this};
        dirs.Add(dir);
    }

    public void AddFile(int size)
    {
        files.Add(size);
    }

    public int GetSize(Tree<string> current)
    {
        current.DirSize = current.files.Sum();
        if (current.dirs.Count != 0)
        {
            foreach (var dir in current.dirs)
            {
                current.DirSize += GetSize(dir);
            }
        }
        return current.DirSize;
    }

    public void FindDirs(Tree<string> current)
    {
        if (current.DirSize <= 100000)
            Global.dirs.Add(current);
        if ((current.DirSize != Global.root) && (70000000 - Global.root + current.DirSize > 30000000))
            Global.mins.Add(current);
        foreach (var dir in current.dirs)
        {
            FindDirs(dir);
        }
        return;
    } 
}