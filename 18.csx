string[] input = File.ReadAllLines("18.txt");

List<int[]> cubes = new List<int[]>();
int minX = 0;
int minY = 0;
int minZ = 0;
int maxX = 0;
int maxY = 0;
int maxZ = 0;

for (int i = 0; i < input.Length; i++)
{
    int x = Convert.ToInt32(input[i].Split(",")[0]);
    if (x < minX) minX = x;
    if (x > maxX) maxX = x;
    int y = Convert.ToInt32(input[i].Split(",")[1]);
    if (y < minY) minY = y;
    if (y > maxY) maxY = y;
    int z = Convert.ToInt32(input[i].Split(",")[2]);
    if (z < minZ) minZ = z;
    if (z > maxZ) maxZ = z;
    cubes.Add(new int[] { x, y, z });
}

Internal.Console.WriteLine("Min X: " + minX + ", Max X: " + maxX);
Internal.Console.WriteLine("Min Y: " + minY + ", Max Y: " + maxY);
Internal.Console.WriteLine("Min Z: " + minZ + ", Max Z: " + maxZ);
Internal.Console.WriteLine("Cubes count: " + cubes.Count);

public bool commonSide(int[] c1, int[] c2)
{
    if (Math.Abs(c1[0] - c2[0]) == 1 && c1[1] == c2[1] && c1[2] == c2[2])
    {
        return true;
    }
    else if (Math.Abs(c1[1] - c2[1]) == 1 && c1[0] == c2[0] && c1[2] == c2[2])
    {
        return true;
    }
    else if (Math.Abs(c1[2] - c2[2]) == 1 && c1[1] == c2[1] && c1[0] == c2[0])
    {
        return true;
    }
    return false;
}

// int total = 0;
// for (int i = 0; i < cubes.Count - 1; i++)
// {
//     for (int j = i + 1; j < cubes.Count; j++)
//     {
//         if (commonSide(cubes[i], cubes[j]))
//         {
//             total++;
//         }
//     }
// }

// Internal.Console.WriteLine("Total common faces: " + total);
// Internal.Console.WriteLine("Exposed faces: " + ((cubes.Count * 6) - (total * 2)));
/* part1: 4482 */

List<int[]> submerged = new List<int[]>();
for (int k = minZ - 1; k <= maxZ + 1; k++)
{
    for (int l = minY - 1; l <= maxY + 1; l++)
    {
        for (int m = minX - 1; m <= maxX + 1; m++)
        {
            int[] currentCube = new int[] { m, l, k };
            if (k == minZ - 1 || k == maxZ + 1 || l == minY - 1 || l == maxY + 1 || m == minX - 1 || m == maxX + 1)
            {
                submerged.Add(currentCube);
            }
        }
    }
}

for (int k = minZ - 1; k <= maxZ + 1; k++)
{
    for (int l = minY - 1; l <= maxY + 1; l++)
    {
        for (int m = minX - 1; m <= maxX + 1; m++)
        {
            int[] currentCube = new int[] { m, l, k };
            if (!cubes.Exists(x => x[0] == m && x[1] == l && x[2] == k) && !submerged.Exists(x => x[0] == m && x[1] == l && x[2] == k))
            {
                if (submerged.Exists(y => y[0] == m - 1 && y[1] == l && y[2] == k)
                || submerged.Exists(y => y[0] == m && y[1] == l - 1 && y[2] == k)
                || submerged.Exists(y => y[0] == m && y[1] == l && y[2] == k - 1)
                || submerged.Exists(y => y[0] == m + 1 && y[1] == l && y[2] == k)
                || submerged.Exists(y => y[0] == m && y[1] == l + 1 && y[2] == k)
                || submerged.Exists(y => y[0] == m && y[1] == l && y[2] == k + 1))
                {
                    submerged.Add(currentCube);
                }
            }
        }
    }
}

for (int k = maxZ + 1; k >= minZ - 1; k--)
{
    for (int l = maxY + 1; l >= minY - 1; l--)
    {
        for (int m = maxX + 1; m >= minX - 1; m--)
        {
            int[] currentCube = new int[] { m, l, k };
            if (!cubes.Exists(x => x[0] == m && x[1] == l && x[2] == k) && !submerged.Exists(x => x[0] == m && x[1] == l && x[2] == k))
            {
                if (submerged.Exists(y => y[0] == m + 1 && y[1] == l && y[2] == k)
                || submerged.Exists(y => y[0] == m && y[1] == l + 1 && y[2] == k)
                || submerged.Exists(y => y[0] == m && y[1] == l && y[2] == k + 1)
                || submerged.Exists(y => y[0] == m - 1 && y[1] == l && y[2] == k)
                || submerged.Exists(y => y[0] == m && y[1] == l - 1 && y[2] == k)
                || submerged.Exists(y => y[0] == m && y[1] == l && y[2] == k - 1))
                {
                    submerged.Add(currentCube);
                }
            }
        }
    }
}


Internal.Console.WriteLine("Submerged count: " + submerged.Count);

int exposed = 0;
for (int i = 0; i < cubes.Count; i++)
{
    if (submerged.Exists(y => y[0] == cubes[i][0] + 1 && y[1] == cubes[i][1] && y[2] == cubes[i][2]))
    {
        exposed++;
    }
    if (submerged.Exists(y => y[0] == cubes[i][0] - 1 && y[1] == cubes[i][1] && y[2] == cubes[i][2]))
    {
        exposed++;
    }
    if (submerged.Exists(y => y[0] == cubes[i][0] && y[1] == cubes[i][1] + 1 && y[2] == cubes[i][2]))
    {
        exposed++;
    }
    if (submerged.Exists(y => y[0] == cubes[i][0] && y[1] == cubes[i][1] - 1 && y[2] == cubes[i][2]))
    {
        exposed++;
    }
    if (submerged.Exists(y => y[0] == cubes[i][0] && y[1] == cubes[i][1] && y[2] == cubes[i][2] + 1))
    {
        exposed++;
    }
    if (submerged.Exists(y => y[0] == cubes[i][0] && y[1] == cubes[i][1] && y[2] == cubes[i][2] - 1))
    {
        exposed++;
    }
}

Internal.Console.WriteLine("Hidden cubes: " + ((maxX + 3) * (maxY + 3) * (maxZ + 3) - submerged.Count - cubes.Count));
Internal.Console.WriteLine("Exposed sides: " + exposed);
