using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using OpenTK;
using Engine2.Core;
using Engine2.Util;
using Game1.Levels;
using Engine2.Actor;

namespace Game1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var g = new Game(1280, 960, 1.5f);
            Constants.RootFolder = "Content";

            var level2 = new Level("Level2.tmx");
            g.SetLevel(level2);

            var a = new GameActor("tile_wall.jpg");
            a.SetScale(0.05f);
            a.Position = new Vector2(0, 0);
            a.Velocity = new Vector2(-1.5f, 0f);
            a.BindToView = true;

            level2.AddActor(a);
            
            g.Run();
        }
    }
}
