string[] input = File.ReadAllLines("21.txt");

Dictionary<string, string> allMonkeys = new Dictionary<string, string>();
for (int i = 0; i < input.Length; i++)
{
    string key = input[i].Split(": ")[0];
    string value = input[i].Split(": ")[1];
    allMonkeys.Add(key, value);
}

public long calculateMonkeyResult(string monkeyName)
{
    string value = allMonkeys[monkeyName];
    if (value.Contains(" "))
    {
        string key1 = value.Split(" ")[0];
        string operand = value.Split(" ")[1];
        string key2 = value.Split(" ")[2];
        long op1 = calculateMonkeyResult(key1);
        long op2 = calculateMonkeyResult(key2);
        return getResult(op1, operand, op2);
    }
    else
    {
        return Convert.ToInt64(value);
    }
}

public long getResult(long op1, string operand, long op2)
{
    if (operand == "+")
    {
        return op1 + op2;
    }
    else if (operand == "-")
    {
        return op1 - op2;
    }
    else if (operand == "*")
    {
        return op1 * op2;
    }
    else
    {
        return op1 / op2;
    }
}

long result1 = calculateMonkeyResult("root");

Internal.Console.WriteLine("root result: " + result1);
/* part1: 124765768589550 */


// long result = calculateMonkeyResult("mwrd");
// Internal.Console.WriteLine("mwrd result before: " + result);

// allMonkeys["mwrd"] = "1";
// result = calculateMonkeyResult("mwrd");
// Internal.Console.WriteLine("mwrd result after: " + result);

const string rootValue = "34588563455325";
const string humanValue = "2950";

public bool containsHumanInChain(string monkeyName)
{
    long value1 = calculateMonkeyResult(monkeyName);
    allMonkeys["humn"] = "1";
    long value2 = calculateMonkeyResult(monkeyName);
    allMonkeys["humn"] = humanValue;
    if (value1 == value2)
    {
        return false;
    }
    return true;
}

string monkeyBeingAnalysed = "hsdb";
long result2 = 34588563455325;

do
{
    string value = allMonkeys[monkeyBeingAnalysed];
    string m1 = value.Split(" ")[0];
    string m2 = value.Split(" ")[2];
    string operand = value.Split(" ")[1];
    long temp = 0;
    if (containsHumanInChain(m1))
    {
        temp = calculateMonkeyResult(m2);
        monkeyBeingAnalysed = m1;
        result2 = getValue1(result2, operand, temp);
    }
    else
    {
        temp = calculateMonkeyResult(m1);
        monkeyBeingAnalysed = m2;
        result2 = getValue2(result2, operand, temp);
    }
} while (monkeyBeingAnalysed != "humn");

Internal.Console.WriteLine("Human value: " + result2);
/* part2: 3059361893920 */

public long getValue1(long finalResult, string operand, long secondMonkeyValue)
{
    if (operand == "+")
    {
        return finalResult - secondMonkeyValue;
    }
    else if (operand == "-")
    {
        return finalResult + secondMonkeyValue;
    }
    else if (operand == "*")
    {
        return finalResult / secondMonkeyValue;
    }
    else
    {
        return finalResult * secondMonkeyValue;
    }
}

public long getValue2(long finalResult, string operand, long firstMonkeyValue)
{
    if (operand == "+")
    {
        return finalResult - firstMonkeyValue;
    }
    else if (operand == "-")
    {
        return firstMonkeyValue - finalResult;
    }
    else if (operand == "*")
    {
        return finalResult / firstMonkeyValue;
    }
    else
    {
        return firstMonkeyValue / finalResult;
    }
}