using System.Drawing;

public class DamagedBot : Bot{
    float speed = 0.005f;
    public DamagedBot(Graphics g) : base(g)
    {
        this.Damage = 3;
    }

    public override void OnFrame(Player player) {
        if (this.entity.Position.Y > player.entity.Position.Y) {
            if (this.entity.Position.X > player.entity.Position.X)
                this.entity.AddStaticAnimation("Damaged bot/damaged-bot-sprites.png", Direction.TopLeft);
            else
                this.entity.AddStaticAnimation("Damaged bot/damaged-bot-sprites.png", Direction.TopRight);
        } else {
            if (this.entity.Position.X > player.entity.Position.X)
                this.entity.AddStaticAnimation("Damaged bot/damaged-bot-sprites.png", Direction.BottomLeft);
            else
                this.entity.AddStaticAnimation("Damaged bot/damaged-bot-sprites.png", Direction.BottomRight);
        }

        this.entity.Position = new PointF(
            (1 - speed) * this.entity.Position.X + speed * player.entity.Position.X,
            (1 - speed) * this.entity.Position.Y + speed * player.entity.Position.Y
        );
    }
}