//-----------------------------------------------------------------------
// <copyright file="Program.cs" company="Lifeprojects.de">
//     Class: Program
//     Copyright © Lifeprojects.de 2023
// </copyright>
//
// <author>Gerhard Ahrens - Lifeprojects.de</author>
// <email>developer@lifeprojects.de</email>
// <date>03.02.2023 14:00:02</date>
//
// <summary>
// Konsolen Applikation zum demonstrieren von Methoden die alle Leerzeichen in einem String entfernen
// </summary>
//-----------------------------------------------------------------------

namespace BestPracticeDilemma
{
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;

    public static class TrimHelpers
    {
        private static Regex whitespace = new Regex(@"\s+", RegexOptions.Compiled);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsWhiteSpace(char ch)
        {
            switch (ch)
            {
                case '\u0009':
                case '\u000A':
                case '\u000B':
                case '\u000C':
                case '\u000D':
                case '\u0020':
                case '\u0085':
                case '\u00A0':
                case '\u1680':
                case '\u2000':
                case '\u2001':
                case '\u2002':
                case '\u2003':
                case '\u2004':
                case '\u2005':
                case '\u2006':
                case '\u2007':
                case '\u2008':
                case '\u2009':
                case '\u200A':
                case '\u2028':
                case '\u2029':
                case '\u202F':
                case '\u205F':
                case '\u3000':
                    return true;
                default:
                    return false;
            }
        }

        public static string TrimAllWithSplitAndConcat(string str)
        {
            return string.Concat(str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }

        public static string TrimAllWithRegex(string str)
        {
            return whitespace.Replace(str, "");
        }

        public static string TrimAllWithLinq(string str)
        {
            return new string(str.Where(c => !IsWhiteSpace(c)).ToArray());
        }

        public static string TrimAllWithStringReplace(string str)
        {
            /*
             * Diese Methode ist funktionell NICHT gleichwertig mit den anderen, da sie nur "leer" trimmt. 
             * ASCII-Zeichen und Leerzeichen umfassen viele andere Zeichen
             */
            return str.Replace(" ", "");
        }

        public static string TrimAllWithCharArrayCopy(string str)
        {
            var len = str.Length;
            var src = str.ToCharArray();
            int srcIdx = 0, dstIdx = 0, count = 0;
            for (int i = 0; i < len; i++)
            {
                switch (src[i])
                {
                    case '\u0020':
                    case '\u00A0':
                    case '\u1680':
                    case '\u2000':
                    case '\u2001':
                    case '\u2002':
                    case '\u2003':
                    case '\u2004':
                    case '\u2005':
                    case '\u2006':
                    case '\u2007':
                    case '\u2008':
                    case '\u2009':
                    case '\u200A':
                    case '\u202F':
                    case '\u205F':
                    case '\u3000':
                    case '\u2028':
                    case '\u2029':
                    case '\u0009':
                    case '\u000A':
                    case '\u000B':
                    case '\u000C':
                    case '\u000D':
                    case '\u0085':
                        count = i - srcIdx;
                        Array.Copy(src, srcIdx, src, dstIdx, count);
                        srcIdx += count + 1;
                        dstIdx += count;
                        len--;
                        continue;
                    default:
                        break;
                }
            }
            if (dstIdx < len)
            {
                Array.Copy(src, srcIdx, src, dstIdx, len - dstIdx);
            }

            string result = new string(src, 0, len);

            return result;
        }

        public static string TrimAllWithInplaceCharArray(string str)
        {
            var len = str.Length;
            var src = str.ToCharArray();
            int dstIdx = 0;
            for (int i = 0; i < len; i++)
            {
                var ch = src[i];
                switch (ch)
                {
                    case '\u0020':
                    case '\u00A0':
                    case '\u1680':
                    case '\u2000':
                    case '\u2001':
                    case '\u2002':
                    case '\u2003':
                    case '\u2004':
                    case '\u2005':
                    case '\u2006':
                    case '\u2007':
                    case '\u2008':
                    case '\u2009':
                    case '\u200A':
                    case '\u202F':
                    case '\u205F':
                    case '\u3000':
                    case '\u2028':
                    case '\u2029':
                    case '\u0009':
                    case '\u000A':
                    case '\u000B':
                    case '\u000C':
                    case '\u000D':
                    case '\u0085':
                        continue;
                    default:
                        src[dstIdx++] = ch;
                        break;
                }
            }

            string result = new string(src, 0, len);
            return result;
        }

        public static unsafe string TrimAllWithStringUnsafeInplace(string str)
        {
            fixed (char* pfixed = str)
            {
                char* dst = pfixed;
                for (char* p = pfixed; *p != 0; p++)
                    switch (*p)
                    {
                        case '\u0020':
                        case '\u00A0':
                        case '\u1680':
                        case '\u2000':
                        case '\u2001':
                        case '\u2002':
                        case '\u2003':
                        case '\u2004':
                        case '\u2005':
                        case '\u2006':
                        case '\u2007':
                        case '\u2008':
                        case '\u2009':
                        case '\u200A':
                        case '\u202F':
                        case '\u205F':
                        case '\u3000':
                        case '\u2028':
                        case '\u2029':
                        case '\u0009':
                        case '\u000A':
                        case '\u000B':
                        case '\u000C':
                        case '\u000D':
                        case '\u0085':
                            continue;
                        default:
                            *dst++ = *p;
                            break;
                    }

                string result = new string(pfixed, 0, (int)(dst - pfixed));
                return result;
            }
        }

        public static unsafe string TrimAllWithStringUnsafeInplaceV2(string str)
        {
            var len = str.Length;
            fixed (char* pStr = str)
            {
                int dstIdx = 0;
                for (int i = 0; i < len; i++)
                    switch (pStr[i])
                    {
                        case '\u0020':
                        case '\u00A0':
                        case '\u1680':
                        case '\u2000':
                        case '\u2001':
                        case '\u2002':
                        case '\u2003':
                        case '\u2004':
                        case '\u2005':
                        case '\u2006':
                        case '\u2007':
                        case '\u2008':
                        case '\u2009':
                        case '\u200A':
                        case '\u202F':
                        case '\u205F':
                        case '\u3000':
                        case '\u2028':
                        case '\u2029':
                        case '\u0009':
                        case '\u000A':
                        case '\u000B':
                        case '\u000C':
                        case '\u000D':
                        case '\u0085':
                            continue;
                        default:
                            pStr[dstIdx++] = pStr[i];
                            break;
                    }

                string result = new string(pStr, 0, dstIdx);
                return result;
            }
        }

        public static string TrimAllWithLexerLoop(string s)
        {
            int length = s.Length;
            var buffer = new StringBuilder(s);
            var dstIdx = 0;
            for (int index = 0; index < s.Length; index++)
            {
                char ch = s[index];
                switch (ch)
                {
                    case '\u0020':
                    case '\u00A0':
                    case '\u1680':
                    case '\u2000':
                    case '\u2001':
                    case '\u2002':
                    case '\u2003':
                    case '\u2004':
                    case '\u2005':
                    case '\u2006':
                    case '\u2007':
                    case '\u2008':
                    case '\u2009':
                    case '\u200A':
                    case '\u202F':
                    case '\u205F':
                    case '\u3000':
                    case '\u2028':
                    case '\u2029':
                    case '\u0009':
                    case '\u000A':
                    case '\u000B':
                    case '\u000C':
                    case '\u000D':
                    case '\u0085':
                        length--;
                        continue;
                    default:
                        break;
                }
                buffer[dstIdx++] = ch;
            }

            buffer.Length = length;
            return buffer.ToString(); ;
        }

        public static string TrimAllWithLexerLoopCharIsWhitespce(string s)
        {
            int length = s.Length;
            var buffer = new StringBuilder(s);
            var dstIdx = 0;
            for (int index = 0; index < s.Length; index++)
            {
                char currentchar = s[index];
                if (IsWhiteSpace(currentchar))
                {
                    length--;
                }
                else
                {
                    buffer[dstIdx++] = currentchar;
                }
            }

            buffer.Length = length;
            return buffer.ToString(); ;
        }

    }
}
