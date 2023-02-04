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

    using Microsoft.VisualBasic;

    public class Program
    {
        private static List<string> demoStrings = null;

        private static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("1. TrimAllWithSplitAndConcat");
                Console.WriteLine("2. TrimAllWithRegex");
                Console.WriteLine("3. TrimAllWithStringReplace");
                Console.WriteLine("4. TrimAllWithLinq");
                Console.WriteLine("5. TrimAllWithArrayCopy");
                Console.WriteLine("6. TrimAllWithInplaceCharArray");
                Console.WriteLine("7. TrimAllWithStringUnsafeInplace V1");
                Console.WriteLine("8. TrimAllWithStringUnsafeInplace V2");
                Console.WriteLine("A. TrimAllWithLexerLoop");
                Console.WriteLine("B. TrimAllWithLexerLoopCharIsWhitespce");
                Console.WriteLine("C. Alle Benchmark ausführen");
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
                        BenchmarkTrimAllWithRegex();
                    }
                    else if (key == ConsoleKey.D3)
                    {
                        BenchmarkStringReplace();
                    }
                    else if (key == ConsoleKey.D4)
                    {
                        BenchmarkLinq();
                    }
                    else if (key == ConsoleKey.D5)
                    {
                        BenchmarkArrayCopy();
                    }
                    else if (key == ConsoleKey.D6)
                    {
                        BenchmarkTrimAllWithInplaceCharArray();
                    }
                    else if (key == ConsoleKey.D7)
                    {
                        BenchmarkTrimAllWithStringUnsafeInplaceV1();
                    }
                    else if (key == ConsoleKey.D8)
                    {
                        BenchmarkTrimAllWithStringUnsafeInplaceV2();
                    }
                    else if (key == ConsoleKey.A)
                    {
                        BenchmarkTrimAllWithLexerLoop();
                    }
                    else if (key == ConsoleKey.B)
                    {
                        BenchmarkTrimAllWithLexerLoopCharIsWhitespce();
                    }
                    else if (key == ConsoleKey.C)
                    {
                        BenchmarkAll();
                    }
                }
            }
            while (true);
        }

        private static void Execute(Action method, string name, bool all = false)
        {
            demoStrings = DemoTextGenerator.GenerateStrings(10000,1024);
            long sum = demoStrings.Sum(s => s.Length);

            Stopwatch watch = new Stopwatch();
            GC.Collect(GC.MaxGeneration, GCCollectionMode.Default, true);
            GC.WaitForPendingFinalizers();

            watch.Restart();
            method();
            watch.Stop();

            var elapsed = watch.ElapsedMilliseconds;

            if (all == false)
            {
                Console.WriteLine($"Name={name.PadRight(25)};Elapsed={elapsed.ToString("N0").PadLeft(5)} ms; Anzahl Zeichen:{sum}");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Name={name.PadRight(25)};Elapsed={elapsed.ToString("N0").PadLeft(5)} ms; Anzahl Zeichen:{sum}");
            }
        }

        private static void BenchmarkAll()
        {
            Console.Clear();

            BenchmarkSplitAndConcat(true);
            BenchmarkTrimAllWithRegex(true);
            BenchmarkLinq(true);
            BenchmarkStringReplace(true);
            BenchmarkArrayCopy(true);
            BenchmarkTrimAllWithInplaceCharArray(true);
            BenchmarkTrimAllWithStringUnsafeInplaceV1(true);
            BenchmarkTrimAllWithStringUnsafeInplaceV2(true);
            BenchmarkTrimAllWithLexerLoop(true);
            BenchmarkTrimAllWithLexerLoopCharIsWhitespce(true);

            Console.ReadKey();
        }

        #region TrimAllWithSplitAndConcat
        private static void BenchmarkSplitAndConcat(bool all = false)
        {
            Execute(() =>
            {
                foreach (var s in demoStrings)
                {
                    TrimAllWithSplitAndConcat(s);
                }
            }, "SPLIT AND CONCAT", all);
        }

        private static void TrimAllWithSplitAndConcat(string demoText)
        {
            int lengthBefore = demoText.Length;
            string result = TrimHelpers.TrimAllWithSplitAndConcat(demoText);
            int lengthAfter = result.Length;
        }
        #endregion TrimAllWithSplitAndConcat

        #region TrimAllWithRegex
        private static void BenchmarkTrimAllWithRegex(bool all = false)
        {
            Execute(() =>
            {
                foreach (var s in demoStrings)
                {
                    TrimAllWithRegex(s);
                }
            }, "REGEX", all);
        }

        private static void TrimAllWithRegex(string demoText)
        {
            int lengthBefore = demoText.Length;
            string result = TrimHelpers.TrimAllWithRegex(demoText);
            int lengthAfter = result.Length;
        }
        #endregion TrimAllWithRegex

        #region TrimAllWithLinq
        private static void BenchmarkLinq(bool all = false)
        {
            Execute(() =>
            {
                foreach (var s in demoStrings)
                {
                    TrimAllWithLinq(s);
                }
            }, "LINQ",all);
        }

        public static void TrimAllWithLinq(string demoText)
        {
            int lengthBefore = demoText.Length;
            string result = TrimHelpers.TrimAllWithLinq(demoText);
            int lengthAfter = result.Length;
        }

        #endregion TrimAllWithLinq

        #region TrimAllWithStringReplace
        private static void BenchmarkStringReplace(bool all = false)
        {
            Execute(() =>
            {
                foreach (var s in demoStrings)
                {
                    TrimAllWithStringReplace(s);
                }
            }, "STRING.REPLACE",all);
        }

        private static void TrimAllWithStringReplace(string demoText)
        {
            int lengthBefore = demoText.Length;
            string result = TrimHelpers.TrimAllWithStringReplace(demoText);
            int lengthAfter = result.Length;
        }
        #endregion TrimAllWithStringReplace

        #region TrimAllWithArrayCopy
        private static void BenchmarkArrayCopy(bool all = false)
        {
            Execute(() =>
            {
                foreach (var s in demoStrings)
                {
                    TrimAllWithArrayCopy(s);
                }
            }, "ARRAY.COPY",all);
        }

        private static void TrimAllWithArrayCopy(string demoText)
        {
            int lengthBefore = demoText.Length;
            string result = TrimHelpers.TrimAllWithStringReplace(demoText);
            int lengthAfter = result.Length;
        }
        #endregion TrimAllWithStringReplace

        #region TrimAllWithInplaceCharArray

        private static void TrimAllWithInplaceCharArray(string demoText)
        {
            int lengthBefore = demoText.Length;
            string result = TrimHelpers.TrimAllWithInplaceCharArray(demoText);
            int lengthAfter = result.Length;
        }

        private static void BenchmarkTrimAllWithInplaceCharArray(bool all = false)
        {
            Execute(() =>
            {
                foreach (var s in demoStrings)
                {
                    TrimAllWithInplaceCharArray(s);
                }
            }, "INPLACE CHAR ARRAY",all);
        }
        #endregion TrimAllWithInplaceCharArray

        #region TrimAllWithStringUnsafeInplaceV1
        private static void TrimAllWithStringUnsafeInplaceV1(string demoText)
        {
            int lengthBefore = demoText.Length;
            string result = TrimHelpers.TrimAllWithStringUnsafeInplace(demoText);
            int lengthAfter = result.Length;
        }

        private static void BenchmarkTrimAllWithStringUnsafeInplaceV1(bool all = false)
        {
            Execute(() =>
            {
                foreach (var s in demoStrings)
                {
                    TrimAllWithStringUnsafeInplaceV1(s);
                }
            }, "STRING UNSAFE INPLACE V1", all);
        }
        #endregion TrimAllWithStringUnsafeInplaceV1

        #region TrimAllWithStringUnsafeInplaceV2
        private static void TrimAllWithStringUnsafeInplaceV2(string demoText)
        {
            int lengthBefore = demoText.Length;
            string result = TrimHelpers.TrimAllWithStringUnsafeInplaceV2(demoText);
            int lengthAfter = result.Length;
        }

        private static void BenchmarkTrimAllWithStringUnsafeInplaceV2(bool all = false)
        {
            Execute(() =>
            {
                foreach (var s in demoStrings)
                {
                    TrimAllWithStringUnsafeInplaceV2(s);
                }
            }, "STRING UNSAFE INPLACE V2", all);
        }
        #endregion TrimAllWithStringUnsafeInplaceV2

        #region TrimAllWithLexerLoop
        private static void TrimAllWithLexerLoop(string demoText)
        {
            int lengthBefore = demoText.Length;
            string result = TrimHelpers.TrimAllWithLexerLoop(demoText);
            int lengthAfter = result.Length;
        }

        private static void BenchmarkTrimAllWithLexerLoop(bool all = false)
        {
            Execute(() =>
            {
                foreach (var s in demoStrings)
                {
                    TrimAllWithLexerLoop(s);
                }
            }, "LEXERLOOP SWITCH", all);
        }

        #endregion TrimAllWithLexerLoop

        #region TrimAllWithLexerLoopCharIsWhitespce
        private static void TrimAllWithLexerLoopCharIsWhitespce(string demoText)
        {
            int lengthBefore = demoText.Length;
            string result = TrimHelpers.TrimAllWithLexerLoopCharIsWhitespce(demoText);
            int lengthAfter = result.Length;
        }

        private static void BenchmarkTrimAllWithLexerLoopCharIsWhitespce(bool all = false)
        {
            Execute(() =>
            {
                foreach (var s in demoStrings)
                {
                    TrimAllWithLexerLoopCharIsWhitespce(s);
                }
            }, "LEXERLOOP CHAR", all);
        }
        #endregion TrimAllWithLexerLoopCharIsWhitespce
    }
}
