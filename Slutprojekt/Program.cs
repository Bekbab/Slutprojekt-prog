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
            // List<Shell> shells = new List<Shell>();

            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
                {
                    new Shell();
                }
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_E))
                {
                    new Enemy();
                }


                Shell.UpdateAll();
                Shell.DrawAll();

                Enemy.UpdateAll();
                Enemy.DrawAll();

                p1.Update();
                p1.Draw();

                Raylib.EndDrawing();
            }
        }
    }
}
