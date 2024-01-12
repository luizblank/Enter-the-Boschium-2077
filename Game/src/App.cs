using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public abstract class App
{
    protected Bitmap bmp = null;
    protected Graphics g = null;
    protected int frame = 0;
    protected PointF cursor = PointF.Empty;

    public void Run()
    {
        ApplicationConfiguration.Initialize();

        PictureBox pb = new PictureBox()
        {
            Dock = DockStyle.Fill
        };

        var timer = new Timer
        {
            Interval = 10,
        };

        var form = new Form
        {
            WindowState = FormWindowState.Maximized,
            FormBorderStyle = FormBorderStyle.None,
            Controls = { pb }
        };

        pb.MouseMove += (o, e) => {
            this.cursor = e.Location;

            this.OnMouseMove(o, e);
        };

        form.Load += delegate
        {
            bmp = new Bitmap(pb.Width, pb.Height);
            pb.Image = bmp;

            g = Graphics.FromImage(bmp);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.Clear(Color.DarkGray);
            pb.Refresh();

            this.Open();
            timer.Start();
        };

        form.KeyDown += (o, e) =>
        {
            this.OnKeyDown(o, e);
        };

        timer.Tick += delegate
        {
            g.Clear(Color.DarkGray);

            frame++;
            this.OnFrame();

            pb.Refresh();
        };

        Application.Run(form);
    }

    public virtual void Open() {}

    public virtual void Close() {}

    public virtual void OnMouseMove(Object o, MouseEventArgs e) {}

    public virtual void OnKeyDown(Object o, KeyEventArgs e) {}

    public abstract void OnFrame();
}
