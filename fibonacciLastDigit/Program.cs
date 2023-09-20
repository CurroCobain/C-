using System;
using System.ComponentModel.Design;

public class Kata
{
    public static int GetLastDigit(int index)
    {
        int num1 = 0;
        int num2 = 1;
        int rep = 0;
        int numResult = 0;
        string strNumResult = "";
        var list = new List<int>();
        while (rep < index) {
            list.Add(numResult);
            numResult = num1 + num2;
            num1 = num2;
            num2 = numResult;
            rep++;
            if (rep == index) 
            {
                strNumResult = System.Convert.ToString(list.Last());
                strNumResult = strNumResult.Substring(strNumResult.Length - 1);
                numResult = System.Convert.ToInt16(strNumResult);
                return numResult;
            }
        }
       
        
      return 1;
    }
    public static void Main()
    {
        System.Console.WriteLine(GetLastDigit(10));
    }
}
