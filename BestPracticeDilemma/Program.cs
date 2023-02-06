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
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor= ConsoleColor.DarkBlue;

            do
            {
                Console.Clear();
                Console.WriteLine("\t1. TrimAllWithSplitAndConcat");
                Console.WriteLine("\t2. TrimAllWithRegex");
                Console.WriteLine("\t3. TrimAllWithStringReplace");
                Console.WriteLine("\t4. TrimAllWithLinq");
                Console.WriteLine("\t5. TrimAllWithArrayCopy");
                Console.WriteLine("\t6. TrimAllWithInplaceCharArray");
                Console.WriteLine("\t7. TrimAllWithStringUnsafeInplace V1");
                Console.WriteLine("\t8. TrimAllWithStringUnsafeInplace V2");
                Console.WriteLine("\tA. TrimAllWithLexerLoop");
                Console.WriteLine("\tB. TrimAllWithLexerLoopCharIsWhitespce");
                Console.WriteLine("\tC. Alle Benchmark ausführen");
                Console.WriteLine("\tX. Beenden");

                Console.WriteLine("\tWählen Sie einen Menüpunkt oder 'x' für beenden");
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

        private static void BenchmarkAll()
        {
            Console.Clear();
            demoStrings = DemoTextBuilder.GenerateStrings(10000, 1024);
            long sumChar = demoStrings.Sum(s => s.Length);
            Console.WriteLine($"\tAnzahl der Zeichen: {sumChar.ToString("N0")}");
            Console.WriteLine("");

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

            Console.WriteLine("\t");
            Console.WriteLine("\tEine Taste für zurück drücken.");
            Console.ReadKey();
        }

        private static void Execute(Action method, string name, bool all = false)
        {
            demoStrings = DemoTextBuilder.GenerateStrings(10000, 1024);
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
                Console.WriteLine($"\tName = {name.PadRight(25)} Elapsed = {elapsed.ToString("N0").PadLeft(5)} ms");
                Console.WriteLine("\t");
                Console.WriteLine("\tEine Taste für zurück drücken.");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"\tName = {name.PadRight(25)} Elapsed = {elapsed.ToString("N0").PadLeft(5)} ms");
            }
        }

        #region TrimAllWithSplitAndConcat
        private static void BenchmarkSplitAndConcat(bool all = false)
        {
            Execute(() =>
            {
                foreach (var demoString in demoStrings)
                {
                    string result = TrimHelpers.TrimAllWithSplitAndConcat(demoString);
                }
            }, "SPLIT AND CONCAT", all);
        }
        #endregion TrimAllWithSplitAndConcat

        #region TrimAllWithRegex
        private static void BenchmarkTrimAllWithRegex(bool all = false)
        {
            Execute(() =>
            {
                foreach (var demoString in demoStrings)
                {
                    string result = TrimHelpers.TrimAllWithRegex(demoString);
                }
            }, "REGEX", all);
        }
        #endregion TrimAllWithRegex

        #region TrimAllWithLinq
        private static void BenchmarkLinq(bool all = false)
        {
            Execute(() =>
            {
                foreach (var demoString in demoStrings)
                {
                    string result = TrimHelpers.TrimAllWithLinq(demoString);
                }
            }, "LINQ",all);
        }

        #endregion TrimAllWithLinq

        #region TrimAllWithStringReplace
        private static void BenchmarkStringReplace(bool all = false)
        {
            Execute(() =>
            {
                foreach (var demoString in demoStrings)
                {
                    string result = TrimHelpers.TrimAllWithStringReplace(demoString);
                }
            }, "STRING.REPLACE",all);
        }

        #endregion TrimAllWithStringReplace

        #region TrimAllWithArrayCopy
        private static void BenchmarkArrayCopy(bool all = false)
        {
            Execute(() =>
            {
                foreach (var demoString in demoStrings)
                {
                    TrimHelpers.TrimAllWithCharArrayCopy(demoString);
                }
            }, "ARRAY.COPY",all);
        }

        #endregion TrimAllWithStringReplace

        #region TrimAllWithInplaceCharArray

        private static void BenchmarkTrimAllWithInplaceCharArray(bool all = false)
        {
            Execute(() =>
            {
                foreach (var demoString in demoStrings)
                {
                    string result = TrimHelpers.TrimAllWithInplaceCharArray(demoString);
                }
            }, "INPLACE CHAR ARRAY",all);
        }
        #endregion TrimAllWithInplaceCharArray

        #region TrimAllWithStringUnsafeInplaceV1
        private static void BenchmarkTrimAllWithStringUnsafeInplaceV1(bool all = false)
        {
            Execute(() =>
            {
                foreach (var demoString in demoStrings)
                {
                    string result = TrimHelpers.TrimAllWithStringUnsafeInplaceV1(demoString);
                }
            }, "STRING UNSAFE INPLACE V1", all);
        }
        #endregion TrimAllWithStringUnsafeInplaceV1

        #region TrimAllWithStringUnsafeInplaceV2

        private static void BenchmarkTrimAllWithStringUnsafeInplaceV2(bool all = false)
        {
            Execute(() =>
            {
                foreach (var demoString in demoStrings)
                {
                    string result = TrimHelpers.TrimAllWithStringUnsafeInplaceV2(demoString);
                }
            }, "STRING UNSAFE INPLACE V2", all);
        }
        #endregion TrimAllWithStringUnsafeInplaceV2

        #region TrimAllWithLexerLoop
        private static void BenchmarkTrimAllWithLexerLoop(bool all = false)
        {
            Execute(() =>
            {
                foreach (var demoString in demoStrings)
                {
                    string result = TrimHelpers.TrimAllWithLexerLoop(demoString);
                }
            }, "LEXERLOOP SWITCH", all);
        }

        #endregion TrimAllWithLexerLoop

        #region TrimAllWithLexerLoopCharIsWhitespce

        private static void BenchmarkTrimAllWithLexerLoopCharIsWhitespce(bool all = false)
        {
            Execute(() =>
            {
                foreach (var demoString in demoStrings)
                {
                    string result = TrimHelpers.TrimAllWithLexerLoopCharIsWhitespce(demoString);
                }
            }, "LEXERLOOP CHAR", all);
        }
        #endregion TrimAllWithLexerLoopCharIsWhitespce
    }
}
