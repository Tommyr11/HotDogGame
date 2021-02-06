using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using HotDogGame.Collisions;

namespace HotDogGame
{
    public class BasketballSprite
    {
        private Vector2 position;

        private Texture2D texture;

        private BoundingCircle circle;

        public BoundingCircle Circle => circle;
        public bool Hit { get; set; } = false;
        /// <summary>
        /// Basketball sprite contructor that creates hitboxes and random positions
        /// </summary>
        /// <param name="position"></param>
        public BasketballSprite(Vector2 position)
        {
            this.position = position;
            this.circle = new BoundingCircle(position - new Vector2(-8, -8), 8);
        }
        /// <summary>
        /// Loads in the basketball image
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("ball_small");
        }
        /// <summary>
        /// Draws the balls if they have not been hit
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="spriteBatch"></param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (Hit) return;
            spriteBatch.Draw(texture, position, Color.White);
        }

    }
}
