var reader = new StreamReader(@"C:\\Users\\radon\\Desktop\\input.txt");
string line = reader.ReadLine();

int rows = 0, score = 0, current;
int visible = line.Length * 4 - 4;
Tree.forest = new char[line.Length][];
while (line != null)
{
	char[] row = line.ToArray();
	Tree.forest[rows] = row;
    line = reader.ReadLine();
	rows++;
}

for (int i = 1; i < Tree.forest.Length - 1; i++)
{
	for (int j = 1; j < Tree.forest[i].Length - 1; j++)
	{
        if (Tree.SearchRight(i, j, i, j) || Tree.SearchLeft(i, j, i, j) || Tree.SearchUp(i, j, i, j) || Tree.SearchDown(i, j, i, j))
            visible++;
        current = Tree.GetRightScore(i, j, i, j) * Tree.GetLeftScore(i, j, i, j) * Tree.GetUpScore(i, j, i, j) * Tree.GetDownScore(i, j, i, j);
        if (current > score)
            score = current;
    }
}
Console.WriteLine(visible);
Console.WriteLine(score);

static class Tree
{
    public static char[][] forest;
    public static bool SearchRight(int row, int col, int i, int j)
	{
        if (j < (forest.Length - 1))
        {
            if (forest[i][j + 1] < forest[row][col])
                return true & SearchRight(row, col, i, j + 1);
            else
                return false;
        }
        else
            return true;
    }

    public static bool SearchLeft(int row, int col, int i, int j)
    {
        if (j > 0)
        {
            if (forest[i][j - 1] < forest[row][col])
                return true & SearchLeft(row, col, i, j - 1);
            else
                return false;
        }
        else
            return true;
    }

    public static bool SearchUp(int row, int col, int i, int j)
    {
        if (i > 0)
        {
            if (forest[i - 1][j] < forest[row][col])
                return true & SearchUp(row, col, i - 1, j);
            else
                return false;
        }
        else
            return true;
    }

    public static bool SearchDown(int row, int col, int i, int j)
    {
        if (i < (forest.Length - 1))
        {
            if (forest[i + 1][j] < forest[row][col])
                return true & SearchDown(row, col, i + 1, j);
            else
                return false;
        }
        else
            return true;
    }

    public static int GetRightScore(int row, int col, int i, int j)
    {
        if (j < (forest.Length - 1))
        {
            if (forest[i][j + 1] < forest[row][col])
                return 1 + GetRightScore(row, col, i, j + 1);
            else
                return 1;
        }
        else
            return 0;
    }

    public static int GetLeftScore(int row, int col, int i, int j)
    {
        if (j > 0)
        {
            if (forest[i][j - 1] < forest[row][col])
                return 1 + GetLeftScore(row, col, i, j - 1);
            else
                return 1;
        }
        else
            return 0;
    }

    public static int GetUpScore(int row, int col, int i, int j)
    {
        if (i > 0)
        {
            if (forest[i - 1][j] < forest[row][col])
                return 1 + GetUpScore(row, col, i - 1, j);
            else
                return 1;
        }
        else
            return 0;
    }

    public static int GetDownScore(int row, int col, int i, int j)
    {
        if (i < (forest.Length - 1))
        {
            if (forest[i + 1][j] < forest[row][col])
                return 1 + GetDownScore(row, col, i + 1, j);
            else
                return 1;
        }
        else
            return 0;
    }
}

