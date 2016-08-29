using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace JapWew
{
    public static class HtmlHelper
    {
        public static string GetUnicodeCodePoint(char c)
        {
            return $"U+{(int)c:X4}";
        }

        public static string GetHtmlCode(char c)
        {
            return $"&#{(int)c};";
        }

        public static string GetHtmlHexCode(char c)
        {
            return $"&#x{(int)c:X2};";
        }

        public unsafe static string GetData(char c)
        {
            string s = "";
            byte* pb = (byte*)&c;
            for (int i = 0; i < sizeof(char);)
                s += $"{pb[i++]:X2} ";
            return s;
        }

        public unsafe static string GetData(string c)
        {
            string s = "";
            fixed (char* pc = c)
            {
                byte* pb = (byte*)pc;
                while (*pb != 0)
                    s += $"{*pb++:X2} ";
            }
            return s;
        }

        //TODO: Add HTML 4.0 entities. e.g. &amp;
        // http://ascii-code.com/html-symbol.php
        public static string GetHtmlEntity(char c)
        {
            switch (c)
            {
                default:
                    return null;
            }
        }
    }
}
