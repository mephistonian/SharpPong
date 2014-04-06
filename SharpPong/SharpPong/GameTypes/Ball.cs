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
using SharpPong.Screens;

namespace SharpPong.GameTypes
{
    public class Ball : GameObject
    {
        // Ball precision Vector2 locations
        public static float ballLeft, ballRight, ballTop, ballBottom;

        // Physics variables
        float VelX = 5;
        float VelY = 5;

        public override void LoadObject(Microsoft.Xna.Framework.Content.ContentManager myContent, string texturePath, int objectX, int objectY, int objectSizeX, int objectSizeY)
        {
            base.LoadObject(myContent, texturePath, objectX, objectY, objectSizeX, objectSizeY);
        }

        public override void DrawObject(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            base.DrawObject(spriteBatch);
        }

        public void Update()
        {
            BallControl();
            InitForce();

            // Initialize ball precision Vector2 locations
            ballLeft = this.objectVector.X;
            ballRight = this.objectVector.X + this.objectRectangle.Width;
            ballTop = this.objectVector.Y;
            ballBottom = this.objectVector.Y + this.objectRectangle.Height;

            // Boundary detection
            if (ballLeft <= 0)
            {
                this.objectVector.X = 0;
                VelX *= -1;
            }
            if (ballRight >= ScreenManager.Instance.Dimensions.X)
            {
                this.objectVector.X = ScreenManager.Instance.Dimensions.X - (this.objectRectangle.Width);
                VelX *= -1;
            }
            if (ballTop <= 0)
            {
                this.objectVector.Y = 0;
                VelY *= -1;
            }
            if (ballBottom >= ScreenManager.Instance.Dimensions.Y)
            {
                this.objectVector.Y = ScreenManager.Instance.Dimensions.Y - (this.objectRectangle.Width);
                VelY = VelY * -1;
            }
        }

        private void InitForce() 
        {
            //ForceCycle = 25;
            //ForceTime++;
            //if (ForceTime <= ForceCycle)
            //    Force = ForceTime;
            //else
            //    Force = 0;
            
            this.objectVector.X += VelX;
            this.objectVector.Y += VelY;
        }

        private void BallControl()
        {
            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //{
            //    VelX *= 1.009f; VelY *= 1.009f;
            //}
            //if (Keyboard.GetState().IsKeyDown(Keys.Up))
            //{
            //    VelX *= 1.009f; VelY *= 1.009f;
            //}
            ////Keys x = Keyboard.GetState().GetPressedKeys()[0];
            //Keys[] keys = Keyboard.GetState().GetPressedKeys();
            ////Keys key = keys[0];
            ////key = Keyboard.GetState().GetPressedKeys();
            //switch (keys)
            //{
            //    case Keys.Up:
            //        VelX *= 1.009f; VelY *= 1.009f;
            //        break;
            //}
            Keys[] pressed_Key = Keyboard.GetState().GetPressedKeys();

            for (int i = 0; i < pressed_Key.Length; i++)
            {
                switch (pressed_Key[i])
                {
                    case Keys.Up:
                            VelX *= 1.009f; VelY *= 1.009f;
                            break;
                    case Keys.Down:
                        VelX *= .991f; VelY *= .991f;
                        break;
                    case Keys.Right:
                        //VelX *= .991f; VelY *= 1.009f;
                        if (VelX > 0)
                        {
                            if (VelY > 0)
                            {
                                VelX *= .991f;
                            }
                            else
                            {
                                VelY = .991f;
                            }
                        }
                        else
                        {
                            if (VelY > 0)
                            {
                                VelY *= 1.009f;
                            }
                            else
                            {
                                VelX *= 1.009f;
                            }
                        }
                        break;
                    case Keys.Left:
                        //VelX *= 1.009f; VelY *= .991f;
                        if (VelX > 0)
                        {
                            if (VelY > 0)
                            {
                                VelY *= .991f;
                            }
                            else
                            {
                                VelX = .991f;
                            }
                        }
                        else
                        {
                            if (VelY > 0)
                            {
                                VelX *= 1.009f;
                            }
                            else
                            {
                                VelY *= 1.009f;
                            }
                        }

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
