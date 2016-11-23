using Engine1Core;
using OpenTK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1
{
    public class SimpleLight : LightSource
    {
        public SimpleLight(Vector2 pos, float intensity) : base(pos, intensity)
        {

        }

        public override void Tick()
        {
            base.Tick();

            //Position.X += 10.0f;            
        }
    }
}
