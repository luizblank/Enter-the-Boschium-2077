using System.Collections.Generic;
using System.Drawing;

public class EletricGuitarEntity : Entity
{
    public EletricGuitarEntity(Graphics g, PointF position) : base(g)
    {
        this.Name = "Eletric Robotic Guitar";

        var rectangles = new List<RectangleF> {
            new RectangleF(
                Size.Width - 7,
                Size.Width - 11,
                15, 22
            )
        };
        this.Hitbox = new Hitbox(rectangles);

        this.Size = new SizeF(500, 500);
        this.Position = new PointF(
            position.X,
            position.Y
        );
    }
}
