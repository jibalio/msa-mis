using System.Drawing;

namespace rylui
{
    class Property
    {
        public class Colors
        {
            public static Color BackColor = Color.WhiteSmoke;
            public static Color TitleBarColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(161)))), ((int)(((byte)(206)))));

            //button Red
            public static Color ButtonRed =  System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            public static Color ButtonRedDown = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(57)))), ((int)(((byte)(43)))));
            public static Color ButtonRedHover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(97)))), ((int)(((byte)(81)))));

            //button Blue
            public static Color ButtonBlue = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(64)))), ((int)(((byte)(82)))));
            public static Color ButtonBlueDown = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(57)))), ((int)(((byte)(81)))));
            public static Color ButtonBlueHover = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(114)))), ((int)(((byte)(146)))));

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
