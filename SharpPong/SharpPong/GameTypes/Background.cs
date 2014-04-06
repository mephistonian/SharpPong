using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpPong.Management;

namespace SharpPong.GameTypes
{
    /// <summary>
    /// Used to dynamically load and draw an instance of the background
    /// </summary>
    class Background
    {
        // background variables (set public to support changing of size, shape, and texture)
        public Texture2D backgroundTexture;
        public Rectangle backgroundRectangle;

        /// <summary>
        /// Used to initialize and load the background rectangle and texture
        /// </summary>
        /// <param name="myContent">Determines ContentManager in which to load the content</param>
        /// <param name="texturePath">Determines the texture to load from content</param>
        /// <param name="backgroundX">Location of backgroundRectangle.X</param>
        /// <param name="backgroundY">Location of backgroundRectangle.Y</param>
        /// <param name="backgroundSizeX">Width of backgroundRectangle</param>
        /// <param name="backgroundSizeY">Height of backgroundRectangle</param>
        public void LoadBackground(ContentManager myContent, string texturePath,
            int backgroundX, int backgroundY, int backgroundSizeX, int backgroundSizeY)
        {
            backgroundRectangle = new Rectangle(backgroundX, backgroundY, backgroundSizeX, backgroundSizeY);
            backgroundTexture = myContent.Load<Texture2D>(texturePath);
        }

        public void LoadBackground(ContentManager myContent, string texturePath)
        {
            backgroundRectangle = new Rectangle(0, 0, (int)ScreenManager.Instance.Dimensions.X, (int)ScreenManager.Instance.Dimensions.Y);
            backgroundTexture = myContent.Load<Texture2D>(texturePath);
        }

        /// <summary>
        /// Used to draw / render the background via the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch">Decides the SpriteBatch in which to draw / render the background</param>
        public void DrawBackground(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(backgroundTexture, backgroundRectangle, Color.White);
        }
    }
}

