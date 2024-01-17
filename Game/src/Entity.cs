using System;
using System.Collections.Generic;
using System.Drawing;

public abstract class Entity
{
    protected Graphics g;
    public PointF Position { get; protected set; }
    public String Name { get; set; }
    public SizeF Size { get; set; }
    public Animation Animation { get; set; }
    public Hitbox Hitbox { get; set; }

    public Entity(Graphics g) {
        this.g = g;
    }

    public virtual void Interact(Mob mob) {}
    public virtual void Spawn() {}
    public virtual void Destroy() {}
    public virtual void OnHit() {}
    public virtual void Move(PointF position)
    {
        this.Position = position;
    }
    public virtual void Draw()
    {
        this.Animation.Draw(g, Position, Size);
        this.Hitbox.Draw(g, Position);
        Animation = Animation.NextFrame();
    }
}