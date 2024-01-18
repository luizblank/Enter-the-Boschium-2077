using System.Drawing;
using System.Windows.Forms;

public class Revolver : Animation
{
    public Image sprite = Bitmap.FromFile("src/Sprites/Guns/revolver.png");
    private float angle = 0;

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

        g.TranslateTransform(
            camPosition.X,
            camPosition.Y + (float)relativeSize.Height / 2
        );
        g.RotateTransform(angle);
        g.TranslateTransform(
            -(camPosition.X),
            -(camPosition.Y + (float)relativeSize.Height / 2)
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
        return new Revolver() {
            sprite = this.sprite,
            Frame = 0,
        };
    }
}