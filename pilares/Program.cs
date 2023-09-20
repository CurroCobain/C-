using System.Runtime.InteropServices;

public class Kata
{
    public static  int Pillars( int numPill, int dist, int width)
    {
        if (numPill > 2)
        {
            return (((numPill - 1) * dist) * 10) - (width * 2);
        }
        else if (numPill == 2) 
        {
            return dist;
        }
        return 0;
    }
    public static void Main()
    {
        System.Console.WriteLine(Pillars(2, 10, 10));
    }
}

