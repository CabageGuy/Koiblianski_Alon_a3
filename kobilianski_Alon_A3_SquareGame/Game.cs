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

  

    public void Setup()
    {
        Window.SetTitle("SquareGame");
        Window.SetSize(400, 400);

        player = new Player();

       
        Objects.SetupSpikes();
        Coins.SetupCoins();


        jumpBoosters = new JumpBooster[]
        {

            new JumpBooster(200, 230),

        };
  
    }
    public void Update()
    {
        Window.ClearBackground(Color.Blue);

        if (isGameOver)
        {
            Draw.FillColor = Color.White;
            Text.Draw("Game Over!", 30, 40);
            Text.Draw($"Score: {score}", 30, 70);
            return;
        }

      
        Objects.RenderAll(cameraOffset);

     
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
        Draw.Rectangle(0 - (int)cameraOffset.X, 320, 5000, 80);
    }
    
}
