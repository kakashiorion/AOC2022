var contents = File.ReadAllLines("5.txt");

char[] l1 = { 'B', 'Z', 'T' };
char[] l2 = { 'V', 'H', 'T', 'D', 'N' };
char[] l3 = { 'B', 'F', 'M', 'D' };
char[] l4 = { 'T', 'J', 'G', 'W', 'V', 'Q', 'L' };
char[] l5 = { 'W', 'D', 'G', 'P', 'V', 'F', 'Q', 'M' };
char[] l6 = { 'V', 'Z', 'Q', 'G', 'H', 'F', 'S' };
char[] l7 = { 'Z', 'S', 'N', 'R', 'L', 'T', 'C', 'W' };
char[] l8 = { 'Z', 'H', 'W', 'D', 'J', 'N', 'R', 'M' };
char[] l9 = { 'M', 'Q', 'L', 'F', 'D', 'S' };

Stack<char> stack1 = new Stack<char>(l1);
Stack<char> stack2 = new Stack<char>(l2);
Stack<char> stack3 = new Stack<char>(l3);
Stack<char> stack4 = new Stack<char>(l4);
Stack<char> stack5 = new Stack<char>(l5);
Stack<char> stack6 = new Stack<char>(l6);
Stack<char> stack7 = new Stack<char>(l7);
Stack<char> stack8 = new Stack<char>(l8);
Stack<char> stack9 = new Stack<char>(l9);

Stack<char>[] allStacksArray =
    { stack1, stack2, stack3, stack4, stack5, stack6, stack7, stack8, stack9 };
List<Stack<char>> allStacksList = new List<Stack<char>>(allStacksArray);

for (int i = 10; i < contents.Length; i++)
{
    var numberMoves = Convert.ToInt32(contents[i].Split(' ')[1]);
    var sourceStackIndex = Convert.ToInt32(contents[i].Split(' ')[3]) - 1;
    var destStackIndex = Convert.ToInt32(contents[i].Split(' ')[5]) - 1;
    var sStack = allStacksList[sourceStackIndex];
    var dStack = allStacksList[destStackIndex];

    for (int j = 0; j < numberMoves; j++)
    {
        char movingBlock = sStack.Pop();
        dStack.Push(movingBlock);
    }
}

string topBlocks = String.Concat(stack1.Peek(), stack2.Peek(), stack3.Peek(), stack4.Peek(), stack5.Peek(), stack6.Peek(), stack7.Peek(), stack8.Peek(), stack9.Peek());
Internal.Console.WriteLine("Stack: " + topBlocks);
/* part1: NTWZZWHFV */


var list1 = new List<char>(l1);
var list2 = new List<char>(l2);
var list3 = new List<char>(l3);
var list4 = new List<char>(l4);
var list5 = new List<char>(l5);
var list6 = new List<char>(l6);
var list7 = new List<char>(l7);
var list8 = new List<char>(l8);
var list9 = new List<char>(l9);
List<char>[] allListsArray = { list1, list2, list3, list4, list5, list6, list7, list8, list9 };
List<List<char>> allListsList = new List<List<char>>(allListsArray);

for (int i = 10; i < contents.Length; i++)
{
    var numberMoves = Convert.ToInt32(contents[i].Split(' ')[1]);
    var sourceListIndex = Convert.ToInt32(contents[i].Split(' ')[3]) - 1;
    var destListIndex = Convert.ToInt32(contents[i].Split(' ')[5]) - 1;
    var sList = allListsList[sourceListIndex];
    var dList = allListsList[destListIndex];

    List<char> movingBlock = sList.GetRange(sList.Count - numberMoves, numberMoves);
    sList.RemoveRange(sList.Count - numberMoves, numberMoves);
    dList.AddRange(movingBlock);

}

topBlocks = String.Concat(list1[^1], list2[^1], list3[^1], list4[^1], list5[^1], list6[^1], list7[^1], list8[^1], list9[^1]);
Internal.Console.WriteLine("Stack: " + topBlocks);
/* part2: BRZGFVBTJ */
