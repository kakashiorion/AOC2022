var contents = File.ReadAllLines("2.txt");

const int rockScore = 1;
const int paperScore = 2;
const int scissorScore = 3;
const int drawScore = 3;
const int winningScore = 6;

int totalScore = 0;

for (int i = 0; i < contents.Length; i++)
{
    var opponentMove = contents[i].Split(' ')[0];
    var playerMove = contents[i].Split(' ')[1];

    var res = roundResult(opponentMove, playerMove);
    var score = roundScore(res, playerMove);
    totalScore += score;
}

Internal.Console.WriteLine("Total Score: " + totalScore);

static string roundResult(string oMove, string pMove)
{
    if (oMove == "A" && pMove == "X")
    {
        return "D";
    }
    else if (oMove == "A" && pMove == "Y")
    {
        return "W";
    }
    else if (oMove == "A" && pMove == "Z")
    {
        return "L";
    }
    else if (oMove == "B" && pMove == "X")
    {
        return "L";
    }
    else if (oMove == "B" && pMove == "Y")
    {
        return "D";
    }
    else if (oMove == "B" && pMove == "Z")
    {
        return "W";
    }
    else if (oMove == "C" && pMove == "X")
    {
        return "W";
    }
    else if (oMove == "C" && pMove == "Y")
    {
        return "L";
    }
    else
    {
        return "D";
    }
}

static int roundScore(string result, string pMove)
{
    int moveScore = scissorScore;
    int resultScore = 0;
    if (pMove == "X")
    {
        moveScore = rockScore;
    }
    else if (pMove == "Y")
    {
        moveScore = paperScore;
    }
    if (result == "W")
    {
        resultScore = winningScore;
    }
    else if (result == "D")
    {
        resultScore = drawScore;
    }
    return moveScore + resultScore;
}
/* part1: 11150 */

int cheatingScore = 0;
for (int i = 0; i < contents.Length; i++)
{
    var opponentMove = contents[i].Split(' ')[0];
    var result = contents[i].Split(' ')[1];

    var myMove = cheatMove(opponentMove, result);
    var score = roundScore2(result, myMove);
    cheatingScore += score;
}

Internal.Console.WriteLine("Cheating Score: " + cheatingScore);
/* part2: 8295 */

static string cheatMove(string oMove, string result)
{
    if (oMove == "A" && result == "X")
    {
        return "S";
    }
    else if (oMove == "A" && result == "Y")
    {
        return "R";
    }
    else if (oMove == "A" && result == "Z")
    {
        return "P";
    }
    else if (oMove == "B" && result == "X")
    {
        return "R";
    }
    else if (oMove == "B" && result == "Y")
    {
        return "P";
    }
    else if (oMove == "B" && result == "Z")
    {
        return "S";
    }
    else if (oMove == "C" && result == "X")
    {
        return "P";
    }
    else if (oMove == "C" && result == "Y")
    {
        return "S";
    }
    else
    {
        return "R";
    }
}

static int roundScore2(string result, string pMove)
{
    int moveScore = scissorScore;
    int resultScore = 0;
    if (pMove == "R")
    {
        moveScore = rockScore;
    }
    else if (pMove == "P")
    {
        moveScore = paperScore;
    }
    if (result == "Z")
    {
        resultScore = winningScore;
    }
    else if (result == "Y")
    {
        resultScore = drawScore;
    }
    return moveScore + resultScore;
}