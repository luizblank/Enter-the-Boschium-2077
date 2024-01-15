using System.Drawing;

public abstract class Mob
{
    public Entity entity = null;
    
    public float MaxLife;
    public float Life;
    public int speed = 10;

    protected Mob(Graphics g)
    {
    }
}