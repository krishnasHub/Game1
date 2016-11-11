using Engine1Core;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    class SimpleActor : Actor
    {
        public SimpleActor(Vector2 pos) : base(pos)
        {
            // do nothing..
        }

        public override void Tick()
        {
            Position.X += 10f;
        }
    }
}
