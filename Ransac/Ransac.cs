using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

partial class Ransac
{
    //part of the class that deals with the constructor and membervariables

    int amountOfPoints;             //n
    int amountOfPlanePoints;        //k
    int ballRadius; // In cm.       //b
    int planeDistance; // In cm.    //d
    
    int planeX, planeY; // In cm!   //a
    int boxLength, boxWidth, boxHeight; // In cm!

    int amountOfIterations, totalResult;
    float PlaneSupport;
    int[] results;

    Random r;

    Punt[] pointList;

    public Ransac(int k, int b, int pX, int pY)
    {
        r = new Random();
        amountOfPoints = 8000;
        amountOfPlanePoints = k;

        ballRadius = b;
        planeDistance = 4;

        planeX = pX;
        planeY = pY;

        boxLength = 5000;
        boxWidth = 5000;
        boxHeight = 2000;

        amountOfIterations = 100;  
        PlaneSupport = 0.9f;  

        FillBox();

        FindThePlane();
    }
    public override string ToString()
    {
        //for readability the variablenames are in it;
        //this can be changed though;
       return "k=" + amountOfPlanePoints + ", b=" + ballRadius + ", a=(" + planeX + "," + planeY + ") ; result = " + totalResult;
    }

    public void WriteToFile(string path, string text = "")
    {
        StreamWriter writer = new StreamWriter(path, true); // Bool true zorgt ervoor dat als file al bestaat, hij de text eraan toevoegd (append).

        if (text == "")
        {
            writer.WriteLine("k;b;x;y;result");
            writer.WriteLine(amountOfPlanePoints+";" +ballRadius+";" +planeX+";" +planeY+";" + totalResult);
            writer.WriteLine("Ordered list of all loose values:");
            foreach (int i in results)
                writer.WriteLine(i);
        }
        else
        {
            writer.WriteLine(text);
        }
        writer.Close();

    }
}
