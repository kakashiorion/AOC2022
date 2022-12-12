var contents = File.ReadAllLines("9.txt");

public class Marker
{
    public int xPos;
    public int yPos;
    public Marker(int xPos, int yPos)
    {
        this.xPos = xPos;
        this.yPos = yPos;
    }
    public void MoveLeft()
    {
        this.xPos--;
    }
    public void MoveRight()
    {
        this.xPos++;
    }
    public void MoveUp()
    {
        this.yPos++;
    }
    public void MoveDown()
    {
        this.yPos--;
    }
}

var head = new Marker(0, 0);
var tail = new Marker(0, 0);
int[] startPosition = { 0, 0 };

List<int[]> tailPositions = new List<int[]>();
tailPositions.Add(startPosition);

for (int i = 0; i < contents.Length; i++)
{
    var headMove = contents[i].Split(' ')[0];
    var headSteps = Convert.ToInt32(contents[i].Split(' ')[1]);

    for (int j = 0; j < headSteps; j++)
    {
        if (headMove == "L")
        {
            head.MoveLeft();
        }
        else if (headMove == "R")
        {
            head.MoveRight();
        }
        else if (headMove == "U")
        {
            head.MoveUp();
        }
        else
        {
            head.MoveDown();
        }
        updateKnot(head, tail);
        int[] newTailPosition = { tail.xPos, tail.yPos };
        if (!tailPositions.Exists(x => x[0] == newTailPosition[0] && x[1] == newTailPosition[1]))
        { tailPositions.Add(newTailPosition); }
    }
}

Internal.Console.WriteLine("Tail positions: " + tailPositions.Count);
/* part1: 6464 */

head = new Marker(0, 0);
var marker1 = new Marker(0, 0);
var marker2 = new Marker(0, 0);
var marker3 = new Marker(0, 0);
var marker4 = new Marker(0, 0);
var marker5 = new Marker(0, 0);
var marker6 = new Marker(0, 0);
var marker7 = new Marker(0, 0);
var marker8 = new Marker(0, 0);
var marker9 = new Marker(0, 0);

List<int[]> m9Positions = new List<int[]>();
m9Positions.Add(startPosition);

for (int i = 0; i < contents.Length; i++)
{
    var headMove = contents[i].Split(' ')[0];
    var headSteps = Convert.ToInt32(contents[i].Split(' ')[1]);

    for (int j = 0; j < headSteps; j++)
    {
        if (headMove == "L")
        {
            head.MoveLeft();
        }
        else if (headMove == "R")
        {
            head.MoveRight();
        }
        else if (headMove == "U")
        {
            head.MoveUp();
        }
        else
        {
            head.MoveDown();
        }
        updateKnot(head, marker1);
        updateKnot(marker1, marker2);
        updateKnot(marker2, marker3);
        updateKnot(marker3, marker4);
        updateKnot(marker4, marker5);
        updateKnot(marker5, marker6);
        updateKnot(marker6, marker7);
        updateKnot(marker7, marker8);
        updateKnot(marker8, marker9);
        int[] newTailPosition = { marker9.xPos, marker9.yPos };
        if (!m9Positions.Exists(x => x[0] == newTailPosition[0] && x[1] == newTailPosition[1]))
        { m9Positions.Add(newTailPosition); }
    }
}

Internal.Console.WriteLine("Marker9 positions: " + m9Positions.Count);
/* part2:  2604*/

public void updateKnot(Marker leading, Marker trailing)
{
    var xDiff = leading.xPos - trailing.xPos;
    var yDiff = leading.yPos - trailing.yPos;
    if (xDiff == 0)
    {
        if (yDiff == 0 || yDiff == 1 || yDiff == -1)
        {
            return;
        }
        else if (yDiff > 1)
        {
            trailing.MoveUp();
            return;
        }
        else if (yDiff < -1)
        {
            trailing.MoveDown();
            return;
        }
    }
    if (xDiff == 1)
    {
        if (yDiff == 0 || yDiff == 1 || yDiff == -1)
        {
            return;
        }
        else if (yDiff > 1)
        {
            trailing.MoveRight();
            trailing.MoveUp();
            return;
        }
        else if (yDiff < -1)
        {
            trailing.MoveRight();
            trailing.MoveDown();
            return;
        }
    }
    if (xDiff == -1)
    {
        if (yDiff == 0 || yDiff == 1 || yDiff == -1)
        {
            return;
        }
        else if (yDiff > 1)
        {
            trailing.MoveLeft();
            trailing.MoveUp();
            return;
        }
        else if (yDiff < -1)
        {
            trailing.MoveLeft();
            trailing.MoveDown();
            return;
        }
    }
    if (xDiff > 1)
    {
        if (yDiff == 0)
        {
            trailing.MoveRight();
            return;
        }
        else if (yDiff > 0)
        {
            trailing.MoveUp();
            trailing.MoveRight();
            return;
        }
        else if (yDiff < 0)
        {
            trailing.MoveDown();
            trailing.MoveRight();
            return;
        }
    }
    if (xDiff < -1)
    {
        if (yDiff == 0)
        {
            trailing.MoveLeft();
            return;
        }
        else if (yDiff > 0)
        {
            trailing.MoveUp();
            trailing.MoveLeft();
            return;
        }
        else if (yDiff < 0)
        {
            trailing.MoveDown();
            trailing.MoveLeft();
            return;
        }
    }
}