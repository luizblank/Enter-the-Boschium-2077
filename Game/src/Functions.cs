using System;
using System.Drawing;

public static class Functions
{
    public static double Distance(float Ax, float Ay, float Bx, float By)
    {
        float dx = Bx - Ax;
        float dy = By - Ay;
        return Math.Sqrt(
            dx * dx +
            dy * dy
        );
    }
    public static double Distance(this PointF A, PointF B)
        => Distance(A.X, A.Y, B.X, B.Y);
    public static double Distance(this PointF A, float Bx, float By)
        => Distance(A.X, A.Y, Bx, By);

    public static PointF LinearInterpolation(float Ax, float Ay, float Bx, float By, double t)
    {
        return new PointF(
            (float)((1 - t) * Ax + t * Bx),
            (float)((1 - t) * Ay + t * By)
        );
    }
    public static PointF LinearInterpolation(this PointF A, PointF B, double t)
        => LinearInterpolation(A.X, A.Y, B.X, B.Y, t);
    public static PointF LinearInterpolation(this PointF A, float Bx, float By, double t)
        => LinearInterpolation(A.X, A.Y, Bx, By, t);
}