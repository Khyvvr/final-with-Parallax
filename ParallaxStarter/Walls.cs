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

            spriteBatch.End();
        }
    }
}