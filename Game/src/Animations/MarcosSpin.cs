using System.Drawing;
using System.Drawing.Imaging;

public class MarcosSpin : Animation
{
    Image sprite = Bitmap.FromFile("src/Sprites/Marcos/Marcos-sprites.png");

    public override Animation NextFrame()
    {
        this.Frame ++;
        return this;
    }

    public override void Draw(Graphics g, PointF position, SizeF size)
    {
        RectangleF rect = new RectangleF((sprite.Width / 4) * (this.Frame % 4), 0, sprite.Width / 4, sprite.Height);

        Bitmap source = new Bitmap(sprite);
        Bitmap frame = source.Clone(rect, source.PixelFormat);

        Size relativeSize = this.RelativeSize(frame, size);
        PointF camPosition = Functions.PositionOnCam(position);

        g.DrawImage(frame, camPosition.X, camPosition.Y, relativeSize.Width, relativeSize.Height);
    }

    public override Animation Clone()
    {
        return new MarcosSpin() {
            Frame = 0,
        };
    }
}