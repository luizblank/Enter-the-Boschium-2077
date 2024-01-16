using System.Collections.Generic;
using System.Drawing;

public class HamiltonBotEntity : Entity
{
    public HamiltonBotEntity(Graphics g, PointF position) : base(g)
    {
        this.Name = "Bolem Bot";

        this.Size = new SizeF(100, 160);
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