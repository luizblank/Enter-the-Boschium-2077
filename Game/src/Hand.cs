using System.Drawing;

public class Hand
{
    public Mob mob { get; private set; }
    public Entity entity { get; set; }

    public Hand(Mob mob)
    {
        this.mob = mob;
    }

    public void Click() {
        entity.Interact(mob);
    }
}