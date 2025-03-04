using System;
using System.Numerics;
using MohawkGame2D;

public class Player
{
    //Vari
    public Vector2 position;
    public Vector2 velocity;
    public float speed = 5f;
    public float jumpStrength = 15f;
    public float gravity = 0.6f;
    public bool isJumping = false;

    public Player()
    {
        position = new Vector2(40, 280); 
    }

    public void Render()
    {
        Draw.LineSize = 1;
        Draw.LineColor = Color.Black;
        Draw.FillColor = Color.Red;
        Draw.Rectangle(position.X, position.Y, 40, 40); 
    }

    public void Update()
    {
        // Apply gravity
        velocity.Y += gravity;
        position.Y += velocity.Y;

        // Ground collision
        if (position.Y >= 280) 
        {
            position.Y = 280;
            velocity.Y = 0;
            isJumping = false;
        }
    }

    // Making the Player Move 
    public void MoveLeft()
    {
        position.X -= speed;
    }

    public void MoveRight()
    {
        position.X += speed;
    }

    public void Jump()
    {
        if (!isJumping)
        {
            velocity.Y = -jumpStrength;
            isJumping = true;
        }
    }

    
    public Vector2 GetPosition()
    {
        return position;
    }
}
