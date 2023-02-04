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
    using System.Text;

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

        public static string LoremIpsum(int minWords, int maxWords, int minSentences, int maxSentences, int numLines)
        {
            var words = new[] { "lorem", "ipsum", "dolor", "sit", "amet", "consectetuer", "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod", "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat" };

            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences) + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;
            var sb = new StringBuilder();
            for (int p = 0; p < numLines; p++)
            {
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { sb.Append(" "); }
                        sb.Append(words[rand.Next(words.Length)]);
                    }

                    sb.Append(". ");
                }

                sb.AppendLine();
            }

            return sb.ToString();
        }

        private static string GenerateString(int len)
        {
            var randomText = Path.GetRandomFileName().Replace('.', ' ');
            while ((randomText += randomText).Length < len);

            return randomText;
        }
    }
}
