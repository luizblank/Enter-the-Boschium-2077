using System;
using System.Collections.Generic;
using System.Drawing;

public abstract class Entity
{
    protected Graphics g;
    public String Name { get; set; }
    public PointF Position { get; set; }
    public SizeF Size { get; set; }
    public Animation Animation { get; set; }
    public Hitbox Hitbox { get; set; }

    public Entity(Graphics g) {
        this.g = g;
    }

    public virtual void Interact() {}
    public virtual void Spawn() {}
    public virtual void Move() {}
    public virtual void Destroy() {}
    public virtual void OnHit() {}
    public virtual void Draw()
    {
        Image sprite = Animation.Draw();
        float scale = Math.Min(Size.Width / (float)sprite.Width, Size.Height / (float)sprite.Height);

        Size size = new Size((int)(sprite.Width * scale), (int)(sprite.Height * scale));

        g.DrawOnCam(sprite, Position, size);

        Animation = Animation.NextFrame();
    }
}