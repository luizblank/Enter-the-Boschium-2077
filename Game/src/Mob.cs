using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public abstract class Mob
{
    public Entity entity = null;
    public List<Hand> hands { get; set; }
    
    public float MaxLife;
    public float Life;
    public float speed = 10;


    protected Mob(Graphics g)
    {
    }

    public virtual void OnInit() {}
    public virtual void OnFrame() {}
    public virtual void OnFrame(Player player) {}
    public virtual void OnMouseMove(object o, MouseEventArgs e) {}
    public virtual void OnKeyDown(object o, KeyEventArgs e) {}
    public virtual void OnKeyUp(object o, KeyEventArgs e) {}
}