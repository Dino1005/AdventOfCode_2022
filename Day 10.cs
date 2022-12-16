var reader = new StreamReader(@"C:\\Users\\radon\\Desktop\\input.txt");
string line = reader.ReadLine();

int cycle = 0, x = 1;

//int sum = 0;
//while(line != null)
//{
//    string[] split = line.Split();
//    if (split[0] == "addx")
//    {
//        for (int i = 0; i < 2; i++)
//        {
//            cycle++;
//            if ((cycle == 20) || (cycle == 60) || (cycle == 100) || (cycle == 140) || (cycle == 180) || (cycle == 220))
//                sum += x * cycle;
//        }
//        x += int.Parse(split[1]);
//    }
//    else
//    {
//        cycle++;
//        if ((cycle == 20) || (cycle == 60) || (cycle == 100) || (cycle == 140) || (cycle == 180) || (cycle == 220))
//            sum += x * cycle;
//    }
//    line = reader.ReadLine();
//}
//Console.WriteLine(sum);

while (line != null)
{
    string[] split = line.Split();
    if (split[0] == "addx")
    {
        for (int i = 0; i < 2; i++)
        {
            cycle++;
            if (cycle == 41)
            {
                Console.Write('\n');
                cycle = 1;
            }
            if ((cycle - 1 == x - 1) || (cycle - 1 == x) || (cycle - 1 == x + 1))
                Console.Write('#');
            else
                Console.Write('.');
        }
        x += int.Parse(split[1]);
    }
    else
    {
        cycle++;
        if (cycle == 41)
        {
            Console.Write('\n');
            cycle = 1;
        }
        if (cycle - 1 == x - 1 || cycle - 1 == x || cycle - 1 == x + 1)
            Console.Write('#');
        else
            Console.Write('.');
    }
    line = reader.ReadLine();
}