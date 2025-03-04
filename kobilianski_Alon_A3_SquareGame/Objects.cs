using System;
using System.Numerics;

namespace MohawkGame2D
{
    public class Objects
    {
        public Vector2 position;
        public float width = 50;  
        public float height = 50; 

        public Objects()
        {
            // Positioning it on top of the rectangle
            position = new Vector2(320, 270);
        }

        public void Render()
        {
            Draw.LineSize = 1;
            Draw.FillColor = Color.White;
            Draw.LineColor = Color.White;

            // Triangle points
            float x1 = position.X;
            float y1 = position.Y + height;

            float x2 = position.X + width;
            float y2 = position.Y + height;

            float x3 = position.X + (width / 2);
            float y3 = position.Y;

            // Draw triangle
            Draw.Triangle(x1, y1, x2, y2, x3, y3);
        }

        public bool IsCollidingWith(Player player)
        {
            float playerWidth = 40;  
            float playerHeight = 40; 

            return (player.position.X < position.X + width &&
                    player.position.X + playerWidth > position.X &&
                    player.position.Y < position.Y + height &&
                    player.position.Y + playerHeight > position.Y);
        }

    }
}
