using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

class Program
{
    static Ransac[] RansacSettings;

    static void Main(string[] args)
    {
        RansacSettings = new Ransac[40];
        int IterateAmount = 700;

        //iterate through all settings
        for (int i = 0; i < RansacSettings.Length; i++)
        {
            int k;
            if (i < 20)
                k = 500;
            else k = 1000;
            int x, y;
            if ((i % 20) < 5)
            { x = 600; y = 600; }
            else if ((i % 20) < 10)
            { x = 900; y = 400; }
            else if ((i % 20) < 15)
            { x = 1200; y = 300; }
            else 
            { x = 1500; y = 240; }
            int b = i % 5;

            Console.WriteLine(System.DateTime.Now + " - Setting " + i +", k="+k+", b="+b+", x="+x+", y="+y);
            RansacSettings[i] = new Ransac(k, b, x, y, IterateAmount);
            RansacSettings[i].WriteToFile("output"+i+".txt");
            Console.WriteLine( System.DateTime.Now +" - Setting "+i+", "+RansacSettings[i].ToString() );
        }
        Console.WriteLine(System.DateTime.Now + " - Mission Accompished.");     

        Console.ReadLine();
    }

}
