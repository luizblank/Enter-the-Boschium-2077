using System.Collections.Generic;
using System.Drawing;

public class DamagedBotEntity : Entity
{
    public DamagedBotEntity(Graphics g, PointF position) : base(g)
    {
        this.Name = "Damaged Bot";

        var rectangles = new List<RectangleF> {
            new RectangleF(
                Size.Width - 7,
                Size.Width - 11,
                15, 22
            )
        };
        this.Hitbox = new Hitbox(rectangles);

        this.Size = new SizeF(110, 110);
        this.Position = new PointF(
            position.X,
            position.Y
        );
    }
}