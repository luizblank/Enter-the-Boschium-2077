using System.Drawing;

public abstract class Animation
{
    public Animation Next = null;
    public int Speed;

    public abstract Image onFrame();
}