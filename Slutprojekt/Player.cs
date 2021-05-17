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
        public static float rotationSpeed = 180; //degrees / second
        public static Vector2 position = new Vector2(960, 540);

        public Texture2D playerTexture = Raylib.LoadTexture(@"tank1.png");

        public static int score = 0;
        public static float recoil = 10; //recoil is 10 pixels

        //For a more realistic feeling the tank has recoil. It doesn't need a speed float since it only needs to "snap" backwards.
        public void Recoil()
        {
            position.X -= (MathF.Sin(rotation * MathF.PI / 180) * recoil);
            position.Y += (MathF.Cos(rotation * MathF.PI / 180) * recoil);
        }
        public void Update()

        {
            //Rotation can not be greater than 360 or less than 0, or else the equation* won't work.
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



            // *This trigonometric equation calculates how much the player should move on the X and Y axis depending on how they are rotated.
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                position.X += (MathF.Sin(rotation * MathF.PI / 180) * speed) * Raylib.GetFrameTime();
                //The Y movement needs to be reversed, probably due to how the Y axis is reversed in Raylib.
                position.Y -= (MathF.Cos(rotation * MathF.PI / 180) * speed) * Raylib.GetFrameTime();
            }
            else if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                //To go backwards it's the same equation only reversed. 
                position.X -= (MathF.Sin(rotation * MathF.PI / 180) * speed) * Raylib.GetFrameTime();
                //Y being posistive in this case
                position.Y += (MathF.Cos(rotation * MathF.PI / 180) * speed) * Raylib.GetFrameTime();
            }
        }
        public void Draw()
        {
            //Draws an overly complicated texture that has it's origin point in the middle
            Raylib.DrawTexturePro(playerTexture, new Rectangle(0, 0, playerTexture.width, playerTexture.height), new Rectangle(position.X, position.Y, playerTexture.width, playerTexture.height), new Vector2(playerTexture.width / 2, playerTexture.height / 2), rotation, Color.WHITE);
            Raylib.DrawText($" FPS: {Raylib.GetFPS()}", 20, 20, 50, Color.RED);
            Raylib.DrawText($" Score: {score}", 400, 20, 50, Color.RED);


        }
    }
}