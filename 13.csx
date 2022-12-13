string[] contents = File.ReadAllLines("13.txt");

public void part1()
{
    int pairIndex = 0;
    List<int> correctPairs = new List<int>();
    for (int i = 0; i < contents.Length; i = i + 3)
    {
        pairIndex++;
        string firstPair = contents[i];
        string secondPair = contents[i + 1];

        LinkedList<int> leftQueue = makeList(firstPair);
        LinkedList<int> rightQueue = makeList(secondPair);

        bool res = compare(leftQueue, rightQueue);
        if (res)
        {
            correctPairs.Add(pairIndex);
        }
    }
    Internal.Console.WriteLine("Sum of correct pair indices: " + correctPairs.Sum().ToString());
}
part1();
/* part1: 5625 */

public LinkedList<int> makeList(string pair)
{
    LinkedList<int> q = new LinkedList<int>();
    string newString = "";
    foreach (char c in pair)
    {
        if (c == '[' || c == ']')
        {
            if (newString != "")
            {
                q.AddLast(Convert.ToInt32(newString));
                newString = "";
            }
            q.AddLast(Convert.ToInt32(c));
        }
        else if (c == ',')
        {
            if (newString != "")
            {
                q.AddLast(Convert.ToInt32(newString));
                newString = "";
            }
        }
        else
        {
            newString = newString + c.ToString();
        }
    }
    return q;
}

public bool compare(LinkedList<int> leftQ, LinkedList<int> rightQ)
{
    while (true)
    {
        int leftValue = leftQ.First();
        int rightValue = rightQ.First();
        //Both are integers
        if (leftValue <= 10 && rightValue <= 10)
        {
            if (leftValue < rightValue)
            {
                return true;
            }
            else if (leftValue > rightValue)
            {
                return false;
            }
            else
            {
                leftQ.RemoveFirst();
                rightQ.RemoveFirst();
            }
        }
        //Left is integer; right is close bracket
        else if (leftValue <= 10 && rightValue == Convert.ToInt32(']'))
        {
            return false;
        }
        //Right is integer; left is close bracket
        else if (rightValue <= 10 && leftValue == Convert.ToInt32(']'))
        {
            return true;
        }
        //Left is integer; right is open bracket
        else if (leftValue <= 10 && rightValue == Convert.ToInt32('['))
        {
            leftQ.RemoveFirst();
            leftQ.AddFirst(Convert.ToInt32(']'));
            leftQ.AddFirst(leftValue);
            leftQ.AddFirst(Convert.ToInt32('['));
        }
        //Right is integer; left is open bracket
        else if (rightValue <= 10 && leftValue == Convert.ToInt32('['))
        {
            rightQ.RemoveFirst();
            rightQ.AddFirst(Convert.ToInt32(']'));
            rightQ.AddFirst(rightValue);
            rightQ.AddFirst(Convert.ToInt32('['));
        }
        //Both are open bracket
        else if (leftValue == Convert.ToInt32('[') && rightValue == Convert.ToInt32('['))
        {
            leftQ.RemoveFirst();
            rightQ.RemoveFirst();
        }
        //Both are close bracket
        else if (leftValue == Convert.ToInt32(']') && rightValue == Convert.ToInt32(']'))
        {
            leftQ.RemoveFirst();
            rightQ.RemoveFirst();
        }
        //left is open bracket right is close bracket
        else if (rightValue == Convert.ToInt32(']'))
        {
            return false;
        }
        //right is open bracket left is close bracket
        else if (leftValue == Convert.ToInt32(']'))
        {
            return true;
        }
    }
}

int firstOrder = 1;
int secondOrder = 2;

for (int i = 0; i < contents.Length; i++)
{
    LinkedList<int> firstKey = makeList("[[2]]");
    LinkedList<int> secondKey = makeList("[[6]]");
    string secondPair = contents[i];
    if (secondPair == "")
    {
        continue;
    }

    if (compare(makeList(secondPair), firstKey))
    {
        firstOrder++;
        secondOrder++;
    }
    else if (compare(makeList(secondPair), secondKey))
    {
        secondOrder++;
    }
}

Internal.Console.WriteLine("Key product: " + (firstOrder * secondOrder));
/* part2: 23111 */