using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace myControls.CommonTools
{
    public enum FontType { Arial }
    public class FontManager
    {
        public Font GetFont(FontType type,FontStyle style,float fontSize) 
        {
            return new Font(new FontFamily(Enum.GetName(typeof(FontType), type)), fontSize, style);
        }
    }
}
