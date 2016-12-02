using Engine2.Actor;
using Engine2.Input;
using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Actors
{
    class MyActor2 : GameActor
    {
        public string Name = "";

        public MyActor2(string path) : base(path)
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
