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
    public Punt Multiply(float f)
    {
        return new Punt(this.X * f, this.Y * f, this.Z * f);
    }
    public Punt Substract(Punt punt)
    {
        return new Punt(this.X - punt.X, this.Y - punt.Y, this.Z - punt.Z);
    }
    public Punt Cross(Punt p)
    {
        return new Punt(this.Y * p.Z - this.Z * p.Y, this.Z * p.X - this.X * p.Z, this.X * p.Y - this.Y * p.X);
    }
    public float Dot(Punt p)
    {
        return this.X * p.X + this.Y * p.Y + this.Z * p.Z;
    }
    public float Length
    {
        get { return (float) Math.Sqrt(Math.Pow(X,2) + Math.Pow(Y,2)+Math.Pow(Z,2) ); }
    }
    public static float DistanceFromPlane(Punt a, Punt b, Punt c, Punt p)
    {
        //plane gaat door a en heeft normaalvector N = (b-a)X(c-a)
        Punt N = b.Substract(a).Cross(c.Substract(a));
        
        //http://mathworld.wolfram.com/Plane.html
        //http://mathworld.wolfram.com/Point-PlaneDistance.html
        //maakt vector van a naar p, projecteert deze op N en geeft zijn lengte terug
        float D = (N.X * p.X + N.Y*p.Y + N.Z*p.Z -N.X*a.X -N.Y*a.Y -N.Z*a.Z)/N.Length;
        return D;
    }
}