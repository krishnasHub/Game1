﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK;
using System.Drawing;

namespace Game1.Examples
{
    public static class Utilities
    {
        /// <summary>
        /// Converts a System.Drawing.Color to a System.Int32.
        /// </summary>
        /// <param name="c">The System.Drawing.Color to convert.</param>
        /// <returns>A System.Int32 containing the R, G, B, A values of the
        /// given System.Drawing.Color in the Rbga32 format.</returns>
        public static int ColorToRgba32(Color c)
        {
            return (int)((c.A << 24) | (c.B << 16) | (c.G << 8) | c.R);
        }

        /// <summary>
        /// Sets the window title to the name of the sample.
        /// </summary>
        /// <param name="window"></param>
        public static void SetWindowTitle(GameWindow window)
        {
            ExampleAttribute info = GetExampleAttribute(window.GetType());
            //window.Title = String.Format("OpenTK | {0} {1}: {2}", info.Category, info.Difficulty, info.Title);
            //window.Icon = OpenTK.Examples.Properties.Resources.App;
        }

        /// <summary>
        /// Sets the window title to the name of the sample.
        /// </summary>
        /// <param name="window"></param>
        public static void SetWindowTitle(System.Windows.Forms.Form window)
        {
            ExampleAttribute info = GetExampleAttribute(window.GetType());
            window.Text = String.Format("OpenTK | {0} {1}: {2}", info.Category, info.Difficulty, info.Title);
            //window.Icon = OpenTK.Examples.Properties.Resources.App;
        }

        static ExampleAttribute GetExampleAttribute(Type type)
        {
            object[] attributes = type.GetCustomAttributes(false);
            foreach (object attr in attributes)
                if (attr is ExampleAttribute)
                    return attr as ExampleAttribute;

            return null;
        }
    }
}
