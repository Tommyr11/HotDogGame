﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections;
using System.Collections.Generic;

namespace HotDogGame
{
    public class BallVoidGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private VoidSprite voidSprite;
        private BasketballSprite[] balls;
        private int ballsHit;
        private SpriteFont spriteFont;
        private Stack<BasketballSprite> newBalls = new Stack<BasketballSprite>();
        private Texture2D basketball;
        private int ballCount = 7;

        public BallVoidGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            System.Random rand = new System.Random();
            balls = new BasketballSprite[]
            {
                new BasketballSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new BasketballSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new BasketballSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new BasketballSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new BasketballSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new BasketballSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height)),
                new BasketballSprite(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height))
            };
           // ballsLeft = balls.Length;
           if(ballCount != 0)  voidSprite = new VoidSprite();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            foreach (var ball in balls) ball.LoadContent(Content);
            voidSprite.LoadContent(Content);
            basketball = Content.Load<Texture2D>("basketball");
            
            //spriteFont = Content.Load<SpriteFont>("arial");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            System.Random rand = new System.Random();
            voidSprite.Update(gameTime,0);
            foreach (var ball in balls)
            {
                if (!ball.Hit && ball.Circle.CollidesWith(voidSprite.Circle))
                {
                    
                    ball.Hit = true;
                    ballCount--;
                    if (ballCount == 0)
                    {
                        Initialize();
                        ballCount = 7;
                    }

                }

            }
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            float scale = 0;
            double s = 0;
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            foreach (var ball in balls)
            {
                ball.Draw(gameTime, _spriteBatch);
                if (ball.Hit)
                {
                    scale += (float).05;
                    
                    
                }
            }

            var rectG = new Rectangle((int)(voidSprite.Circle.Center.X - voidSprite.Circle.Radius),
                                          (int)(voidSprite.Circle.Center.Y - voidSprite.Circle.Radius),
                                          (int)(2 * voidSprite.Circle.Radius), (int)(2 * voidSprite.Circle.Radius));
            _spriteBatch.Draw(basketball, rectG, Color.White);


            voidSprite.Draw(gameTime, _spriteBatch,scale);
            voidSprite.Update(gameTime,0);
            s--;
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
