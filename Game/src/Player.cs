using System.Drawing;

public class Player : Mob
{
    public Player(Graphics g) : base(g) {}

    public void Move(Walk x, Walk y)
        => entity.Move(new PointF(entity.Position.X + speed * (int)x, entity.Position.Y + speed * (int)y));
}