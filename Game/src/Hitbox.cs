using System.Collections.Generic;
using System.Drawing;

public class Hitbox
{
    public List<RectangleF> Rectangles { get; set; }
    public Pen pen = Pens.Red;

    public Hitbox() {}
    public Hitbox(List<RectangleF> rectangles)
    {
        this.Rectangles = rectangles;
    }

    public void Draw(Graphics g, PointF position)
    {
        foreach (var rectangle in Rectangles)
        {
            PointF location = new PointF(
                rectangle.Location.X + position.X,
                rectangle.Location.X + position.Y
            );
            PointF rectLoc = Functions.PositionOnCam(location);
            Rectangle rect = new Rectangle(
                (int)rectLoc.X,
                (int)rectLoc.Y,
                (int)(rectangle.Width * Camera.Zoom),
                (int)(rectangle.Height * Camera.Zoom)
            );
            g.DrawRectangle(pen, rect);
        }
    }

    public bool VerifyCollision(Entity A, Entity B)
    {
        foreach (var rectA in A.Hitbox.Rectangles)
        {
            foreach (var rectB in B.Hitbox.Rectangles)
            {
                var entityARect = new RectangleF(
                    A.Position.X + rectA.X,
                    A.Position.Y + rectA.Y,
                    rectA.Width,
                    rectA.Height
                );
                var entityBRect = new RectangleF(
                    B.Position.X + rectB.X,
                    B.Position.Y + rectB.Y,
                    rectB.Width,
                    rectB.Height
                );
                if (entityARect.IntersectsWith(entityBRect))
                {
                    A.OnHit(B);
                    return true;
                }
            }
        }

        return false;
    }
}