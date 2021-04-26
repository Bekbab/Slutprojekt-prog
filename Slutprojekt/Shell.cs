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

        public Texture2D shellTexture = Raylib.LoadTexture(@"shell.png");

        public Vector2 movement;

        public List<Shell> shells = new List<Shell>();


        public void Update()
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                shells.Add(new Shell)
            }
        }

        public void Draw()
        {
            Raylib.DrawTexturePro(shellTexture, new Rectangle(0, 0, shellTexture.width, shellTexture.height), new Rectangle(shellPosition.X, shellPosition.Y, shellTexture.width, shellTexture.height), new Vector2(shellTexture.width / 2, shellTexture.height / 2), shellRotation, Color.WHITE);
        }

    }
}
