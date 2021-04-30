using System;
using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;

namespace Slutprojekt
{
    public class MachineGun
    {
        public Rectangle machineGunHitBox = new Rectangle(1700, 500, 50, 50);

        public static List<MachineGun> machineGuns = new List<MachineGun>();

        public static List<MachineGun> machineGunsToRemove = new List<MachineGun>();

        public MachineGun()
        {
            machineGuns.Add(this);
        }

        public void Draw()
        {
            Raylib.DrawRectangleRec(machineGunHitBox, Color.GREEN);
        }

        public static void DrawAll()
        {
            foreach (MachineGun machineGun in machineGuns)
            {
                machineGun.Draw();
            }
        }

        public static void UpdateAll()
        {
            foreach (MachineGun machineGun in MachineGun.machineGuns)
            {
                foreach (Shell shell in Shell.shells)
                {
                    if (Raylib.CheckCollisionRecs(machineGun.machineGunHitBox, shell.shellHitBox))
                    {
                        Shell.shellsToRemove.Add(shell);
                        machineGunsToRemove.Add(machineGun);
                        Shell.timerMaxValue /= 2;

                    }
                }
            }

            foreach (MachineGun machineGun in machineGunsToRemove)
            {
                machineGuns.Remove(machineGun);
            }
            machineGunsToRemove.Clear();

        }
    }
}
