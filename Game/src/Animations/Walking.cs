using System.Drawing;

public class Walking : Animation
{
    public Image sprite = null;
    public float speed = .7f;
    public Walk direction = Walk.Front;
    private float angle = 0;

    public override Animation NextFrame()
    {
        angle += speed * (int)direction;

        if (angle > 5)
            direction = Walk.Back;
        else if (angle < -5)
            direction = Walk.Front;

        if (angle < speed && angle > -speed && Frame > 0)
            return this.Skip();

        Frame++;
        return this;
    }

    public override void Draw(Graphics g, PointF position, SizeF size)
    {
        Size relativeSize = this.RelativeSize(sprite, size);
        PointF camPosition = Functions.PositionOnCam(position);

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
            angle = this.angle,
            direction = this.direction
        };
    }
}