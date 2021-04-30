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
        public float speed = 15;

        public static Texture2D shellTexture = Raylib.LoadTexture(@"shell.png");

        public Rectangle shellHitBox;

        public Vector2 shellOrigin;

        public Vector2 movement;

        public static float timerMaxValue = 0.5f;
        public static float timerCurrentValue = timerMaxValue;

        public static List<Shell> shells = new List<Shell>();

        public static List<Shell> shellsToRemove = new List<Shell>();

        public Shell()
        {
            shells.Add(this);
        }

        public void Update()
        {
            movement.X = MathF.Sin(shellRotation * MathF.PI / 180) * speed;
            movement.Y = -(MathF.Cos(shellRotation * MathF.PI / 180) * speed);
            shellPosition += movement;
            shellHitBox = new Rectangle(shellPosition.X, shellPosition.Y, shellTexture.width, shellTexture.height);

        }

        public void Draw()
        {
            Raylib.DrawTexturePro(shellTexture, new Rectangle(0, 0, shellTexture.width, shellTexture.height), shellHitBox, shellOrigin = new Vector2(shellTexture.width / 2, shellTexture.height / 2), shellRotation, Color.WHITE);
        }

        public static void UpdateAll()
        {
            foreach (Shell shell in shells)
            {
                shell.Update();


                if (shell.shellPosition.Y < 0 || shell.shellPosition.X < 0 || shell.shellPosition.X > 1920 || shell.shellPosition.Y > 1080)
                {
                    shellsToRemove.Add(shell);
                }
                foreach (Enemy enemy in Enemy.enemies)
                {
                    if (Raylib.CheckCollisionRecs(enemy.enemyHitBox, shell.shellHitBox))
                    {
                        shellsToRemove.Add(shell);
                        Enemy.enemiesToRemove.Add(enemy);
                    }
                }




            }

            timerCurrentValue -= Raylib.GetFrameTime();

            foreach (Shell shell in shellsToRemove)
            {
                shells.Remove(shell);
            }
            shellsToRemove.Clear();
        }

        public static void DrawAll()
        {
            foreach (Shell shell in shells)
            {
                shell.Draw();

            }
            Raylib.DrawText($" shells {shells.Count}", 1600, 20, 50, Color.RED);
        }


    }
}
