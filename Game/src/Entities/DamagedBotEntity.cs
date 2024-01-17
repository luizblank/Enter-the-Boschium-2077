using System.Collections.Generic;
using System.Drawing;

public class DamagedBotEntity : Entity
{
    public DamagedBotEntity(Graphics g, PointF position) : base(g)
    {
        this.Name = "Damaged Bot";

        this.Size = new SizeF(85, 110);
        var rectangles = new List<RectangleF> {
            new RectangleF(
                -3, 0,
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

    public override void OnHit(Entity entity)
    {
    }
}