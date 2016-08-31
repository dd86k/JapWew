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

        public static string GetHtmlHexCode(string c) => $"&#x{GetDecimal(c):X2};";

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

        //TODO: Reverse LookupEntity(string)
        // trim '&' and ';' -> Switch

        //TODO: Add HTML 4.0 entities. e.g. &amp;
        // http://ascii-code.com/html-symbol.php
        public static string GetHtmlEntity(char c)
        {
            switch ((ushort)c)
            {
                case '"': return "&quot;";
                case '&': return "&amp;";
                case '<': return "&lt;";
                case '>': return "&gt;";

                case '€': return "&euro;";
                case '¢': return "&cent;";
                case '¤': return "&curren;";
                case '¥': return "&yen;";

                case 0x2002: return "&ensp;";
                case 0x2003: return "&emsp;";
                case 0x2009: return "&thinsp;";
                case 0x200C: return "&zwnj;";
                case 0x200D: return "&zwj;";
                case 0x200E: return "&lrm;";
                case 0x200F: return "&rlm;";
                case '–': return "&ndash;";
                case '—': return "&mdash;";
                case '‘': return "&lsquo;";
                case '’': return "&rsquo;";
                case '‚': return "&sbquo;";
                case '“': return "&ldquo;";
                case '”': return "&rdquo;";
                case '„': return "&bdquo;";
                case '†': return "&dagger;";
                case '‡': return "&Dagger;";
                case '•': return "&bull;";
                case '…': return "&hellip;";
                case '‰': return "&permil;";
                case '′': return "&prime;";
                case '″': return "&Prime;";
                case '‹': return "&lsaquo;";
                case '›': return "&rsaquo;";
                case '‾': return "&oline;";
                case '⁄': return "&frasl;";

                case '◊': return "&loz;";

                case 'Α': return "&Alpha;";
                case 'Β': return "&Beta;";
                case 'Γ': return "&Gamma;";
                case 'Δ': return "&Delta;";
                case 'Ε': return "&Epsilon;";
                case 'Ζ': return "&Zeta;";
                case 'Η': return "&Eta;";
                case 'Θ': return "&Theta;";
                case 'Ι': return "&Iota;";
                case 'Κ': return "&Kappa;";
                case 'Λ': return "&Lambda;";
                case 'Μ': return "&Mu;";
                case 'Ν': return "&Nu;";
                case 'Ξ': return "&Xi;";
                case 'Ο': return "&Omicron;";
                case 'Π': return "&Pi;";
                case 'Ρ': return "&Rho;";
                case 'Σ': return "&Sigma;";
                case 'Τ': return "&Tau;";
                case 'Υ': return "&Upsilon;";
                case 'Φ': return "&Phi;";
                case 'Χ': return "&Chi;";
                case 'Ψ': return "&Psi;";
                case 'Ω': return "&Omega;";
                case 'α': return "&alpha;";
                case 'β': return "&beta;";
                case 'γ': return "&gamma;";
                case 'δ': return "&delta;";
                case 'ε': return "&epsilon;";
                case 'ζ': return "&zeta;";
                case 'η': return "&eta;";
                case 'θ': return "&theta;";
                case 'ι': return "&iota;";
                case 'κ': return "&kappa;";
                case 'λ': return "&lambda;";
                case 'μ': return "&mu;";
                case 'ν': return "&nu;";
                case 'ξ': return "&xi;";
                case 'ο': return "&omicron;";
                case 'π': return "&pi;";
                case 'ρ': return "&rho;";
                case 'ς': return "&sigmaf;";
                case 'σ': return "&sigma;";
                case 'τ': return "&tau;";
                case 'υ': return "&upsilon;";
                case 'φ': return "&phi;";
                case 'χ': return "&chi;";
                case 'ψ': return "&psi;";
                case 'ω': return "&omega;";
                case 'ϑ': return "&thetasym;";
                case 'ϒ': return "&upsih;";
                case 'ϖ': return "&piv;";

                case '←': return "&larr;";
                case '↑': return "&uarr;";
                case '→': return "&rarr;";
                case '↓': return "&rarr;";
                case '↔': return "&harr;";
                case '⇐': return "&lArr;";
                case '⇑': return "&uArr;";
                case '⇒': return "&rArr;";
                case '⇓': return "&dArr;";
                case '⇔': return "&hArr;";
                default:  return null;
            }
        }
    }
}
