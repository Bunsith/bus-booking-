﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus_bookig
{
    public static class ThemeColor
    {
        public static Color PrimaryColor { get; set; }
        public static Color SecondaryColor { get; set; }
        public static List<string> ColorList = new List<string>()   { "#3F51B5",//ocean blue
                                                                        "#009688",// dark green
                                                                        "#FF5722",// carrot
                                                                        "#607D8B",// gray
                                                                        "#FF9800",// orange
                                                                        "#9C27B0",// purple
                                                                        "#2196F3",// sky blue
                                                                        "#EA676C",// pink
                                                                        "#E41A4A",// red pink
                                                                        "#5978BB",// light blue
                                                                        "#018790",// dark green
                                                                        "#0E3441",// light black done
                                                                        "#00B0AD",
                                                                        "#721D47",// dark pink
                                                                        "#EA4833",
                                                                        "#EF937E",
                                                                        "#F37521",
                                                                        "#A12059",
                                                                        "#126881",
                                                                        "#8BC240",
                                                                        "#364D5B",
                                                                        "#C7DC5B",
                                                                        "#0094BC",
                                                                        "#E4126B",
                                                                        "#43B76E",
                                                                        "#7BCFE9",
                                                                        "#B71C46"};
        public static Color ChangeColorBrightness(Color color, double correctionFactor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;
            //If correction factor is less than 0, darken color.
            if (correctionFactor < 0)
            {
                correctionFactor = 1 + correctionFactor;
                red *= correctionFactor;
                green *= correctionFactor;
                blue *= correctionFactor;
            }
            //If correction factor is greater than zero, lighten color.
            else
            {
                red = (255 - red) * correctionFactor + red;
                green = (255 - green) * correctionFactor + green;
                blue = (255 - blue) * correctionFactor + blue;
            }
            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);

        }
    }

}
