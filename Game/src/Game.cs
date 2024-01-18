using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class Game : App
{
    public Player player = null;
    public Bot bot = null;
    private Entity camOn = null;
    
    public override void Open()
    {
        GUI.Size = new Size(bmp.Width, bmp.Height);
        Camera.Size = new SizeF(bmp.Width, bmp.Height);

        var marcos = new Marcos(g, new PointF(350, 100));
        player = new Player(g)
        {
            MaxLife = 11,
            Life = 2,
            spriteLocal = "marcos/marcos-sprites-old.png",
        };
        player.Set(marcos);
        camOn = marcos;

        var hamilton2 = new HamiltonBotEntity(g, new PointF(300, 400));
        hamilton2.AddWalkingAnimation("hamilton-bot/hamilton-bot-sprites-new.png");
        Entities.Add(hamilton2);

        Entities.Add(marcos);

        var damagedbot = new DamagedBotEntity(g, new PointF(500, 500));
        damagedbot.AddStaticAnimation("damaged-bot/damaged-bot-sprites.png");
        Entities.Add(damagedbot);

        bot = new DamagedBot(g);
        bot.Set(damagedbot);

        var guitar = new EletricGuitarEntity(g, new PointF(1000, 1000));
        guitar.Animation = new MelBotPlaying();
        Entities.Add(guitar);

        var life = new Life(g, player);
        GUI.Add(life);
    }

    public override void OnFrame()
    {
        
        camOn.CamOnEntity();

        player.OnFrame();
        bot.OnFrame(player);
        Entities.VerifyCollision();
        
        foreach (var entity in Entities.Get())
        {
            entity.cooldown -= entity.cooldown > 0 ? 1 : 0;
            if(entity.cooldown % 2 == 0)
                entity.Draw();
        }
        GUI.Draw();
    }

    public override void OnKeyDown(object o, KeyEventArgs e)
    {
        player.OnKeyDown(o, e);
        bot.OnKeyDown(o, e);

        switch (e.KeyCode)
        {
            case Keys.Enter:
                Camera.speed = 0.15f;
                camOn = Entities.Get(2);
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

            // default:
            //     MessageBox.Show(e.KeyCode.ToString());
            //     break;
        }
    }

    public override void OnKeyUp(object o, KeyEventArgs e)
    {
        player.OnKeyUp(o, e);
        bot.OnKeyUp(o, e);
    }

    public override void OnMouseMove(object o, MouseEventArgs e)
    {
        player.OnMouseMove(o, e);
        bot.OnMouseMove(o, e);
    }
}
