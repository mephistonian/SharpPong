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
    class Physics
    {
        // Initialization variables
        ContentManager content;
        GameTime gameTime;
        Ball ball;

        // Ball properties
        float velocity;
        float mass;
        Vector2 position;
        float elapsed;
        float momentum;
        float acceleration;

        // Ball precision Vector2 locations
        float ballLeft, ballRight, ballTop, ballBottom;

        public Physics(ContentManager content, GameTime gameTime, Ball ball) 
        { 
            this.content = content;
            this.gameTime = gameTime;
            this.ball = ball;

            // General mass components

            // Determine mass
            mass = .5f;

            // Determine elapsed time
            elapsed = gameTime.ElapsedGameTime.Milliseconds;

            // Determine velocity
            velocity = mass * elapsed;

            // Determine momentum
            momentum = mass * velocity;

            //Determine acceleration
            acceleration = velocity * elapsed;

            //position = ball.objectVector;
            //ball.objectVector.X += velocity * mass;
            ball.objectVector.Y += velocity * mass;

            // Initialize ball precision Vector2 locations
            ballLeft = ball.objectVector.X;
            ballRight = ball.objectVector.X + ball.objectRectangle.Width;
            ballTop = ball.objectVector.Y;
            ballBottom = ball.objectVector.Y + ball.objectRectangle.Height;
        }

        public void Boundaries()
        {
            if (ballLeft <= 0)
            {
                // Reset timer
                elapsed = 0;
                // Stop ball from moving beyond boundaries
                ball.objectVector.X = 0;
                // Invert X axis
            }
            if (ballRight >= ScreenManager.Instance.Dimensions.X)
            {
                // Reset timer
                elapsed = 0;
                // Stop ball from moving beyond boundaries
                ball.objectVector.X = ScreenManager.Instance.Dimensions.X - (ballRight - ball.objectVector.X);
                // Invert X axis
            }
            if (ballTop <= 0)
            {
                // Reset timer
                elapsed = 0;
                // Stop ball from moving beyond boundaries
                ball.objectVector.Y = 0;
                // Invert Y axis
            }
            if (ballBottom >= ScreenManager.Instance.Dimensions.Y)
            {
                // Reset timer
                elapsed = 0;
                // Stop ball from moving beyond boundaries
                ball.objectVector.Y = ScreenManager.Instance.Dimensions.Y - (ballBottom - ball.objectVector.Y);
                // Invert Y axis
            }
        }
    }
}
