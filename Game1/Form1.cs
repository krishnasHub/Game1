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
using Engine2.Physics.Block;
using Engine2.Physics.Actor;
using Game1.Actors;

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

            var a = new MyActor1("tile_wall.jpg");
            a.Name = "Wall";
            a.SetScale(0.05f);
            a.Position = new Vector2(350, 1050);
            a.Velocity = new Vector2(0.25f, 0f);
            a.BindToView = true;
            a.PhysicsComponent = new ActorPhysics();

            var b = new MyActor1("tile_grass.png");
            b.Name = "Grass";
            b.SetScale(0.1f);
            b.Position = new Vector2(450, 1050);
            b.Velocity = new Vector2(-0.25f, 0f);
            b.PhysicsComponent = new ActorPhysics();

            level2.SetBlockPhysics(2, new SolidBlockPhysics());

            level2.AddActor(a);
            level2.AddActor(b);

            g.Run();
        }
    }
}
