using MohawkGame2D;
using System.Numerics;

public class Player
{
    // Variables
    public Vector2 position;
    public Vector2 velocity;
    public float speed = 5f;
    public float jumpStrength = 12f;
    public float gravity = 0.6f;
    public bool isJumping = false;
    public bool canDoubleJump = false;
    Sound JumpSound;

    public Player()
    {
        position = new Vector2(40, 280);
        JumpSound = Audio.LoadSound("../../../../assets/Sound/Jump.MP3");
    }

    public void Render(Vector2 cameraOffset)
    {
        Draw.FillColor = Color.Red;
        int playerWidth = 40;
        int playerHeight = 40;
        Draw.Rectangle((position.X - cameraOffset.X), position.Y, playerWidth, playerHeight);
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
            canDoubleJump = false; 
        }
    }

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
        if (!isJumping) // First jump
        {
            velocity.Y = -jumpStrength;
            isJumping = true;
            Audio.Play(JumpSound);
            
        }
        else if (canDoubleJump) 
        {
            velocity.Y = -jumpStrength;
            canDoubleJump = false; // Use up the extra jump
            
        }
    }

    public Vector2 GetPosition()
    {
        return position;
    }
}
