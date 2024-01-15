using System.Drawing;

public abstract class Bot : Mob 
{
    public float Damage { get; set; }
    public Bot(Graphics g) : base(g) {}

    public abstract void OnFrame(Player player);
}