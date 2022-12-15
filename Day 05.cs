using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

var reader = new StreamReader(@"C:\\Users\\radon\\Desktop\\input.txt");
string line = reader.ReadLine();
List<char> temporary = new List<char>();
List<List<char>> col = new List<List<char>>() 
{ 
    new List<char>(),
    new List<char>(),
    new List<char>(),
    new List<char>(),
    new List<char>(),
    new List<char>(),
    new List<char>(),
    new List<char>(),
    new List<char>(),
};

while (line != "")
{
    for (int i = 0; i < 35; i++)
    {
        if (line[i] >= 'A' && line[i] <= 'Z')
        {
            switch (i)
            {
                case 1: col[0].Add(line[i]); break;
                case 5: col[1].Add(line[i]); break;
                case 9: col[2].Add(line[i]); break;
                case 13: col[3].Add(line[i]); break;
                case 17: col[4].Add(line[i]); break;
                case 21: col[5].Add(line[i]); break;
                case 25: col[6].Add(line[i]); break;
                case 29: col[7].Add(line[i]); break;
                case 33: col[8].Add(line[i]); break;
            }
        }
    }
    Console.WriteLine(line);
    line = reader.ReadLine();
}

line = reader.ReadLine();
while (line != null)
{
    line = line.Replace("move ", "");
    line = line.Replace("from ", "");
    line = line.Replace("to ", "");
    string[] numbers = line.Split(" ");

    //for (int i = 0; i < int.Parse(numbers[0]); i++)
    //{
    //    char temp = col[int.Parse(numbers[1]) - 1].First();
    //    col[int.Parse(numbers[2]) - 1].Insert(0, temp);
    //    col[int.Parse(numbers[1]) - 1].Remove(temp);
    //}

    for (int i = 0; i < int.Parse(numbers[0]); i++)
    {
        temporary.Add(col[int.Parse(numbers[1]) - 1].First());
        col[int.Parse(numbers[1]) - 1].Remove(col[int.Parse(numbers[1]) - 1].First());
    }
    for (int i = 0; i < int.Parse(numbers[0]); i++)
    {
        col[int.Parse(numbers[2]) - 1].Insert(0, temporary.Last());
        temporary.RemoveAt(temporary.Count - 1);
    }
    line = reader.ReadLine();
}
foreach (var c in col)
{
    Console.Write(c.First());
}