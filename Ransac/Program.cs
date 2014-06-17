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
        //Directory.GetCurrentDirectory();
        //StreamWriter SW = new StreamWriter(Directory.GetCurrentDirectory() + "/output.txt",true);
            //( Directory.GetCurrentDirectory() +"/output.txt", FileMode.Create);
        //iterate through all settings
        for (int i = 0; i < 1; i++)
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

            string text = System.DateTime.Now + " - Iteration " + i +", k="+k+", b="+b+", x="+x+", y="+y;
            Console.WriteLine(text);
            RansacSettings[i] = new Ransac(k, b, x, y);
            string path = "output.txt";
            RansacSettings[i].WriteToFile(path, text);
            RansacSettings[i].WriteToFile(path);
            //RansacSettings[i].ToStream(SW);
            Console.WriteLine( System.DateTime.Now +" - "+i+" - "+RansacSettings[i].ToString() );
        }
        //SW.WriteLine(System.DateTime.Now + " - Mission Accompished.");
        

        Console.ReadLine();

    }

}
