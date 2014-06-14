using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class Program
{
    static Ransac[] RansacSettings;

    static void Main(string[] args)
    {
        RansacSettings = new Ransac[1];

        Console.WriteLine(System.DateTime.Now + " - Iteration 0");
        RansacSettings[0] = new Ransac(500, 3, 600, 600);

        Console.WriteLine( System.DateTime.Now +" - "+RansacSettings[0].ToString() );

        Console.ReadLine();

    }

}
