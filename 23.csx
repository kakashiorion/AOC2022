string[] input = File.ReadAllLines("23.txt");

char[,] map = new char[249, 249];

public void drawMap()
{
    for (int i = 0; i < 89; i++)
    {
        for (int j = 0; j < 249; j++)
        {
            map[i, j] = '.';
        }
    }
    for (int i = 89; i < 160; i++)
    {
        for (int j = 0; j < 89; j++)
        {
            map[i, j] = '.';
        }
        for (int j = 89; j < 160; j++)
        {
            map[i, j] = input[i - 89][j - 89];
        }
        for (int j = 160; j < 249; j++)
        {
            map[i, j] = '.';
        }
    }
    for (int i = 160; i < 249; i++)
    {
        for (int j = 0; j < 249; j++)
        {
            map[i, j] = '.';
        }
    }
}

drawMap();

Dictionary<string, List<char>> proposalMap = new Dictionary<string, List<char>>();

public void propose(int x, int y, char direction)
{
    if (proposalMap.ContainsKey(x.ToString() + "," + y.ToString()))
    {
        proposalMap[x.ToString() + "," + y.ToString()].Add(direction);
    }
    else
    {
        proposalMap[x.ToString() + "," + y.ToString()] = new List<char>();
        proposalMap[x.ToString() + "," + y.ToString()].Add(direction);
    }
}

public bool elfInNoDirections(int x, int y)
{
    if (map[x - 1, y] == '.' && map[x - 1, y - 1] == '.' && map[x - 1, y + 1] == '.'
    && map[x + 1, y] == '.' && map[x + 1, y - 1] == '.' && map[x + 1, y + 1] == '.'
    && map[x, y - 1] == '.' && map[x, y + 1] == '.')
    {
        return true;
    }
    return false;
}

public bool noElfInNorth(int x, int y)
{
    if (map[x - 1, y] == '#' || map[x - 1, y - 1] == '#' || map[x - 1, y + 1] == '#')
    {
        return false;
    }
    return true;
}

public bool noElfInSouth(int x, int y)
{
    if (map[x + 1, y] == '#' || map[x + 1, y - 1] == '#' || map[x + 1, y + 1] == '#')
    {
        return false;
    }
    return true;
}

public bool noElfInEast(int x, int y)
{
    if (map[x - 1, y + 1] == '#' || map[x, y + 1] == '#' || map[x + 1, y + 1] == '#')
    {
        return false;
    }
    return true;
}

public bool noElfInWest(int x, int y)
{
    if (map[x - 1, y - 1] == '#' || map[x, y - 1] == '#' || map[x + 1, y - 1] == '#')
    {
        return false;
    }
    return true;
}

public int round(int roundNumber)
{
    //First half of the round
    for (int i = 0; i < 249; i++)
    {
        for (int j = 0; j < 249; j++)
        {
            if (map[i, j] == '#')
            {
                //No nearby elf.. skip
                if (elfInNoDirections(i, j))
                {
                    continue;
                }
                //Else, propose a move
                else
                {
                    if (roundNumber % 4 == 0)
                    {
                        if (noElfInNorth(i, j))
                        {
                            propose(i - 1, j, 'N');
                        }
                        else if (noElfInSouth(i, j))
                        {
                            propose(i + 1, j, 'S');
                        }
                        else if (noElfInWest(i, j))
                        {
                            propose(i, j - 1, 'W');
                        }
                        else if (noElfInEast(i, j))
                        {
                            propose(i, j + 1, 'E');
                        }
                    }
                    else if (roundNumber % 4 == 1)
                    {
                        if (noElfInSouth(i, j))
                        {
                            propose(i + 1, j, 'S');
                        }
                        else if (noElfInWest(i, j))
                        {
                            propose(i, j - 1, 'W');
                        }
                        else if (noElfInEast(i, j))
                        {
                            propose(i, j + 1, 'E');
                        }
                        else if (noElfInNorth(i, j))
                        {
                            propose(i - 1, j, 'N');
                        }
                    }
                    else if (roundNumber % 4 == 2)
                    {
                        if (noElfInWest(i, j))
                        {
                            propose(i, j - 1, 'W');
                        }
                        else if (noElfInEast(i, j))
                        {
                            propose(i, j + 1, 'E');
                        }
                        else if (noElfInNorth(i, j))
                        {
                            propose(i - 1, j, 'N');
                        }
                        else if (noElfInSouth(i, j))
                        {
                            propose(i + 1, j, 'S');
                        }
                    }
                    else if (roundNumber % 4 == 3)
                    {
                        if (noElfInEast(i, j))
                        {
                            propose(i, j + 1, 'E');
                        }
                        else if (noElfInNorth(i, j))
                        {
                            propose(i - 1, j, 'N');
                        }
                        else if (noElfInSouth(i, j))
                        {
                            propose(i + 1, j, 'S');
                        }
                        else if (noElfInWest(i, j))
                        {
                            propose(i, j - 1, 'W');
                        }
                    }
                }
            }
        }
    }
    //Second half of the round.. move single proposal elfs
    int movingElves = 0;
    foreach (string movingBlock in proposalMap.Keys)
    {
        if (proposalMap[movingBlock].Count == 1)
        {
            int x = Convert.ToInt32(movingBlock.Split(',')[0]);
            int y = Convert.ToInt32(movingBlock.Split(',')[1]);
            map[x, y] = '#';
            movingElves++;
            if (proposalMap[movingBlock][0] == 'N')
            {
                map[x + 1, y] = '.';
            }
            else if (proposalMap[movingBlock][0] == 'S')
            {
                map[x - 1, y] = '.';
            }
            else if (proposalMap[movingBlock][0] == 'E')
            {
                map[x, y - 1] = '.';
            }
            else if (proposalMap[movingBlock][0] == 'W')
            {
                map[x, y + 1] = '.';
            }
        }
    }
    //Clear proposals for next round
    proposalMap.Clear();
    return movingElves;
}

public int countEmptyTiles()
{
    int lowX = 248;
    int highX = 0;
    int lowY = 248;
    int highY = 0;
    for (int i = 0; i < 249; i++)
    {
        for (int j = 0; j < 249; j++)
        {
            if (map[i, j] == '#')
            {
                if (i > highX)
                {
                    highX = i;
                }
                if (i < lowX)
                {
                    lowX = i;
                }
                if (j < lowY)
                {
                    lowY = j;
                }
                if (j > highY)
                {
                    highY = j;
                }
            }
        }
    }
    int emptyCount = 0;
    for (int i = lowX; i <= highX; i++)
    {
        for (int j = lowY; j <= highY; j++)
        {
            if (map[i, j] == '.')
            {
                emptyCount++;
            }
        }
    }
    return emptyCount;
}

public int countElves()
{
    int elves = 0;
    for (int i = 0; i < 249; i++)
    {
        for (int j = 0; j < 249; j++)
        {
            if (map[i, j] == '#')
            {
                elves++;
            }
        }
    }
    return elves;
}

public void part1()
{
    int movingElves = 0;
    for (int k = 0; k < 10; k++)
    {
        movingElves = round(k);
    }
    Internal.Console.WriteLine("Empty tiles: " + countEmptyTiles().ToString());
}

part1();
/* part1: 3970 */

public void part2()
{
    int movingElves = 1;
    int roundNumber = 0;
    do
    {
        movingElves = round(roundNumber);
        roundNumber++;
    } while (movingElves > 0);
    Internal.Console.WriteLine("No moving round: " + roundNumber);
}

drawMap();
part2();
/* part2: 923 */
