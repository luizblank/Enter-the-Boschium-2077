using System.Collections.Generic;
using System.Drawing;

public class Hitbox
{
    public List<RectangleF> Rectangles { get; set; }

    public Hitbox() {}
    public Hitbox(List<RectangleF> rectangles)
    {
        this.Rectangles = rectangles;
    }
}