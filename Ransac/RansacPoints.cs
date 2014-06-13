using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

partial class Ransac
{
    // part of the implemetation that takes care of filling the box

    public void FillBox()
    {   // punt K points on the plane and fills the rest of the box uniformly

        //first, we create 'amountOfPlanePoints' on the plane and put them in pointList
        pointList = new Punt[amountOfPoints];
        CreatePlanePoints();

        // The pointList array is now filled up untill 'amountOfPlanePoints'.
        // Now, we need to randomize these with the RandomizePoints() method.
        RandomizePlanePoints();

        // When this is done, create a new array of points size 'amountOfPoints', fill it with the randomized plane points
        // And then add 'amountofPoints - amountOfPlanePoints' extra points.
        CreateBoxPoints();
    }
    private void CreatePlanePoints()
    {
        // Some simple math to determine the beginning- and endcoördinates of the plane.
        int boxCenterX, boxCenterY, boxCenterZ;
        int minX, maxX, minY, maxY;

        boxCenterX = (0 + boxLength) / 2;
        boxCenterY = (0 + boxWidth) / 2;
        boxCenterZ = (0 + boxHeight) / 2;

        minX = boxCenterX - planeX / 2;
        maxX = boxCenterX + planeX / 2;
        minY = boxCenterY - planeY / 2;
        maxY = boxCenterY + planeY / 2;

        // Which are then passed along as parameters to the CreatePoints() method.
        CreatePoints(minX, maxX, minY, maxY, boxCenterZ, boxCenterZ, amountOfPlanePoints);
    }

    private void CreateBoxPoints()
    {
        //fills the array 'pointList' uniformly between indexes 500 (or 1000) and 8000
        CreatePoints(0, boxWidth, 0, boxLength, 0, boxHeight, amountOfPoints, amountOfPlanePoints);
    }

    private void CreatePoints(int x1, int x2, int y1, int y2, int z1, int z2, int endIndex, int startIndex = 0)
    {
        //creates the uniform random point between the given x,y,z-values
        int newX, newY, newZ;
        for (int i = startIndex; i < endIndex; i++)
        {
            newX = r.Next(x1, x2 + 1);
            newY = r.Next(y1, y2 + 1);

            if (z1 != z2)
                newZ = r.Next(z1, z2 + 1);
            else newZ = z1;
            pointList[i] = new Punt(newX, newY, newZ);
        }
    }

    private void RandomizePlanePoints()
    {
        //randomises the point on the plane within a ball of radius 'ballRadius'
        Punt V;
        for (int p = 0; p < amountOfPlanePoints; p++)
        {
            // Create ball on (0,0,0), create a shiftVector within ball.
            V = ShiftPointWithinBall(pointList[p], ballRadius);
            // apply this shift on pointList[p]
            pointList[p] = pointList[p].Add(V);
        }
    }

    private Punt ShiftPointWithinBall(Punt p, int BallRadius)
    {
        //shifts a point within a ball of a certain radius
        double X1, X2, X3, U;
        X1 = r.NextDouble();
        X2 = r.NextDouble();
        X3 = r.NextDouble();
        U = r.NextDouble();

        float D = ballRadius * (float)Math.Pow(U, ((double)1 / (double)3));

        double v = D / Math.Sqrt(Math.Pow(X1, 2) + Math.Pow(X2, 2) + Math.Pow(X3, 2));

        return new Punt((float)(v * X1), (float)(v * X2), (float)(v * X3));

    }
}
