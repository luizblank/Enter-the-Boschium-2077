using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class Game : App
{
    public Player player = null;
    public List<Entity> entities = new List<Entity>();
    public string PlayerSpriteLocal = "Marcos/Marcos-sprites.png";

    private Entity camOn = null;
    private Walk playerX = 0;
    private Walk playerY = 0;

    public override void Open()
    {
        Camera.Size = new SizeF(bmp.Width, bmp.Height);

        var marcos = new Marcos(g, new PointF(400, 400));
        marcos.AddStaticAnimation(PlayerSpriteLocal);
        player = new Player(g)
        {
            entity = marcos
        };
        camOn = marcos;

        var hamilton = new Marcos(g, new PointF(400, 400));
        hamilton.AddStaticAnimation("Hamilton bot/Hamilton-bot-sprites.png");
        entities.Add(hamilton);
        entities.Add(marcos);
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
                Camera.speed = 0.15f;
                camOn = entities[1];
                break;

            case Keys.A:
                playerX = Walk.Back;
                break;

            case Keys.D:
                playerX = Walk.Front;
                break;

            case Keys.W:
                playerY = Walk.Back;
                break;

            case Keys.S:
                playerY = Walk.Front;
                break;

            case Keys.Add:
                Camera.Zoom += 1;
                break;
            
            case Keys.Subtract:
                Camera.Zoom -= 1;
                break;

            case Keys.Escape:
                this.Close();
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
                playerX = Walk.Stop;
                break;

            case Keys.D:
                playerX = Walk.Stop;
                break;

            case Keys.W:
                playerY = Walk.Stop;
                break;

            case Keys.S:
                playerY = Walk.Stop;
                break;
        }
    }

    public override void OnMouseMove(object o, MouseEventArgs e)
    {
        if (this.cursor.Y > player.entity.RelativePosition().Y) {
            if (this.cursor.X > player.entity.RelativePosition().X)
                player.entity.AddStaticAnimation(PlayerSpriteLocal, Direction.BottomRight);
            else
                player.entity.AddStaticAnimation(PlayerSpriteLocal, Direction.BottomLeft);
        } else {
            if (this.cursor.X > player.entity.RelativePosition().X)
                player.entity.AddStaticAnimation(PlayerSpriteLocal, Direction.TopRight);
            else
                player.entity.AddStaticAnimation(PlayerSpriteLocal, Direction.TopLeft);
        }
    }
}
