using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Engine1Core;
using OpenTK;

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
            var gw = new Engine1Core.GameWindow(1024, 768);

            var actor = new SimpleActor(Vector2.Zero);
            actor.SetTexture("sample_texture_1.jpg");

            var light = new LightSource(Vector2.Zero, 0.65f);
            
            gw.AddGameObject(actor);
            gw.AddGameObject(light);
            gw.Run();
        }
    }
}
