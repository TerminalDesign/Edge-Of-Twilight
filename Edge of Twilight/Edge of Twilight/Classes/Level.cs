using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Edge_of_Twilight.Classes
{
    class Level
    {
        struct BackgroundItem
        {
            Texture2D _texture;
            Vector2 _position;
            float _speed;
            float _layerDepth;

            public BackgroundItem(Texture2D texture, Vector2 position, float speed, float layerDepth)
            {
                _texture = texture;
                _position = position;
                _speed = speed;
                _layerDepth = layerDepth;
            }

            public void Draw(SpriteBatch sb)
            {
                sb.Draw(_texture, Camera.GetScreenPosition(_position), null, Color.White, 0f, Vector2.Zero, 3.2f, SpriteEffects.None, _layerDepth);
            }
        }

        List<BackgroundItem> backgrounds;
        public Rectangle playBounds;


        public Level()
        {
            backgrounds = new List<BackgroundItem>();
        }

        public void Update(GameTime gt)
        {
            if (InputHelper.WasKeyPressed(Keys.Q))
            {
                AddToPlayArea(150);
            }
        }

        public void Draw(SpriteBatch sb, SpriteBatch sbHud)
        {
            for (int i = 0; i < backgrounds.Count; i++)
            {
                backgrounds[i].Draw(sb);
            }


        }

        public void AddBackgroundItem(Texture2D texture, Vector2 position, float speed, float layerDepth)
        {
            backgrounds.Add(new BackgroundItem(texture, position, speed, layerDepth));
        }

        public void AddToPlayArea(int area)
        {
            this.playBounds.Width += area;
        }
    }
}
