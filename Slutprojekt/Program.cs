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
            Shell s1 = new Shell();

            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);
                p1.Update();
                p1.Draw();





                Raylib.EndDrawing();
            }
        }
    }
}
