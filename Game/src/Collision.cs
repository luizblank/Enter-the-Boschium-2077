using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public static class Entities
{
    private static List<Entity> entities = new List<Entity>();

    public static void Add(Entity entity)
    {
        entities.Add(entity);
    }

    public static List<Entity> Get()
    {
        return entities;
    }

    public static Entity Get(int index)
    {
        return entities[index];
    }

    public static void VerifyCollision()
    {
        foreach (var entity in entities)
        {
            bool collision = false;
            foreach (var allEntities in entities)
            {
                if (entity != allEntities)
                {
                    bool result = entity.Hitbox.VerifyCollision(entity, allEntities);

                    if (result)
                        collision = true;
                }
            }
            if (collision)
                entity.Hitbox.pen = Pens.Blue;
            else
                entity.Hitbox.pen = Pens.Red;
        }
    }
}