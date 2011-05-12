using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Edge_of_Twilight.Classes
{
    enum GameState
    {
        MainMenu,
        HowToPlay,
        Playing
    }

    static class GameManager
    {
        public static GameState gameState = GameState.MainMenu;
        public static List<Level> levels = new List<Level>();
        public static int currentLevel = 0;

        public static void Update(GameTime gameTime)
        {
            switch (gameState)
            {
                case GameState.MainMenu:
                    MenuManager.Update();
                    break;

                case GameState.HowToPlay:
                    //Wait for input to go back to the main menu
                    if (InputHelper.WasButtonPressed(PlayerIndex.One, Buttons.A)
                        || InputHelper.WasKeyPressed(Keys.Space))
                    {
                        gameState = GameState.MainMenu;
                    }
                    break;

                case GameState.Playing:
                    levels[currentLevel].Update(gameTime);
                    break;
            }
        }

        public static void Draw(SpriteBatch SB, SpriteBatch SBHUD)
        {
            switch (gameState)
            {
                case GameState.MainMenu:
                    MenuManager.Draw(SBHUD);
                    break;
                case GameState.HowToPlay:
                    SBHUD.DrawString(Game1.fontSmall, "Move - Arrow Keys / D-Pad", new Vector2(179, 50), Color.White);
                    SBHUD.DrawString(Game1.fontSmall, "Jump - Space / A", new Vector2(179, 100), Color.White);
                    break;
                case GameState.Playing:
                    levels[currentLevel].Draw(SB, SBHUD);
                    break;
            }

        }

        /*
        public static void CreateLevels()
        {
            Level level = new Level();

            level.playBounds = new Rectangle(0, 380, Game1.SCREEN_WIDTH, 170);

            level.AddBackgroundItem(Game1.sprStage1BGMain, Vector2.Zero, 1f, 0.90f);

            level.Actors.Add(new Player(new Vector2(100, 400), level, PlayerIndex.One));
            level.player1 = level.Actors[level.Actors.Count - 1] as Player;
            level.player1.facingDir = Direction.Right;

            level.Actors.Add(new Enemy(new Vector2(1400, 500), level));
            level.Actors.Add(new Enemy(new Vector2(800, 500), level));
            level.Actors.Add(new Enemy(new Vector2(900, 500), level));
            levels.Add(level);

            HUDManager.SetLevel(level);

            Camera.position = new Vector2(Game1.SCREEN_WIDTH / 2, Game1.SCREEN_HEIGHT / 2);


        }
        */

    }
}
