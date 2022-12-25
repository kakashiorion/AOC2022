string[] input = File.ReadAllLines("25.txt");

public double convertSnafuToNumber(string s)
{
    int l = s.Length;
    double number = 0;
    foreach (char c in s)
    {
        l--;
        if (c.Equals('2'))
        {
            number += Math.Pow(5, l) * 2;
        }
        else if (c.Equals('1'))
        {
            number += Math.Pow(5, l);
        }
        else if (c.Equals('-'))
        {
            number -= Math.Pow(5, l);
        }
        else if (c.Equals('='))
        {
            number -= Math.Pow(5, l) * 2;
        }
        else
        {
            number += 0;
        }
    }
    return number;
}

public string convertNumberToSnafu(double number)
{
    string s = "";
    do
    {
        s = s.Insert(0, (number % 5).ToString());
        number /= 5;
        number = Math.Floor(number);
    } while (number != 0);
    // Internal.Console.WriteLine(s);
    string y = "";
    for (int i = s.Length - 1; i >= 0; i--)
    {
        char c = s[i];
        if (c == '0')
        {
            y = y.Insert(0, "0");
        }
        else if (c == '1')
        {
            // if (y[0])
        }

    }


    return s;
}

double sum = 0;
for (int i = 0; i < input.Length; i++)
{
    sum += convertSnafuToNumber(input[i]);
}
Internal.Console.WriteLine("Sum of Snafu: " + sum);

// double sum = 34182852926025;
/* part1 : 2-0-01==0-1=2212=100 */