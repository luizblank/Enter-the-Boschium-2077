using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;

public static class GUI
{
    public static Size Size { get; set; } = new Size(1, 1);
    public static List<Icon> Icons { get; private set; } = new List<Icon>();

    public static void Add(Icon icon)
        => Icons.Add(icon);
    public static void Remove(Icon icon)
        => Icons.Remove(icon);
    public static void Remove(int index)
        => Icons.RemoveAt(index);
    public static void Draw()
    {
        foreach (var icon in Icons)
            icon.Draw();
    }


    public static void DrawImage(this Graphics g, Image sprite, PointF position, Size size)
    {
        g.DrawImage( sprite,
            position.X,
            position.Y,
            size.Width,
            size.Height
        );
    }
    public static Size RelativeSize(this Image sprite, SizeF size)
    {
        float scale = Math.Min(size.Width / (float)sprite.Width, size.Height / (float)sprite.Height);
        return new Size(
            (int)(sprite.Width * scale),
            (int)(sprite.Height * scale)
        );
    }
}