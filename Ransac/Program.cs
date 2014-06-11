using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ransak
{
    class Program
    {
        #region Declarations

        static int amountOfPoints;
        static int amountOfPlanePoints;
        static int ballRadius; // In cm.
        static int planeDistance; // In cm.

        static int planeX, planeY; // In cm!

        static int boxLength, boxWidth, boxHeight; // In cm!

        #endregion

        static void Main(string[] args)
        {
            amountOfPoints = 8000;
            amountOfPlanePoints = 500;
            ballRadius = 0;
            planeDistance = 4;

            planeX = 600;
            planeY = 600;

            boxLength = 5000;
            boxWidth = 5000;
            boxHeight = 2000;
        }

        static Punt[] FillBox()
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

            // Which is then passed along as parameters to the CreatePoints() method.
            Punt[] pointList = CreatePoints(amountOfPlanePoints, minX, maxX, minY, maxY, boxCenterZ, boxCenterZ);

            // We now have an array of random points with size 'amountOfPlanePoints'.
            // Now, we need to randomize these with the RandomizePoints() method.

            // When this is done, create a new array of points size 'amountOfPoints', fill it with the randomized plane points
            // And then add 'amountofPoints - amountOfPlanePoints' extra points.

            // Finally, return that list.
            return pointList;
        }

        static Punt[] CreatePoints(int amountOfPoints, int x1, int x2, int y1, int y2, int z1, int z2)
        {
            Punt[] pointList = new Punt[amountOfPoints];
            Random random = new Random();

            int newX, newY, newZ;
            for (int i = 0; i < pointList.Length; i++)
            {
                newX = random.Next(x1, x2 + 1);
                newY = random.Next(y1, y2 + 1);

                if (z1 != z2)
                    newZ = random.Next(z1, z2 + 1);
                else newZ = z1;
                pointList[i] = new Punt(newX, newY, newZ);
            }

            return pointList;
        }

        static Punt[] RandomizePoints(Punt[] pointList)
        {
            Punt[] newList = new Punt[pointList.Length];

            foreach (Punt p in pointList)
            {
                // Create ball, create new random point within ball.
            }

            return newList;
        }
    }

    class Punt
    {
        public int X, Y, Z; // Working with ints is okay, because smallest size we use is cm's, which are still integers.

        public Punt(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Punt Add(Punt punt)
        {
            return new Punt(punt.X + this.X, punt.Y + this.Y, punt.Z + this.Z);
        }
    }
}
