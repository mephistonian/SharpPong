using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using SharpPong.Management;
using SharpPong.GameTypes;
using SharpPong.Logic;

namespace SharpPong.Screens
{
    class Level : GameScreen
    {
        Background background = new Background();
        Ball ball = new Ball();
        GameObject paddle = new GameObject();

        Physics physics;

        public override void LoadContent()
        {
            base.LoadContent();

            background.LoadBackground(content, "Background");
            ball.LoadObject(content, "Ball", ((int)ScreenManager.Instance.Dimensions.X / 2) - (ball.objectRectangle.Width / 2), 
                ((int)ScreenManager.Instance.Dimensions.Y / 2) - (ball.objectRectangle.Height / 2), 15, 15);

           
        }

        public override void UnloadContent()
        {
            base.UnloadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            ball.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            background.DrawBackground(spriteBatch);
            ball.DrawObject(spriteBatch);

            base.Draw(spriteBatch);
        }
    }
}
