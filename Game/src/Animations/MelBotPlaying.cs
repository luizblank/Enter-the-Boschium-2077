using System.Drawing;

public class MelBotPlaying : Animation
{
    int frameForCalc = 0;
    Image sprite = Bitmap.FromFile("src/Sprites/mel-bot/mel-bot-playing-sprites.png");

    public override Animation Clone()
    {
        return new MelBotPlaying() {
            Frame = 0,
        };
    }

    public override void Draw(Graphics g, PointF position, SizeF size)
    {
        Bitmap frame = sprite.Cut(frameForCalc % 12, 12);

        Size relativeSize = this.RelativeSize(frame, size);
        PointF camPosition = Functions.PositionOnCam(position);

        g.DrawImage(frame, camPosition, relativeSize);
    }

    public override Animation NextFrame()
    {
        this.Frame++;
        if (this.Frame % 4 == 0)
        {
            frameForCalc++;
        }
        return this;
    }
}