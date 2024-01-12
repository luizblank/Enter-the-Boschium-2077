using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class Game : App
{
    public Player player = null;
    public List<Entity> entities = new List<Entity>();
    public string PlayerSpriteLocal = "Marcos/Marcos-sprites.png";
    public override void Open()
    {
        Camera.Size = new SizeF(bmp.Width, bmp.Height);

        var marcos = new Marcos(g, new PointF(bmp.Width / 2, bmp.Height / 2));
        marcos.BottomLeft(PlayerSpriteLocal);
        entities.Add(marcos);
        player = new Player(g);
        player.entity = marcos;

        var hamilton = new Marcos(g, new PointF(500, 200));
        hamilton.BottomLeft("Hamilton bot/Hamilton-bot-sprites.png");
        entities.Add(hamilton);
    }

    public override void OnMouseMove(object o, MouseEventArgs e)
    {
        if (this.cursor.Y > player.entity.Position.Y) {
            if (this.cursor.X > player.entity.Position.X)
                player.entity.BottomRight(PlayerSpriteLocal);
            else
                player.entity.BottomLeft(PlayerSpriteLocal);
        } else {
            if (this.cursor.X > player.entity.Position.X)
                player.entity.TopRight(PlayerSpriteLocal);
            else
                player.entity.TopLeft(PlayerSpriteLocal);
        }
    }

    public override void OnFrame()
    {
        player.entity.CamOnEntity();
        foreach (var entity in entities.OnCam())
        {
            entity.Draw();
        }
    }
}
