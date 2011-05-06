using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Edge_of_Twilight.Classes
{
    static class InputHelper
    {
        private const int numberOfPlayers = 4;

        /// <summary>
        /// Old Gamepad States, Feed me a PlayerIndex, cast to an int
        /// </summary>
        public static GamePadState[] OGS = new GamePadState[numberOfPlayers];
        
        /// <summary>
        /// Old Gamepad States, Feed me a PlayerIndex, cast to an int
        /// </summary>
        public static GamePadState[] NGS = new GamePadState[numberOfPlayers];

        /// <summary>
        /// Old Keyboard State
        /// </summary>
        public static KeyboardState OKS;
        
        /// <summary>
        /// New Keyboard State
        /// </summary>
        public static KeyboardState NKS;

        /// <summary>
        /// Update Input Device States
        /// </summary>
        public static void UpdateStates()
        {
            for (int i = 0; i < numberOfPlayers; i++)
            {
                OGS[i] = NGS[i];
                NGS[i] = GamePad.GetState((PlayerIndex)i);
            }

            OKS = NKS;
            NKS = Keyboard.GetState();
        }

        public static bool WasButtonPressed(PlayerIndex playerIndex, Buttons button)
        {
            return NGS[(int)playerIndex].IsButtonDown(button) && OGS[(int)playerIndex].IsButtonUp(button);
        }

        public static bool WasKeyPressed(Keys key)
        {
            return NKS.IsKeyDown(key) && OKS.IsKeyUp(key);
        }

        public static bool isKeyHeld(Keys key)
        {
            return NKS.IsKeyDown(key);
        }
    }
}
