using System.Drawing;

public abstract class Icon
{
    protected Graphics g = null;
    public PointF Position { get; set; }
    public SizeF Size { get; set; }

    public Icon(Graphics g) => this.g = g;
    public Icon(Graphics g, SizeF size)
    {
        this.g = g;
        this.Size = size;
    }

    public abstract void Draw();
    public abstract void OnClick();
    public abstract void OnMouse();
}