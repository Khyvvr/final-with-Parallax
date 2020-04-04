using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ParallaxStarter
{
    public class AutoScrollController : IScrollController
    {
        float elapsedTime = 0;
        public float Speed = 10f;

        //gets the current transformation matrix
        public Matrix Transform
        {
            get
            {
                return Matrix.CreateTranslation(-elapsedTime * Speed, 0, 0);
            }
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
