using Engine2.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Actors
{
    class MyActor1 : GameActor
    {
        public string Name = "";

        public MyActor1(string path) : base(path)
        {
            // do nothing..
        }

        public override void onHit(GameActor otherActor)
        {
            base.onHit(otherActor);

            this.Velocity *= -1f;
            this.Position += this.Velocity;
        }
    }
}
