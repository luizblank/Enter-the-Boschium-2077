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
            g.DrawRectangle(Pens.Red, rect);
        }
    }

    public bool VerifyCollision(List<Rectangle> rectangles)
    {
        foreach (var rectangle in rectangles)
        {
            // continua a parada aqui
        }
    }
}