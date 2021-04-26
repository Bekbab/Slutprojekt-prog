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

                Shell.UpdateAll();
                Shell.DrawAll();

                p1.Update();
                p1.Draw();



                Raylib.EndDrawing();
            }
        }
    }
}
