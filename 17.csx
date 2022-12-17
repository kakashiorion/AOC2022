string input = File.ReadAllLines("17.txt")[0];
// string input = ">>><<><>><<<>><>>><<<>>><<<><<<>><>><<>>";
int sizeInput = input.Length;

List<string> tower = new List<string>();
tower.Add("-------");

List<string> rock1 = new List<string> { "..@@@@." };
List<string> rock2 = new List<string> { "...@...", "..@@@..", "...@..." };
List<string> rock3 = new List<string> { "..@@@..", "....@..", "....@.." };
List<string> rock4 = new List<string> { "..@....", "..@....", "..@....", "..@...." };
List<string> rock5 = new List<string> { "..@@...", "..@@..." };

List<List<string>> allRocks = new List<List<string>> { rock1, rock2, rock3, rock4, rock5 };

public void addRock(int rockIndex)
{
    List<string> inputRock = allRocks[rockIndex];
    tower.Add(".......");
    tower.Add(".......");
    tower.Add(".......");
    foreach (string r in inputRock)
    {
        tower.Add(String.Copy(r));
    }
}

public void moveLeft()
{
    bool canMoveLeft = true;
    foreach (string r in tower)
    {
        if (r.Contains('@'))
        {
            if (r[0] == '@' || r[r.IndexOf('@') - 1] == '#')
            {
                canMoveLeft = false;
                break;
            }
        }
    }
    if (canMoveLeft)
    {
        for (int i = 0; i < tower.Count; i++)
        {
            if (tower[i].Contains('@'))
            {
                for (int j = 1; j <= 6; j++)
                {
                    if (tower[i][j] == '@')
                    {
                        string s = string.Copy(tower[i]);
                        s = s.Substring(0, j - 1) + "@." + (j < 6 ? s.Substring(j + 1) : "");
                        tower[i] = s;
                    }
                }
            }
        }
    }
}

public void moveRight()
{
    bool canMoveRight = true;
    foreach (string r in tower)
    {
        if (r.Contains('@'))
        {
            if (r[6] == '@' || r[r.LastIndexOf('@') + 1] == '#')
            {
                canMoveRight = false;
                break;
            }
        }
    }
    if (canMoveRight)
    {
        for (int i = 0; i < tower.Count; i++)
        {
            if (tower[i].Contains('@'))
            {
                for (int j = 5; j >= 0; j--)
                {
                    if (tower[i][j] == '@')
                    {
                        string s = string.Copy(tower[i]);
                        s = (j == 0 ? "" : s.Substring(0, j)) + ".@" + (j == 5 ? "" : s.Substring(j + 2));
                        tower[i] = s;
                    }
                }
            }
        }
    }
}

public bool moveDown()
{
    bool canMoveDown = true;
    for (int i = 0; i < tower.Count; i++)
    {
        if (tower[i].Contains('@'))
        {
            for (int j = 0; j < 7; j++)
            {
                if (tower[i][j] == '@' && (tower[i - 1][j] == '-' || tower[i - 1][j] == '#'))
                {
                    canMoveDown = false;
                    break;
                }
            }
        }
    }
    if (canMoveDown)
    {
        for (int i = 0; i < tower.Count; i++)
        {
            if (tower[i].Contains('@'))
            {
                for (int j = 0; j < 7; j++)
                {
                    string s = string.Copy(tower[i - 1]);
                    if (tower[i][j] == '@')
                    {
                        if (j == 0)
                        {
                            s = '@' + tower[i - 1].Substring(1);
                        }
                        else if (j == 6)
                        {
                            s = tower[i - 1].Substring(0, 6) + '@';
                        }
                        else
                        {
                            s = tower[i - 1].Substring(0, j) + '@' + tower[i - 1].Substring(j + 1);
                        }

                    }
                    if (tower[i - 1][j] == '@')
                    {
                        if (j == 0)
                        {
                            s = tower[i][j] + tower[i - 1].Substring(1);
                        }
                        else if (j == 6)
                        {
                            s = tower[i - 1].Substring(0, 6) + tower[i][j];
                        }
                        else
                        {
                            s = tower[i - 1].Substring(0, j) + tower[i][j] + tower[i - 1].Substring(j + 1);
                        }
                    }
                    tower[i - 1] = s;
                }
            }
        }
        int k = tower.Count - 1;
        while (!tower[k].Contains('@'))
        {
            if (!tower[k].Contains('#'))
            {
                tower.RemoveAt(k);
            }
            k--;
        }
        tower[k] = tower[k].Replace('@', '.');
        if (tower[k] == ".......")
        {
            tower.RemoveAt(k);
        }
    }
    else
    {
        for (int i = 0; i < tower.Count; i++)
        {
            if (tower[i].Contains('@'))
            {
                string r = tower[i].Replace('@', '#');
                tower[i] = r;
            }
        }
    }
    return canMoveDown;
}

public void printTower()
{
    for (int i = tower.Count - 1; i >= 0; i--)
    {
        Internal.Console.WriteLine("|" + tower[i] + "|");
    }
}

// long totalheight = 0;

public void part1(long playRounds)
{
    int inputIndex = 0;
    for (long round = 0; round < playRounds; round++)
    {
        // Internal.Console.WriteLine("Round: " + round);
        addRock((int)(round % 5));
        do
        {
            // printTower();
            if (input[inputIndex] == '<')
            {
                moveLeft();
                // Internal.Console.WriteLine("Moving left");
            }
            else
            {
                moveRight();
                // Internal.Console.WriteLine("Moving right");
            }
            inputIndex++;
            if (inputIndex == sizeInput)
            {
                inputIndex = 0;
                Internal.Console.WriteLine("Iteration: " + round);
                Internal.Console.WriteLine("Tower h: " + tower.Count);
                Internal.Console.WriteLine(tower[tower.Count - 1]);

            }
            // printTower();
        }
        while (moveDown());
        // printTower();
        // if (inputIndex == 0)
        // {
        // }
        // if (inputIndex == 0 && round % 5 == 4)
        // {
        //     // totalheight = tower.Count;
        //     Internal.Console.WriteLine(tower[tower.Count - 1]);
        //     Internal.Console.WriteLine("Total height: " + tower.Count);
        //     Internal.Console.WriteLine("Iteration: " + round);
        //     break;
        // }
    }
}

// part1(2022);
part1(1875);

Internal.Console.WriteLine("Tower height: " + (tower.Count - 1));
/* part1 : 3117 */


long modulo = 140;
long dividend = 576368876;
long roundRepeating = 1735;
long heightRepeating = 2695;

long answer = dividend * heightRepeating - heightRepeating + tower.Count - 1;
Internal.Console.WriteLine("Tower height: " + (answer));
/* part2: 1553314121019 */