using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Tests
 * e - U+0065, &#101;, 65
 * ✓ - U+2713, &#10003;, 13 27
 * ｅ - U+FF45, &#65349;, 45 FF
 * 😑 - U+1F611, &#128529;, 3D D8 11 DE
 */

namespace JapWew
{
    public static class HtmlHelper
    {
        public static string GetUnicodeCodePoint(char c) => $"U+{(int)c:X4}";

        public static string GetUnicodeCodePoint(string c) => $"U+{GetDecimal(c):X4}";

        public static string GetHtmlCode(char c) => $"&#{(int)c};";

        public static string GetHtmlCode(string c) => $"&#{GetDecimal(c)};";

        public static string GetHtmlHexCode(char c) => $"&#x{(int)c:X2};";

        public unsafe static string GetHtmlHexCode(string c) => $"&#x{GetDecimal(c):X2};";

        public unsafe static string GetUtf16leData(char c)
        {
            string s = "";
            byte* pb = (byte*)&c;
            for (int i = 0; i < sizeof(char);)
                s += $"{pb[i++]:X2} ";
            return s;
        }

        public unsafe static string GetUtf16leData(string c)
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

        unsafe static uint GetDecimal(string c)
        {
            int n = 0, code = 0;
            fixed (char* pc = c)
            {
                byte* pb = (byte*)pc;
                while (*pb != 0)
                    code |= *pb++ << (n++ * 8);
            }
            return (uint)code;
        }

        //TODO: Add HTML 4.0 entities. e.g. &amp;
        // http://ascii-code.com/html-symbol.php
        public static string GetHtmlEntity(char c)
        {
            switch (c)
            {
                case '&': return "&amp;";
                default:  return null;
            }
        }
    }
}
