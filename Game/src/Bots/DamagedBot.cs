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
        rectangle = new Rectangle(
            (int)this.entity.Position.X - 100,
            (int)this.entity.Position.Y - 100,
            200, 200);
    }

    public override void OnFrame(Player player)
    {
        if (player.Life > 0 && this.entity.Position.Distance(player.entity.Position) < 1000)
        {
            isMoving = true;
            verifyPosition(player.entity.Position.X, player.entity.Position.Y);
            nextPosition = player.entity.Position;

            this.entity.Move(new PointF(
                (1 - speed) * this.entity.Position.X + speed * nextPosition.X,
                (1 - speed) * this.entity.Position.Y + speed * nextPosition.Y
            ));
        }
        else
        {
            isMoving = true;
            verifyPosition(nextPosition.X, nextPosition.Y);

            if (nextPosition != PointF.Empty && this.entity.Position.Distance(nextPosition) < 5)
                nextPosition = new PointF(
                    Random.Shared.Next(rectangle.X, rectangle.X + rectangle.Width), 
                    Random.Shared.Next(rectangle.Y, rectangle.Y + rectangle.Height)
                );
            this.entity.Move(new PointF(
                (1 - speed) * this.entity.Position.X + speed * nextPosition.X,
                (1 - speed) * this.entity.Position.Y + speed * nextPosition.Y
            ));
        }
    }

    public void verifyPosition(float PlayerX, float PlayerY)
    {
        if (this.entity.Position.Y > PlayerY)
        {
            if (this.entity.Position.X > PlayerX)
                direction = Direction.TopLeft;
            else
                direction = Direction.TopRight;
        }
        else
        {
            if (this.entity.Position.X > PlayerX)
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