var reader = new StreamReader(@"C:\\Users\\radon\\Desktop\\input.txt");
int i = 0, points = 0;
string line = reader.ReadLine();

//while (line != null)
//{
//    if(line.First() == 'A')
//    {
//        if (line.Last() == 'X')
//            points += 4;
//        else if (line.Last() == 'Y')
//            points += 8;
//        else if (line.Last() == 'Z')
//            points += 3;
//    }

//    else if (line.First() == 'B')
//    {
//        if (line.Last() == 'X')
//            points += 1;
//        else if (line.Last() == 'Y')
//            points += 5;
//        else if (line.Last() == 'Z')
//            points += 9;
//    }

//    else if (line.First() == 'C')
//    {
//        if (line.Last() == 'X')
//            points += 7;
//        else if (line.Last() == 'Y')
//            points += 2;
//        else if (line.Last() == 'Z')
//            points += 6;
//    }
//    line = reader.ReadLine();
//}

while (line != null)
{
    if (line.First() == 'A')
    {
        if (line.Last() == 'X')
            points += 3;
        else if (line.Last() == 'Y')
            points += 4;
        else if (line.Last() == 'Z')
            points += 8;
    }

    else if (line.First() == 'B')
    {
        if (line.Last() == 'X')
            points += 1;
        else if (line.Last() == 'Y')
            points += 5;
        else if (line.Last() == 'Z')
            points += 9;
    }

    else if (line.First() == 'C')
    {
        if (line.Last() == 'X')
            points += 2;
        else if (line.Last() == 'Y')
            points += 6;
        else if (line.Last() == 'Z')
            points += 7;
    }
    line = reader.ReadLine();
}
Console.WriteLine(points);