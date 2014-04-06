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
    public class GameObject
    {
        // object variables (set public to support changing of size, shape, and texture)
        public Texture2D objectTexture;
        public Rectangle objectRectangle;
        public Vector2 objectVector;

        /// <summary>
        /// Used to initialize and load the object rectangle and texture
        /// </summary>
        /// <param name="myContent">Determines ContentManager in which to load the content</param>
        /// <param name="texturePath">Determines the texture to load from content</param>
        /// <param name="objectX">Location of objectRectangle.X</param>
        /// <param name="objectY">Location of objectRectangle.Y</param>
        /// <param name="objectSizeX">Width of objectRectangle</param>
        /// <param name="objectSizeY">Height of objectRectangle</param>
        public virtual void LoadObject(ContentManager myContent, string texturePath,
            int objectX, int objectY, int objectSizeX, int objectSizeY)
        {
            objectVector = new Vector2(objectX, objectY);
            objectRectangle = new Rectangle(objectX, objectY, objectSizeX, objectSizeY);
            objectTexture = myContent.Load<Texture2D>(texturePath);
        }

        /// <summary>
        /// Used to draw / render the object via the given SpriteBatch
        /// </summary>
        /// <param name="spriteBatch">Decides the SpriteBatch in which to draw / render the object</param>
        public virtual void DrawObject(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(objectTexture, objectVector, objectRectangle, Color.White);
        }
    }
}
