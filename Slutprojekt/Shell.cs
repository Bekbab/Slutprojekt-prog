using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class Shell
    {
        public float shellRotation = Player.rotation;
        public Vector2 shellPosition = Player.position;
        public float speed = 10;

        public Texture2D shellTexture = Raylib.LoadTexture(@"shell.png");

        public Vector2 movement;

        public void Update()
        {
            movement.X = MathF.Sin(shellRotation * MathF.PI / 180) * speed;
            movement.Y = -(MathF.Cos(shellRotation * MathF.PI / 180) * speed);
            shellPosition += movement;
        }

        public void Draw()
        {
            Raylib.DrawTexturePro(shellTexture, new Rectangle(0, 0, shellTexture.width, shellTexture.height), new Rectangle(shellPosition.X, shellPosition.Y, shellTexture.width, shellTexture.height), new Vector2(shellTexture.width / 2, shellTexture.height / 2), shellRotation, Color.WHITE);
        }

    }
}
