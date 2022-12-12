const int rows = 41;
const int columns = 93;
const int infinity = 10000;
string[] contents = File.ReadAllLines("12.txt");

int[,] pathScore = new int[rows, columns];
int startXPosition;
int startYPosition;
int targetXPosition;
int targetYPosition;
int[,] elevations = new int[rows, columns];
int lowestElevation = Convert.ToInt32('a');
int highestElevation = Convert.ToInt32('z');
char[,] visited = new char[rows, columns];

public void setup()
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            pathScore[i, j] = infinity;
            elevations[i, j] = Convert.ToInt32(contents[i][j]);
            visited[i, j] = '.';
            if (contents[i][j] == 'S')
            {
                pathScore[i, j] = 0;
                startXPosition = i;
                startYPosition = j;
                elevations[i, j] = lowestElevation;
                visited[i, j] = 'S';
            }
            else if (contents[i][j] == 'E')
            {
                targetXPosition = i;
                targetYPosition = j;
                elevations[i, j] = highestElevation;
            }
        }
    }
}

public void round()
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            int up = i > 0 ? pathScore[i - 1, j] : infinity;
            int down = i < rows - 1 ? pathScore[i + 1, j] : infinity; ;
            int left = j > 0 ? pathScore[i, j - 1] : infinity;
            int right = j < columns - 1 ? pathScore[i, j + 1] : infinity; ;

            int currentElevation = elevations[i, j];
            int upElevation = i > 0 ? elevations[i - 1, j] : infinity;
            int downElevation = i < rows - 1 ? elevations[i + 1, j] : infinity;
            int leftElevation = j > 0 ? elevations[i, j - 1] : infinity;
            int rightElevation = j < columns - 1 ? elevations[i, j + 1] : infinity;

            if ((currentElevation <= upElevation + 1) && up + 1 < pathScore[i, j])
            {
                pathScore[i, j] = up + 1;
                visited[i, j] = '#';
            }
            if ((currentElevation <= downElevation + 1) && down + 1 < pathScore[i, j])
            {
                pathScore[i, j] = down + 1;
                visited[i, j] = '#';
            }
            if ((currentElevation <= leftElevation + 1) && left + 1 < pathScore[i, j])
            {
                pathScore[i, j] = left + 1;
                visited[i, j] = '#';
            }
            if ((currentElevation <= rightElevation + 1) && right + 1 < pathScore[i, j])
            {
                pathScore[i, j] = right + 1;
                visited[i, j] = '#';
            }
        }
    }
}

setup();
for (int k = 0; k < rows * columns; k++)
{
    round();
}

// for (int i = 0; i < rows; i++)
// {
//     for (int j = 0; j < columns; j++)
//     {
//         Internal.Console.Write(visited[i, j].ToString());
//     }
//     Internal.Console.WriteLine("\n");
// }
Internal.Console.WriteLine("End position steps:" + pathScore[targetXPosition, targetYPosition].ToString());
/* part1: 412 */

public void setup2()
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            pathScore[i, j] = infinity;
            elevations[i, j] = Convert.ToInt32(contents[i][j]);
            visited[i, j] = '.';
            if (contents[i][j] == 'E')
            {
                startXPosition = i;
                startYPosition = j;
                pathScore[i, j] = 0;
                elevations[i, j] = highestElevation;
                visited[i, j] = 'E';
            }
        }
    }
}

setup2();

bool reachedLowest = false;
int cycle = 0;
while (!reachedLowest)
{
    int itemsChanged = 0;
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if (pathScore[i, j] == cycle)
            {
                int up = i > 0 ? pathScore[i - 1, j] : infinity;
                int down = i < rows - 1 ? pathScore[i + 1, j] : infinity;
                int left = j > 0 ? pathScore[i, j - 1] : infinity;
                int right = j < columns - 1 ? pathScore[i, j + 1] : infinity;

                int currentElevation = elevations[i, j];
                int upElevation = i > 0 ? elevations[i - 1, j] : infinity;
                int downElevation = i < rows - 1 ? elevations[i + 1, j] : infinity;
                int leftElevation = j > 0 ? elevations[i, j - 1] : infinity;
                int rightElevation = j < columns - 1 ? elevations[i, j + 1] : infinity;

                if ((currentElevation - 1 <= upElevation) && up > cycle && i > 0)
                {
                    pathScore[i - 1, j] = cycle + 1;
                    visited[i - 1, j] = '#';
                    itemsChanged++;
                    if (upElevation == lowestElevation)
                    {
                        reachedLowest = true;
                        visited[i - 1, j] = 'A';
                    }
                }
                if ((currentElevation - 1 <= downElevation) && down > cycle && i < rows - 1)
                {
                    pathScore[i + 1, j] = cycle + 1;
                    visited[i + 1, j] = '#';
                    itemsChanged++;
                    if (downElevation == lowestElevation)
                    {
                        reachedLowest = true;
                        visited[i + 1, j] = 'A';
                    }
                }
                if ((currentElevation - 1 <= leftElevation) && left > cycle && j > 0)
                {
                    pathScore[i, j - 1] = cycle + 1;
                    visited[i, j - 1] = '#';
                    itemsChanged++;
                    if (leftElevation == lowestElevation)
                    {
                        reachedLowest = true;
                        visited[i, j - 1] = 'A';
                    }
                }
                if ((currentElevation - 1 <= rightElevation) && right > cycle && j < columns - 1)
                {
                    pathScore[i, j + 1] = cycle + 1;
                    visited[i, j + 1] = '#';
                    itemsChanged++;
                    if (rightElevation == lowestElevation)
                    {
                        reachedLowest = true;
                        visited[i, j + 1] = 'A';
                    }
                }
            }
        }
    }
    cycle++;

    // Internal.Console.WriteLine("Completed cycle:" + cycle.ToString());
    // Internal.Console.WriteLine("Visited items:" + itemsChanged.ToString());
}

// for (int i = 0; i < rows; i++)
// {
//     for (int j = 0; j < columns; j++)
//     {
//         Internal.Console.Write(visited[i, j].ToString());
//     }
//     Internal.Console.WriteLine("\n");
// }
Internal.Console.WriteLine("End position steps:" + cycle.ToString());
/* part2: 402 */