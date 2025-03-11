using MohawkGame2D;
using System;
using System.Numerics;

public class Coins
{
    public Vector2 position;
    private int radius = 20;
    public bool isCollected = false;

    // Static array to hold all coins
    public static Coins[] coins;

    public Coins(float x, float y)
    {
        position = new Vector2(x, y);
    }

    // Initialize coins array
    public static void SetupCoins()
    {
        coins = new Coins[]
        {
            new Coins(220, 250),
            new Coins(420, 250),
            new Coins(620, 250)
        };
    }

    // Render all coins
    public static void RenderAll(Vector2 cameraOffset)
    {
        if (coins == null) return;

        foreach (var coin in coins)
        {
            coin.Render(cameraOffset);
        }
    }

    // Check if player collides with any coin
    public static void CheckCollisions(Player player, ref int score)
    {
        if (coins == null) return;

        foreach (var coin in coins)
        {
            if (coin.IsCollidingWith(player) && !coin.isCollected)
            {
                coin.isCollected = true;
                score += 50;
                Console.WriteLine($"Coin collected! Score: {score}");
            }
        }
    }

    public void Render(Vector2 cameraOffset)
    {
        if (!isCollected)
        {
            Draw.FillColor = Color.Yellow;
            Draw.Circle((int)(position.X - cameraOffset.X), (int)position.Y, radius);
        }
    }

    public bool IsCollidingWith(Player player)
    {
        float playerLeft = player.position.X;
        float playerRight = player.position.X + 40;
        float playerTop = player.position.Y;
        float playerBottom = player.position.Y + 40;

        float coinLeft = position.X - radius;
        float coinRight = position.X + radius;
        float coinTop = position.Y - radius;
        float coinBottom = position.Y + radius;

        bool isOverlapping = !(playerLeft > coinRight || playerRight < coinLeft || playerTop > coinBottom || playerBottom < coinTop);

        return !isCollected && isOverlapping;
    }
}
