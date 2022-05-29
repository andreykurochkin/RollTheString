using System;
using System.Collections.Generic;
using System.Linq;

namespace RollTheString.Src;
public class Result
{
    public static string RollTheString(string s, List<int> rolls)
    {
        throw new NotImplementedException();
    }

    private const int Delta = 'z' - 'a' + 1;

    public static List<int> RollOperations(List<int> source)
    {
        var result = new int[source.Count + 1].ToList();

        for (int i = 0; i < source.Count; i++)
        {
            result[0] += 1;
            result[source[i]] -= 1;
        }
        for (int i = 1; i < source.Count; i++)
        {
            result[i] += result[i - 1]; 
        }

        return result.Take(source.Count).ToList();
    }

    public static char PerformRoll(char c, int rollValue)
    {
        return (char)
            ((c + rollValue - 'a') % Delta + 'a');
    }
}
