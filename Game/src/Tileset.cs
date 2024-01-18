using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;

public class Tileset
{
    protected Graphics g;
    private Sprite sprite;

    public PointF Position { get; protected set; }

    public SizeF Size => sprite.Rect.Size;

    public static List<Tileset> GetAll()
    {
        var tilesets = new List<Tileset>();
        var tilesetSprite = Bitmap.FromFile(@"./Sprites/tileset/tileset.png") as Bitmap;

        var y2 = 0;
        for (int j = 0; j < 9; j++)
        {
            for (int i = 0; i < 20; i++)
            {
                var sprite = new Sprite(tilesetSprite);
                sprite.Rect = new RectangleF(i * 23, y2, 23, 23);

                Tileset tileset = new Tileset();
                tileset.sprite = sprite;

                tilesets.Add(tileset);
            }
            y2 += 23;
        }

        return tilesets;
    }

    public virtual void Draw(Graphics g, Rectangle rect)
    {
        sprite.Draw(g, rect);
    }

}