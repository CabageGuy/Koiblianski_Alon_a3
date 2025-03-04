// Include the namespaces (code libraries) you need below.
using System;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
    public class Game
    {
        // Place your variables here:
        Player player;

        /// <summary>
        ///     Setup runs once before the game loop begins.
        /// </summary>
        public void Setup()
        {
            Window.SetTitle("SquareGame");
            Window.SetSize(400, 400);
            Window.ClearBackground(Color.Blue);
            
            
            player = new Player();

        }

        /// <summary>
        ///     Update runs every frame.
        /// </summary>
        public void Update()
        {
            player.Render();

            Draw.LineSize = 1;
            Draw.LineColor = Color.Black;
            Draw.FillColor = Color.Black;
            Draw.Rectangle(0, 320, 400, 320);

            
        }
    }

}
