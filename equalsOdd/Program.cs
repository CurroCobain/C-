public class Kata
{
    public static String equalsOdd(int x, int y)
    {
        if (x == y)
            return "equals";
        else return "odd";
    }
        
    public static void Main () {
        System.Console.WriteLine(equalsOdd(10,7));
        System.Console.WriteLine(equalsOdd(7, 7));

    }
}

