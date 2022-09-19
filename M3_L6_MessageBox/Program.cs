using System;
using M3_L6_MessageBox;

public class Program
{
    public static void Main()
    {
        var box = new MessageBox();
        box.Open();

        if (box.state == MessageBox.State.Ok)
        {
            Console.WriteLine("Operation confirmed");
        }
        else
        {
            Console.WriteLine("Operation canceled");
        }
    }
}
