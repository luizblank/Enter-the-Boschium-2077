using System.Collections.Generic;
using System.Drawing;

public class RevolverEntity : Entity
{
    public float angle { get; set; }
    public RevolverEntity(Graphics g) : base(g)
    {
        this.Name = "Revolver";

        var rectangles = new List<RectangleF> {
            new RectangleF(
                Size.Width - 7,
                Size.Width - 11,
                15, 22
            )
        };
        this.Hitbox = new Hitbox(rectangles);

        this.Size = new SizeF(80, 80);
    }
}
