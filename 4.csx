var contents = File.ReadAllLines("4.txt");

int totalOverlaps = 0;
int partialOverlaps = 0;

for (int i = 0; i < contents.Length; i++)
{
    var firstPair = contents[i].Split(',')[0];
    var secondPair = contents[i].Split(',')[1];
    var startFP = Convert.ToInt32(firstPair.Split('-')[0]);
    var endFP = Convert.ToInt32(firstPair.Split('-')[1]);
    var startSP = Convert.ToInt32(secondPair.Split('-')[0]);
    var endSP = Convert.ToInt32(secondPair.Split('-')[1]);

    if (startFP <= startSP && endFP >= endSP)
    {
        totalOverlaps += 1;
    }
    else if (startFP >= startSP && endFP <= endSP)
    {
        totalOverlaps += 1;
    }

    if ((startFP <= endSP && startSP <= endFP))
    {
        partialOverlaps += 1;
    }
}
Internal.Console.WriteLine("Total overlaps: " + totalOverlaps);
/* part1: 464 */

Internal.Console.WriteLine("Partial overlaps: " + partialOverlaps);
/* part2: 770 */
