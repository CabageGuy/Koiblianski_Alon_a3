using System;
using System.Numerics;

namespace MohawkGame2D;
public class Game
{
    Player player;
    Vector2 cameraOffset;
    bool isGameOver = false;
    int score = 0;
    JumpBooster[] jumpBoosters;
    Color DarkBlue = new Color(107,171,255 );
    
    public void Setup()
    {
        Window.SetTitle("SquareGame");
        Window.SetSize(400, 400);

        InitializeGame();
    }

    public void Update()
    {
        Window.ClearBackground(DarkBlue);

        if (isGameOver)
        {
            Window.ClearBackground(Color.Red);
            Draw.FillColor = Color.White;
            Text.Draw("Game Over!", 30, 40);
            Text.Draw($"Score: {score}", 30, 70);
            Text.Draw("Press R to Restart",30, 120);

            // Check for restart input 
            if (Input.IsKeyboardKeyDown(KeyboardInput.R))
            {
                RestartGame(); // Restart the game when 'R' is pressed
            }
            return;
        }

        // Render game objects
        Objects.RenderAll(cameraOffset);

        // Handle jump boosters collision
        if (jumpBoosters != null)
        {
            foreach (var booster in jumpBoosters)
            {
                if (booster.CheckCollision(player))
                {
                    player.canDoubleJump = true;
                    booster.IsActive = false;
                }
                booster.Render(cameraOffset);
            }
        }

        // Check for collisions with obstacles
        if (Objects.CheckCollisions(player))
        {
            Console.WriteLine("Touched object - Game Over!");
            isGameOver = true;
        }

        // Player Movement
        if (Input.IsKeyboardKeyDown(KeyboardInput.A)) player.MoveLeft();
        if (Input.IsKeyboardKeyDown(KeyboardInput.D)) player.MoveRight();
        if (Input.IsKeyboardKeyDown(KeyboardInput.Space)) player.Jump();

        // Check coin collection
        Coins.CheckCollisions(player, ref score);

        // Camera follows player
        cameraOffset.X = player.position.X - 200;

        // Update & Render Player
        player.Update();
        player.Render(cameraOffset);

        // Render all coins
        Coins.RenderAll(cameraOffset);

        // Display Score
        Draw.FillColor = Color.White;
        Text.Draw($"Score: {score}", 10, 10);

        // Draw Ground
        Draw.LineSize = 1;
        Draw.LineColor = Color.Black;
        Draw.FillColor = Color.Black;
        Draw.Rectangle(0 - (int)cameraOffset.X, 320, 3000, 80);
    }

    public void RestartGame()
    {
        
        InitializeGame();
        isGameOver = false;
        score = 0;
        cameraOffset = Vector2.Zero;
    }

    public void InitializeGame()
    {
        
        player = new Player();
        Objects.SetupSpikes();
        Coins.SetupCoins();

       
        jumpBoosters = new JumpBooster[]
        {
            new JumpBooster(200, 230),
            new JumpBooster(655, 200),
            new JumpBooster(1135, 200),
            new JumpBooster(1250, 200),
            new JumpBooster(1350, 200),
            new JumpBooster(1350, 200),
            new JumpBooster(1480, 200),
            new JumpBooster(1640, 200),
            new JumpBooster(1840, 200),
            new JumpBooster(2040, 200),
            new JumpBooster(2360, 200),
            new JumpBooster(2460, 200),
            
            
        };
    }
}
