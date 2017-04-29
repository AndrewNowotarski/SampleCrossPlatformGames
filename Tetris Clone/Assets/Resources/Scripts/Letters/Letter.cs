using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Resources.Scripts.Letters
{
    /// <summary>
    /// Class that represents a single letter.
    /// </summary>
    public class Letter
    {
        /// <summary>
        /// The value of the letter, 'A', 'B'...
        /// </summary>
        public char Value { get; private set; }

        /// <summary>
        /// The weight, or likelihood that a letter is chosen (2x, 1.5x, .25x...)
        /// </summary>
        public int Weight { get; set; }

        public Letter(char value, int weight)
        {
            this.Value = value;
            this.Weight = weight;
        }
    }
}
