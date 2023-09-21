using System;

public static class Kata
{
    public static int Solve(string str)
    {
        string longest = "";
        int longestLenth = 0;
        var vowelsList = new List<Char> { 'a','e','i','o','u' };
        for (int i = 0; i < str.Length; i++)
            if (vowelsList.Contains(str[i]))
                System.Console.WriteLine(str[i]);

        throw new NotImplementedException();
    }
    public static void Main ()
    {
        string str = "ajsdhadhisaod";
        Solve(str);
    }
}
