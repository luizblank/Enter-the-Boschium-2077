using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class Game : App
{
    public Player player = null;
    public Bot bot = null;
    public List<Entity> entities = new List<Entity>();
    public string PlayerSpriteLocal = "marcos/marcos-sprites-old.png";

    private Entity camOn = null;
    private Walk playerX = 0;
    private Walk playerY = 0;

    public override void Open()
    {
        Camera.Size = new SizeF(bmp.Width, bmp.Height);

        var marcos = new Marcos(g, new PointF(350, 100));
        marcos.AddStaticAnimation(PlayerSpriteLocal);
        player = new Player(g)
        {
            MaxLife = 10,
            Life = 10,
            entity = marcos
        };
        camOn = marcos;

        var hamilton2 = new HamiltonBotEntity(g, new PointF(300, 400));
        hamilton2.AddWalkingAnimation("hamilton-bot/hamilton-bot-sprites-new.png");
        entities.Add(hamilton2);

        entities.Add(marcos);

        var damagedbot = new DamagedBotEntity(g, new PointF(500, 500));
        damagedbot.AddWalkingAnimation("damaged-bot/damaged-bot-sprites.png");
        entities.Add(damagedbot);
        bot = new DamagedBot(g)
        {
            entity = damagedbot
        };
    }

    public override void OnFrame()
    {
        camOn.CamOnEntity();

        player.Move(playerX, playerY);
        bot.OnFrame(player);

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
        Direction newDirection = Direction.BottomLeft;
        if (this.cursor.Y > player.entity.RelativePosition().Y) {
            if (this.cursor.X > player.entity.RelativePosition().X)
                newDirection = Direction.BottomRight;
            else
                newDirection = Direction.BottomLeft;
        } else {
            if (this.cursor.X > player.entity.RelativePosition().X)
                newDirection = Direction.TopRight;
            else
                newDirection = Direction.TopLeft;
        }

        if ((int)playerX != 0 || (int)playerY != 0)
            player.entity.AddWalkingAnimation(PlayerSpriteLocal, newDirection);
        else
            player.entity.AddStaticAnimation(PlayerSpriteLocal, newDirection);
    }
}
