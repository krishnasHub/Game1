using Engine2.Core;
using Engine2.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game1.Levels
{
    public class Level : GameLevel
    {
        public Level(string levelFileName) : base(levelFileName)
        {
            // Nothing as of now..
        }

        public override void Render()
        {
            base.Render();

            for (int x = 0; x < this.Width; x++)
            {
                for (int y = 0; y < this.Height; y++)
                {
                    RectangleF source;
                    // Tileset has 5 different tiles. Each starting from 1 to 5.
                    // Their location on the sprite sheet 
                    switch (this[x, y].Type)
                    {
                        case 1:
                            source = GetSourceRectangle(0, 0, Constants.TILE_SIZE);
                            break;

                        case 2:
                            source = GetSourceRectangle(0, 1, Constants.TILE_SIZE);
                            break;

                        case 3:
                            source = GetSourceRectangle(0, 2, Constants.TILE_SIZE);
                            break;

                        case 4:
                            source = GetSourceRectangle(0, 3, Constants.TILE_SIZE);
                            break;

                        case 5:
                            source = GetSourceRectangle(1, 0, Constants.TILE_SIZE);
                            break;

                        default:
                            source = new RectangleF(0, 0, 0, 0);
                            break;
                    }

                    DrawSprite(source, x, y);
                }
            }
        }
    }
}
