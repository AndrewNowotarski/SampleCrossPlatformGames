using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.WordGeneration
{
    /// <summary>
    /// Class used to represent a word and its attributes.
    /// </summary>
    public class Word
    {
        /// <summary>
        /// The value of the word; "Cat" / "Dog"
        /// </summary>
        public string Value { get; private set; }

        /// <summary>
        /// The length of the word, "Cat" = 3
        /// </summary>
        public int Length { get; private set; }

        /// <summary>
        /// Determines whether or not the word has been used yet in this play session.
        /// </summary>
        public bool HasBeenUsed { get; set; }

        /// <summary>
        /// Constructor to add a new Word.
        /// </summary>
        public Word(string word)
        {
            this.Value = word;
            this.Length = word.Length;
            this.HasBeenUsed = false;
        }
    }
}
