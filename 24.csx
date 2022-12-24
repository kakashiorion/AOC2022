string[] input = File.ReadAllLines("24.txt");

const int rows = 27;
const int columns = 122;
const string startPoint = "0,1";
const string finishPoint = "26,120";
char[,] map = new char[rows, columns];
Dictionary<string, List<char>> currentMap = new Dictionary<string, List<char>>();
Dictionary<string, List<char>> nextMap = new Dictionary<string, List<char>>();

for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        char x = input[i][j];
        map[i, j] = x;
        if (x != '#' && x != '.')
        {
            currentMap[i.ToString() + "," + j.ToString()] = new List<char>();
            currentMap[i.ToString() + "," + j.ToString()].Add(x);
        }
    }
}

public void addNextMap(int x, int y, char c)
{
    string s = x.ToString() + "," + y.ToString();
    if (!nextMap.ContainsKey(s))
    {
        nextMap[s] = new List<char>();
    }
    nextMap[s].Add(c);
}

public void createNextMap()
{
    nextMap.Clear();
    for (int i = 1; i < rows - 1; i++)
    {
        for (int j = 1; j < columns - 1; j++)
        {
            bool noMovement = true;
            string up = (i - 1).ToString() + "," + j.ToString();
            string down = (i + 1).ToString() + "," + j.ToString();
            string left = i.ToString() + "," + (j - 1).ToString();
            string right = i.ToString() + "," + (j + 1).ToString();
            if (i == 1)
            {
                up = "25," + j.ToString();
            }
            if (i == rows - 2)
            {
                down = "1," + j.ToString();
            }
            if (j == 1)
            {
                left = i.ToString() + ",120";
            }
            if (j == columns - 2)
            {
                right = i.ToString() + ",1";
            }

            if (currentMap.ContainsKey(up) && currentMap[up].Contains('v'))
            {
                addNextMap(i, j, 'v');
                noMovement = false;
            }
            if (currentMap.ContainsKey(down) && currentMap[down].Contains('^'))
            {
                addNextMap(i, j, '^');
                noMovement = false;
            }
            if (currentMap.ContainsKey(left) && currentMap[left].Contains('>'))
            {
                addNextMap(i, j, '>');
                noMovement = false;
            }
            if (currentMap.ContainsKey(right) && currentMap[right].Contains('<'))
            {
                addNextMap(i, j, '<');
                noMovement = false;
            }
            if (noMovement)
            {
                addNextMap(i, j, '.');
            }
        }
    }
    addNextMap(0, 1, '.');
    addNextMap(26, 120, '.');
}

public int part1(string startingPoint, string endingPoint)
{
    int minute = 0;
    // while (!currentMap.ContainsKey(endingPoint) || !currentMap[endingPoint].Contains('E'))
    while (!currentMap[endingPoint].Contains('E'))
    {
        createNextMap();
        foreach (string s in currentMap.Keys)
        {
            if (currentMap[s].Contains('E'))
            {
                string currentPlayerPosition = s;
                int x = Convert.ToInt32(currentPlayerPosition.Split(",")[0]);
                int y = Convert.ToInt32(currentPlayerPosition.Split(",")[1]);
                string right = x.ToString() + "," + (y + 1).ToString();
                string down = (x + 1).ToString() + "," + y.ToString();
                string up = (x - 1).ToString() + "," + y.ToString();
                string left = x.ToString() + "," + (y - 1).ToString();

                if (nextMap.ContainsKey(down) && nextMap[down].Contains('.'))
                {
                    nextMap[down].Add('E');
                }
                if (nextMap.ContainsKey(right) && nextMap[right].Contains('.'))
                {
                    nextMap[right].Add('E');
                }
                if (nextMap.ContainsKey(currentPlayerPosition) && nextMap[currentPlayerPosition].Contains('.'))
                {
                    nextMap[currentPlayerPosition].Add('E');
                }
                if (nextMap.ContainsKey(up) && nextMap[up].Contains('.'))
                {
                    nextMap[up].Add('E');
                }
                if (nextMap.ContainsKey(left) && nextMap[left].Contains('.'))
                {
                    nextMap[left].Add('E');
                }
            }
        }
        currentMap = new Dictionary<string, List<char>>(nextMap);
        minute++;
        // Internal.Console.WriteLine("Ran " + minute + " minutes");
    }
    Internal.Console.WriteLine("Reached " + endingPoint + " after minutes: " + minute.ToString());
    return minute;
}

currentMap[startPoint] = new List<char>();
currentMap[startPoint].Add('E');
currentMap[finishPoint] = new List<char>();
currentMap[finishPoint].Add('.');

// part1(startPoint, finishPoint);
/* part1: 301 */

public void cleanPlayerPositions(string exceptPoint)
{
    foreach (string s in currentMap.Keys)
    {
        if (currentMap[s].Contains('E') && !s.Equals(exceptPoint))
        {
            currentMap[s].RemoveAll(x => x == 'E');
        }
    }
}

public void part2()
{
    int r1 = part1(startPoint, finishPoint);
    cleanPlayerPositions(finishPoint);
    int r2 = part1(finishPoint, startPoint);
    cleanPlayerPositions(startPoint);
    int r3 = part1(startPoint, finishPoint);
    Internal.Console.WriteLine("Completed: " + (r1 + r2 + r3).ToString());
}

part2();
/* part2: 859 */