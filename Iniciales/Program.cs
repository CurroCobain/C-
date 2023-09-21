public partial class Kata
{
    public static string MakeString(string s)
    {
        string myStr = "";

        if (s[0] != ' ')
        {
            myStr += s[0];
        }

        for (int i = 1; i < s.Length - 1; i++)
        {
            if (s[i] == ' ')
            {
                myStr += s[i + 1];
            }
        }
        return myStr;
    }
}