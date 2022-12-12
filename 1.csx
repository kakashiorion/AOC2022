List<int> elfCalories = new List<int>();
int newElfCal = 0;
var contents = File.ReadAllLines("1.txt");

for (int i = 0; i < contents.Length; i++)
{
    if (contents[i] == "")
    {
        elfCalories.Add(newElfCal);
        newElfCal = 0;
    }
    else
    {
        int newNumber = Convert.ToInt32(contents[i]);
        newElfCal = newElfCal + newNumber;
        // Internal.Console.WriteLine(newElfCal.ToString());
    }
}

var anArray = elfCalories.ToArray();
Array.Sort(anArray);

var largestValue = anArray[anArray.Length - 1];
Internal.Console.WriteLine(largestValue.ToString());
/* part1: 69693 */

var sumValue = anArray[anArray.Length - 1] + anArray[anArray.Length - 2] + anArray[anArray.Length - 3];
Internal.Console.WriteLine(sumValue.ToString());
/* part2: 200945 */