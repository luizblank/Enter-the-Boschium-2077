using System.Drawing;

public class MarcosDying : Animation
{
    int frameForCalc = 0;
    Image sprite = Bitmap.FromFile("src/Sprites/marcos/marcos-dying-sprites.png");

    public override Animation Clone()
    {
        return new MarcosDying() {
            Frame = 0,
        };
    }

    public override void Draw(Graphics g, PointF position, SizeF size)
    {   
        Bitmap frame = sprite.Cut(frameForCalc % 16, 16);

        if(frameForCalc >= 16)
        {
            frame = sprite.Cut(15, 16);
        }

        Size relativeSize = this.RelativeSize(frame, size * 1.2f);
        PointF camPosition = Functions.PositionOnCam(position);

        g.DrawImage(frame, camPosition, relativeSize);
    }

    public override Animation NextFrame()
    {
        this.Frame++;
        if (this.Frame % 8 == 0)
        {
            frameForCalc++;
        }
        return this;
    }
}