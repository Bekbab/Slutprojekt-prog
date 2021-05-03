using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class Player
    {
        public static float rotation = 0;

        public static float speed = 150; //pixels / second
        public static float rotationSpeed = 180;
        public static Vector2 position = new Vector2(960, 540);

        public Texture2D playerTexture = Raylib.LoadTexture(@"tank1.png");

        public static int score = 0;
        public static float recoil = 10; //recoil is 10 pixels


        public void Recoil()
        {
            position.X -= (MathF.Sin(rotation * MathF.PI / 180) * recoil);
            position.Y += (MathF.Cos(rotation * MathF.PI / 180) * recoil);
        }
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
                rotation -= rotationSpeed * Raylib.GetFrameTime();
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                rotation += rotationSpeed * Raylib.GetFrameTime();
            }



            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                position.X += (MathF.Sin(rotation * MathF.PI / 180) * speed) * Raylib.GetFrameTime();
                position.Y -= (MathF.Cos(rotation * MathF.PI / 180) * speed) * Raylib.GetFrameTime();
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                position.X -= (MathF.Sin(rotation * MathF.PI / 180) * speed) * Raylib.GetFrameTime();
                position.Y += (MathF.Cos(rotation * MathF.PI / 180) * speed) * Raylib.GetFrameTime();
            }
        }
        public void Draw()
        {   //Ritar en extremt komplicerad texture som har sin origin i mitten.
            Raylib.DrawTexturePro(playerTexture, new Rectangle(0, 0, playerTexture.width, playerTexture.height), new Rectangle(position.X, position.Y, playerTexture.width, playerTexture.height), new Vector2(playerTexture.width / 2, playerTexture.height / 2), rotation, Color.WHITE);
            Raylib.DrawText($" FPS: {Raylib.GetFPS()}", 20, 20, 50, Color.RED);
            Raylib.DrawText($" Score: {score}", 400, 20, 50, Color.RED);


        }
    }
}