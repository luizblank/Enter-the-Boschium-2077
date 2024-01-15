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
        this.Animation.Draw(g, Position, Size);

        Animation = Animation.NextFrame();
    }
}