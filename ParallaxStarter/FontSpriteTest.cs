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
        Player player;


        //creates new static sprite
        public FontSpriteTest(SpriteFont font, String text, Vector2 position, Player player)
        {
            this.font = font;
            this.position = position;
            this.text = text;
            this.player = player;
        }

        //draws the sprite
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            var offset = new Vector2(750, 500);
            offset.X -= player.bounds.X;
            offset.Y -= player.bounds.Y;
            var tMatrix = Matrix.CreateTranslation(offset.X, offset.Y, 0);

            if (player.gameState == GameState.Over)
            {
                var textOffsetGameOver = offset * -1;
                textOffsetGameOver.X += 750;
                textOffsetGameOver.Y += 500;
                spriteBatch.DrawString(font, "Game Over", textOffsetGameOver, Color.White);
            }
            else if (player.gameState == GameState.Win)
            {
                var textOffsetWin = offset * -1;
                textOffsetWin.X += 750;
                textOffsetWin.Y += 500;
                spriteBatch.DrawString(font, "You Win", textOffsetWin, Color.White);
            }
            else
            {
                spriteBatch.DrawString(font, text, position, Color.White);
            }
        }
    }
}
