string[] input = File.ReadAllLines("19.txt");

public class BluePrint
{
    public int id;
    public int oreRobotCost;
    public int clayRobotCost;
    public int obsidianRobotOreCost;
    public int obsidianRobotClayCost;
    public int geodeRobotOreCost;
    public int geodeRobotObsidianCost;
    public List<int> geodesExtracted;

    public BluePrint(int id, int oreRobotCost, int clayRobotCost, int obsidianRobotOreCost, int obsidianRobotClayCost, int geodeRobotOreCost, int geodeRobotObsidianCost)
    {
        this.id = id;
        this.oreRobotCost = oreRobotCost;
        this.clayRobotCost = clayRobotCost;
        this.obsidianRobotOreCost = obsidianRobotOreCost;
        this.obsidianRobotClayCost = obsidianRobotClayCost;
        this.geodeRobotOreCost = geodeRobotOreCost;
        this.geodeRobotObsidianCost = geodeRobotObsidianCost;
        this.geodesExtracted = new List<int>();
    }
}

List<BluePrint> allBlueprints = new List<BluePrint>();

for (int i = 0; i < input.Length; i++)
{
    int blueprintID = Convert.ToInt32(input[i].Split(": ")[0].Split(" ")[1]);
    int oreRobotCost = Convert.ToInt32(input[i].Split("ore robot costs ")[1].Split(" ore")[0]);
    int clayRobotCost = Convert.ToInt32(input[i].Split("clay robot costs ")[1].Split(" ore")[0]);
    int obsidianRobotOreCost = Convert.ToInt32(input[i].Split("obsidian robot costs ")[1].Split("ore")[0]);
    int obsidianRobotClayCost = Convert.ToInt32(input[i].Split("obsidian robot costs ")[1].Split("ore and ")[1].Split(" clay")[0]);
    int geodeRobotOreCost = Convert.ToInt32(input[i].Split("geode robot costs ")[1].Split("ore")[0]);
    int geodeRobotObsidianCost = Convert.ToInt32(input[i].Split("geode robot costs ")[1].Split("ore and ")[1].Split(" obsidian")[0]);

    BluePrint newBlueprint = new BluePrint(blueprintID, oreRobotCost, clayRobotCost, obsidianRobotOreCost, obsidianRobotClayCost, geodeRobotOreCost, geodeRobotObsidianCost);
    allBlueprints.Add(newBlueprint);
}

public void extract(int timeRemaining, int ore, int clay, int obsidian, int geode, BluePrint blueprint, int oreRobots, int clayRobots, int obsidianRobots, int geodeRobots)
{
    if (timeRemaining == 0)
    {
        blueprint.geodesExtracted.Add(geode);
    }
    else
    {
        timeRemaining--;

        //Make geode robot
        if (obsidian >= blueprint.geodeRobotObsidianCost && ore >= blueprint.geodeRobotOreCost && timeRemaining > 0)
        {
            extract(timeRemaining, ore - blueprint.geodeRobotOreCost + oreRobots, clay + clayRobots, obsidian - blueprint.geodeRobotObsidianCost + obsidianRobots,
             geode + geodeRobots, blueprint, oreRobots, clayRobots, obsidianRobots, geodeRobots + 1);
        }
        //Make obsidian robot
        if (clay >= blueprint.obsidianRobotClayCost && ore >= blueprint.obsidianRobotOreCost && obsidianRobots < blueprint.geodeRobotObsidianCost && timeRemaining > 1)
        {
            extract(timeRemaining, ore - blueprint.obsidianRobotOreCost + oreRobots, clay - blueprint.obsidianRobotClayCost + clayRobots, obsidian + obsidianRobots,
             geode + geodeRobots, blueprint, oreRobots, clayRobots, obsidianRobots + 1, geodeRobots);
        }
        //Make clay robot
        if (ore >= blueprint.clayRobotCost && clayRobots < blueprint.obsidianRobotClayCost && timeRemaining > 1)
        {
            extract(timeRemaining, ore - blueprint.clayRobotCost + oreRobots, clay + clayRobots, obsidian + obsidianRobots,
             geode + geodeRobots, blueprint, oreRobots, clayRobots + 1, obsidianRobots, geodeRobots);
        }
        // Make ore robot
        // if (ore >= blueprint.oreRobotCost && oreRobots < blueprint.clayRobotCost && timeRemaining > 1)
        // {
        //     extract(timeRemaining, ore - blueprint.oreRobotCost + oreRobots, clay + clayRobots, obsidian + obsidianRobots,
        //      geode + geodeRobots, blueprint, oreRobots + 1, clayRobots, obsidianRobots, geodeRobots);
        // }
        // Do nothing
        extract(timeRemaining, ore + oreRobots, clay + clayRobots, obsidian + obsidianRobots,
         geode + geodeRobots, blueprint, oreRobots, clayRobots, obsidianRobots, geodeRobots);

    }
}

const int timeLimit = 24;
int quantityLevel = 0;
foreach (BluePrint blueprint in allBlueprints)
{
    extract(timeLimit, 0, 0, 0, 0, blueprint, 1, 0, 0, 0);
    quantityLevel += (blueprint.id * blueprint.geodesExtracted.Max());
    Internal.Console.WriteLine("Quantity Level: " + quantityLevel + " for blueprint " + blueprint.id);
}
/* part1: 1981 */

const int timeLimit2 = 32;
int quantityLevel2 = 1;
for (int k = 0; k < 3; k++)
{
    extract(timeLimit2, 0, 0, 0, 0, allBlueprints[k], 1, 0, 0, 0);
    quantityLevel2 *= allBlueprints[k].geodesExtracted.Max();
    Internal.Console.WriteLine("Max geode: " + allBlueprints[k].geodesExtracted.Max() + " for blueprint " + allBlueprints[k].id);
}

Internal.Console.WriteLine("Quantity Level: " + quantityLevel2);


