<<<<<<< HEAD
﻿using System.ComponentModel;

public class Kata
{
    public static Boolean unosAndCeros (string oneCerosChain)
    {
        string str1 = "";
        string str2 = "";
        int cont1 = 0;
        int cont2 = 0;
        for (int i = 0; i < oneCerosChain.Length; i++)
        {
            string str = oneCerosChain[i].ToString();
            if (i == 0 && str == "0")
            {
                return false;
            }
            else if (str == "1")
            {
                str1 = str1 + "1";
                if (cont2 != 0 && cont1 != 0)
                {
                    if (cont1 != cont2)
                    {
                        return false;
                    }
                    else
                    {
                        cont1 = 0;
                    }
                }
                cont1++;
            }
            else if (str == "0")
            {
                str2 = str2 + "0";
                if (cont2 != 0 && cont1 != 0)
                {
                    if (cont1 != cont2)
                    {
                        return false;
                    }
                    else
                    {
                        cont2 = 0;
                    }
                    cont2++;
                }
            }
        }
        if (str1.Length == str2.Length) {
            return true;

         }
        return false; 
    }
    public static void Main()
    {
        System.Console.WriteLine(unosAndCeros("111000111000"));
    }
=======
﻿using System.ComponentModel;

public class Kata
{
    public static Boolean unosAndCeros (string oneCerosChain)
    {
        string str1 = "";
        string str2 = "";
        int cont1 = 0;
        int cont2 = 0;
        for (int i = 0; i < oneCerosChain.Length; i++)
        {
            string str = oneCerosChain[i].ToString();
            if (i == 0 && str == "0")
            {
                return false;
            }
            else if (str == "1")
            {
                str1 = str1 + "1";
                if (cont2 != 0 && cont1 != 0)
                {
                    if (cont1 != cont2)
                    {
                        return false;
                    }
                    else
                    {
                        cont1 = 0;
                    }
                }
                cont1++;
            }
            else if (str == "0")
            {
                str2 = str2 + "0";
                if (cont2 != 0 && cont1 != 0)
                {
                    if (cont1 != cont2)
                    {
                        return false;
                    }
                    else
                    {
                        cont2 = 0;
                    }
                    cont2++;
                }
            }
        }
        if (str1.Length == str2.Length) {
            return true;

         }
        return false; 
    }
    public static void Main()
    {
        System.Console.WriteLine(unosAndCeros("111000111000"));
    }
>>>>>>> 155e288acf783cfcbb5212d2cdef77cad8a1eacf
}