using Assets.Scripts.WordGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Resources.Scripts.Letters
{
	/// <summary>
	/// Static object that handles randomization and generation of letters.
	/// </summary>
    public static class LetterGenerator
    {
        static List<Letter> letters = new List<Letter>();
        static int totalWeight = 0;
		static int setLetterWeight = 0;
		static Word currentWord;
        static Random rand = new Random();

		/// <summary>
		/// Constructor that sets up the initial list of letters with default weights.
		/// </summary>
        static LetterGenerator()
        {
            /* Initialize the letters collection. */
            letters.Add(new Letter('A', 10));
            letters.Add(new Letter('B', 10));
            letters.Add(new Letter('C', 10));
            letters.Add(new Letter('D', 10));
            letters.Add(new Letter('E', 10));
            letters.Add(new Letter('F', 10));
            letters.Add(new Letter('G', 10));
            letters.Add(new Letter('H', 10));
            letters.Add(new Letter('I', 10));
            letters.Add(new Letter('J', 10));
            letters.Add(new Letter('K', 10));
            letters.Add(new Letter('L', 10));
            letters.Add(new Letter('M', 10));
            letters.Add(new Letter('N', 10));
            letters.Add(new Letter('O', 10));
            letters.Add(new Letter('P', 10));
            letters.Add(new Letter('Q', 10));
            letters.Add(new Letter('R', 10));
            letters.Add(new Letter('S', 10));
            letters.Add(new Letter('T', 10));
            letters.Add(new Letter('U', 10));
            letters.Add(new Letter('V', 10));
            letters.Add(new Letter('W', 10));
            letters.Add(new Letter('X', 10));
            letters.Add(new Letter('Y', 10));
            letters.Add(new Letter('Z', 10));
        }

		/// <summary>
		/// Returns 
		/// </summary>
		/// <returns>The letter.</returns>
		/// <param name="currentWord">Current word.</param>
		/// <param name="setWeight">Set weight.</param>
        public static char GetLetter()
        {
            int randomNumber = rand.Next(0, totalWeight);

			/* Placeholder letter. */
            char letter = 'A';

            foreach (Letter l in letters)
            {
                if (randomNumber < l.Weight)
                {
                    letter = l.Value;
                    break;
                }

                randomNumber = randomNumber - l.Weight;
            }

            return letter;
        }

		/// <summary>
		/// Method that sets up a new word.
		/// </summary>
		/// <param name="currentWord">The current word being spelled.</param>
		/// <param name="setWeight">The weight of the letters in the current word (how often will they appear).</param>
        public static void SetUpWord(Word word, int setWeight)
        {
			/* Set the current static variables. */
			currentWord = word;
			setLetterWeight = setWeight;

            /* Reset the letters list. */
            letters.Select(l => { l.Weight = 10; return l; });

            /* Get a set of distinct characters in the word. */
            var lettersInWord = currentWord.Value.ToUpper().ToCharArray().Distinct();

            /* Update each characters weight. */
            foreach(char letter in lettersInWord)            {
                letters.Where(l => l.Value == letter).First().Weight = setWeight;            }

            /* Set the total weight of all of the letters. */
            totalWeight = letters.Sum(l => l.Weight);
        }
    }
}
