using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Edge_of_Twilight.Classes
{
    class Camera
    {
        public static Vector2 position;

        public static Vector2 GetScreenPosition(Vector2 worldPosition)
        {
            return worldPosition - Camera.position + new Vector2(Game1.SCREEN_WIDTH / 2, Game1.SCREEN_HEIGHT / 2);
        }
    }
}
