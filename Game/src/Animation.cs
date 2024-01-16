using System;
using System.ComponentModel.Design;
using System.Drawing;

public abstract class Animation
{
    public int Frame = 0;
    public Animation Next = null;

    public abstract Animation NextFrame();
    public abstract void Draw(Graphics g, PointF position, SizeF size);
    public abstract Animation Clone();
    public virtual Animation Skip()
    {
        if (this.Next is null)
            return this.Clone();
        
        return this.Next;
    }
    protected virtual Size RelativeSize(Image sprite, SizeF size)
    {
        float scale = Math.Min(size.Width / (float)sprite.Width, size.Height / (float)sprite.Height);
        return new Size(
            (int)(sprite.Width * scale * Camera.Zoom),
            (int)(sprite.Height * scale * Camera.Zoom)
        );
    }
    protected virtual PointF PositionOnCam(PointF position)
    {
        float x = (position.X - Camera.Location.X) * Camera.Zoom;
        float y = (position.Y - Camera.Location.Y) * Camera.Zoom;

        return new PointF(x, y);
    }
}