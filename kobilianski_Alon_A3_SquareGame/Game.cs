// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;


namespace MohawkGame2D;
public class Game
{
   //Place Variables Here
    Player player;
    Objects spikes;

    //Setup For the Game
    public void Setup()
    {
        Window.SetTitle("SquareGame");
        Window.SetSize(400, 400);     

        player = new Player();
        spikes = new Objects();
    }
    //Updates For the Game
    public void Update()
    {
        Window.ClearBackground(Color.Blue);

        if (Input.IsKeyboardKeyDown(KeyboardInput.A))
        {
            player.MoveLeft();
        }

        if (Input.IsKeyboardKeyDown(KeyboardInput.D))
        {
            player.MoveRight();
        }

        if (Input.IsKeyboardKeyDown(KeyboardInput.Space))
        {
            player.Jump();
        }

        player.Update();
        player.Render();
        spikes.Render();


        if (spikes.IsCollidingWith(player))
        {
            Console.WriteLine("touched object");
            player.position = new Vector2(100, 280);  
        }


        Draw.LineSize = 1;
        Draw.LineColor = Color.Black;
        Draw.FillColor = Color.Black;
        Draw.Rectangle(0, 320, 400, 320);
    }


}


