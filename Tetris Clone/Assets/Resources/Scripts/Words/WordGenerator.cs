using Assets.Scripts.ExtensionMethods;
using Assets.Scripts.WordGeneration;
using Assets.Resources;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    static public class WordGenerator
    {
        /// <summary>
        /// Private list of all words that are read into memory.
        /// </summary>
        private static List<Word> WordDictionary = new List<Word>();

        static WordGenerator()
        {
            var fileName = "Data/words";

            //TextAsset wordsFile = (TextAsset)Resources.Load(fileName, typeof(TextAsset));
            string wordsFile = @"cat\ndog\nlow\";

            /* Read from the data file and load the words into memory. */
            foreach (string line in wordsFile.Split('\n'))
            {
                WordDictionary.Add(new Word(line.Trim()));
            }
        }

        /// <summary>
        /// Method to return a random word of length wordLength that has not already been used.
        /// </summary>
        /// <param name="wordLength">Denotes how long the return word should be.</param>
        /// <returns>A random word of length wordLength that has not already been used.</returns>
        static public Word GenerateWord(int wordLength)
        {
            /* Because we are returning a refernece to the word in the collection, we can make any changes to it here. */
            var word = WordDictionary.Shuffle().Where(w => w.Length == wordLength && !w.HasBeenUsed).FirstOrDefault();

            if (word != null)
                word.HasBeenUsed = true;

			//TODO figure out why word is null.
			word = new Word("cat");

            /* Return either a word if we still have some to use or return nothing. */
            return word;
        }

    }

}
