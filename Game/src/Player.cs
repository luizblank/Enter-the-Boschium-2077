using System.Drawing;
using System.Windows.Forms;

public class Player : Mob
{
    public Player(Graphics g) : base(g) {}
    public string spriteLocal { get; set; }
    public Direction direction = Direction.BottomLeft;
    public Walk WalkX = Walk.Stop;
    public Walk WalkY = Walk.Stop;

    public override void OnFrame()
    {
        this.Move();
        if (WalkX != Walk.Stop || WalkY != Walk.Stop)
            this.entity.AddWalkingAnimation(spriteLocal, direction);
        else
            this.entity.AddStaticAnimation(spriteLocal, direction);
    }

    public override void OnKeyDown(object o, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.A:
                WalkX = Walk.Back;
                break;

            case Keys.D:
                WalkX = Walk.Front;
                break;

            case Keys.W:
                WalkY = Walk.Back;
                break;

            case Keys.S:
                WalkY = Walk.Front;
                break;
        }
    }

    public override void OnKeyUp(object o, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.A:
                WalkX = Walk.Stop;
                break;

            case Keys.D:
                WalkX = Walk.Stop;
                break;

            case Keys.W:
                WalkY = Walk.Stop;
                break;

            case Keys.S:
                WalkY = Walk.Stop;
                break;
        }
    }

    public override void OnMouseMove(object o, MouseEventArgs e)
    {
        if (e.Location.Y > this.entity.RelativePosition().Y) {
            if (e.Location.X > this.entity.RelativePosition().X)
                direction = Direction.BottomRight;
            else
                direction = Direction.BottomLeft;
        } else {
            if (e.Location.X > this.entity.RelativePosition().X)
                direction = Direction.TopRight;
            else
                direction = Direction.TopLeft;
        }
    }

    private void Move()
        => entity.Move(new PointF(entity.Position.X + speed * (int)WalkX, entity.Position.Y + speed * (int)WalkY));
}