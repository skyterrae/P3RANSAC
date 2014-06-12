using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

partial class Ransac
{
    //part of the class that deals with the constructor and membervariables

    int amountOfPoints;             //n
    int amountOfPlanePoints;        //k
    int ballRadius; // In m.        //b
    int planeDistance; // In m.     //d
    
    int planeX, planeY; // In m!    //a
    int boxLength, boxWidth, boxHeight; // In m!

    int amountOfIterations, totalResult;
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

        boxLength = 50;
        boxWidth = 50;
        boxHeight = 20;

        amountOfIterations = 10;

        FillBox();

        FindPlane();
    }

    public override string ToString()
    {
        //for readability the variablenames are in it;
        //this can be changed though;
        return "k = " + amountOfPlanePoints + ", b = " + ballRadius + ", a = (" + planeX + "," + planeY + ") ; result = " + totalResult;
    }
}
