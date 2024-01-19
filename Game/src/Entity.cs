using System;
using System.Collections.Generic;
using System.Drawing;

public abstract class Entity
{
    protected Graphics g;
    public PointF Position { get; protected set; }
    public Mob mob = null;
    public String Name { get; set; }
    public SizeF Size { get; set; }
    public Animation Animation { get; set; }
    public Hitbox Hitbox { get; set; }
    public int damage { get; set; } = 0;
    public int cooldown { get; set; } = 0;

    public Entity(Graphics g) {
        this.g = g;
    }

    public virtual void Interact(Mob mob) {}
    public virtual void Spawn() {}
    public virtual void Destroy() 
        => mob.OnDestroy();
    public virtual void OnHit(Entity entity) {
        if (this.mob is null || this.cooldown > 0)
            return;

        this.mob.Life -= entity.damage;
        this.cooldown = entity.damage > 0 && this.mob.Life > 0 ? 60 : 0;
        if (this.mob.Life <= 0)
            this.Destroy();
    }
    public virtual void OnCollision(Entity entity) {}
    public virtual void Move(PointF position)
    {
        this.Position = position;
    }
    public virtual void Draw()
    {
        this.Animation.Draw(g, Position, Size);
        // this.Hitbox.Draw(g, Position);
        Animation = Animation.NextFrame();
    }
}