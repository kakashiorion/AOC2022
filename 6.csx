var contents = File.ReadAllLines("6.txt");

string inputString = contents[0];

for (int i = 3; i < inputString.Length; i++)
{
    string code = inputString.Substring(i - 3, 4);
    if (code.Substring(1).Contains(code[0]) || code.Substring(2).Contains(code[1]) || code.Substring(3).Contains(code[2]))
    {
        continue;
    }
    else
    {
        Internal.Console.WriteLine("Processed code: " + (i + 1));
        break;
    }
}
/* part1 :1702 */


for (int i = 13; i < inputString.Length; i++)
{
    string message = inputString.Substring(i - 13, 14);
    if (
        message.Substring(1).Contains(message[0]) || message.Substring(2).Contains(message[1]) || message.Substring(3).Contains(message[2]) ||
        message.Substring(4).Contains(message[3]) || message.Substring(5).Contains(message[4]) || message.Substring(6).Contains(message[5]) ||
        message.Substring(7).Contains(message[6]) || message.Substring(8).Contains(message[7]) || message.Substring(9).Contains(message[8]) ||
        message.Substring(10).Contains(message[9]) || message.Substring(11).Contains(message[10]) || message.Substring(12).Contains(message[11]) ||
        message.Substring(13).Contains(message[12])
    )
    {
        continue;
    }
    else
    {
        Internal.Console.WriteLine("Processed message: " + (i + 1));
        break;
    }
}

// Internal.Console.WriteLine(inputString);
