using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Resources.Scripts.Letters
{
    public static class Weight
    {
        public static readonly Dictionary<string, decimal> LetterWeight = new Dictionary<string, decimal>();

        static Weight()
        {
            LetterWeight.Add("Level1", 2.0m);
            LetterWeight.Add("Level2", 1.75m);
            LetterWeight.Add("Level3", 1.5m);
            LetterWeight.Add("Level4", 1.25m);
            LetterWeight.Add("Level5", 1.0m);
            LetterWeight.Add("Level6", 0.75m);
            LetterWeight.Add("Level7", 0.5m);
            LetterWeight.Add("Level8", 0.25m);
        }
    }
}
