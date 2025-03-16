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
            new Objects(new Vector2(640, 280)),
            new Objects(new Vector2(680, 280)),
            new Objects(new Vector2(720, 280)),
            new Objects(new Vector2(760, 280)),
            new Objects(new Vector2(800, 280)),
            new Objects(new Vector2(1100, 280)),
            new Objects(new Vector2(1120, 260)),
            new Objects(new Vector2(1140, 240)),
            new Objects(new Vector2(1160, 220)),
            new Objects(new Vector2(1180, 200)),
            new Objects(new Vector2(1200, 280)),
            new Objects(new Vector2(1220, 260)),
            new Objects(new Vector2(1240, 240)),
            new Objects(new Vector2(1260, 220)),
            new Objects(new Vector2(1280, 200)),
            new Objects(new Vector2(1300, 280)),
            new Objects(new Vector2(1320, 260)),
            new Objects(new Vector2(1340, 240)),
            new Objects(new Vector2(1360, 220)),
            new Objects(new Vector2(1380, 200)),
            new Objects(new Vector2(1480, 230)),
            new Objects(new Vector2(1520, 230)),
            new Objects(new Vector2(1560, 230)),
            new Objects(new Vector2(1600, 230)),
            new Objects(new Vector2(1640, 230)),
            new Objects(new Vector2(1680, 230)),
            new Objects(new Vector2(1720, 230)),
            new Objects(new Vector2(1760, 230)),
            new Objects(new Vector2(1800, 230)),
            new Objects(new Vector2(1840, 230)),
            new Objects(new Vector2(1880, 230)),
            new Objects(new Vector2(1920, 230)),
            new Objects(new Vector2(1960, 230)),
            new Objects(new Vector2(2000, 230)),
            new Objects(new Vector2(2040, 230)),
            new Objects(new Vector2(2080, 230)),

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
