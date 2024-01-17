using System;
using System.Drawing;
using System.Drawing.Drawing2D;

public static class AnimationBuilder
{
    public static Bitmap Cut(this Image sprite, int index, int spritesQuant = 4)
    {
        RectangleF rect = new RectangleF((sprite.Width / spritesQuant) * index, 0, sprite.Width / spritesQuant, sprite.Height);

        Bitmap source = new Bitmap(sprite);
        Bitmap frame = source.Clone(rect, source.PixelFormat);

        return frame;
    }

    public static void AddAnimation(this Entity entity, Animation animation)
    {
        if (entity.Animation is null)
            entity.Animation = animation;
        else
            entity.Animation.Next = animation;
    }

    public static void AddStaticAnimation(this Entity entity, String local, Direction direction = Direction.BottomLeft)
    {
        Image sprite = Bitmap.FromFile("src/Sprites/" + local);
        entity.AddAnimation(new Static() {
            sprite = sprite.Cut((int) direction),
        });
    }

    public static void AddWalkingAnimation(this Entity entity, String local, Direction direction = Direction.BottomLeft)
    {
        Image sprite = Bitmap.FromFile("src/Sprites/" + local);
        entity.AddAnimation(new Walking() {
            sprite = sprite.Cut((int) direction),
        });
    }
}