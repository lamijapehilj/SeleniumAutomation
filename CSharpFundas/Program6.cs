using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

ArrayList a = new ArrayList();
a.Add("hello");
a.Add("bye");
a.Add("Rahul");
a.Add("Apple");

Console.WriteLine(a[1]);

foreach(String item in a)
{
    Console.WriteLine(item);
}
Console.WriteLine(a.Contains("Rahul"));

Console.WriteLine("After sorting");
a.Sort();

foreach(string item in a)
{
    Console.WriteLine(item); 
}


