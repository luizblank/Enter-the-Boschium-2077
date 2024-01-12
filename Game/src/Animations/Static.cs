using System.Drawing;

public class Static : Animation
{
    public Image sprite = null;

    public override Animation NextFrame()
    {
        return this;
    }

    public override Image Draw()
    {
        return sprite;
    }

    public override Animation Clone()
    {
        return new Static() {
            sprite = this.sprite,
            Frame = 0,
            Next = this.Next,
        };
    }
}