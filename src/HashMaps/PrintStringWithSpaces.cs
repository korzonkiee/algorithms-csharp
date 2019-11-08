
using System;
using System.Collections.Generic;
using System.Text;

namespace src.DataStructures
{
    public class PrintStringWithSpaces
    {
        // ABAA
        // AB_A__A
        public String PrintWithSpacesWithCooldown(string s, int cooldown)
        {
            var occurences = new Dictionary<char, int>();
            StringBuilder stringBuilder = new StringBuilder();

            int currentPositionInNewString = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (occurences.ContainsKey(s[i]))
                {
                    int lastCharacterPosition = occurences[s[i]];

                    int diff = currentPositionInNewString - lastCharacterPosition - 1;
                    int spacesToPrint = cooldown - diff;

                    for (int space = 0; space < spacesToPrint; space++)
                    {
                        stringBuilder.Append(" ");
                        currentPositionInNewString++;
                    }

                    stringBuilder.Append(s[i]);
                    occurences[s[i]] = i;
                    currentPositionInNewString++;
                }
                else
                {
                    stringBuilder.Append(s[i]);
                    occurences.Add(s[i], i);
                    currentPositionInNewString++;
                }
            }

            return stringBuilder.ToString();
        }
    }
}
