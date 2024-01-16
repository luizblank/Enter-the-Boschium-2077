using System;
using System.Collections.Generic;
using System.Drawing;

public static class Camera
{
    public static PointF Location { get; set; }
    public static SizeF Size { get; set; }
    public static float Zoom { get; set; } = 1;
    public static float speed { get; set; } = 0.9f;

    public static void CamOnEntity(this Entity entity, bool motion = true)
    {
        float x = entity.Position.X + entity.Size.Width / 2 - Camera.Size.Width / (2 * Zoom);
        float y = entity.Position.Y + entity.Size.Height / 2 - Camera.Size.Height / (2 * Zoom);

        if (!motion) {
            Location = new PointF(x, y);
            return;
        }

        double distance = Location.Distance(x, y);

        double t = speed * (distance / (Camera.Size.Width / Zoom));
        Location = Location.LinearInterpolation(x, y, t);
    }

    public static List<Entity> OnCam(this List<Entity> entities)
    {
        List<Entity> entitiesOnCam = new List<Entity>();
        var cam = new RectangleF(Location.X, Location.Y, Size.Width, Size.Height);

        foreach (var entity in entities)
        {
            var rect = new RectangleF(entity.Position.X, entity.Position.Y, entity.Size.Width, entity.Size.Height);
            if (cam.IntersectsWith(rect))
                entitiesOnCam.Add(entity);
        }
        return entitiesOnCam;
    }

    public static void DrawOnCam(this Graphics g, Image image, PointF position, Size size)
    {

        float x = (position.X - Camera.Location.X) * Zoom;
        float y = (position.Y - Camera.Location.Y) * Zoom;

        g.DrawImage(image, x, y, size.Width * Zoom, size.Height * Zoom);
    }

    public static PointF RelativePosition(this Entity entity)
    {
        float x = entity.Position.X - Camera.Location.X;
        float y = entity.Position.Y - Camera.Location.Y;

        return new PointF(x, y);
    }
}