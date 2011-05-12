using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Edge_of_Twilight.Classes
{
    enum MenuState
    {
        TitleScreen,
        MainMenu
    }

    struct MenuItem
    {
        
        Vector2 position;
        string text;

        public MenuItem(string text, Vector2 position)
        {
            this.text = text;
            this.position = position;
        }

        public void Draw(SpriteBatch SBHUD, Color drawColor)
        {
            SBHUD.DrawString(Game1.fontSmall, text, position, drawColor);
        }
    }

    static class MenuManager
    {
        static Color colorStandard = Color.White;
        static Color colorSelected = Color.Red;

        static List<MenuItem> menuItems = new List<MenuItem>();
        static int currentMenuItem = 0;
        public static MenuState MenuState = MenuState.TitleScreen;

        public static void Update()
        {
            switch (MenuState)
            {
                case MenuState.TitleScreen:
                    //Wait for input to move to Main Menu
                    if (InputHelper.WasButtonPressed(PlayerIndex.One, Buttons.A)
                        || InputHelper.WasButtonPressed(PlayerIndex.One, Buttons.Start)
                        || InputHelper.WasKeyPressed(Keys.Space))
                    {
                        MenuState = MenuState.MainMenu;
                    }
                    break;

                case MenuState.MainMenu:
                    //Menu Navigation
                    if (InputHelper.WasButtonPressed(PlayerIndex.One, Buttons.DPadUp)
                        || (InputHelper.NGS[(int)PlayerIndex.One].ThumbSticks.Left.Y < 0.3
                        && InputHelper.OGS[(int)PlayerIndex.One].ThumbSticks.Left.Y > 0.3)
                        || InputHelper.WasKeyPressed(Keys.Up))
                    {
                        currentMenuItem--;
                        if (currentMenuItem < 0)
                            currentMenuItem = menuItems.Count - 1;
                    }

                    if (InputHelper.WasButtonPressed(PlayerIndex.One, Buttons.DPadDown)
                        || (InputHelper.NGS[(int)PlayerIndex.One].ThumbSticks.Left.Y < -0.3
                        && InputHelper.OGS[(int)PlayerIndex.One].ThumbSticks.Left.Y > -0.3)
                        || InputHelper.WasKeyPressed(Keys.Down))
                    {
                        currentMenuItem++;
                        if (currentMenuItem >= menuItems.Count)
                            currentMenuItem = 0;
                    }

                    //Activate Menu Item
                    if (InputHelper.WasButtonPressed(PlayerIndex.One, Buttons.A)
                        || InputHelper.WasKeyPressed(Keys.Space))
                    {
                        switch (currentMenuItem)
                        {
                            case 0: //Start Game
                                //GameManager.CreateLevels();
                                //GameManager.gameState = GameState.Playing;
                                break;

                            case 1: //Options
                                GameManager.gameState = GameState.HowToPlay;
                                break;

                            case 2: //Exit Game
                                Game1.ExitGame();
                                break;
                        }
                    }
                    break;
            }
        }

        public static void Draw(SpriteBatch SBHUD)
        {
            switch (MenuState)
            {
                case MenuState.TitleScreen:
                    SBHUD.DrawString(Game1.fontLarge, "Edge of Twilight", new Vector2(107, 100), Color.White);
                    SBHUD.DrawString(Game1.fontLarge, "Press Start", new Vector2(200, 400), Color.White);
                    break;

                case MenuState.MainMenu:
                    for (int i = 0; i < menuItems.Count; i++)
                    {
                        if (i == currentMenuItem)
                            menuItems[i].Draw(SBHUD, colorSelected);
                        else
                            menuItems[i].Draw(SBHUD, colorStandard);
                    }
                    break;
            }
        }

        public static void createMenuItems()
        {
            menuItems.Add(new MenuItem("Start Game", new Vector2(45, 50)));
            menuItems.Add(new MenuItem("Options", new Vector2(45, 120)));
            menuItems.Add(new MenuItem("Exit", new Vector2(45, 190)));
        }
    }
}
