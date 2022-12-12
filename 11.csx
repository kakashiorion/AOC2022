string[] contents = File.ReadAllLines("11.txt");
const int lcm = 3 * 5 * 2 * 11 * 7 * 13 * 17 * 19;

//List of all monkeys
static List<Monkey> allMonkeys;

//Setup - Creating monkeys from input file
public void setup()
{
    allMonkeys = new List<Monkey>();
    for (int i = 0; i < contents.Length; i++)
    {
        if (contents[i].Split(' ')[0] == "Monkey")
        {
            i++;
            string items = contents[i].Split(": ")[1];
            Queue<long> newQueue = new Queue<long>();
            foreach (string item in items.Split(", "))
            {
                newQueue.Enqueue(Convert.ToInt64(item));
            }

            i++;
            string op = contents[i].Split("= old ")[1];

            i++;
            int test = Convert.ToInt32(contents[i].Split("by ")[1]);

            i++;
            int trueId = Convert.ToInt32(contents[i].Split("monkey ")[1]);

            i++;
            int falseId = Convert.ToInt32(contents[i].Split("monkey ")[1]);

            Monkey newMonkey = new Monkey(i + 1, newQueue, op, test, trueId, falseId);
            allMonkeys.Add(newMonkey);
            i++;
        }
    }
}

setup();

//Monkey class
public class Monkey
{
    public int id;
    public Queue<long> items;
    public string operation;
    public int divisibleTest;
    public int trueMonkeyId;
    public int falseMonkeyId;
    public int inspectionTimes;
    public Monkey(int id, Queue<long> items, string operation, int divisibleTest, int trueMonkeyId, int falseMonkeyId)
    {
        this.id = id;
        this.items = items;
        this.operation = operation;
        this.divisibleTest = divisibleTest;
        this.trueMonkeyId = trueMonkeyId;
        this.falseMonkeyId = falseMonkeyId;
        this.inspectionTimes = 0;
    }
    long operateItem(long item)
    {
        string opertr = operation.Split(' ')[0];
        long oprnd;
        if (operation.Split(' ')[1] == "old")
        {
            oprnd = item;
        }
        else
        {
            oprnd = Convert.ToInt64(operation.Split(' ')[1]);
        }
        if (opertr == "+")
        {
            return item + oprnd;
        }
        else
        {
            return item * oprnd;
        }
    }
    long operateItem2(long item)
    {
        string opertr = operation.Split(' ')[0];
        long oprnd;
        if (operation.Split(' ')[1] == "old")
        {
            oprnd = item;
        }
        else
        {
            oprnd = Convert.ToInt64(operation.Split(' ')[1]);
        }

        if (opertr == "+")
        {
            return (item + oprnd) % lcm;
        }
        else
        {
            return (item * oprnd) % lcm;
        }
    }
    int checkDivisiblity(long value)
    {
        if (value % divisibleTest == 0)
        {
            return trueMonkeyId;
        }
        else
        {
            return falseMonkeyId;
        }
    }
    long cooldown(long item)
    {
        return item / 3;
    }
    public void monkeyTurn()
    {
        int tempItems = items.Count;
        for (long k = 0; k < tempItems; k++)
        {
            long currentItem = items.Dequeue();
            long newItem = operateItem(currentItem);
            newItem = cooldown(newItem);
            int catchingMonkeyId = checkDivisiblity(newItem);
            Monkey m = allMonkeys[catchingMonkeyId];
            m.items.Enqueue(newItem);
            inspectionTimes++;
        }
    }
    public void monkeyTurn2()
    {
        int tempItems = items.Count;
        for (long k = 0; k < tempItems; k++)
        {
            long currentItem = items.Dequeue();
            long newItem = operateItem2(currentItem);
            int catchingMonkeyId = checkDivisiblity(newItem);
            Monkey m = allMonkeys[catchingMonkeyId];
            m.items.Enqueue(newItem);
            inspectionTimes++;
        }
    }
}

public void monkeyRound()
{
    foreach (Monkey m in allMonkeys)
    {
        m.monkeyTurn();
    }
}

for (long j = 0; j < 20; j++)
{
    monkeyRound();
}

List<long> iTimes = new List<long>();
foreach (Monkey m in allMonkeys)
{
    iTimes.Add(m.inspectionTimes);
    // Internal.Console.WriteLine(m.inspectionTimes.ToString());
}
iTimes.Sort();
Internal.Console.WriteLine("business: " + iTimes[^1] * iTimes[^2]);
/* part1: 58056*/

setup();

public void monkeyRound2()
{
    foreach (Monkey m in allMonkeys)
    {
        m.monkeyTurn2();
    }
}

for (long j = 0; j < 10000; j++)
{
    monkeyRound2();
}
iTimes = new List<long>();
foreach (Monkey m in allMonkeys)
{
    iTimes.Add(m.inspectionTimes);
    // Internal.Console.WriteLine(m.inspectionTimes.ToString());
}
iTimes.Sort();
Internal.Console.WriteLine("business: " + iTimes[^1] * iTimes[^2]);
/* part2: 15048718170*/
