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
        public List<Actor> actors;
        public Rectangle playBounds;
        //public Player player1;

        public Level()
        {
            backgrounds = new List<BackgroundItem>();
            actors = new List<Actor>();
        }

        public void Update(GameTime gt)
        {
            for (int i = -0; i < actors.Count; i++)
            {
                actors[i].Update(gt);
            }

            //UpdateCameraPosition();

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

            for (int i = 0; i < actors.Count; i++)
            {
                actors[i].Draw(sb);
            }

            //HUDManager.Draw(sbHud);
        }

        /*
        private void UpdateCameraPosition()
        {
            if (player1.position.X > Camera.position.X)
            {
                Camera.position.X += 3;
                if (Camera.position.X + Game1.SCREEN_WIDTH / 2 > this.playBounds.Right)
                {
                    this.playBounds.Width += 3;
                    Camera.position.X = this.playBounds.Right - Game1.SCREEN_WIDTH / 2;
                }

            }
        }
        */

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
