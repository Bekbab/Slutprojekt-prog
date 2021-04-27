using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class Enemy
    {
        public Rectangle enemyHitBox = new Rectangle(500, 500, 20, 20);

        public static List<Enemy> enemies = new List<Enemy>();


        public static List<Enemy> enemiesToRemove = new List<Enemy>();


        public Enemy()
        {
            enemies.Add(this);
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(enemyHitBox, Color.RED);
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

            foreach (Enemy enemy in enemiesToRemove)
            {
                enemies.Remove(enemy);
            }
            enemiesToRemove.Clear();

            Raylib.DrawText($" enemies {enemies.Count}", 1000, 20, 50, Color.RED);
        }
    }
}
