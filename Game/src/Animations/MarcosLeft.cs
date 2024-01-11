using System.Drawing;

public class MarcosLeft : Animation
{
    public override Image onFrame()
    {
        return Bitmap.FromFile("../../../Sprites/marcos left.png");
    }
}