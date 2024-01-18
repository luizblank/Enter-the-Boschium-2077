using System.Drawing;
using System.Windows.Forms;

public class Hand
{
    public Mob Mob { get; set; }
    public Entity Entity { get; set; }
    public double Distance { get; set; }

    public Hand(Mob mob, Entity entity)
    {
        this.Mob = mob;
        this.Entity = entity;
    }

    public void Draw(PointF point) {
        double distance = Mob.entity.Position.Distance(point);
        double t = Distance / distance;

        Entity.Move(Mob.entity.Position.LinearInterpolation(point, t));
        Entity.Draw();
    }

    public void Click() {
        Entity.Interact(Mob);
    }
}