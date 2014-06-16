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

        amountOfIterations = 100;  // moet nog naar 100
        PlaneSupport = 0.9f;  // moet nog naar 0.9f voor 90%

        FillBox();

        FindThePlane();
    }
     public override string ToString()
    {
        //for readability the variablenames are in it;
        //this can be changed though;
       return "k=" + amountOfPlanePoints + ", b=" + ballRadius + ", a=(" + planeX + "," + planeY + ") ; result = " + totalResult;
    }

    public void ToStream(StreamWriter sw)
    {
        //for readability the variablenames are in it;
        //this can be changed though;
        sw.WriteLine("k=" + amountOfPlanePoints + ", b=" + ballRadius + ", a=(" + planeX + "," + planeY + ") ; result = " + totalResult);
        sw.WriteLine("Ordered list of loose values:");
        foreach (int i in results)
            sw.WriteLine(i + ";");
    }
}
