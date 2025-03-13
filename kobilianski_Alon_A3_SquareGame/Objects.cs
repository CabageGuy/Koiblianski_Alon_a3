using MohawkGame2D;
using System.Numerics;

public class Objects
{
    public Vector2 position;
    private int size = 40;

    // Make spikes public so we can check it in Game.cs
    public static Objects[] spikes;

    public Objects(Vector2 startPosition)
    {
        position = startPosition;
    }

    public static void SetupSpikes()
    {
        spikes = new Objects[]
        {
            new Objects(new Vector2(200, 280)),
            new Objects(new Vector2(250, 280)),
            new Objects(new Vector2(450, 280)),
            new Objects(new Vector2(600, 280)),
            new Objects(new Vector2(640, 280))

        };
    }



  public static void RenderAll(Vector2 cameraOffset)
    {
        if (spikes == null) return;

        foreach (var spike in spikes)
        {
            spike.Render(cameraOffset);
        }
    }

    // Check if player collides with any spike
    public static bool CheckCollisions(Player player)
    {
        if (spikes == null) return false;

        foreach (var spike in spikes)
        {
            if (spike.IsCollidingWith(player))
            {
                return true; // Collision detected
            }
        }
        return false;
    }

    public void Render(Vector2 cameraOffset)
    {
        Draw.FillColor = Color.White;

        int baseX = (int)(position.X - cameraOffset.X);
        int baseY = (int)position.Y;

        int x1 = baseX;
        int y1 = baseY + size;

        int x2 = baseX + size;
        int y2 = baseY + size;

        int x3 = baseX + (size / 2);
        int y3 = baseY; // Peak

        // Draw the triangle
        Draw.Triangle(x1, y1, x2, y2, x3, y3);
    }

    public bool IsCollidingWith(Player player)
    {
        return player.position.X < position.X + size &&
               player.position.X + 40 > position.X &&
               player.position.Y < position.Y + size &&
               player.position.Y + 40 > position.Y;
    }
}
