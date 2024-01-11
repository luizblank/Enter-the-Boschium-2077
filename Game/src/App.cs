using System.Drawing;
using System.Windows.Forms;

public abstract class App
{
    Bitmap bmp = null;
    Graphics g = null;
    int frame = 0;

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

        form.Load += delegate
        {
            bmp = new Bitmap(pb.Width, pb.Height);
            pb.Image = bmp;

            g = Graphics.FromImage(bmp);
            g.Clear(Color.DarkGray);
            pb.Refresh();

            this.Open();
            timer.Start();
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

    public abstract void OnFrame();
}
