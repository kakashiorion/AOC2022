string[] input = File.ReadAllLines("20.txt");

List<int> grooves = new List<int>();
List<int> indices = new List<int>();
for (int i = 0; i < input.Length; i++)
{
    grooves.Add(Convert.ToInt32(input[i]));
    indices.Add(i);
}

int groovesLength = grooves.Count;
for (int i = 0; i < groovesLength; i++)
{
    int indexA = indices.FindIndex(x => x == i);
    indices.Remove(i);
    int newIndex = (indexA + grooves[i] + (groovesLength - 1) * 3) % (groovesLength - 1);
    indices.Insert(newIndex == 0 ? groovesLength - 1 : newIndex, i);
}
int zeroIndex = indices.FindIndex(x => grooves[x] == 0);
int index1 = grooves[indices[(zeroIndex + 1000) % groovesLength]];
int index2 = grooves[indices[(zeroIndex + 2000) % groovesLength]];
int index3 = grooves[indices[(zeroIndex + 3000) % groovesLength]];

Internal.Console.WriteLine("I1: " + (index1));
Internal.Console.WriteLine("I2: " + (index2));
Internal.Console.WriteLine("I3: " + (index3));
Internal.Console.WriteLine("Sum: " + (index1 + index2 + index3));
/* part1: 18257 */

const long decryptionKey = 811589153;
List<int> grooves2 = new List<int>();
List<int> indices2 = new List<int>();
for (int i = 0; i < input.Length; i++)
{
    grooves2.Add(Convert.ToInt32(input[i]));
    indices2.Add(i);
}
int grooves2Length = grooves2.Count;

mixing2(10);

public void mixing2(int times)
{
    for (int k = 0; k < times; k++)
    {
        for (int i = 0; i < grooves2Length; i++)
        {
            int indexA = indices2.FindIndex(x => x == i);
            indices2.Remove(i);
            long xyz = (long)grooves2[i] * decryptionKey;
            long newIndex = (long)indexA + xyz;
            if (newIndex < 0)
            {
                while (newIndex < 0)
                {
                    newIndex = ((newIndex + grooves2Length - 1) % (grooves2Length - 1));
                }
            }
            if (newIndex > (grooves2Length - 1))
            {
                newIndex = newIndex % (grooves2Length - 1);
            }
            int newIndex2 = (int)newIndex;
            indices2.Insert(newIndex2 == 0 ? grooves2Length - 1 : newIndex2, i);
        }
    }
}
int zeroIndex2 = indices2.FindIndex(x => grooves2[x] == 0);
long index12 = grooves2[indices2[(zeroIndex2 + 1000) % grooves2Length]] * decryptionKey;
long index22 = grooves2[indices2[(zeroIndex2 + 2000) % grooves2Length]] * decryptionKey;
long index32 = grooves2[indices2[(zeroIndex2 + 3000) % grooves2Length]] * decryptionKey;

Internal.Console.WriteLine("I1: " + (index12));
Internal.Console.WriteLine("I2: " + (index22));
Internal.Console.WriteLine("I3: " + (index32));
Internal.Console.WriteLine("Sum: " + (index12 + index22 + index32));
/* part2: 4148032160983 */