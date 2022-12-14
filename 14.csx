string[] contents = File.ReadAllLines("14.txt");

// int caveDepth = 0;
// int caveWidth = 0;

// for (int i = 0; i < contents.Length; i++)
// {
//     string[] coords = contents[i].Split(" -> ");
//     foreach (string c in coords)
//     {
//         var x = Convert.ToInt32(c.Split(',')[0]);
//         var y = Convert.ToInt32(c.Split(',')[1]);
//         if (x > caveWidth)
//         {
//             caveWidth = x;
//         }
//         if (y > caveDepth)
//         {
//             caveDepth = y;
//         }
//     }
// }
// Internal.Console.WriteLine("depth:" + caveDepth + " width:" + caveWidth);

const int maxCaveDepth = 158;
const int maxCaveWidth = 506;
char[,] cave = new char[maxCaveDepth + 3, maxCaveWidth + maxCaveDepth + 1];
const int sourceX = 500;
const int sourceY = 0;

public void drawHorizontal(int y, int x1, int x2)
{
    for (int i = x1; x1 < x2 ? i <= x2 : i >= x2; i = x1 < x2 ? i + 1 : i - 1)
    {
        cave[y, i] = '#';
    }
}

public void drawVertical(int x, int y1, int y2)
{
    for (int j = y1; y1 < y2 ? j <= y2 : j >= y2; j = y1 < y2 ? j + 1 : j - 1)
    {
        cave[j, x] = '#';
    }
}

public void drawCave()
{
    for (int i = 0; i < maxCaveWidth + maxCaveDepth + 1; i++)
    {
        for (int j = 0; j < maxCaveDepth + 3; j++)
        {
            cave[j, i] = '.';
            if (j == maxCaveDepth + 2)
            {
                cave[j, i] = '#';
            }
        }
    }

    for (int i = 0; i < contents.Length; i++)
    {
        string[] coords = contents[i].Split(" -> ");
        for (int j = 0; j < coords.Length - 1; j++)
        {
            int x1 = Convert.ToInt32(coords[j].Split(',')[0]);
            int y1 = Convert.ToInt32(coords[j].Split(',')[1]);
            int x2 = Convert.ToInt32(coords[j + 1].Split(',')[0]);
            int y2 = Convert.ToInt32(coords[j + 1].Split(',')[1]);
            if (x1 == x2)
            {
                drawVertical(x1, y1, y2);
            }
            else
            {
                drawHorizontal(y1, x1, x2);
            }
        }
    }
}

public int[] dropSand()
{
    bool comeToRest = false;
    int currentX = sourceX;
    int currentY = sourceY;
    while (!comeToRest)
    {
        if (currentY > maxCaveDepth)
        {
            int[] abyss = { currentX, currentY };
            return abyss;
        }
        else if (cave[currentY + 1, currentX] != '#' && cave[currentY + 1, currentX] != 'o')
        {
            currentY++;
        }
        else if (cave[currentY + 1, currentX - 1] != '#' && cave[currentY + 1, currentX - 1] != 'o')
        {
            currentX--;
            currentY++;
        }
        else if (cave[currentY + 1, currentX + 1] != '#' && cave[currentY + 1, currentX + 1] != 'o')
        {
            currentX++;
            currentY++;
        }
        else
        {
            comeToRest = true;
        }
    }
    int[] res = { currentX, currentY };
    return res;
}

drawCave();
int count = 0;
bool reachedAbyss = false;
while (!reachedAbyss)
{
    int[] res = dropSand();
    if (res[1] > maxCaveDepth)
    {
        reachedAbyss = true;
    }
    else
    {
        count++;
        cave[res[1], res[0]] = 'o';
    }
}
Internal.Console.WriteLine("Part1 Count: " + count);
/* part1: 578 */

// for (int j = 0; j <= maxCaveDepth + 1; j++)
// {
//     for (int i = 0; i <= maxCaveWidth + 1; i++)
//     {

//         Internal.Console.Write(cave[j, i].ToString());
//     }
//     Internal.Console.WriteLine("\n");
// }

public int[] dropSand2()
{
    bool comeToRest = false;
    int currentX = sourceX;
    int currentY = sourceY;
    while (!comeToRest)
    {
        if (cave[currentY + 1, currentX] != '#' && cave[currentY + 1, currentX] != 'o')
        {
            currentY++;
        }
        else if (cave[currentY + 1, currentX - 1] != '#' && cave[currentY + 1, currentX - 1] != 'o')
        {
            currentX--;
            currentY++;
        }
        else if (cave[currentY + 1, currentX + 1] != '#' && cave[currentY + 1, currentX + 1] != 'o')
        {
            currentX++;
            currentY++;
        }
        else
        {
            comeToRest = true;
        }
    }
    int[] res = { currentX, currentY };
    return res;
}

drawCave();
int count2 = 0;
bool canDrop = true;
while (canDrop)
{
    int[] res = dropSand();
    count2++;
    if (res[1] == 0)
    {
        canDrop = false;
    }
    else
    {
        cave[res[1], res[0]] = 'o';
    }
}
Internal.Console.WriteLine("Part2 Count: " + count2);
/* part2: 24377 */