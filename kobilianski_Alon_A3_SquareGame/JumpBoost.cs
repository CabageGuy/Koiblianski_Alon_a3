﻿using MohawkGame2D;
using System.Numerics;

public class JumpBooster
{
    public Vector2 Position;
    public int Radius = 20; // ✅ Circle size
    public bool IsActive = true; // ✅ Disappear after collection

    public JumpBooster(float x, float y)
    {
        Position = new Vector2(x, y);
    }

    public void Render(Vector2 cameraOffset)
    {
        if (IsActive)
        {
            Draw.FillColor = Color.Green; 
            Draw.Circle((int)(Position.X - cameraOffset.X), (int)Position.Y, Radius);
        }
    }

    public bool CheckCollision(Player player)
    {
        int playerSize = 40; 

        Vector2 boosterCenter = new Vector2(Position.X + Radius, Position.Y + Radius);

        
        Vector2 playerCenter = new Vector2(player.position.X + playerSize / 2, player.position.Y + playerSize / 2);

       
        float distance = Vector2.Distance(playerCenter, boosterCenter);

        
        return IsActive && distance < (Radius + (playerSize * .8));
    }
}
