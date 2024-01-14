using System.Collections.Generic;
using System.Drawing;

public class Marcos : Entity
{
    public Marcos(Graphics g, PointF position) : base(g)
    {
        this.Name = "Marcos";

        var rectangles = new List<RectangleF> {
            new RectangleF(
                Size.Width - 7,
                Size.Width - 11,
                15, 22
            )
        };
        this.Hitbox = new Hitbox(rectangles);

        this.Size = new SizeF(100, 100);
        this.Position = new PointF(
            position.X,
            position.Y
        );
    }
}