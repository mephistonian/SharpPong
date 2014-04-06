using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SharpPong.Management;
using SharpPong.GameTypes;
using SharpPong.Screens;

namespace SharpPong.Logic
{
    class Collision
    {
        // Initialization variables
        ContentManager content;
        GameTime gameTime;
        GameObject ball;

        public Collision(ContentManager content, GameTime gameTime, GameObject ball) 
        { 
            this.content = content;
            this.gameTime = gameTime;
            this.ball = ball;
        }
    }
}
