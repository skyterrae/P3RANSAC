using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Punt
{
    // simple implementation of a 3D pointF

    public float X, Y, Z; 

    public Punt(float x, float y, float z)
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