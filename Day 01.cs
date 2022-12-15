var reader = new StreamReader(@"C:\\Users\\radon\\Desktop\\input.txt");
string line;
List<int> elfs = new List<int>();
int i = 0, number, sum = 0;

do
{
    elfs.Add(0);
    line = reader.ReadLine();
    while (int.TryParse(line, out number))
    {
        elfs[i] += int.Parse(line);
        line = reader.ReadLine();
    }
    i++;
} while (line != null);

for (i = 0; i < 3; i++)
{
    sum += elfs.Max();
    elfs.Remove(elfs.Max());
}
Console.WriteLine(sum);