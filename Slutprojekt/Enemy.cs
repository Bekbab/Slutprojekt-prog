using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class Enemy
    {
        //Enemies are very simple ai that randomly move around individually. They can be killed but cannot yet kill the player.
        public static Random generator = new Random();
        public Vector2 position = new Vector2(generator.Next(1920), generator.Next(1080));

        public Rectangle enemyHitBox;

        public float rotation = 0;

        public float rotationSpeed = generator.Next(-180, 181);

        public float speed = generator.Next(-100, 101);
        public static List<Enemy> enemies = new List<Enemy>();

        public static List<Enemy> enemiesToRemove = new List<Enemy>();

        public static float timerMaxValue = 2;
        public float timerCurrentValue = timerMaxValue;

        public static float spawnTimerMaxValue = (float)generator.NextDouble() + generator.Next(2, 6);
        public static float spawnTimerCurrentValue = spawnTimerMaxValue;


        public Enemy()
        {
            enemies.Add(this);
        }

        public void Update()
        {

            timerCurrentValue -= Raylib.GetFrameTime();

            if (rotation > 360)
            {
                rotation = 0;
            }
            if (rotation < 0)
            {
                rotation = 360;
            }

            if (timerCurrentValue > 0 && timerCurrentValue < 1)
            {
                rotation += rotationSpeed * Raylib.GetFrameTime();
            }

            else if (timerCurrentValue > 1)
            {
                position.X += (MathF.Sin(rotation * MathF.PI / 180) * speed) * Raylib.GetFrameTime();
                position.Y -= (MathF.Cos(rotation * MathF.PI / 180) * speed) * Raylib.GetFrameTime();
            }

            else if (timerCurrentValue < 0)
            {
                timerCurrentValue = timerMaxValue;
                speed = generator.Next(-100, 101);
                rotationSpeed = generator.Next(-190, 181);

            }

            if (position.Y < 0 || position.X < 0 || position.X > 1920 || position.Y > 1080)
            {
                position = new Vector2(generator.Next(1920), generator.Next(1080));
            }

        }
        public void Draw()
        {
            Raylib.DrawRectanglePro(enemyHitBox = new Rectangle(position.X, position.Y, 50, 50), new Vector2(enemyHitBox.width / 2, enemyHitBox.height / 2), rotation, Color.RED);
        }



        public static void DrawAll()
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Draw();
            }
        }

        public static void UpdateAll()
        {
            spawnTimerCurrentValue -= Raylib.GetFrameTime();
            foreach (Enemy enemy in enemies)
            {
                enemy.Update();

            }
            foreach (Enemy enemy in enemiesToRemove)
            {
                enemies.Remove(enemy);
            }
            enemiesToRemove.Clear();

            // Raylib.DrawText($" timer {nemy.timerCurrentValue}", 1000, 20, 50, Color.RED);
        }
    }
}
