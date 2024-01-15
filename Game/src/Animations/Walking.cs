using System.Drawing;

public class Walking : Animation
{
    public Image sprite = null;
    public int speed = 1;
    public Walk direction = Walk.Front;
    private int angle = 0;

    public override Animation NextFrame()
    {
        Bitmap bitmap = new Bitmap(sprite);
        Graphics g = Graphics.FromImage(bitmap);

        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
        g.TranslateTransform((float)sprite.Width / 2, (float)sprite.Height);

        g.RotateTransform(angle);

        g.TranslateTransform(-(float)sprite.Width / 2, -(float)sprite.Height);
        g.DrawImage(sprite, 0, 0, sprite.Width, sprite.Height);

        sprite = bitmap;
        return this;
    }

    public override Image Draw()
    {
        return sprite;
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