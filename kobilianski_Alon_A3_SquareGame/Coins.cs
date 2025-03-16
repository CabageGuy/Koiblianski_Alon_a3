using MohawkGame2D;
using System;
using System.Numerics;

public class Coins
{
    public Vector2 position;
    private int radius = 20;
    public bool isCollected = false;
   
    public static Sound CoinSound;
    // Static array to hold all coins
    public static Coins[] coins;

    public Coins(float x, float y)
    {
        position = new Vector2(x, y);
        
    }
    
    // Initialize coins array
    public static void SetupCoins()
    {
        CoinSound = Audio.LoadSound("../../../../assets/Sound/Coin.MP3");
        coins = new Coins[]
        {
            new Coins(220, 250),
            new Coins(280, 250),
            new Coins(470, 250),
            new Coins(620, 250),
            new Coins(660, 250),
            new Coins(840, 280),
            new Coins(880, 280),
            new Coins(920, 280),
            new Coins(960, 280),
            new Coins(1000, 280),
            new Coins(1060, 280),
            new Coins(1100, 280),
            new Coins(1490, 300),
            new Coins(1540, 300),
            new Coins(1590, 300),
            new Coins(1640, 300),
            new Coins(1690, 300),
            new Coins(1740, 300),
            new Coins(1790, 300),
            new Coins(1830, 300),
            new Coins(1890, 300),
            new Coins(1930, 300),
            new Coins(1970, 300),
            new Coins(2040, 300),
         
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
                Audio.Play(CoinSound);
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
