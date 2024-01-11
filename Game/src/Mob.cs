using System.Drawing;

public abstract class Mob
{
    public Entity entity = null;

    public float MaxLife;
    public float Life;

    protected Mob(Graphics g)
    {
    }
}