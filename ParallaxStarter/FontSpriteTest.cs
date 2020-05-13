using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ParallaxStarter
{
    public class FontSpriteTest : ISprite
    {
        public Vector2 position = Vector2.Zero;         //sprite's position in the world
        SpriteFont font;                              //sprite's font
        String text;


        //creates new static sprite
        public FontSpriteTest(SpriteFont font, String text, Vector2 position)
        {
            this.font = font;
            this.position = position;
            this.text = text;
        }

        //draws the sprite
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.DrawString(font, text, position, Color.White);
        }
    }
}
