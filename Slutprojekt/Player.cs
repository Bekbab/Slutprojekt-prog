using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class Player
    {
        public static float rotation = 0;

        public float speed = 3;
        public static Vector2 position = new Vector2(960, 540);

        public Texture2D playerTexture = Raylib.LoadTexture(@"tank1.png");

        public void Update()

        {
            if (rotation > 360)
            {
                rotation = 0;
            }
            if (rotation < 0)
            {
                rotation = 360;
            }



            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                rotation -= 3;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                rotation += 3;
            }



            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                position.X += MathF.Sin(rotation * MathF.PI / 180) * speed;
                position.Y -= MathF.Cos(rotation * MathF.PI / 180) * speed;
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                position.X -= MathF.Sin(rotation * MathF.PI / 180) * speed;
                position.Y += MathF.Cos(rotation * MathF.PI / 180) * speed;
            }
        }
        public void Draw()
        {   //Ritar en extremt komplicerad texture som har sin origin i mitten.
            Raylib.DrawTexturePro(playerTexture, new Rectangle(0, 0, playerTexture.width, playerTexture.height), new Rectangle(position.X, position.Y, playerTexture.width, playerTexture.height), new Vector2(playerTexture.width / 2, playerTexture.height / 2), rotation, Color.WHITE);
            Raylib.DrawText($" FPS {Raylib.GetFPS()}", 20, 20, 50, Color.RED);

        }
    }
}