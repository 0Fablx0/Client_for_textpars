using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Client_for_textpars
{
    static internal class Logic
    {
        /// <summary>
        /// Function return List of int - corect Id
        /// and List of string - wrong id
        /// </summary>
        internal static (List<int>, List<string>) parsInputID (string inputID)
        {
            
            inputID = inputID.Trim(' ');
            string[] ID = inputID.Split(';', ',');
            List<string> wrongID = new List<string>();
            List<int> correctID = new List<int>();
            List<int> integerID = new List<int>();

            foreach (var x in ID)
            {
                try
                {
                    int number = Convert.ToInt32(x);
                    integerID.Add(number);
                }
                catch
                {
                    wrongID.Add(x);
                }
            }

            foreach (int x in integerID)
            {
                if (x < 20 && x > -1)
                {
                    if(!correctID.Contains(x)) correctID.Add(x);
                }
                else
                {
                    wrongID.Add(x.ToString());
                }
            }
            return (correctID, wrongID);
        }
        internal static int getCountWords (string text)
        {
            Regex regex = new Regex(@".(?!\.)[\,\.\?\!\;\:\s\n…]");
            MatchCollection matches = regex.Matches(text);
            return matches.Count;
        }
        internal static int getCountVowelLetter(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
            string textNormalize = stringBuilder.ToString().Normalize(NormalizationForm.FormC);

            Regex regex = new Regex(@"[aeiouауоыиэяюёе]");
            MatchCollection matches = regex.Matches(textNormalize);

            regex = new Regex(@"[й]");
            MatchCollection consonants = regex.Matches(text);

            return matches.Count - consonants.Count;
        }
    }
}
