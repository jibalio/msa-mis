using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rylui
{
    class Property
    {
        public class Colors
        {
            public static Color BackColor = Color.WhiteSmoke;
            public static Color TitleBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(161)))), ((int)(((byte)(206)))));
            public static Color ButtonRed =  System.Drawing.Color.IndianRed;
            public static Color ButtonBlue = TitleBarColor;

        }

        public class ButtonText
        {
            public static string OK = "OK";
        }

        public class TextProperties
        {
           
            public static Point LocationNoIcon =  new System.Drawing.Point(13, 39);
            public static Size SizeNoIcon = new System.Drawing.Size(483, 131);
            
        }
    }
}
