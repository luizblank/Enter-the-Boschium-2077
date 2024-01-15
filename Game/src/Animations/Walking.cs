using System.Drawing;

public class Walking : Animation
{
    public Image sprite = null;
    public Image rotated = null;
    public float speed = 0.7f;
    public Walk direction = Walk.Front;
    private float angle = 0;

    public override Animation NextFrame()
    {
        angle += speed * (int)direction;

        if (angle > 5)
            direction = Walk.Back;
        else if (angle < -5)
            direction = Walk.Front;
        return this;
    }

    public override void Draw(Graphics g, PointF position, SizeF size)
    {
        Size relativeSize = this.RelativeSize(sprite, size);
        PointF camPosition = this.PositionOnCam(position);

        g.TranslateTransform(
            camPosition.X - (float)relativeSize.Width / 2,
            camPosition.Y
        );
        g.RotateTransform(angle);
        g.TranslateTransform(
            -(camPosition.X - (float)relativeSize.Width / 2),
            -(camPosition.Y)
        );
        g.DrawImage(sprite,
            camPosition.X - relativeSize.Width,
            camPosition.Y - relativeSize.Height,
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
            direction = this.direction
        };
    }
}