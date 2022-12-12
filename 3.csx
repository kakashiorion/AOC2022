var contents = File.ReadAllLines("3.txt");

int total = 0;
for (int i = 0; i < contents.Length; i++)
{
    var rucksack = contents[i];
    var len = rucksack.Length;
    for (int j = 0; j < len / 2; j++)
    {
        if (rucksack.Substring(len / 2).Contains(rucksack[j]))
        {
            total += getValue(rucksack[j]);
            break;
        }
    }
}
Internal.Console.WriteLine("Anomalies score: " + total);
/* part 1: 7997 */

int newTotal = 0;
for (int i = 0; i < contents.Length; i = i + 3)
{
    var rucksack = contents[i];
    var len = rucksack.Length;
    for (int j = 0; j < len; j++)
    {
        if (contents[i + 1].Contains(rucksack[j]) && contents[i + 2].Contains(rucksack[j]))
        {
            newTotal += getValue(rucksack[j]);
            break;
        }
    }
}
Internal.Console.WriteLine("Anomalies score: " + newTotal);
/* part 2: 2545 */

static int getValue(char c)
{
    int ascii = Convert.ToInt32(c);
    if (c.ToString().ToUpper() == c.ToString())
    {
        return ascii - 38;
    }
    else
    {
        return ascii - 96;
    }
}