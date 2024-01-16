using System.Drawing;

public class Angle : Animation
{
    public Image sprite = null;
    public Image rotated = null;
    private float angle = -10;

    public override Animation NextFrame()
    {
        return this;
    }

    public override void Draw(Graphics g, PointF position, SizeF size)
    {
        Size relativeSize = this.RelativeSize(sprite, size);
        PointF camPosition = this.PositionOnCam(position);

        g.TranslateTransform(
            camPosition.X + (float)relativeSize.Width / 2,
            camPosition.Y + (float)relativeSize.Height
        );
        g.RotateTransform(angle);
        g.TranslateTransform(
            -(camPosition.X + (float)relativeSize.Width / 2),
            -(camPosition.Y + (float)relativeSize.Height)
        );
        g.DrawImage(sprite,
            camPosition.X,
            camPosition.Y,
            relativeSize.Width, 
            relativeSize.Height);
    
        g.ResetTransform();
    }

    public override Animation Clone()
    {
        return new Walking()
        {
            sprite = this.sprite,
            Frame = 0,
        };
    }
}