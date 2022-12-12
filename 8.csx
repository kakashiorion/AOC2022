var contents = File.ReadAllLines("8.txt");

char[,] visibilityArray = new char[99, 99];

for (int i = 0; i < 99; i++)
{
    for (int j = 0; j < 99; j++)
    {
        visibilityArray[i, j] = 'v';
        if (i == 0 || j == 0 || i == 98 || j == 98)
        {
            continue;
        }
        int value = Convert.ToInt32(contents[i][j]);
        for (int k = 0; k < j; k++)
        {
            if (Convert.ToInt32(contents[i][k]) >= value)
            {
                visibilityArray[i, j] = 'i';
                break;
            }
        }
        if (visibilityArray[i, j] == 'v')
        {
            continue;
        }
        visibilityArray[i, j] = 'v';
        for (int k = j + 1; k < 99; k++)
        {
            if (Convert.ToInt32(contents[i][k]) >= value)
            {
                visibilityArray[i, j] = 'i';
                break;
            }
        }
        if (visibilityArray[i, j] == 'v')
        {
            continue;
        }
        visibilityArray[i, j] = 'v';
        for (int k = 0; k < i; k++)
        {
            if (Convert.ToInt32(contents[k][j]) >= value)
            {
                visibilityArray[i, j] = 'i';
                break;
            }
        }
        if (visibilityArray[i, j] == 'v')
        {
            continue;
        }
        visibilityArray[i, j] = 'v';
        for (int k = i + 1; k < 99; k++)
        {
            if (Convert.ToInt32(contents[k][j]) >= value)
            {
                visibilityArray[i, j] = 'i';
                break;
            }
        }
    }
}

int total = 0;
for (int i = 0; i < 99; i++)
{
    for (int j = 0; j < 99; j++)
    {
        if (visibilityArray[i, j] == 'v')
        { total++; }
    }
}

Internal.Console.WriteLine("Visible trees: " + total.ToString());

// for (int i = 0; i < visibilityArray.GetLength(0); i++)
// {
//     for (int j = 0; j < visibilityArray.GetLength(1); j++)
//     {
//         Internal.Console.Write(visibilityArray[i, j].ToString());
//     }
//     Internal.Console.WriteLine();
// }

/* part1: 1693 */

int[,] treeScoreArray = new int[99, 99];

for (int i = 0; i < 99; i++)
{
    for (int j = 0; j < 99; j++)
    {
        if (i == 0 || j == 0 || i == 98 || j == 98)
        {
            treeScoreArray[i, j] = 0;
            continue;
        }
        int value = Convert.ToInt32(contents[i][j]);
        int leftScore = 1;
        for (int k = j - 1; k > 0; k--)
        {
            if (Convert.ToInt32(contents[i][k]) >= value)
            {
                break;
            }
            else
            {
                leftScore++;
            }
        }
        int rightScore = 1;
        for (int k = j + 1; k < 98; k++)
        {
            if (Convert.ToInt32(contents[i][k]) >= value)
            {
                break;
            }
            else
            {
                rightScore++;
            }
        }
        int upScore = 1;
        for (int k = i - 1; k > 0; k--)
        {
            if (Convert.ToInt32(contents[k][j]) >= value)
            {
                break;
            }
            else
            {
                upScore++;
            }
        }
        int downScore = 1;
        for (int k = i + 1; k < 98; k++)
        {
            if (Convert.ToInt32(contents[k][j]) >= value)
            {
                break;
            }
            else
            {
                downScore++;
            }
        }
        treeScoreArray[i, j] = leftScore * rightScore * upScore * downScore;
    }
}

int maxScore = 0;
for (int i = 0; i < treeScoreArray.GetLength(0); i++)
{
    for (int j = 0; j < treeScoreArray.GetLength(1); j++)
    {
        if (treeScoreArray[i, j] > maxScore)
        {
            maxScore = treeScoreArray[i, j];
        }
    }
}
Internal.Console.WriteLine("Max tree score: " + maxScore.ToString());
/* part2: 422059 */