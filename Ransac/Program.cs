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

        //iterate through all settings
        for (int i = 0; i < 2; i++)
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

            string text = "Setting " + i +", k="+k+", b="+b+", x="+x+", y="+y;
            Console.WriteLine(System.DateTime.Now + " - " + text);
            RansacSettings[i] = new Ransac(k, b, x, y);
            RansacSettings[i].WriteToFile("output"+i+".txt");
            Console.WriteLine( System.DateTime.Now +" - "+i+" - "+RansacSettings[i].ToString() );
        }
        Console.WriteLine(System.DateTime.Now + " - Mission Accompished.");
        

        Console.ReadLine();

    }

}
