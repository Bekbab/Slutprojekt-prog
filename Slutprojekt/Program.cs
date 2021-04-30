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


            Raylib.SetTargetFPS(60);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                if (Shell.timerCurrentValue < 0 && Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                {
                    new Shell();

                    Shell.timerCurrentValue = Shell.timerMaxValue;
                }
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_E))
                {
                    new Enemy();
                }
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_R))
                {
                    new MachineGun();
                }
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_T))
                {
                    new MegaShot();
                }
                if (Raylib.IsKeyPressed(KeyboardKey.KEY_Y))
                {
                    new NewEngine();
                }






                Shell.UpdateAll();
                Enemy.UpdateAll();
                MachineGun.UpdateAll();
                MegaShot.UpdateAll();
                NewEngine.UpdateAll();
                p1.Update();

                Shell.DrawAll();
                Enemy.DrawAll();
                MachineGun.DrawAll();
                MegaShot.DrawAll();
                NewEngine.DrawAll();
                p1.Draw();

                Raylib.EndDrawing();
            }
        }
    }
}
