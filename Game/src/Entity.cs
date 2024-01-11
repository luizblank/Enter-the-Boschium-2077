using System;
using System.Collections.Generic;
using System.Drawing;

public abstract class Entity
{
    public Graphics g;
    public String Name;
    public PointF Position;
    public Animation Animation;
    public List<RectangleF> Hitbox;

    public Entity(Graphics g) {
        this.g = g;
    }

    public virtual void Interact() {}
    public virtual void Spawn() {}
    public virtual void Move() {}
    public virtual void Destroy() {}
}