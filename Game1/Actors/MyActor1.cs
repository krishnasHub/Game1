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

        public void MovePlayer(InputEvent keyInput)
        {
            float value = 3f;
            
            switch (keyInput.Key)
            {
                case Key.Left:
                case Key.A:
                    this.Position += new Vector2(-value, 0);
                    break;

                case Key.Right:
                case Key.D:
                    this.Position += new Vector2(value, 0);
                    break;

                case Key.Up:
                case Key.W:
                    this.Position += new Vector2(0f, -value);
                    break;

                case Key.Down:
                case Key.S:
                    this.Position += new Vector2(0f, value);
                    break;
            }
            
        }
    }
}
