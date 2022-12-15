using System.Globalization;

var reader = new StreamReader(@"C:\\Users\\radon\\Desktop\\input.txt");
int priority = 0;
string prvi = reader.ReadLine();
bool stop1 = false, stop2 = false;

//while (line != null)
//{
//    string prvi = line.Substring(0, line.Length / 2);
//    string drugi = line.Substring(line.Length / 2);
//    for (int i = 0; i < prvi.Length; i++)
//    {
//        for (int j = 0; j < drugi.Length; j++)
//        {
//            if (prvi[i] == drugi[j])
//            {
//                if (Char.IsUpper(prvi[i]))
//                    priority += (int)prvi[i] - 38;
//                else
//                    priority += (int)prvi[i] - 96;
//                stop = true;
//                break;
//            }
//        }
//        if (stop == true)
//        {
//            stop = false;
//            break;
//        }
//    }
//    line = reader.ReadLine();
//}

while (prvi != null)
{
    string drugi = reader.ReadLine();
    string treci = reader.ReadLine();
    for (int i = 0; i < prvi.Length; i++)
    {
        for (int j = 0; j < drugi.Length; j++)
        {
            if (prvi[i] == drugi[j])
            {
                for (int k = 0; k < treci.Length; k++)
                {
                    if (drugi[j] == treci[k])
                    {
                        if (Char.IsUpper(prvi[i]))
                            priority += (int)prvi[i] - 38;
                        else
                            priority += (int)prvi[i] - 96;
                        stop1 = true;
                        stop2 = true;
                        break;
                    }
                }
                if (stop2 == true)
                {
                    stop2 = false;
                    break;
                }
            }
        }
        if (stop1 == true)
        {
            stop1 = false;
            break;
        }
    }
    prvi = reader.ReadLine();
}
Console.WriteLine(priority);


