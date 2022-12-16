using System.Drawing;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

var reader = new StreamReader(@"C:\\Users\\radon\\Desktop\\input.txt"); 
string line = reader.ReadLine();

int x = 0, div = 1;
string items = null, operation = null, test = null, lcm = null;
List<Monkey> monkeys = new List<Monkey>();

while (line != null)
{
    for (int i = 0; i < 4; i++)
    {
        string[] temp = line.Split();
        if (i == 1)
        {

            for (int j = 4; j < temp.Length; j++)
            {
                items += temp[j];
            }
        }
        if (i == 2)
        {
            operation += temp[temp.Length - 2] + ',' + temp[temp.Length - 1];
        }
        if (i == 3)
        {
            test += temp[temp.Length - 1];
            lcm += temp[temp.Length - 1] + ',';
            line = reader.ReadLine();
            string[] ifTrue = line.Split();
            test += ',' + ifTrue[ifTrue.Length - 1];
            line = reader.ReadLine();
            string[] ifFalse = line.Split();
            test += ',' + ifFalse[ifFalse.Length - 1];
        }

        line = reader.ReadLine();
    }
    monkeys.Add(new Monkey(items, operation, test));
    items = null;
    operation = null;
    test = null;
    line = reader.ReadLine();
}

foreach (var monkey in monkeys)
{
    div *= int.Parse(monkey.test.Split(",").First());
}

//for (int i = 0; i < 20; i++)
for (int i = 0; i < 10000; i++)
{
    foreach (var monkey in monkeys)
    {
        while(monkey.itemWorryLevel.Count != 0)
        {
            monkey.DoOperation();
            monkey.count++;
            //monkey.itemWorryLevel[0] = monkey.itemWorryLevel[0] / 3;
            monkey.itemWorryLevel[0] = monkey.itemWorryLevel[0] % div;
            x = monkey.Test();
            monkeys[x].itemWorryLevel.Add(Monkey.item);
        }
        
    }
}

Monkey first = monkeys.MaxBy(x => x.count);
monkeys.Remove(first);
Monkey second = monkeys.MaxBy(x => x.count);
Console.WriteLine(first.count * second.count);

public class Monkey
{
    public List<long> itemWorryLevel = new List<long>();
    public string operation;
    public string test;
    public static long item;
    public long count;

    public Monkey(string items, string operation, string test)
    {
        foreach (var item in items.Split(","))
        {
            itemWorryLevel.Add(long.Parse(item));
        }
        this.operation = operation;
        this.test = test;
        count = 0;
    }

    public void DoOperation()
    {
        string[] split = operation.Split(",");
        if (split[0] == "+")
        {
            if (long.TryParse(split[1], out long number))
            {
                itemWorryLevel[0] += number;
            }
            else
                itemWorryLevel[0] += itemWorryLevel[0];
        }
        else
        {
            if (long.TryParse(split[1], out long number))
            {
                itemWorryLevel[0] *= number;
            }
            else
                itemWorryLevel[0] *= itemWorryLevel[0];
        }
    }

    public int Test()
    {
        string[] split = test.Split(",");
        int ifFalse = int.Parse(split[2]);
        int ifTrue = int.Parse(split[1]);

        if (itemWorryLevel[0] % int.Parse(split[0]) == 0)
        {
            item = itemWorryLevel[0];
            itemWorryLevel.RemoveAt(0);
            return ifTrue;
        }
        item = itemWorryLevel[0];
        itemWorryLevel.RemoveAt(0);
        return ifFalse;
    }
}
