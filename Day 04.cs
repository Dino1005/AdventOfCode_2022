using System.Globalization;

var reader = new StreamReader(@"C:\\Users\\radon\\Desktop\\input.txt");
int count = 0;
string line = reader.ReadLine();

//while (line != null)
//{
//    string[] numbers = line.Split(",");
//    string[] prvi = numbers[0].Split("-");
//    string[] drugi = numbers[1].Split("-");
//    if ((int.Parse(prvi[0]) >= int.Parse(drugi[0])) && (int.Parse(prvi[1]) <= int.Parse(drugi[1])))
//        count++;
//    else if ((int.Parse(drugi[0]) >= int.Parse(prvi[0])) && (int.Parse(drugi[1]) <= int.Parse(prvi[1])))
//        count++;
//    line = reader.ReadLine();
//}

while (line != null)
{
    string[] numbers = line.Split(",");
    string[] prvi = numbers[0].Split("-");
    string[] drugi = numbers[1].Split("-");
    if ((int.Parse(prvi[0]) <= int.Parse(drugi[0])) && (int.Parse(prvi[1]) >= int.Parse(drugi[0])))
        count++;
    else if ((int.Parse(prvi[0]) <= int.Parse(drugi[1])) && (int.Parse(prvi[1]) >= int.Parse(drugi[1])))
        count++;
    else if ((int.Parse(drugi[0]) <= int.Parse(prvi[1])) && (int.Parse(drugi[1]) >= int.Parse(prvi[1])))
        count++;
    else if ((int.Parse(drugi[0]) <= int.Parse(prvi[1])) && (int.Parse(drugi[1]) >= int.Parse(prvi[1])))
        count++;
    line = reader.ReadLine();
}
Console.WriteLine(count);

