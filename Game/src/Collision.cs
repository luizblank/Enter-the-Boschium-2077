using System.Collections.Generic;

public static class Collision {
    public static List<Entity> Entities { get; set; }

    public static void VerifyCollision()
    {
        foreach (var entity in Entities)
        {
            entity.OnCollision(entity);
        }
    }
}