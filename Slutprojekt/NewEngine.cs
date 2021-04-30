using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class NewEngine
    {
        public Rectangle newEngineHitBox = new Rectangle(1000, 100, 50, 50);

        public static List<NewEngine> newEngines = new List<NewEngine>();

        public static List<NewEngine> newEnginesToRemove = new List<NewEngine>();

        public NewEngine()
        {
            newEngines.Add(this);
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(newEngineHitBox, Color.PURPLE);
        }

        public static void DrawAll()
        {
            foreach (NewEngine newEngine in newEngines)
            {
                newEngine.Draw();
            }
        }

        public static void UpdateAll()
        {
            foreach (NewEngine newEngine in NewEngine.newEngines)
            {
                foreach (Shell shell in Shell.shells)
                {
                    if (Raylib.CheckCollisionRecs(newEngine.newEngineHitBox, shell.shellHitBox))
                    {
                        Shell.shellsToRemove.Add(shell);
                        newEnginesToRemove.Add(newEngine);
                        Player.speed *= 2;

                    }
                }
            }

            foreach (NewEngine newEngine in newEnginesToRemove)
            {
                newEngines.Remove(newEngine);
            }
            newEnginesToRemove.Clear();

        }
    }
}
