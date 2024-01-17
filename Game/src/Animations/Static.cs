using System.Drawing;

public class Static : Animation
{
    public Image sprite = null;

    public override Animation NextFrame()
    {
        if (Next is null)
            return this;
        return Next;
    }

    public override void Draw(Graphics g, PointF position, SizeF size)
    {
        Size relativeSize = this.RelativeSize(sprite, size);
        PointF camPosition = Functions.PositionOnCam(position);

        g.DrawImage(sprite, camPosition.X, camPosition.Y, relativeSize.Width, relativeSize.Height);
    }

    public override Animation Clone()
    {
        return new Static() {
            sprite = this.sprite,
            Frame = 0,
        };
    }
}