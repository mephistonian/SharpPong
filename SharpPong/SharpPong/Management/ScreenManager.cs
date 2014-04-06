using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpPong.Screens;

namespace SharpPong.Management
{
    class ScreenManager
    {

        public Vector2 Dimensions { private set; get; }
        private static ScreenManager instance;
        public ContentManager Content { private set; get; }

        GameScreen currentScreen;

        public static ScreenManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ScreenManager();
                return instance;
            }
        }

        public ScreenManager()
        {
            Dimensions = new Vector2(800, 600);
            currentScreen = new Level();
        }

        /// <summary>
        /// Loads in-game content such as sprites and images
        /// </summary>
        public void LoadContent(ContentManager myContent)
        {
            this.Content = new ContentManager(myContent.ServiceProvider, "Content");
            currentScreen.LoadContent();
        }

        /// <summary>
        /// Unloads in-game content such as sprites and images
        /// </summary>
        public void UnloadContent()
        {
            currentScreen.UnloadContent();
        }

        /// <summary>
        /// Updates game logic and elements
        /// </summary>
        public void Update(GameTime gameTime)
        {
            currentScreen.Update(gameTime);
        }

        /// <summary>
        /// Renders content to screen
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            currentScreen.Draw(spriteBatch);
        }
    }
}