using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParallaxStarter
{
    public class StaticSprite : ISprite
    {
        public Vector2 position = Vector2.Zero;         //sprite's position in the world
        Texture2D texture;                              //sprite's texture

        BoundingRectangle bounds = new BoundingRectangle(); //sprite's boundaries

        //creates new static sprite
        public StaticSprite(Texture2D texture)
        {
            this.texture = texture;
        }

        public StaticSprite(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
        }

        public StaticSprite(Texture2D texture, Vector2 position, float width, float height)
        {
            this.texture = texture;
            this.position = position;
            this.bounds.X = position.X;
            this.bounds.Y = position.Y;
            this.bounds.Width = width;
            this.bounds.Height = height;
        }

        //draws the sprite
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(texture, position, Color.White);

            spriteBatch.Draw(texture, bounds, Color.White);
        }
    }
}
