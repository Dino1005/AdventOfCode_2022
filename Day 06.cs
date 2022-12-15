var reader = new StreamReader(@"C:\\Users\\radon\\Desktop\\input.txt");
int counter = 14;
List<char> list = new List<char>
{
    (char)reader.Read(),
    (char)reader.Read(),
    (char)reader.Read(),
    (char)reader.Read(),
    (char)reader.Read(),
    (char)reader.Read(),
    (char)reader.Read(),
    (char)reader.Read(),
    (char)reader.Read(),
    (char)reader.Read(),
    (char)reader.Read(),
    (char)reader.Read(),
    (char)reader.Read(),
    (char)reader.Read()
};

char x = (char)reader.Read();
while (x >= 'a' && x <= 'z')
{
    List<char> temp = list.Distinct().ToList();
    if (temp.Count == 14)
    {
        break;
    }
    list.RemoveAt(0);
    list.Add(x);
    counter++;
    x = (char)reader.Read();
}
Console.WriteLine(counter);