using System.ComponentModel.Design;
using System.Drawing;

public abstract class Animation
{
    public int Frame = 0;
    public Animation Next = null;

    public abstract Animation NextFrame();
    public abstract Image Draw();
    public abstract Animation Clone();
    public virtual Animation Skip()
    {
        if (this.Next is null)
            return this.Clone();
        
        return this.Next;
    }
}