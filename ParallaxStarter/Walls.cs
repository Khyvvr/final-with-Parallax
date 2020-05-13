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
    public class Walls
    {
        Game1 game;
        Texture2D texture;

        //const int WALL_WIDTH = 50;
        //const int CORRIDOR_WIDTH = 138;

        const int CELL_DIMENSIONS = 135;

        int[,] mazeArray = new int[,] {{1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
                                       {1,0,0,1,0,0,0,1,0,0,0,0,0,0,0,0,1},
                                       {1,0,0,0,0,1,0,1,0,1,0,1,1,1,1,1,1},
                                       {1,0,1,1,1,1,0,1,0,1,0,0,0,0,0,0,1},
                                       {1,0,0,1,0,0,0,1,0,1,1,1,1,1,1,0,1},
                                       {1,1,0,1,1,1,1,1,0,1,0,0,0,0,0,0,1},
                                       {1,0,0,0,0,0,0,0,0,1,0,1,0,1,1,0,1},
                                       {1,0,1,1,1,1,1,1,0,1,1,1,1,1,2,2,1},
                                       {1,0,0,0,1,0,0,0,0,0,0,0,0,1,2,2,1},
                                       {1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1}};

        public List<BoundingRectangle> Maze = new List<BoundingRectangle>();
        public List<BoundingRectangle> Goal = new List<BoundingRectangle>();

        /*
        public BoundingRectangle WallN = new BoundingRectangle();
        public BoundingRectangle WallS = new BoundingRectangle();
        public BoundingRectangle WallE = new BoundingRectangle();
        public BoundingRectangle WallW = new BoundingRectangle();

        public BoundingRectangle MazeWall01 = new BoundingRectangle();
        public BoundingRectangle MazeWall02 = new BoundingRectangle();
        public BoundingRectangle MazeWall03 = new BoundingRectangle();
        public BoundingRectangle MazeWall04 = new BoundingRectangle();
        public BoundingRectangle MazeWall05 = new BoundingRectangle();
        public BoundingRectangle MazeWall06 = new BoundingRectangle();
        public BoundingRectangle MazeWall07 = new BoundingRectangle();
        public BoundingRectangle MazeWall08 = new BoundingRectangle();
        public BoundingRectangle MazeWall09 = new BoundingRectangle();
        */

        public Walls(Game1 game)
        {
            this.game = game;
        }

        public void Initialize()
        {
            for(int i = 0; i < mazeArray.GetLength(0); i++)
            {
                for(int j = 0; j < mazeArray.GetLength(1); j++)
                {
                    if(mazeArray[i,j] == 1)
                    {
                        BoundingRectangle cell = new BoundingRectangle();
                        cell.X = j * CELL_DIMENSIONS;
                        cell.Y = i * CELL_DIMENSIONS;
                        cell.Width = CELL_DIMENSIONS;
                        cell.Height = CELL_DIMENSIONS;
                        Maze.Add(cell);
                    }
                    else if(mazeArray[i,j] == 2)
                    {
                        BoundingRectangle cell = new BoundingRectangle();
                        cell.X = j * CELL_DIMENSIONS;
                        cell.Y = i * CELL_DIMENSIONS;
                        cell.Width = CELL_DIMENSIONS;
                        cell.Height = CELL_DIMENSIONS;
                        Goal.Add(cell);
                    }
                }
            }

            /*
            WallN.X = -50;
            WallN.Y = -50;
            WallN.Width = 2050;
            WallN.Height = WALL_WIDTH;
            Maze.Add(WallN);

            WallS.X = -50;
            WallS.Y = 1950;
            WallS.Width = 2050;
            WallS.Height = WALL_WIDTH;
            Maze.Add(WallS);

            WallE.X = 1950;
            WallE.Y = 0;
            WallE.Width = WALL_WIDTH;
            WallE.Height = 1950;
            Maze.Add(WallE);

            WallW.X = -50;
            WallW.Y = 0;
            WallW.Width = WALL_WIDTH;
            WallW.Height = 1950;
            Maze.Add(WallW);

            MazeWall02.X = 300;
            MazeWall02.Y = 0;
            MazeWall02.Width = WALL_WIDTH;
            MazeWall02.Height = 100;
            Maze.Add(MazeWall02);

            MazeWall01.X = CORRIDOR_WIDTH;
            MazeWall01.Y = MazeWall02.Y + MazeWall02.Height + CORRIDOR_WIDTH;
            MazeWall01.Width = MazeWall02.X + MazeWall02.Width;
            MazeWall01.Height = WALL_WIDTH;
            Maze.Add(MazeWall01);

            MazeWall03.X = MazeWall01.Width + CORRIDOR_WIDTH;
            MazeWall03.Y = CORRIDOR_WIDTH;
            MazeWall03.Width = WALL_WIDTH;
            MazeWall03.Height = MazeWall02.Height + WALL_WIDTH;
            Maze.Add(MazeWall03);

            MazeWall04.X = MazeWall03.X + MazeWall03.Width + CORRIDOR_WIDTH;
            MazeWall04.Y = 0;
            MazeWall04.Width = WALL_WIDTH;
            MazeWall04.Height = MazeWall01.Y + MazeWall01.Height + CORRIDOR_WIDTH + 15;
            Maze.Add(MazeWall04);

            MazeWall05.X = CORRIDOR_WIDTH;
            MazeWall05.Y = MazeWall01.Y + MazeWall01.Height + CORRIDOR_WIDTH;
            MazeWall05.Width = WALL_WIDTH;
            MazeWall05.Height = 200;
            Maze.Add(MazeWall05);

            MazeWall06.X = MazeWall05.X + MazeWall05.Width + CORRIDOR_WIDTH;
            MazeWall06.Y = MazeWall01.Y + MazeWall01.Height;
            MazeWall06.Width = WALL_WIDTH;
            MazeWall06.Height = 200;
            Maze.Add(MazeWall06);

            MazeWall07.X = 0;
            MazeWall07.Y = MazeWall05.Y + MazeWall05.Height;
            MazeWall07.Width = (2 * CORRIDOR_WIDTH) + WALL_WIDTH;
            MazeWall07.Height = WALL_WIDTH;
            Maze.Add(MazeWall07);

            MazeWall08.X = MazeWall06.X + MazeWall06.Width;
            MazeWall08.Y = MazeWall06.Y + MazeWall06.Height - WALL_WIDTH;
            MazeWall08.Width = MazeWall04.X - MazeWall06.X;
            MazeWall08.Height = WALL_WIDTH;
            Maze.Add(MazeWall08);

            MazeWall09.X = MazeWall07.Width + CORRIDOR_WIDTH;
            MazeWall09.Y = MazeWall08.Y + MazeWall08.Height;
            MazeWall09.Width = WALL_WIDTH;
            MazeWall09.Height = (3 * CORRIDOR_WIDTH) + (2 * WALL_WIDTH);
            Maze.Add(MazeWall09);*/
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("pixel");
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();

            foreach(BoundingRectangle wall in Maze)
            {
                spriteBatch.Draw(texture, wall, Color.Brown);
            }

            /*
            spriteBatch.Draw(texture, WallN, Color.Brown);
            spriteBatch.Draw(texture, WallS, Color.Brown);
            spriteBatch.Draw(texture, WallE, Color.Brown);
            spriteBatch.Draw(texture, WallW, Color.Brown);

            spriteBatch.Draw(texture, MazeWall01, Color.Brown);
            spriteBatch.Draw(texture, MazeWall02, Color.Brown);
            spriteBatch.Draw(texture, MazeWall03, Color.Brown);
            spriteBatch.Draw(texture, MazeWall04, Color.Brown);
            spriteBatch.Draw(texture, MazeWall05, Color.Brown);
            spriteBatch.Draw(texture, MazeWall06, Color.Brown);
            spriteBatch.Draw(texture, MazeWall07, Color.Brown);
            spriteBatch.Draw(texture, MazeWall08, Color.Brown);
            spriteBatch.Draw(texture, MazeWall09, Color.Brown);
            */

            spriteBatch.End();
        }
    }
}