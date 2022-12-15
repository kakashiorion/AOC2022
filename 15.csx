string[] contents = File.ReadAllLines("15.txt");

List<int[]> sensors = new List<int[]>();
List<int[]> beacons = new List<int[]>();

for (int i = 0; i < contents.Length; i++)
{
    string s = contents[i].Split(": ")[0];
    string b = contents[i].Split(": ")[1];

    int sensorX = Convert.ToInt32(s.Split(',')[0].Split("x=")[1]);
    int sensorY = Convert.ToInt32(s.Split(',')[1].Split("y=")[1]);

    int beaconX = Convert.ToInt32(b.Split(',')[0].Split("x=")[1]);
    int beaconY = Convert.ToInt32(b.Split(',')[1].Split("y=")[1]);

    sensors.Add(new int[] { sensorX, sensorY });
    beacons.Add(new int[] { beaconX, beaconY });
}

public int getManhattanDistance(int aX, int aY, int bX, int bY)
{
    int xDiff = Math.Abs(aX - bX);
    int yDiff = Math.Abs(aY - bY);
    return xDiff + yDiff;
}

const int scanningRow = 2000000;
List<int[]> positions = new List<int[]>();

for (int k = 0; k < sensors.Count; k++)
{
    int beaconDist = getManhattanDistance(sensors[k][0], sensors[k][1], beacons[k][0], beacons[k][1]);
    int yDiff = Math.Abs(sensors[k][1] - scanningRow);
    int xDiff = beaconDist - yDiff;
    if (xDiff >= 0)
    {
        positions.Add(new int[] { sensors[k][0] - xDiff, sensors[k][0] + xDiff });
    }
}

public int[] merge(int lowA, int highA, int lowB, int highB)
{
    return new int[] { (lowA < lowB ? lowA : lowB), (highA < highB ? highB : highA) };
}

bool foundMerge = true;
while (foundMerge)
{
    foundMerge = false;
    for (int i = 1; i < positions.Count; i++)
    {
        for (int j = 0; j < i; j++)
        {
            int lowA = positions[i][0];
            int highA = positions[i][1];
            int lowB = positions[j][0];
            int highB = positions[j][1];
            if (lowA > highB || lowB > highA)
            {
                continue;
            }
            else
            {
                positions[i] = merge(lowA, highA, lowB, highB);
                positions.RemoveAt(j);
                foundMerge = true;
                Internal.Console.WriteLine("Found merge");
                break;
            }
        }
    }
}

Internal.Console.WriteLine((positions[0][1] - positions[0][0]).ToString());
/* part1: 5073496 */

const int minCoordinate = 0;
const int maxCoordinate = 4000000;
Dictionary<string, int> points = new Dictionary<string, int>();

public bool containedInSpace(int[] p)
{
    if (p[0] >= minCoordinate && p[0] <= maxCoordinate && p[1] >= minCoordinate && p[1] <= maxCoordinate)
    {
        return true;
    }
    return false;
}

public void addPoint(int[] p)
{
    string s = p[0].ToString() + "," + p[1].ToString();
    if (points.ContainsKey(s))
    {
        points[s]++;
    }
    else
    {
        points.Add(s, 1);
    }
}

for (int k = 0; k < sensors.Count; k++)
{
    int searchDist = getManhattanDistance(sensors[k][0], sensors[k][1], beacons[k][0], beacons[k][1]) + 1;
    int right = sensors[k][0] + searchDist;
    int left = sensors[k][0] - searchDist;
    int top = sensors[k][1] + searchDist;
    int bottom = sensors[k][1] - searchDist;
    int[] topPoint = new int[] { sensors[k][0], top };
    int[] bottomPoint = new int[] { sensors[k][0], bottom };
    int[] leftPoint = new int[] { left, sensors[k][1] };
    int[] rightPoint = new int[] { right, sensors[k][1] };
    if (containedInSpace(topPoint))
    {
        addPoint(topPoint);
    }
    if (containedInSpace(bottomPoint))
    {
        addPoint(bottomPoint);
    }
    if (containedInSpace(leftPoint))
    {
        addPoint(leftPoint);
    }
    if (containedInSpace(rightPoint))
    {
        addPoint(rightPoint);
    }

    for (int i = 1; i < searchDist; i++)
    {
        int[] newKeyA = new int[] { left + i, top + i - searchDist };
        if (containedInSpace(newKeyA))
        {
            addPoint(newKeyA);
        }
        int[] newKeyB = new int[] { left + i, bottom - i + searchDist };
        if (containedInSpace(newKeyB))
        {
            addPoint(newKeyB);

        }
        int[] newKeyC = new int[] { right - i, top + i - searchDist };
        if (containedInSpace(newKeyC))
        {
            addPoint(newKeyC);

        }
        int[] newKeyD = new int[] { right - i, bottom - i + searchDist };
        if (containedInSpace(newKeyD))
        {
            addPoint(newKeyD);

        }
        // points.Add(new int[]{left+i,top+i-searchDist});
        // points.Add(new int[]{left+i,bottom-i+searchDist});
        // points.Add(new int[]{right-i,top+i-searchDist});
        // points.Add(new int[]{right-i,bottom-i+searchDist});
    }
}

Internal.Console.WriteLine(points.Count.ToString());

foreach (var v in points)
{
    if (v.Value > 3)
    {
        Internal.Console.WriteLine(v.Key + ":" + v.Value.ToString());
        long xCoord = Convert.ToInt64(v.Key.Split(',')[0]);
        long yCoord = Convert.ToInt64(v.Key.Split(',')[1]);
        Internal.Console.WriteLine((xCoord * maxCoordinate + yCoord).ToString());
    }
}
/* part2: 13081194638237 */
/* 3270298,2638237:4 */