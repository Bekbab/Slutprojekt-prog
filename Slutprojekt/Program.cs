using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Slutprojekt
{

    class Program
    {

        static void Main(string[] args)
        {


            Raylib.InitWindow(1920, 1080, "Tanky");

            Player p1 = new Player();

            Raylib.SetTargetFPS(120);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                Shell.UpdateAll();
                Enemy.UpdateAll();
                MegaShot.UpdateAll();
                AutoLoader.UpdateAll();
                NewEngine.UpdateAll();
                p1.Update();

                Shell.DrawAll();
                Enemy.DrawAll();
                MegaShot.DrawAll();
                AutoLoader.DrawAll();
                NewEngine.DrawAll();
                p1.Draw();

                if (Shell.reloadCurrentValue < 0 && Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                {
                    new Shell();
                    p1.Recoil();
                    Shell.reloadCurrentValue = Shell.reloadMaxValue;

                }
                if (Enemy.spawnTimerCurrentValue < 0)
                {
                    new Enemy();
                    Enemy.spawnTimerCurrentValue = (float)Enemy.generator.NextDouble() + Enemy.generator.Next(2, 6);
                }

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
                {
                    new AutoLoader();
                }
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_T))
                {
                    new MegaShot();
                }
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_Y))
                {
                    new NewEngine();
                }
                Raylib.EndDrawing();
            }
        }
    }
}
