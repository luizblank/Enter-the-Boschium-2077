using System.Collections.Generic;
using System.Drawing;

public class Marcos : Entity
{
    public Marcos(Graphics g, PointF position) : base(g)
    {
        this.Name = "Marcos";

        this.Size = new SizeF(75, 100);
        var rectangles = new List<RectangleF> {
            new RectangleF(
                0, 0,
                Size.Width,
                Size.Height
            )
        };
        this.Hitbox = new Hitbox(rectangles);

        this.Position = new PointF(
            position.X,
            position.Y
        );
    }
}