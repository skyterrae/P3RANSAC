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

        RansacSettings[0] = new Ransac(500, 3, 600, 600);

        Console.WriteLine( RansacSettings[0].ToString() );

        Console.ReadLine();

    }

}
