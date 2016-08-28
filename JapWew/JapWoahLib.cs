using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapWoahLib
{
    public static class JapWoah
    {
        const int MINIMUM_CHAR = 192;

        public static string ToFullwidth(string input)
        {
            const int OFFSET = 65248;
            char c = '\0';
            int len = input.Length;

            StringBuilder _out = new StringBuilder();
            for (var i = 0; i < len; i++)
            {
                c = input[i];

                if (c < MINIMUM_CHAR)
                    switch ((short)c)
                    {
                        case 32:
                        case 0xA:
                        case 0xD:
                            break;
                        case 163: c += (char)94; break; // £
                        case 162: c += (char)92; break; // ¢
                        default:
                            _out.Append((char)(c + OFFSET));
                            break;
                    }
                else
                    _out.Append(c);
            }

            return _out.ToString();
        }

        public static string ToCircled(string input)
        {
            const int OFFSET = 9327;
            char c = '\0';
            int len = input.Length;

            StringBuilder _out = new StringBuilder();
            for (var i = 0; i < len; i++)
            {
                c = input[i];

                // Cap, number, normal
                if (((c >= 65 && c <= 90) || (c >= 48 && c <= 57) || (c >= 97 && c <= 122)) && c < MINIMUM_CHAR)
                {
                    // Caps
                    if (c >= 65 && c <= 90) c += (char)6;
                    // Numbers 1-9
                    if (c >= 49 && c <= 57) c -= (char)64;
                    // Number 0
                    if (c == 48) c += (char)75;

                    _out.Append((char)(c + OFFSET));
                }
                else
                {
                    _out.Append(c);
                }
            }

            return _out.ToString();
        }

        public static string ToParathese(string input)
        {
            const int OFFSET = 9327;
            char c = '\0';
            int len = input.Length;

            StringBuilder _out = new StringBuilder();
            for (var i = 0; i < len; i++)
            {
                c = input[i];

                // Cap, number, normal
                if (((c >= 65 && c <= 90) || (c >= 48 && c <= 57) || (c >= 97 && c <= 122)) && c < MINIMUM_CHAR)
                {
                    // Caps
                    if (c >= 65 && c <= 90) c += (char)32;
                    // Numbers 1-9
                    if (c >= 49 && c <= 57) c += (char)8;

                    _out.Append((char)(c + OFFSET));
                }
                else
                {
                    _out.Append(c);
                }
            }

            return _out.ToString();
        }

        public static string ToUnderDot(string input)
        {
            const char OFFSET = (char)9327;
            short c = 0;
            int len = input.Length;

            StringBuilder _out = new StringBuilder();
            for (var i = 0; i < len; i++)
            {
                c = (short)input[i];

                switch (c)
                {
                    // LATIN CAPITAL LETTER WITH DOT BELOW
                    case 65: c += 160; break; // A
                    case 66: c += 3; break;   // B
                    case 68: c += 9; break;   // D
                    case 69: c += 180; break; // E
                    case 72: c += 29; break;  // H
                    case 73: c += 194; break; // I
                    case 75: c += 40; break;  // K
                    case 76: c += 43; break;  // L
                    case 77: c += 54; break;  // M
                    case 78: c += 57; break;  // N
                    case 79: c += 190; break; // O
                    case 82: c += 73; break;  // R
                    case 83: c += 80; break;  // S
                    case 84: c += 89; break;  // T
                    case 85: c += 208; break; // U
                    case 86: c += 105; break; // V
                    case 87: c += 114; break; // W
                    case 89: c += 220; break; // Y
                    case 90: c += 121; break; // Z
                    // LATIN SMALL LETTER WITH DOT BELOW
                    case 97: c += 129; break;  // a
                    case 98: c -= 28; break;   // b
                    case 100: c -= 22; break;  // d
                    case 101: c += 149; break; // e
                    case 104: c -= 2; break;   // h
                    case 105: c += 163; break; // i
                    case 107: c += 9; break;   // k
                    case 108: c += 12; break;  // l
                    case 109: c += 23; break;  // m
                    case 110: c += 26; break;  // n
                    case 111: c += 159; break; // o
                    case 114: c += 42; break;  // r
                    case 115: c += 49; break;  // s
                    case 116: c += 58; break;  // t
                    case 117: c += 177; break; // u
                    case 118: c += 74; break;  // v
                    case 119: c += 83; break;  // w
                    case 121: c += 189; break; // y
                    default: c -= (short)OFFSET; break; // Cancel
                }

                _out.Append((char)(c + OFFSET));
            }

            return _out.ToString();
        }

        public static string ToShit(string input)
        {
            StringBuilder _out = new StringBuilder();

            int len = input.Length;

            for (int i = 0; i < len; i++)
            {
                switch (input[i])
                {
                    case 'a':
                    case 'A':
                        _out.Append("█▀█"); break;
                    case 'b':
                    case 'B':
                        _out.Append("B"); break;
                    case 'c':
                    case 'C':
                        _out.Append("C"); break;
                    case 'd':
                    case 'D':
                        _out.Append("D"); break;
                    case 'e':
                    case 'E':
                        _out.Append("E"); break;
                    case 'f':
                    case 'F':
                        _out.Append("F"); break;
                    case 'g':
                    case 'G':
                        _out.Append("G"); break;
                    case 'h':
                    case 'H':
                        _out.Append("█▬█"); break;
                    case 'i':
                    case 'I':
                        _out.Append("█"); break;
                    case 'j':
                    case 'J':
                        _out.Append("▄█"); break;
                    case 'k':
                    case 'K':
                        _out.Append("K"); break;
                    case 'l':
                    case 'L':
                        _out.Append("█▄"); break;
                    case 'm':
                    case 'M':
                        _out.Append("█▀█▀█"); break;
                    case 'n':
                    case 'N':
                        _out.Append("█▀▄█"); break;
                    case 'o':
                    case 'O':
                        _out.Append("███"); break;
                    case 'p':
                    case 'P':
                        _out.Append("█▀"); break;
                    case 'q':
                    case 'Q':
                        _out.Append("███▄"); break;
                    case 'r':
                    case 'R':
                        _out.Append("█▀▄"); break;
                    case 's':
                    case 'S':
                        _out.Append("▄█▀"); break;
                    case 't':
                    case 'T':
                        _out.Append("▀█▀"); break;
                    case 'u':
                    case 'U':
                        _out.Append("█▄█"); break;
                    case 'v':
                    case 'V':
                        _out.Append("▐▄▌"); break;
                    case 'w':
                    case 'W':
                        _out.Append("█▄█▄█"); break;
                    case 'x':
                    case 'X':
                        _out.Append("X"); break;
                    case 'y':
                    case 'Y':
                        _out.Append("Y"); break;
                    case 'z':
                    case 'Z':
                        _out.Append("▀█▄"); break;
                    default:
                        _out.Append(input[i]); break;
                }

                _out.Append(' ');
            }

            return _out.ToString();
        }

        public static string ToSmallCaps(string input)
        {
            const int OFFSET = 7329;
            short c = 0;
            StringBuilder _out = new StringBuilder();

            int len = input.Length;
            for (var i = 0; i < len; i++)
            {
                c = (short)input[i];

                if (c >= 0x61 && c <= 0x7A)
                {
                    switch (c)
                    {
                        case 0x61: // a
                            _out.Append((char)(c + 7327));
                            break;
                        case 0x65: // e
                            _out.Append((char)(c + 7330));
                            break;
                        case 0x66: // f
                            _out.Append((char)(c + 1069));
                            break;
                        case 0x67: // g
                            _out.Append((char)(c + 507));
                            break;
                        case 0x68: // h
                            _out.Append((char)(c + 564));
                            break;
                        case 0x69: // i
                            _out.Append((char)(c + 513));
                            break;
                        case 0x6A: // j
                        case 0x6B: // k
                        case 0x6D: // m
                        case 0x6F: // o
                            _out.Append((char)(c + 7328));
                            break;
                        case 0x6C: // l
                            _out.Append((char)(c + 563));
                            break;
                        case 0x6E: // n
                            _out.Append((char)(c + 518));
                            break;
                        case 0x70: // p
                        case 0x7A: // z
                            _out.Append((char)(c + 7336));
                            break;
                        case 0x71: // q
                            _out.Append((char)(c + 378));
                            break;
                        case 0x72: // r
                            _out.Append((char)(c + 526));
                            break;
                        case 0x73: // s
                        case 0x78: // x
                            _out.Append((char)(c));
                            break;
                        case 0x74: // t
                        case 0x75: // u
                            _out.Append((char)(c + 7335));
                            break;
                        case 0x76: // v
                        case 0x77: // w
                            _out.Append((char)(c + 7338));
                            break;
                        case 0x79: // y
                            _out.Append((char)(c + 534));
                            break;

                        default:
                            _out.Append((char)(c + OFFSET));
                            break;
                    } // Switch
                }
                else
                {
                    _out.Append((char)(c));
                } // if
            } // for

            return _out.ToString();
        }

        public static string Normalize(string input)
        {
            StringBuilder _out = new StringBuilder();
            var FULLWIDTH = 65248;
            var CIRCLED = 9327;
            var PARA = 9275;
            ushort c;

            var len = input.Length;
            for (var i = 0; i < len; i++)
            {
                c = input[i];

                switch (c)
                {
                    // -- Fullwidth --
                    // A-Z
                    case 0xFF21:
                    case 0xFF22:
                    case 0xFF23:
                    case 0xFF24:
                    case 0xFF25:
                    case 0xFF26:
                    case 0xFF27:
                    case 0xFF28:
                    case 0xFF29:
                    case 0xFF2A:
                    case 0xFF2B:
                    case 0xFF2C:
                    case 0xFF2D:
                    case 0xFF2E:
                    case 0xFF2F:
                    case 0xFF30:
                    case 0xFF31:
                    case 0xFF32:
                    case 0xFF33:
                    case 0xFF34:
                    case 0xFF35:
                    case 0xFF36:
                    case 0xFF37:
                    case 0xFF38:
                    case 0xFF39:
                    case 0xFF3A:
                    // a-z
                    case 0xFF41:
                    case 0xFF42:
                    case 0xFF43:
                    case 0xFF44:
                    case 0xFF45:
                    case 0xFF46:
                    case 0xFF47:
                    case 0xFF48:
                    case 0xFF49:
                    case 0xFF4A:
                    case 0xFF4B:
                    case 0xFF4C:
                    case 0xFF4D:
                    case 0xFF4E:
                    case 0xFF4F:
                    case 0xFF50:
                    case 0xFF51:
                    case 0xFF52:
                    case 0xFF53:
                    case 0xFF54:
                    case 0xFF55:
                    case 0xFF56:
                    case 0xFF57:
                    case 0xFF58:
                    case 0xFF59:
                    case 0xFF5A:
                    // misc
                    case 0xFE5F:
                    case 0xFF03:
                    case 0xFE60:
                    case 0xFF06:
                    case 0xFE69:
                    case 0xFF04:
                    case 0xFE6A:
                    case 0xFF05:
                    case 0xFE6B:
                    case 0xFF20:
                    case 0xFFE0:
                    case 0xFFE1:
                    case 0xFF5E:
                    case 0xFF3B:
                    case 0xFF3D:
                    case 0xFE5B:
                    case 0xFE5C:
                    case 0xFF5B:
                    case 0xFF5D:
                    case 0xFE59:
                    case 0xFE5A:
                    case 0xFF3C:
                    case 0xFF08:
                    case 0xFF09:
                        {
                            switch (c)
                            {
                                case 0xFFE0: c -= 92; break; // ¢
                                case 0xFFE1: c -= 94; break; // £
                            }
                            _out.Append((char)(c - FULLWIDTH));
                        }
                        break;

                    // -- Circled --
                    // A-Z
                    case 0x24B6:
                    case 0x24B7:
                    case 0x24B8:
                    case 0x24B9:
                    case 0x24BA:
                    case 0x24BB:
                    case 0x24BC:
                    case 0x24BD:
                    case 0x24BE:
                    case 0x24BF:
                    case 0x24C0:
                    case 0x24C1:
                    case 0x24C2:
                    case 0x24C3:
                    case 0x24C4:
                    case 0x24C5:
                    case 0x24C6:
                    case 0x24C7:
                    case 0x24C8:
                    case 0x24C9:
                    case 0x24CA:
                    case 0x24CB:
                    case 0x24CC:
                    case 0x24CD:
                    case 0x24CE:
                    case 0x24CF:
                    // a-z
                    case 0x24D0:
                    case 0x24D1:
                    case 0x24D2:
                    case 0x24D3:
                    case 0x24D4:
                    case 0x24D5:
                    case 0x24D6:
                    case 0x24D7:
                    case 0x24D8:
                    case 0x24D9:
                    case 0x24DA:
                    case 0x24DB:
                    case 0x24DC:
                    case 0x24DD:
                    case 0x24DE:
                    case 0x24DF:
                    case 0x24E0:
                    case 0x24E1:
                    case 0x24E2:
                    case 0x24E3:
                    case 0x24E4:
                    case 0x24E5:
                    case 0x24E6:
                    case 0x24E7:
                    case 0x24E8:
                    // 0-9
                    case 0x24E9:
                    case 0x24EA:
                    case 0x2460:
                    case 0x2461:
                    case 0x2462:
                    case 0x2463:
                    case 0x2464:
                    case 0x2465:
                    case 0x2466:
                    case 0x2467:
                    case 0x2468:
                        {
                            // Caps
                            if (c >= 0x24B6 && c <= 0x24CF) c -= 6;
                            // Numbers 1-9
                            if (c >= 0x24EA && c <= 0x2468) c += 64;
                            // Number 0
                            if (c == 0x24E9) c -= 75;
                            _out.Append((char)(c - CIRCLED));
                        }
                        break;

                    default:
                        _out.Append((char)c);
                        break;
                }
            }

            return _out.ToString();
        }
    }
}
