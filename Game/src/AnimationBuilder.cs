using System;
using System.Drawing;

public static class AnimationBuilder
{
    private static Bitmap Cut(this Image sprite, int index, int spritesQuant = 4)
    {
        RectangleF rect = new RectangleF((sprite.Width / spritesQuant) * index, 0, sprite.Width / spritesQuant, sprite.Height);

        Bitmap source = new Bitmap(sprite);
        Bitmap frame = source.Clone(rect, source.PixelFormat);

        return frame;
    }
    public static void BottomRight(this Entity entity, String local)
    {
        Image sprite = Bitmap.FromFile("src/Sprites/" + local);
        entity.Animation = new Static() {
            sprite = sprite.Cut(0),
        };
    }

    public static void BottomLeft(this Entity entity, String local)
    {
        Image sprite = Bitmap.FromFile("src/Sprites/" + local);
        entity.Animation = new Static() {
            sprite = sprite.Cut(1),
        };
    }

    public static void TopLeft(this Entity entity, String local)
    {
        Image sprite = Bitmap.FromFile("src/Sprites/" + local);
        entity.Animation = new Static() {
            sprite = sprite.Cut(2),
        };
    }

    public static void TopRight(this Entity entity, String local)
    {
        Image sprite = Bitmap.FromFile("src/Sprites/" + local);
        entity.Animation = new Static() {
            sprite = sprite.Cut(3),
        };
    }
}