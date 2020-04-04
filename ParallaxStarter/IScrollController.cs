using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace ParallaxStarter
{
    public interface IScrollController
    {
        Matrix Transform { get; }

        void Update(GameTime gameTime);
    }
}
