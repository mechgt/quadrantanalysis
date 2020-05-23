using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
namespace QuadrantAnalysis.UI
{
    class Common
    {
        internal enum ChartBasis
        {
            Power, HR, Cadence
        }

        public static readonly Color ColorCadence = Color.FromArgb(78, 154, 6);
        public static readonly Color ColorElevation = Color.FromArgb(143, 89, 2);
        public static readonly Color ColorGrade = Color.FromArgb(193, 125, 17);
        public static readonly Color ColorHR = Color.FromArgb(204, 0, 0);
        public static readonly Color ColorPower = Color.FromArgb(92, 53, 102);
        public static readonly Color ColorSpeed = Color.FromArgb(32, 74, 135);

        public static List<Color> Colors
        {
            get
            {
                List<Color> colors = new List<Color>();

                colors.Add(Color.SpringGreen);
                colors.Add(Color.DarkOrchid);
                colors.Add(Color.HotPink);
                colors.Add(Color.DarkSalmon);
                colors.Add(Color.PaleVioletRed);
                colors.Add(Color.Green);
                colors.Add(Color.ForestGreen);
                colors.Add(Color.Brown);
                colors.Add(Color.OrangeRed);
                colors.Add(Color.SteelBlue);
                colors.Add(Color.DeepPink);
                colors.Add(Color.DodgerBlue);
                colors.Add(Color.Blue);
                colors.Add(Color.Crimson);
                colors.Add(Color.Indigo);
                colors.Add(Color.SaddleBrown);
                colors.Add(Color.MidnightBlue);
                colors.Add(Color.DarkMagenta);

                return colors;
            }
        }

        public static Color GetRandomColor()
        {
            return Colors[new Random().Next(Colors.Count)];
        }

    }
}
