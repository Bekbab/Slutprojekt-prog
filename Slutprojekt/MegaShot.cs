using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class MegaShot
    {
        public Rectangle megaShotHitBox = new Rectangle(1000, 800, 50, 50);

        public static List<MegaShot> megaShots = new List<MegaShot>();

        public static List<MegaShot> megaShotsToRemove = new List<MegaShot>();

        public MegaShot()
        {
            megaShots.Add(this);
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(megaShotHitBox, Color.BLUE);
        }

        public static void DrawAll()
        {
            foreach (MegaShot megaShot in megaShots)
            {
                megaShot.Draw();
            }
        }

        public static void UpdateAll()
        {
            foreach (MegaShot megaShot in MegaShot.megaShots)
            {
                foreach (Shell shell in Shell.shells)
                {
                    if (Raylib.CheckCollisionRecs(megaShot.megaShotHitBox, shell.shellHitBox))
                    {
                        Shell.shellsToRemove.Add(shell);
                        megaShotsToRemove.Add(megaShot);
                        Shell.shellTexture = Raylib.LoadTexture(@"shellBig.png");

                    }
                }
            }

            foreach (MegaShot megaShot in megaShotsToRemove)
            {
                megaShots.Remove(megaShot);
            }
            megaShotsToRemove.Clear();

        }
    }
}
