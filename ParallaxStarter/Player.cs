using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace ParallaxStarter
{
    enum State
    {
        South = 0,
        East = 1,
        North = 2,
        West = 3,
        Idle = 4,
    }

    public enum GameState
    {
        Game = 0,
        Over = 1,
        Win = 2,
    }

    public class Player : ISprite
    {
        /// <summary>
        /// A spritesheet containing a helicopter image
        /// </summary>
        Texture2D spritesheet;

        /// <summary>
        /// The origin of the helicopter sprite
        /// </summary>
        Vector2 origin = new Vector2(0, 0);

        /// <summary>
        /// The player's position in the world
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// How fast the player moves
        /// </summary>
        public float Speed { get; set; } = 250;


        const int FRAMERATE = 124;
        const int FRAME_WIDTH = 16;
        const int FRAME_HEIGHT = 31;

        public BoundingRectangle bounds;
        State animationState;
        TimeSpan timer;
        int frame;
        public GameState gameState;

        /// <summary>
        /// Constructs a player
        /// </summary>
        /// <param name="spritesheet">The player's spritesheet</param>
        public Player(Texture2D spritesheet, Game1 game)
        {
            this.spritesheet = spritesheet;
            this.Position = new Vector2(200, 200);

            timer = new TimeSpan(0);
            animationState = State.Idle;
            gameState = GameState.Game;

            bounds.X = Position.X;
            bounds.Y = Position.Y;
            bounds.Width = 75;
            bounds.Height = 100;
        }

        /// <summary>
        /// Loads content for player and player layer (might include walls here)
        /// </summary>
        /// <param name="content"></param>
        public void LoadContent(ContentManager content)
        {
            
        }

        /// <summary>
        /// Updates the player position based on GamePad or Keyboard input
        /// </summary>
        /// <param name="gameTime">The GameTime object</param>
        public void Update(GameTime gameTime)
        {
            Vector2 direction = Vector2.Zero;

            // Override with keyboard input
            var keyboard = Keyboard.GetState();
            if(keyboard.IsKeyDown(Keys.Left) || keyboard.IsKeyDown(Keys.A))
            {
                animationState = State.West;
                direction.X -= 1;
            }
            if (keyboard.IsKeyDown(Keys.Right) || keyboard.IsKeyDown(Keys.D)) 
            {
                animationState = State.East;
                direction.X += 1;
            }
            if(keyboard.IsKeyDown(Keys.Up) || keyboard.IsKeyDown(Keys.W))
            {
                animationState = State.North;
                direction.Y -= 1;
            }
            if(keyboard.IsKeyDown(Keys.Down) || keyboard.IsKeyDown(Keys.S))
            {
                animationState = State.South;
                direction.Y += 1;
            }
            else
            {
                animationState = State.Idle;
            }

            // Move the character
            Position += (float)gameTime.ElapsedGameTime.TotalSeconds * Speed * direction;
            bounds.X = Position.X;
            bounds.Y = Position.Y;

            // Animation Timer
            if (animationState != State.Idle)
            {
                timer += gameTime.ElapsedGameTime;
            }
            while (timer.TotalMilliseconds > FRAMERATE)
            {
                frame++;
                timer -= new TimeSpan(0, 0, 0, 0, FRAMERATE);
            }
            frame %= 4; 
        }

        /// <summary>
        /// Draws the player sprite
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            Rectangle sourceRect = new Rectangle(
                frame * FRAME_WIDTH,
                (int)animationState % 4 * FRAME_HEIGHT,
                FRAME_WIDTH,
                FRAME_HEIGHT);

            // Render the character
            spriteBatch.Draw(spritesheet, Position, sourceRect, Color.White, 0, origin, 3f, SpriteEffects.None, 0.0f);
        }

    }
}
