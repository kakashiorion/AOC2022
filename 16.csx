string[] contents = File.ReadAllLines("16.txt");

class Valve
{
    public string name;
    public int flowRate;
    public string[] accessibleValves;
    public bool isOpen;
    public int pressureReleased;
    public int depth;
    public Valve(string name, string[] accessibleValves, int flowRate)
    {
        this.name = name;
        this.accessibleValves = accessibleValves;
        this.flowRate = flowRate;
        this.isOpen = false;
        this.pressureReleased = 0;
        this.depth = 999;
    }
    public void openValve(int timeRemaining)
    {
        isOpen = true;
        pressureReleased = flowRate * timeRemaining;
    }
}

List<Valve> allValves = new List<Valve>();
for (int i = 0; i < contents.Length; i++)
{
    string name = contents[i].Substring(6, 2);
    int flowRate = Convert.ToInt32(contents[i].Split(';')[0].Substring(23));
    string[] accessibleValves = contents[i].Split("valves ")[1].Split(", ");
    Valve newvalve = new Valve(name, accessibleValves, flowRate);
    allValves.Add(newvalve);
}

int a = 20 * 21 + 25 * 17 + 23 * 13 + 24 * 5;

class WeightedValve
{
    public string name;
    public int flowRate;
    public WeightedValve[] accessibleValves;

}



// public void exploreValve(string valveName, int currentDepth)
// {
//     Valve v = allValves.Find(x => x.name == valveName);
//     foreach (string aV in v.accessibleValves)
//     {
//         Valve v2 = allValves.Find(x => x.name == aV);
//         if (v2.depth > currentDepth + 1)
//         {
//             v2.depth = currentDepth + 1;
//             exploreValve(aV, currentDepth + 1);
//         }
//     }
// }

// exploreValve("AA", 0);

// allValves.Sort((x, y) => x.flowRate > y.flowRate ? 0 : 1);

// foreach (Valve v in allValves)
// {
//     Internal.Console.WriteLine(v.name + " " + v.flowRate + " " + v.depth);
// }

// const string initialValve = "AA";
// const int initialTimeRemaining = 30;
// Dictionary<string, int> allPressureReleased = new Dictionary<string, int>();
// // allPressureReleased.Add("AA", 0);

// exploreValve(initialValve, initialTimeRemaining, 0);

// public void exploreValve(string currentValve, int timeRemaining, int totalPressureReleased)
// {
//     Valve v = allValves.Find(x => x.name == currentValve);

//     //If time has expired, do not pursue further
//     if (timeRemaining <= 0)
//     {
//         return;
//     }

//     //have not visited yet - pursue further
//     if (!allPressureReleased.ContainsKey(currentValve))
//     {
//         allPressureReleased.Add(currentValve, totalPressureReleased);
//     }
//     //already visited with lesser value - pursue further
//     else
//     if (allPressureReleased[currentValve] < totalPressureReleased)
//     {
//         allPressureReleased[currentValve] = totalPressureReleased;
//     }
//     //already visited with greater value - do not pursue further
//     else
//     {
//         return;
//     }

//     //If valve has not been opened
//     if (v.flowRate > 0)
//     {
//         foreach (string aV in v.accessibleValves)
//         {
//             //Open valve and pursue further
//             // v.openValve(timeRemaining - 1);
//             exploreValve(aV, timeRemaining - 2, totalPressureReleased + (v.flowRate * (timeRemaining - 1)));

//             //Keep valve closed and pursue further
//             exploreValve(aV, timeRemaining - 1, totalPressureReleased);
//         }
//     }
//     else if (v.flowRate == 0)
//     {
//         foreach (string aV in v.accessibleValves)
//         {
//             exploreValve(aV, timeRemaining - 1, totalPressureReleased);
//         }
//     }
// }

// Internal.Console.WriteLine("Max pressure released: " + allPressureReleased.Values.Max().ToString());

// while (timeRemaining > 0)
// {
//     Valve v = allValves.Find(x => x.name == currentValve);
//     if (v.flowRate > 0)
//     {
//         timeRemaining--;
//         v.openValve(timeRemaining);
//     }
//     int largestValveFlow = 0;
//     string largestValveName = v.accessibleValves[0];
//     foreach (string aV in v.accessibleValves)
//     {
//         Valve v2 = allValves.Find(x => x.name == aV);
//         if (v2.flowRate > largestValveFlow)
//         {
//             largestValveFlow = v2.flowRate;
//             largestValveName = aV;
//         }
//     }
//     Valve nextValve = allValves.Find(x => x.name == largestValveName);
//     timeRemaining--;
//     currentValve = nextValve.name;
// }

// int totalPressureReleased = 0;
// foreach (Valve v in allValves)
// {
//     totalPressureReleased += v.pressureReleased;
// }

// Internal.Console.WriteLine("Pressure: " + totalPressureReleased);