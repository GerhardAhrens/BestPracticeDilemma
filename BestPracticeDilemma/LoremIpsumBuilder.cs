/*
 * <copyright file="LoremIpsumBuilder.cs" company="Lifeprojects.de">
 *     Class: LoremIpsumBuilder
 *     Copyright © Lifeprojects.de 2023
 * </copyright>
 *
 * <author>Gerhard Ahrens - Lifeprojects.de</author>
 * <email>gerhard.ahrens@lifeprojects.de</email>
 * <date>04.02.2023 21:18:23</date>
 * <Project>CurrentProject</Project>
 *
 * <summary>
 * Beschreibung zur Klasse
 * </summary>
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by the Free Software Foundation, 
 * either version 3 of the License, or (at your option) any later version.
 * This program is distributed in the hope that it will be useful,but WITHOUT ANY WARRANTY; 
 * without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.You should have received a copy of the GNU General Public License along with this program. 
 * If not, see <http://www.gnu.org/licenses/>.
*/

namespace BestPracticeDilemma
{
    using System.Collections.Generic;
    using System.Text;

    public class LoremIpsumBuilder
    {
        private const string ORIGINALTEXT = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        private readonly List<string> _arrOriginal = new List<string>();

        /// <summary>
        /// Initializes a new instance of the <see cref="LoremIpsumBuilder"/> class.
        /// </summary>
        public LoremIpsumBuilder()
        {
            string[] arrText = ORIGINALTEXT.Split(' ');
            _arrOriginal = new List<string>(arrText);
        }

        public string GetChars()
        {
            return this.GetWords(ORIGINALTEXT.Length);
        }

        public string GetWords(int length)
        {
            var output = new StringBuilder();

            if (length == 0)
            {
                length = ORIGINALTEXT.Length; 
            }

            for (var i = 0; i < length; i++)
            {
                output.Append(ORIGINALTEXT[i]);
            }

            return output.ToString();
        }

        public string GetParagraphs(int count)
        {
            var output = new StringBuilder();
            for (int i = 0; i <= count; i++)
            {
                if (i == count)
                    output.Append(ORIGINALTEXT);
                else
                    output.Append(ORIGINALTEXT + "\n\n");
            }
            return output.ToString();
        }
    }
}
