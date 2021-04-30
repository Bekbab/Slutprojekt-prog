using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class Enemy
    {
        public static Random generator = new Random();
        public Vector2 position = new Vector2(generator.Next(1920), generator.Next(1080));

        public Rectangle enemyHitBox;

        public float rotation = 0;

        public float rotationSpeed = generator.Next(-180, 181);

        public Vector2 speed = new Vector2(generator.Next(-3, 4), generator.Next(-3, 4));
        public static List<Enemy> enemies = new List<Enemy>();

        public static List<Enemy> enemiesToRemove = new List<Enemy>();

        public static float timerMaxValue = 2;
        public float timerCurrentValue = timerMaxValue;


        public Enemy()
        {
            enemies.Add(this);
        }

        public void Update()
        {
            Rectangle enemyHitBox = new Rectangle(position.X, position.Y, 50, 50);

            if (timerCurrentValue > 0)
            {
                rotationSpeed = generator.Next(-180, 181);
            }

            else if (timerCurrentValue > 1)
            {
                timerCurrentValue -= Raylib.GetFrameTime();
                position.X += (MathF.Sin(rotation * MathF.PI / 180) * speed) * Raylib.GetFrameTime();
                position.Y -= (MathF.Cos(rotation * MathF.PI / 180) * speed) * Raylib.GetFrameTime();
            }

            else if (timerCurrentValue < 0)
            {
                timerCurrentValue = timerMaxValue;
                speed = new Vector2(generator.Next(-3, 4), generator.Next(-3, 4));

            }

            if (enemyHitBox.y < 0 || enemyHitBox.x < 0 || enemyHitBox.x > 1920 || enemyHitBox.y > 1080)
            {
                speed = new Vector2(0, 0);
            }

        }
        public void Draw()
        {
            Raylib.DrawRectanglePro(enemyHitBox, new Vector2(enemyHitBox.x / 2, enemyHitBox.y / 2), rotation, Color.RED);
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
