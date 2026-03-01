using System;
using System.ComponentModel.Design;


//
String[] a = { "hello", "bye", "Rahul", "Shetty" };
int[] b = { 1, 2, 3, 4, 5 };

string[] a1 = new string[4];
a1[0] = "hello";
a1[1] = "bye";

Console.WriteLine(a[1]);

for (int i = 0; i < a.Length; i++)
{
    Console.WriteLine(a[i]);
    if (a[i] == "Rahul")
    {
        Console.WriteLine("Match found");
        break;
    }
    
}
