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
using OpenTK.Input;
using Engine2.Physics.Level;
using Game1.Examples;

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
            var g = new Game(1280, 960, 4.5f);
            Constants.RootFolder = "Content";

            var level2 = new Level("Level2.tmx");
            g.SetLevel(level2);
            level2.LevelPhysics = new LevelPhysics();

            var a = new MyActor1();
            a.Name = "Wall";
            a.SetScale(1.25f);
            a.Position = new Vector2(400, 950);
            a.BindToView = true;
            a.PhysicsComponent = new ActorPhysics();

            var b = new MyActor2("tile_grass.png");
            b.Name = "Grass";
            b.SetScale(0.1f);
            b.Position = new Vector2(450, 1050);
            b.BounceFactor = 20f;
            b.PhysicsComponent = new ActorPhysics();

            level2.SetBlockPhysics(2, new SolidBlockPhysics());
            level2.SetBlockPhysics(4, new LadderBlockPhysics());
            level2.AddActor(a);
            level2.AddActor(b);

            g.AddKeyEvent(Key.Right, a.MovePlayer);
            g.AddKeyEvent(Key.D, a.MovePlayer);
            g.AddKeyEvent(Key.Left, a.MovePlayer);
            g.AddKeyEvent(Key.A, a.MovePlayer);
            g.AddKeyEvent(Key.Up, a.MovePlayer);
            g.AddKeyEvent(Key.W, a.MovePlayer);
            g.AddKeyEvent(Key.Down, a.MovePlayer);
            g.AddKeyEvent(Key.S, a.MovePlayer);
            g.AddKeyEvent(Key.Space, a.MovePlayer);

            g.Run();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (T04_Vertex_Lighting example = new T04_Vertex_Lighting())
            {
                Utilities.SetWindowTitle(example);
                example.Run(30.0, 0.0);
            }
        }
    }
}
