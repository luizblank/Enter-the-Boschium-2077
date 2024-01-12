using System.Collections.Generic;
using System.Drawing;

public static class Camera
{
    public static PointF Location { get; set; }
    public static SizeF Size { get; set; }

    public static void CamOnEntity(this Entity entity)
    {
        Location = entity.Position;
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
}