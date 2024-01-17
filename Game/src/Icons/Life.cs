using System.Drawing;

public class Life : Icon
{
    public Mob Mob { get; set; }
    public float Gap { get; set; } = 2;
    public Image fullHeart = null;
    public Image midHeart = null;
    public Image voidHeart = null;

    public Life(Graphics g, Mob mob)
    : base(g, new SizeF(50, 50))
    {
        this.Mob = mob;
        this.Position = new PointF(10, 10);

        Image sprite = Bitmap.FromFile("src/Sprites/hearts/hearts-sprite.png");
        this.fullHeart = AnimationBuilder.Cut(sprite, 0, 3);
        this.midHeart = AnimationBuilder.Cut(sprite, 1, 3);
        this.voidHeart = AnimationBuilder.Cut(sprite, 2, 3);
    }

    public override void Draw()
    {
        var maxLife = Mob.MaxLife;
        var life = Mob.Life;
        var point = this.Position;

        for (int i = 0; i < maxLife; i += 2)
        {
            if(life > 1)
                g.DrawImage(fullHeart, point, fullHeart.RelativeSize(Size));
            else if (life == 1)
                g.DrawImage(midHeart, point, midHeart.RelativeSize(Size));
            else
                g.DrawImage(voidHeart, point, voidHeart.RelativeSize(Size));

            point.X += Gap + Size.Width;
            life -= 2;
        }
    }

    public override void OnClick() {}

    public override void OnMouse() {}
}
