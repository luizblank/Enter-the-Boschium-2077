using System;
using System.Drawing;

public class DamagedBot : Bot
{
    private bool isMoving = false;
    Direction direction = Direction.BottomLeft;
    Rectangle rectangle = Rectangle.Empty;
    PointF nextPosition = PointF.Empty;

    public DamagedBot(Graphics g) : base(g)
    {
        this.Damage = 3;
        this.speed = 0.005f;
    }

    public override void Set(Entity entity)
    {
        base.Set(entity);

    }

    public override void OnFrame(Player player)
    {
        if (player.Life > 0 && this.entity.Position.Distance(player.entity.Position) < 1000)
        {
            isMoving = true;
            verifyPosition();
            nextPosition = player.entity.Position;
        }
        else
        {
            rectangle = new Rectangle(
                (int)this.entity.Position.X - 200,
                (int)this.entity.Position.Y - 200,
                400, 400);
            isMoving = true;
            verifyPosition();

            if (nextPosition == PointF.Empty || this.entity.Position.Distance(nextPosition) < 100)
                nextPosition = new PointF(
                    Random.Shared.Next(rectangle.X, rectangle.X + rectangle.Width),
                    Random.Shared.Next(rectangle.Y, rectangle.Y + rectangle.Height)
                );
        }
        this.entity.Move(
            this.entity.Position.LinearInterpolation(
                nextPosition,
                speed)
        );
    }

    public void verifyPosition()
    {
        if (this.entity.Position.Y > nextPosition.Y)
        {
            if (this.entity.Position.X > nextPosition.X)
                direction = Direction.TopLeft;
            else
                direction = Direction.TopRight;
        }
        else
        {
            if (this.entity.Position.X > nextPosition.X)
                direction = Direction.BottomLeft;
            else
                direction = Direction.BottomRight;
        }

        if (isMoving == true)
        {
            this.entity.AddWalkingAnimation("damaged-bot/damaged-bot-sprites.png", direction);
        }
        else
        {
            this.entity.AddStaticAnimation("damaged-bot/damaged-bot-sprites.png", Direction.BottomLeft);
        }
    }
}