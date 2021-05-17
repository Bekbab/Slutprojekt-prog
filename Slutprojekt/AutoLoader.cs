using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class AutoLoader
    {
        //AutoLoader halves your reload speed, making you fire twice as fast. 
        public Rectangle autoLoaderHitBox = new Rectangle(1700, 500, 50, 50);

        public static List<AutoLoader> autoLoaders = new List<AutoLoader>();

        public static List<AutoLoader> autoLoadersToRemove = new List<AutoLoader>();

        //Creates an instance in a static list shared by all instances 
        public AutoLoader()
        {
            autoLoaders.Add(this);
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(autoLoaderHitBox, Color.GREEN);
        }

        public static void DrawAll()
        {
            foreach (AutoLoader autoLoader in autoLoaders)
            {
                autoLoader.Draw();
            }
        }

        //Update function that updates every instance
        public static void UpdateAll()
        {
            foreach (AutoLoader autoLoader in AutoLoader.autoLoaders)
            {
                foreach (Shell shell in Shell.shells)
                {
                    if (Raylib.CheckCollisionRecs(autoLoader.autoLoaderHitBox, shell.shellHitBox))
                    {
                        Shell.shellsToRemove.Add(shell);
                        autoLoadersToRemove.Add(autoLoader);
                        if (Shell.reloadMaxValue > Shell.reloadMaxSpeed)
                        {
                            Shell.reloadMaxValue /= 2;
                        }

                    }
                }
            }

            foreach (AutoLoader autoLoader in autoLoadersToRemove)
            {
                autoLoaders.Remove(autoLoader);
            }
            autoLoadersToRemove.Clear();

        }
    }
}
