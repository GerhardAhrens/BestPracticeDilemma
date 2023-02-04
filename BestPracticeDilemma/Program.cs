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
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using Microsoft.VisualBasic;

    public class Program
    {
        private static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1. TrimAllWithSplitAndConcat");
                Console.WriteLine("2. TrimAllWithRegex");
                Console.WriteLine("3. TrimAllWithStringReplace");
                Console.WriteLine("4. RangeOf & CountOf");
                Console.WriteLine("5. Complex Class");
                Console.WriteLine("X. Beenden");

                Console.WriteLine("Wählen Sie einen Menüpunkt oder 'x' für beenden");
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.X)
                {
                    Environment.Exit(0);
                }
                else
                {
                    if (key == ConsoleKey.D1)
                    {
                        BenchmarkSplitAndConcat();
                    }
                    else if (key == ConsoleKey.D2)
                    {
                        TrimAllWithRegex();
                    }
                    else if (key == ConsoleKey.D3)
                    {
                        BenchmarkStringReplace();
                    }
                    else if (key == ConsoleKey.D4)
                    {
                    }
                    else if (key == ConsoleKey.D5)
                    {
                    }
                }
            }
            while (true);
        }

        private static void Execute(Action method, string name)
        {
            Stopwatch watch = new Stopwatch();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Default, true);
            GC.WaitForPendingFinalizers();

            watch.Restart();
            method();
            watch.Stop();

            var elapsed = watch.Elapsed;
        }

        private static void BenchmarkSplitAndConcat()
        {
            string s = DemoText();
            Execute(() =>
            {
                TrimAllWithSplitAndConcat(s);
            }, "SPLIT AND CONCAT");
        }

        private static void TrimAllWithSplitAndConcat(string demoText)
        {
            int lengthBefore = demoText.Length;
            string result = TrimHelpers.TrimAllWithSplitAndConcat(demoText);
            int lengthAfter = result.Length;
        }

        private static void TrimAllWithRegex()
        {
            string s = DemoText();
            int lengthBefore = s.Length;
            string result = TrimHelpers.TrimAllWithRegex(s);
            int lengthAfter = result.Length;
        }

        private static void BenchmarkStringReplace()
        {
            string s = DemoText();
            Execute(() =>
            {
                TrimAllWithStringReplace(s);
            }, "STRING.REPLACE");
        }

        private static void TrimAllWithStringReplace(string demoText)
        {
            int lengthBefore = demoText.Length;
            string result = TrimHelpers.TrimAllWithStringReplace(demoText);
            int lengthAfter = result.Length;
        }

        private static string DemoText()
        {
            string s = "Lorem ipsum dolor sit amet et vero erat ullamcorper amet sadipscing sanctus labore no invidunt. Accusam euismod voluptua dolore " +
                "eum dignissim ut clita sanctus volutpat duis kasd takimata est nonumy dolore tempor ut sadipscing. Dolores sed odio amet sadipscing. Et " +
                "elit diam rebum gubergren ex diam et blandit. Sea stet ad nibh te est. Rebum dignissim stet sit sit est kasd stet rebum et stet sit " +
                "consetetur et takimata diam est dolores et. Voluptua te gubergren labore et molestie augue vero. Elitr illum stet clita dolore sanctus " +
                "rebum erat aliquyam tempor accumsan diam aliquip sit illum. Eirmod velit takimata volutpat et no. Esse magna tempor labore diam nulla " +
                "accusam ipsum kasd tempor luptatum et amet amet labore feugiat stet. Gubergren at sit et aliquyam sadipscing quis ad ipsum nonumy dolor " +
                "facilisi laoreet no dolores at sea duis. Cum no labore. Eos ipsum suscipit labore at justo rebum lorem sadipscing sadipscing sanctus sit " +
                "labore rebum sed eleifend sadipscing hendrerit. Sit et sit lorem imperdiet tation eirmod at. Lorem molestie erat invidunt iriure ea takimata " +
                "duo takimata no lorem eos. Sit est enim lorem vel dolor kasd duo lorem dolor gubergren nonumy. Sadipscing diam vel stet. Ut id ut labore " +
                "ut diam et consectetuer erat laoreet justo consetetur nisl. Sea takimata ea imperdiet ut. Eros invidunt dolore sadipscing accusam dolor " +
                "justo rebum iusto lobortis et hendrerit consetetur rebum. Esse ea dolores amet dolore amet dolor labore consequat at aliquam praesent " +
                "takimata rebum magna clita consetetur. Justo ut ut clita aliquyam augue eirmod dolor sanctus sed kasd accumsan minim sit hendrerit odio. " +
                "Elitr eu aliquyam at sadipscing veniam dolor eum veniam. Dolores stet lorem ut erat et sanctus takimata stet eos te. In kasd tempor " +
                "consetetur justo eos. Ipsum sanctus sed justo no nonumy aliquyam eu eum te sanctus et sit molestie aliquyam accusam labore takimata stet. " +
                "Molestie sadipscing sadipscing diam sea gubergren takimata consetetur justo. Eirmod doming erat illum praesent. Diam sadipscing justo lorem " +
                "lorem tation tation sed takimata lorem voluptua et ut at ut tempor dolore. Elitr eirmod rebum dolor gubergren est dolore volutpat facilisis " +
                "vero sanctus feugiat lorem. Dolores justo magna diam. Dolore invidunt aliquyam praesent erat ipsum gubergren et odio justo nihil invidunt sit " +
                "facilisis tation elitr dolor. Eirmod labore dolore ullamcorper. Dolor sit lorem erat amet voluptua ut. Voluptua dolor amet lorem est rebum " +
                "nonumy labore dolore sit stet consetetur et dolores magna. Delenit wisi nulla eos invidunt. Takimata laoreet amet tation et dolore vero vero dolore " +
                "takimata eirmod autem accusam. Iriure minim dolor stet ut dolor et dolore sit stet clita dolore. Assum et aliquyam dolor aliquyam et illum invidunt " +
                "dolor tempor ad elitr takimata gubergren sea diam rebum takimata. Facilisis magna nonumy et stet iriure praesent nonumy sit et voluptua lorem id " +
                "sea dignissim lorem nulla. Eos sea sed sit possim et sadipscing. Accusam dolores tempor sit erat magna takimata gubergren. Ea duo et praesent " +
                "lobortis. Magna et kasd tempor velit et. Amet euismod duis blandit sed dolore in diam ut est diam veniam accumsan aliquip dolor erat sit. " +
                "Elitr amet gubergren est et te sit et sit nihil dignissim erat sit est. Invidunt ipsum elit consequat aliquyam diam sea ipsum accusam vero. " +
                "Elitr sed lorem et erat molestie lorem in eum sanctus vero dolor. Diam praesent at ipsum amet at eos nonummy invidunt clita tempor ipsum. " +
                "Dolore adipiscing tempor ut feugiat diam ad ullamcorper enim gubergren. Amet wisi lorem aliquyam soluta. Sadipscing augue eleifend at " +
                "imperdiet vel luptatum lorem no commodo at sit takimata rebum. Sadipscing sea nobis option at iriure accumsan ut et eum sed eos elitr invidunt " +
                "consetetur tempor duo vero. Qui at magna ea lorem eirmod. Stet ut ullamcorper sanctus et at wisi sanctus. Consetetur sit option sed diam nisl " +
                "nostrud ut clita sanctus. Elitr diam sed clita nulla. Aliquyam quod invidunt. Sadipscing dolore veniam sit et invidunt sadipscing " +
                "consetetur. Wisi et ipsum consetetur sit duo molestie vel aliquyam ut illum invidunt ipsum ea dolore rebum at diam magna. Vel consetetur " +
                "accusam et sit amet hendrerit eirmod exerci commodo et ipsum diam aliquyam suscipit adipiscing sanctus vel. Amet sanctus aliquyam amet " +
                "sadipscing tincidunt liber sed et. No sea aliquyam stet sit sea odio lorem eu sadipscing wisi sed option vero consequat. Sed sit vel. " +
                "Adipiscing takimata duis elitr ipsum elitr nobis consetetur vel magna no. Takimata sea amet sed tempor takimata nostrud erat eirmod diam. " +
                "Ex rebum et tincidunt sanctus ut voluptua sit gubergren consetetur nibh duis ipsum nulla lorem gubergren lorem feugait. Facilisi velit augue" +
                " no in sanctus vero consetetur aliquyam accusam aliquip. Vulputate tation eos lorem sanctus tempor vulputate. No voluptua duo lorem ut " +
                "aliquyam aliquyam ipsum rebum. Ipsum sadipscing lorem diam lobortis lobortis ipsum. Feugait dolore dolore at sit. Sea sea nonumy est dolor " +
                "sed at eos dolores lorem wisi justo volutpat no dolore feugait. Voluptua et nonumy vero no labore no lorem ullamcorper aliquyam. " +
                "Sanctus qui diam et no vero amet sea sed at sed aliquip. Voluptua at est gubergren invidunt. Sadipscing sanctus labore takimata in " +
                "quis duo duo duis vero aliquyam dolor erat dolor vulputate dolor ipsum. Amet nostrud sanctus rebum lorem illum velit eu ullamcorper et " +
                "ipsum praesent erat lorem duo magna. Amet consetetur nihil lorem nonumy elitr quod sit et duis eos lorem. Diam magna sed sit gubergren id " +
                "dolores. Takimata labore dolor. Est zzril et et. Magna labore nonummy eu elitr. Qui sit elit praesent dolore duo tempor et stet. Ipsum " +
                "magna praesent sea erat nonumy sadipscing ipsum tation labore in sea erat. Sit eos rebum accusam minim nonumy et sea ipsum veniam nulla " +
                "lorem congue voluptua invidunt kasd. Clita sed dolor sit sit velit hendrerit dolores. Et vero et accusam takimata vero facer et est sea " +
                "dolor amet vero tincidunt facilisis tation dolore eirmod. Erat no et dolores dolor commodo lorem. Eirmod amet clita tempor in tempor " +
                "accumsan rebum et aliquyam. Et aliquyam vero ipsum lorem sanctus in et eirmod consequat kasd no nobis ipsum sed tempor commodo sed sea. " +
                "Eirmod facilisis sit ea sit eum accusam et no. Gubergren rebum sanctus est amet consequat. Sanctus et velit sanctus sit kasd sit diam " +
                "accumsan erat tation congue ad eos et. Nibh suscipit ea ut at eos magna accusam elitr tincidunt eirmod amet sed lorem eum lorem sanctus " +
                "vel. Soluta blandit ipsum mazim ea duo eros est lorem vel wisi. Diam hendrerit est tation kasd labore amet amet labore. Dolores dolore " +
                "accusam nonumy et clita ut praesent sea sadipscing dolore. Diam exerci sed dolores amet magna duo consectetuer dolore takimata facilisi. " +
                "Amet est at kasd.";
            return s;
        }
    }

    public class DemoTextGenerator
    {
        public static List<string> GenerateStrings(int txtCount, int txtLength)
        {
            List<string> strings;
            var count = Convert.ToInt32(txtCount);
            var len = Convert.ToInt32(txtLength);
            strings = new List<string>(count);
            for (int i = 0; i < count; i++)
            {
                strings.Add(GenerateString(len));
            }

            return strings;
        }
        private static string GenerateString(int len)
        {
            var randomText = Path.GetRandomFileName().Replace('.', ' ');
            while ((randomText += randomText).Length < len);

            return randomText;
        }
    }

    public static class TrimHelpers
    {
        private static Regex whitespace = new Regex(@"\s+", RegexOptions.Compiled);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool isWhiteSpace(char ch)
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
            return new string(str.Where(c => !isWhiteSpace(c)).ToArray());
        }

        public static string TrimAllWithStringReplace(string str)
        {
            // This method is NOT functionaly equivalent to the others as it will only trim "blank" 
            // ASCII characters and white-space comprises lots of other characters
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
                // using the switch above is faster than calling the method (even when inlined)
                /*if (isWhiteSpace(src[i])) {
                    count = i - srcIdx;
                    Array.Copy(src, srcIdx, src, dstIdx, count);
                    srcIdx += count + 1;
                    dstIdx += count;
                    len--;
                }*/
            }
            if (dstIdx < len)
                Array.Copy(src, srcIdx, src, dstIdx, len - dstIdx);
            return new string(src, 0, len);
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
                // using the switch above is faster than calling the method (even when inlined)
                /*if (!isWhiteSpace(ch))
                    src[dstIdx++] = ch;*/
            }
            return new string(src, 0, dstIdx);
        }

        public static unsafe string TrimAllWithStringInplace(string str)
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
                // using the switch above is faster than calling the method isWhiteSpace (even when inlined)
                /*if (!isWhiteSpace(*p)) 
                    *dst++ = *p;*/

                /*// reset the string size
                    * ONLY IT DIDN'T WORK! A GARBAGE COLLECTION ACCESS VIOLATION OCCURRED AFTER USING IT
                    * SO I HAD TO RESORT TO RETURN A NEW STRING INSTEAD, WITH ONLY THE PERTINENT BYTES
                    * IT WOULD BE A LOT FASTER IF IT DID WORK THOUGH...
                Int32 len = (Int32)(dst - pfixed);
                Int32* pi = (Int32*)pfixed;
                pi[-1] = len;
                pfixed[len] = '\0';*/
                return new string(pfixed, 0, (int)(dst - pfixed));
            }
        }

        public static unsafe string TrimAllWithStringInplaceV2(string str)
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
                // using the switch above is faster than calling the method isWhiteSpace (even when inlined)
                /* if (!isWhiteSpace(pStr[i])) 
                    pStr[dstIdx++] = pStr[i]; */

                // reset the string size...
                /*int* pi = (int*)pStr;
                pi[-1] = dstIdx;
                pStr[dstIdx] = '\0'; */
                // since the unsafe string length reset didn't work we need to this slower compromise
                return new string(pStr, 0, dstIdx);
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
                if (isWhiteSpace(currentchar))
                    length--;
                else
                    buffer[dstIdx++] = currentchar;
            }
            buffer.Length = length;
            return buffer.ToString(); ;
        }

    }
}
