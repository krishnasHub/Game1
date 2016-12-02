using Engine2.Actor;
using Engine2.Input;
using Engine2.Lighting.Light;
using OpenTK;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Actors
{
    class MyActor1 : GameActor
    {
        public string Name = "";

        private int[] leftIndices = { 1, 2, 3, 4, 5, 6 };
        private int[] rightIndices = { 15, 16, 17, 18, 19, 20 };
        private int ladderClimbIndex = 49;
        private int idleIndex = 46;
        private int leftJumpIndex = 7;
        private int rghtJumpIndex = 21;
        private int currentIndex = 1;

        private int currentLeftIndex = 0;
        private int currentRightIndex = 0;
        private int changeCount = 0;
        private int changeFactor = 5;

        private int lastTurn = 0;

        public MyActor1() 
        {
            // Set the content to load for the actor.
            var tileSheet = new TileSheetManager("Actors/actor_tilesheet4.png");
            tileSheet.Rows = 4;
            tileSheet.Columns = 14;
            tileSheet.SpriteWidth = 672f / tileSheet.Columns;
            tileSheet.SpriteHeight = 192f / tileSheet.Rows;
            tileSheet.CurrentSprite = currentIndex;
            tileSheet.SpriteBuffer = new RectangleF(12f, 0f, 15f, 15f);

            this.TileSheet = tileSheet;
        }

        private int pastIndex = 1;
        private bool jumped = false;


        public override void Tick()
        {
            base.Tick();

            if (this.InAir)
            {
                if (currentIndex != leftJumpIndex && currentIndex != rghtJumpIndex)
                    pastIndex = currentIndex;

                if(lastTurn == -1)
                    currentIndex = leftJumpIndex;
                //if (getAnimDirection() == 1)
                else
                    currentIndex = rghtJumpIndex;
            }                
            else if (jumped)
            {
                currentIndex = pastIndex;
                jumped = false;
            }

            
            this.TileSheet.CurrentSprite = currentIndex;
        }


        public override void onHit(GameActor otherActor)
        {
            base.onHit(otherActor);

            this.Velocity *= -1f;
            this.Position += this.Velocity;
        }


        protected int animate(int[] indices, int index)
        {
            int changedIndex = index;
            if (changeCount % changeFactor == 0 || !(currentIndex >= indices[0] && currentIndex <= indices[indices.Length - 1]))
            {
                changedIndex = changedIndex % indices.Length;
                currentIndex = indices[changedIndex];
                changedIndex++;
                changeCount = 0;
            }

            return changedIndex;
        }

        public void MovePlayer(InputEvent keyInput)
        {
            changeCount++;
            float value = 2f;

            if(keyInput.IsReleased)
            {
                currentIndex = idleIndex;
                return;
            }
            
            switch (keyInput.Key)
            {
                case Key.Left:
                case Key.A:
                    if(keyInput.IsDown)
                        this.Position += new Vector2(-value, 0);
                    lastTurn = -1;
                    currentLeftIndex = animate(leftIndices, currentLeftIndex);
                    break;

                case Key.Right:
                case Key.D:
                    if (keyInput.IsDown)
                        this.Position += new Vector2(value, 0);
                    currentRightIndex = animate(rightIndices, currentRightIndex);
                    lastTurn = 1;
                    break;

                case Key.Up:
                case Key.W:
                    if (keyInput.IsDown)
                        this.Position += new Vector2(0f, -value);
                    currentIndex = ladderClimbIndex;
                    break;

                case Key.Down:
                case Key.S:
                    if (keyInput.IsDown)
                        this.Position += new Vector2(0f, value);
                    break;

                case Key.Space:
                    jumped = true;
                    this.Jump();
                    break;
            }
            
        }
    }
}
