using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ParallaxStarter
{
    public class PlayerTrackingScrollController : IScrollController
    {
        Player player;
        public float ScrollRatio = 1.0f;                 // paralax layer scroll relative to player position
        public Vector2 Offset = new Vector2(750,500);    // offset between the scrolling layer and the player

        public Matrix Transform
        {
            get
            {
                float x = ScrollRatio * (Offset.X - player.Position.X);
                float y = ScrollRatio * (Offset.Y - player.Position.Y);
                return Matrix.CreateTranslation(x, y, 0);
            }
        }

        public void Update(GameTime gameTime)
        {

        }

        public PlayerTrackingScrollController(Player player, float ratio)
        {
            this.player = player;
            this.ScrollRatio = ratio;
        }
    }
}
