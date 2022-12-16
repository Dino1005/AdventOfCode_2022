var reader = new StreamReader(@"C:\\Users\\radon\\Desktop\\input.txt"); 
string line = reader.ReadLine();

int rows = 0, startRow = 0, startCol = 0;
Global.grid = new List<List<char>>();


while (line != null)
{
    Global.grid.Add(line.ToList());
    line = reader.ReadLine();
    rows++;
}

for (int i = 0; i < Global.grid.Count; i++)
{
    for (int j = 0; j < Global.grid[i].Count; j++)
    {
        if (Global.grid[i][j] == 'S')
        {
            startRow = i;
            startCol = j;
        }

        if (Global.grid[i][j] == 'E')
        {
            Global.endRow = i;
            Global.endCol = j;
        }

    }
}
Global.grid[startRow][startCol] = 'a';
Global.grid[Global.endRow][Global.endCol] = 'z';
Console.WriteLine(Global.FindShortestPath(startRow, startCol, ' '));

static class Global
{
    public static List<List<char>> grid;
    public static int count = 0;
    public static bool end = false;
    public static int endRow = 0;
    public static int endCol = 0;
    public static List<string> visited = new List<string>();
    public static int order = 0;

    public static int FindShortestPath(int row, int col, char dir)
    {
        //Console.WriteLine($"{row} {col}");
        if (!visited.Contains(row.ToString() + col.ToString()))
        {
            visited.Add(row.ToString() + col.ToString());
            if (row == endRow && col == endCol)
                end = true;

            SearchRight(row, col, dir);
            SearchLeft(row, col, dir);
            SearchDown(row, col, dir);
            SearchUp(row, col, dir);
        }

        return count;
    }

    public static void SearchRight(int row, int col, char dir)
    {
        if (end == true)
            return;
        if (col + 1 < grid[0].Count)
            if ((dir != 'L') && ((grid[row][col] + 1 == grid[row][col + 1]) || (grid[row][col] == grid[row][col + 1])))
            {
                count++;
                FindShortestPath(row, col + 1, 'R');
            }
    }

    public static void SearchLeft(int row, int col, char dir)
    {
        if (end == true)
            return;
        if (col - 1 >= 0)
            if ((dir != 'R') && ((grid[row][col] + 1 == grid[row][col - 1]) || (grid[row][col] == grid[row][col - 1])))
            {
                count++;
                FindShortestPath(row, col - 1, 'L');
            }
    }

    public static void SearchDown(int row, int col, char dir)
    {
        if (end == true)
            return;
        if (row + 1 < grid.Count)
            if ((dir != 'U') && ((grid[row][col] + 1 == grid[row + 1][col]) || (grid[row][col] == grid[row + 1][col])))
            {
                count++;
                FindShortestPath(row + 1, col, 'D');
            }
    }

    public static void SearchUp(int row, int col, char dir)
    {
        if (end == true)
            return;
        if (row - 1 >= 0)
            if ((dir != 'D') && ((grid[row][col] + 1 == grid[row - 1][col]) || (grid[row][col] == grid[row - 1][col])))
            {
                count++;
                FindShortestPath(row - 1, col, 'U');
            }
    }
}

