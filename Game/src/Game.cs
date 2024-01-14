using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class Game : App
{
    public Player player = null;
    public List<Entity> entities = new List<Entity>();
    public string PlayerSpriteLocal = "Marcos/Marcos-sprites.png";

    private Entity camOn = null;
    private Direction playerX = 0;
    private Direction playerY = 0;

    public override void Open()
    {
        Camera.Size = new SizeF(bmp.Width, bmp.Height);

        var marcos = new Marcos(g, new PointF(400, 400));
        marcos.BottomLeft(PlayerSpriteLocal);
        entities.Add(marcos);
        player = new Player(g)
        {
            entity = marcos
        };
        camOn = marcos;

        var hamilton = new Marcos(g, new PointF(400, 400));
        hamilton.BottomLeft("Hamilton bot/Hamilton-bot-sprites.png");
        entities.Add(hamilton);
    }

    public override void OnFrame()
    {
        camOn.CamOnEntity();

        player.Move(playerX, playerY);

        foreach (var entity in entities)
        {
            entity.Draw();
        }
    }

    public override void OnKeyDown(object o, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.Enter:
                camOn = entities[1];
                break;

            case Keys.A:
                playerX = Direction.Back;
                break;

            case Keys.D:
                playerX = Direction.Front;
                break;

            case Keys.W:
                playerY = Direction.Back;
                break;

            case Keys.S:
                playerY = Direction.Front;
                break;

            case Keys.Add:
                Camera.Zoom += 1;
                break;
            
            case Keys.Subtract:
                Camera.Zoom -= 1;
                break;

            case Keys.Escape:
                this.form.Close();
                break;

            default:
                MessageBox.Show(e.KeyCode.ToString());
                break;
        }
    }

    public override void OnKeyUp(object o, KeyEventArgs e)
    {
        switch (e.KeyCode)
        {
            case Keys.A:
                playerX = Direction.Stop;
                break;

            case Keys.D:
                playerX = Direction.Stop;
                break;

            case Keys.W:
                playerY = Direction.Stop;
                break;

            case Keys.S:
                playerY = Direction.Stop;
                break;
        }
    }

    public override void OnMouseMove(object o, MouseEventArgs e)
    {
        if (this.cursor.Y > player.entity.RelativePosition().Y) {
            if (this.cursor.X > player.entity.RelativePosition().X)
                player.entity.BottomRight(PlayerSpriteLocal);
            else
                player.entity.BottomLeft(PlayerSpriteLocal);
        } else {
            if (this.cursor.X > player.entity.RelativePosition().X)
                player.entity.TopRight(PlayerSpriteLocal);
            else
                player.entity.TopLeft(PlayerSpriteLocal);
        }
    }
}
