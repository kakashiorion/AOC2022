var contents = File.ReadAllLines("10.txt");

int cycle = 0;
int registerX = 1;

List<int> signalStrengths = new List<int>();
int[] requiredCycles = { 20, 60, 100, 140, 180, 220 };

for (int i = 0; i < contents.Length; i++)
{
    if (contents[i] == "noop")
    {
        cycle++;
        if (requiredCycles.Contains(cycle))
        {
            signalStrengths.Add(registerX * cycle);
        }
        continue;
    }
    else
    {
        cycle++;
        if (requiredCycles.Contains(cycle))
        {
            signalStrengths.Add(registerX * cycle);
        }
        cycle++;
        if (requiredCycles.Contains(cycle))
        {
            signalStrengths.Add(registerX * cycle);
        }
        int value = Convert.ToInt32(contents[i].Split(' ')[1]);
        registerX += value;
    }
}

Internal.Console.WriteLine("Sum of signal strengths: " + signalStrengths.ToArray().Sum().ToString());
/* part1: 11960*/

cycle = 0;
registerX = 1;
int[] changeLineCycles = { 40, 80, 120, 160, 200 };

if (cycle == 40)
{
    Internal.Console.Write("\n");
    cycle = 0;
}
for (int i = 0; i < contents.Length; i++)
{
    if (contents[i] == "noop")
    {
        if (registerX - 1 == cycle || registerX == cycle || registerX + 1 == cycle)
        {
            Internal.Console.Write("#");
        }
        else
        {
            Internal.Console.Write(".");
        }
        cycle++;
        if (cycle == 40)
        {
            Internal.Console.Write("\n");
            cycle = 0;
        }
        continue;
    }
    else
    {
        if (registerX - 1 == cycle || registerX == cycle || registerX + 1 == cycle)
        {
            Internal.Console.Write("#");
        }
        else
        {
            Internal.Console.Write(".");
        }
        cycle++;
        if (cycle == 40)
        {
            Internal.Console.Write("\n");
            cycle = 0;
        }
        if (registerX - 1 == cycle || registerX == cycle || registerX + 1 == cycle)
        {
            Internal.Console.Write("#");
        }
        else
        {
            Internal.Console.Write(".");
        }
        cycle++;
        if (cycle == 40)
        {
            Internal.Console.Write("\n");
            cycle = 0;
        }
        int value = Convert.ToInt32(contents[i].Split(' ')[1]);
        registerX += value;
    }
}
/* part2: EJCFPGLH*/
