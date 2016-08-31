using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public static string GetHtmlCode(char c) => $"#{(int)c};";

        public static string GetHtmlCode(string c) => $"#{GetDecimal(c)};";

        public static string GetHtmlHexCode(char c) => $"#x{(int)c:X2};";

        public static string GetHtmlHexCode(string c) => $"#x{GetDecimal(c):X2};";

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

        public static string GetHtmlEntity(char c)
        {
            string o = GetEntity(c);

            return o == null ? "--" : $"&{o};";
        }
                
        //https://en.wikipedia.org/wiki/List_of_XML_and_HTML_character_entity_references
        public static string GetEntity(char c)
        {
            switch ((ushort)c)
            {
                case '"': return "quot";
                case '&': return "amp";
                case '<': return "lt";
                case '>': return "gt";
                case 'ˆ': return "circ";
                case '˜': return "tilde";
                case '¡': return "iexcl";
                case '¦': return "brvbar";
                case '§': return "sect";
                case '¨': return "uml";
                case 'ª': return "ordf";
                case '«': return "laquo";
                case '»': return "raquo";
                case '¬': return "not";
                case 0xAD: return "shy";
                case '®': return "reg";
                case '°': return "deg";
                case '¹': return "sup1";
                case '²': return "sup2";
                case '³': return "sup3";
                case '´': return "acute";
                case '¶': return "para";
                case '·': return "middot";
                case '¸': return "cedil";
                case 'º': return "ordm";
                case '¿': return "iquest";
                case 'À': return "Agrave";
                case 'Á': return "Aacute";
                case 'Â': return "Acirc";
                case 'Ã': return "Atilde";
                case 'Ä': return "Auml";
                case 'Å': return "Aring";
                case 'Æ': return "AElig";
                case 'Ç': return "Ccedil";
                case 'È': return "Egrave";
                case 'É': return "Eacute";
                case 'Ê': return "Ecirc";
                case 'Ë': return "Euml";
                case 'Ì': return "Igrave";
                case 'Í': return "Iacute";
                case 'Î': return "Icirc";
                case 'Ï': return "Iuml";
                case 'Ð': return "ETH";
                case 'Ñ': return "Ntilde";
                case 'Ò': return "Ograve";
                case 'Ó': return "Oacute";
                case 'Ô': return "Ocirc";
                case 'Õ': return "Otilde";
                case 'Ö': return "Ouml";
                case 'Ù': return "Ugrave";
                case 'Ú': return "Uacute";
                case 'Û': return "Ucirc";
                case 'Ü': return "Uuml";
                case 'Ý': return "Yacute";
                case 'Þ': return "THORN";
                case 'ß': return "szlig";
                case 'à': return "agrave";
                case 'á': return "aacute";
                case 'â': return "acirc";
                case 'ã': return "atilde";
                case 'ä': return "auml";
                case 'å': return "aring";
                case 'æ': return "aelig";
                case 'ç': return "ccedil";
                case 'è': return "egrave";
                case 'é': return "eacute";
                case 'ê': return "ecirc";
                case 'ë': return "euml";
                case 'ì': return "igrave";
                case 'í': return "iacute";
                case 'î': return "icirc";
                case 'ï': return "iuml";
                case 'ð': return "eth";
                case 'ñ': return "ntilde";
                case 'ò': return "ograve";
                case 'ó': return "oacute";
                case 'ô': return "ocirc";
                case 'õ': return "otilde";
                case 'ö': return "ouml";
                case 'ø': return "oslash";
                case 'ù': return "ugrave";
                case 'ú': return "uacute";
                case 'û': return "ucirc";
                case 'ý': return "yacute";
                case 'þ': return "thorn";
                case 'ÿ': return "yuml";
                case 'Ÿ': return "Yuml";

                case 0x00A0: return "nbsp";
                case 0x2002: return "ensp";
                case 0x2003: return "emsp";
                case 0x2009: return "thinsp";
                case 0x200C: return "zwnj";
                case 0x200D: return "zwj";
                case 0x200E: return "lrm";
                case 0x200F: return "rlm";
                case '–': return "ndash";
                case '—': return "mdash";
                case '‘': return "lsquo";
                case '’': return "rsquo";
                case '‚': return "sbquo";
                case '“': return "ldquo";
                case '”': return "rdquo";
                case '„': return "bdquo";
                case '†': return "dagger";
                case '‡': return "Dagger";
                case '•': return "bull";
                case '…': return "hellip";
                case '‰': return "permil";
                case '′': return "prime";
                case '″': return "Prime";
                case '‹': return "lsaquo";
                case '›': return "rsaquo";
                case '‾': return "oline";
                case '⁄': return "frasl";

                case '€': return "euro";
                case '¢': return "cent";
                case '¤': return "curren";
                case '¥': return "yen";
                case '£': return "pound";

                case '◊': return "loz";

                case 'Α': return "Alpha";
                case 'Β': return "Beta";
                case 'Γ': return "Gamma";
                case 'Δ': return "Delta";
                case 'Ε': return "Epsilon";
                case 'Ζ': return "Zeta";
                case 'Η': return "Eta";
                case 'Θ': return "Theta";
                case 'Ι': return "Iota";
                case 'Κ': return "Kappa";
                case 'Λ': return "Lambda";
                case 'Μ': return "Mu";
                case 'Ν': return "Nu";
                case 'Ξ': return "Xi";
                case 'Ο': return "Omicron";
                case 'Π': return "Pi";
                case 'Ρ': return "Rho";
                case 'Σ': return "Sigma";
                case 'Τ': return "Tau";
                case 'Υ': return "Upsilon";
                case 'Φ': return "Phi";
                case 'Χ': return "Chi";
                case 'Ψ': return "Psi";
                case 'Ω': return "Omega";
                case 'α': return "alpha";
                case 'β': return "beta";
                case 'γ': return "gamma";
                case 'δ': return "delta";
                case 'ε': return "epsilon";
                case 'ζ': return "zeta";
                case 'η': return "eta";
                case 'θ': return "theta";
                case 'ι': return "iota";
                case 'κ': return "kappa";
                case 'λ': return "lambda";
                case 'μ': return "mu";
                case 'ν': return "nu";
                case 'ξ': return "xi";
                case 'ο': return "omicron";
                case 'π': return "pi";
                case 'ρ': return "rho";
                case 'ς': return "sigmaf";
                case 'σ': return "sigma";
                case 'τ': return "tau";
                case 'υ': return "upsilon";
                case 'φ': return "phi";
                case 'χ': return "chi";
                case 'ψ': return "psi";
                case 'ω': return "omega";
                case 'ϑ': return "thetasym";
                case 'ϒ': return "upsih";
                case 'ϖ': return "piv";

                case 'Œ': return "OElig";
                case 'œ': return "oelig";
                case 'Š': return "Scaron";
                case 'š': return "scaron";

                case 'ƒ': return "fnof";

                case '©': return "copy";
                case 'ℑ': return "image";
                case '℘': return "weierp";
                case 'ℜ': return "real";
                case '™': return "trade";
                case 'ℵ': return "alefsym";

                case '±': return "plusmn";
                case '¼': return "frac14";
                case '½': return "frac12";
                case '¾': return "frac34";
                case '×': return "times";
                case '÷': return "divide";
                case '∀': return "forall";
                case '∂': return "part";
                case '∃': return "exist";
                case '∅': return "empty";
                case '∇': return "nabla";
                case '∈': return "isin";
                case '∉': return "notin";
                case '∋': return "ni";
                case '∏': return "prod";
                case '∑': return "sum";
                case '−': return "minus";
                case '∗': return "lowast";
                case '√': return "radic";
                case '∝': return "prop";
                case '∞': return "infin";
                case '∠': return "ang";
                case '∧': return "and";
                case '∨': return "or";
                case '∩': return "cap";
                case '∪': return "cup";
                case '∫': return "int";
                case '∴': return "there4";
                case '∼': return "sim";
                case '≅': return "cong";
                case '≈': return "asymp";
                case '≠': return "ne";
                case '≡': return "equiv";
                case '≤': return "le";
                case '≥': return "ge";
                case '⊂': return "sub";
                case '⊃': return "sup";
                case '⊄': return "nsub";
                case '⊆': return "sube";
                case '⊇': return "supe";
                case '⊕': return "oplus";
                case '⊗': return "otimes";
                case '⊥': return "perp";
                case '⋅': return "sdot";

                case '←': return "larr";
                case '↑': return "uarr";
                case '→': return "rarr";
                case '↓': return "rarr";
                case '↔': return "harr";
                case '⇐': return "lArr";
                case '⇑': return "uArr";
                case '⇒': return "rArr";
                case '⇓': return "dArr";
                case '⇔': return "hArr";

                case '♠': return "spades";
                case '♣': return "clubs";
                case '♥': return "hearts";
                case '♦': return "diams";

                case '⌈': return "lceil";
                case '⌉': return "rceil";
                case '⌊': return "lfloor";
                case '⌋': return "rfloor";
                case '〈': return "lang";
                case '〉': return "rang";

                default: return null;
            }
        }
    }
}
