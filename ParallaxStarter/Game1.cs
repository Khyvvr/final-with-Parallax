using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ParallaxStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Walls walls;
        Player player;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            walls = new Walls(this);
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            graphics.PreferredBackBufferWidth = 1500;
            graphics.PreferredBackBufferHeight = 900;
            graphics.ApplyChanges();

            walls.Initialize();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            walls.LoadContent(Content);

            var spritesheet = Content.Load<Texture2D>("character");
            player = new Player(spritesheet, this);
            

            // Parallax Implementation START
            // Load Textures
            var backgroundTexture = Content.Load<Texture2D>("background");
            var starsTexture = Content.Load<Texture2D>("stars");
            var farPlanetsTexture = Content.Load<Texture2D>("farPlanets");
            var bigPlanetTexture = Content.Load<Texture2D>("bigPlanet");
            var ringPlanetTexture = Content.Load<Texture2D>("ringPlanet");

            var mazeTexture = Content.Load<Texture2D>("pixel");

            // Create corresponding StaticSprites
            var backgroundSprite = new StaticSprite(backgroundTexture, new Vector2(0, 0));
            var starsSprite = new StaticSprite(starsTexture, new Vector2(0, 0));
            var farPlanetsSprite = new StaticSprite(farPlanetsTexture, new Vector2(100, 200));
            var bigPlanetSprite = new StaticSprite(bigPlanetTexture, new Vector2(300, 300));
            var ringPlanetSprite = new StaticSprite(ringPlanetTexture, new Vector2(800, 200));

            var mazeSprites = new List<StaticSprite>();
            foreach (BoundingRectangle wall in walls.Maze)
            {
                // set staticsprite for each wall of the maze and give it corresponding position (mazeTexture, wall.Position)
                var position = new Vector2(wall.X, wall.Y);
                var sprite = new StaticSprite(mazeTexture, position, wall.Width, wall.Height);

                mazeSprites.Add(sprite);
            }

            // Create corresponding Parallax Layers
            var backgroundLayer = new ParallaxLayer(this);
            var starsLayer = new ParallaxLayer(this);
            var farPlanetsLayer = new ParallaxLayer(this);
            var bigPlanetLayer = new ParallaxLayer(this);
            var playerLayer = new ParallaxLayer(this);
            var ringPlanetLayer = new ParallaxLayer(this);

            var mazeLayer = new ParallaxLayer(this);
            foreach (var sprite in mazeSprites)
            {
                mazeLayer.Sprites.Add(sprite);
            }

            // Add sprites to corresponding layers
            backgroundLayer.Sprites.Add(backgroundSprite);
            starsLayer.Sprites.Add(starsSprite);
            farPlanetsLayer.Sprites.Add(farPlanetsSprite);
            bigPlanetLayer.Sprites.Add(bigPlanetSprite);
            playerLayer.Sprites.Add(player);
            ringPlanetLayer.Sprites.Add(ringPlanetSprite);

            // Create Draw Order (back to front)
            backgroundLayer.DrawOrder = 0;
            starsLayer.DrawOrder = 1;
            farPlanetsLayer.DrawOrder = 2;
            bigPlanetLayer.DrawOrder = 3;
            playerLayer.DrawOrder = 4;
            ringPlanetLayer.DrawOrder = 5;

            mazeLayer.DrawOrder = 4;

            // Add parallax layers to components
            Components.Add(backgroundLayer);
            Components.Add(starsLayer);
            Components.Add(farPlanetsLayer);
            Components.Add(bigPlanetLayer);
            Components.Add(playerLayer);
            Components.Add(ringPlanetLayer);

            Components.Add(mazeLayer);



            // SCROLLING WITH PLAYER (PART 8 IN LAB TUTORIAL)
            backgroundLayer.ScrollController = new PlayerTrackingScrollController(player, 0.1f);
            starsLayer.ScrollController = new PlayerTrackingScrollController(player, 0.2f);
            farPlanetsLayer.ScrollController = new PlayerTrackingScrollController(player, 0.3f);
            bigPlanetLayer.ScrollController = new PlayerTrackingScrollController(player, 0.4f);
            playerLayer.ScrollController = new PlayerTrackingScrollController(player, 1.0f);
            ringPlanetLayer.ScrollController = new PlayerTrackingScrollController(player, 1.0f);

            mazeLayer.ScrollController = new PlayerTrackingScrollController(player, 1.0f);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            var environmentColor = new Color(r:16,g:7,b:16);
            GraphicsDevice.Clear(environmentColor);

            // TODO: Add your drawing code here
            

            base.Draw(gameTime);
        }
    }
}
