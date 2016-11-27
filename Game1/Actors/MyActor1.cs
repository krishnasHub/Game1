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
            float value = 2f;
            
            switch (keyInput.Key)
            {
                case Key.Left:
                case Key.A:
                    if(keyInput.IsDown)
                        this.Position += new Vector2(-value, 0);
                    break;

                case Key.Right:
                case Key.D:
                    if (keyInput.IsDown)
                        this.Position += new Vector2(value, 0);
                    break;

                case Key.Up:
                case Key.W:
                    //this.Velocity += new Vector2(0f, -value);
                    this.Jump();
                    break;

                case Key.Down:
                case Key.S:
                    if (keyInput.IsDown)
                        this.Velocity += new Vector2(0f, value);
                    break;
            }
            
        }
    }
}
