using System.Drawing;

public class Marcos : Entity
{
    public Marcos(Graphics g, PointF position) : base(g)
    {
        this.Name = "Marcos";
        this.Position = position;
        this.Hitbox.Add(
            new RectangleF(
                position.X - 7,
                position.Y - 11,
                15, 22
            ));
        this.Animation = new MarcosLeft();
    }
}