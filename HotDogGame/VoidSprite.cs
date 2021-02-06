using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using HotDogGame.Collisions;

namespace HotDogGame
{
    public class VoidSprite
    {
        private GamePadState gamePadState;

        private bool hitBox;

        private KeyboardState keyboardState;

        private Texture2D texture;

        public Vector2 position = new Vector2(200,200);

        public BoundingCircle circle = new BoundingCircle(new Vector2(0,-32),16);

        public BoundingCircle Circle => circle;

        public Color color { get; set; } = Color.White;
        /// <summary>
        /// Rainbox Void image is loaded in
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("RainbowBall");
        }
        /// <summary>
        /// Sprites update method used to reframe hitbox and adjust position according to input
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="sc"></param>
        public void Update(GameTime gameTime, double sc)
        {
            gamePadState = GamePad.GetState(0);
            keyboardState = Keyboard.GetState();

            
            position += gamePadState.ThumbSticks.Left * new Vector2(1, -1);
           
            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.W)) position += new Vector2(0, -1);
            if (keyboardState.IsKeyDown(Keys.Down) || keyboardState.IsKeyDown(Keys.S)) position += new Vector2(0, 1);
            if (keyboardState.IsKeyDown(Keys.Left) || keyboardState.IsKeyDown(Keys.A))
            {
                position += new Vector2(-1, 0);
                
            }
            if (keyboardState.IsKeyDown(Keys.Right) || keyboardState.IsKeyDown(Keys.D))
            {
                position += new Vector2(1, 0);
               
            }
            circle.Center = position - new Vector2(-13,-13);
            
            
        }
        /// <summary>
        /// Draws the sprite using the supplied SpriteBatch
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The spritebatch to render with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch, float sc)
        {
            //SpriteEffects spriteEffects = (flipped) ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
            float scale = .05f + sc;
            if(sc/.05f > 1)
            {
                hitBox = true;
            }
            spriteBatch.Draw(texture,position,null,Color.White,0,new Vector2(64,64), scale ,SpriteEffects.None,0);
            
        }
    }
}
