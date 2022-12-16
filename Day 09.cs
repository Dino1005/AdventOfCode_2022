var reader = new StreamReader(@"C:\\Users\\radon\\Desktop\\input.txt");
string line = reader.ReadLine();
int headRow = 0, headCol = 0, prevRow = 0, prevCol = 0;

while (line != null)
{
    string[] split = line.Split();
    if (split[0] == "R")
    {
        for (int i = 0; i < int.Parse(split[1]); i++)
        {
            prevCol = headCol;
            headCol++;
            Tail.CheckTail(headRow, headCol, prevRow, prevCol);
        }
        prevCol = headCol;
    }
        
    if (split[0] == "L")
    {
        for (int i = 0; i < int.Parse(split[1]); i++)
        {
            prevCol = headCol;
            headCol--;
            Tail.CheckTail(headRow, headCol, prevRow, prevCol);
        }
        prevCol = headCol;
    }
        
    if (split[0] == "U")
    {
        for (int i = 0; i < int.Parse(split[1]); i++)
        {
            prevRow = headRow;
            headRow--;
            Tail.CheckTail(headRow, headCol, prevRow, prevCol);
        }
        prevRow = headRow;
    }
        
    if (split[0] == "D")
    {
        for (int i = 0; i < int.Parse(split[1]); i++)
        {
            prevRow = headRow;
            headRow++;
            Tail.CheckTail(headRow, headCol, prevRow, prevCol);
        }
        prevRow = headRow;
    }
        

    line = reader.ReadLine();
}
Console.WriteLine(Tail.visited.Count);


static class Tail
{
    public static int tailRow = 0;
    public static int tailCol = 0;
    public static List<string> visited = new List<string> {"00"};

    public static void CheckTail(int row, int col, int prevRow, int prevCol)
    {
        if (Math.Sqrt((Math.Pow((row - tailRow), 2)) + (Math.Pow((col - tailCol), 2))) >= 2)
        {
            tailRow = prevRow;
            tailCol = prevCol;

            string cords = prevRow.ToString() + prevCol.ToString();
            if (!visited.Contains(cords))
                visited.Add(cords);

        }
    }
}


//svi tailovi se sada mogu kretat dijagonalno i prate tail ispred sebe