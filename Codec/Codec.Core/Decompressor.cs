using System;
using System.Linq;
using System.Text;

namespace Codec.Core
{
    public class Decompressor
    {
        public string Decompress(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input), "Argument cannot be null.");
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;

            var inflated = Inflate(input);
            return inflated;
        }

        private static string Inflate(string input)
        {
            var output = new StringBuilder();
            for (var i = 0; i < input.Length; i++)
            {
                var text = Iterate(input, i);
                output.Append(text);
            }

            return output.ToString();
        }

        private static string Iterate(string input, int i)
        {
            var output = new StringBuilder();
            if ((i + 1) % 2 == 0)
            {
                try
                {
                    var count = int.Parse(input[i].ToString());
                    var characters = new string(Enumerable.Repeat(input[i - 1], count).ToArray());
                    output.Append(characters);
                }
                catch (FormatException)
                {
                    throw new InvalidOperationException($"Expected a number but got a \"{input[i - 1]}\".");
                }
            }
            return output.ToString();
        }
    }
}