using System.Collections.Generic;
using System.Drawing;

public class HamiltonBotEntity : Entity
{
    public HamiltonBotEntity(Graphics g, PointF position) : base(g)
    {
        this.Name = "Bolem Bot";

        var rectangles = new List<RectangleF> {
            new RectangleF(
                Size.Width - 9,
                Size.Width - 16,
                19, 32
            )
        };
        this.Hitbox = new Hitbox(rectangles);

        this.Size = new SizeF(140, 160);
        this.Position = new PointF(
            position.X,
            position.Y
        );
    }
}