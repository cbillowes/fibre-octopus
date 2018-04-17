using System;
using System.Text;

namespace Codec.Core
{
    public class Compressor
    {
        public string Compress(string input)
        {
            if (input == null) throw new ArgumentNullException(nameof(input), "Argument cannot be null.");
            if (string.IsNullOrWhiteSpace(input)) return string.Empty;
            if (input.Length == 1) return $"{input}1";

            var deflated = Deflate(input);
            return deflated;
        }

        private static string Deflate(string input)
        {
            var total = 0;
            var output = new StringBuilder();
            for (var index = 0; index < input.Length; index++)
            {
                var iteration = Iterate(input, index, total);
                total = iteration.total;
                output.Append(iteration.output);
            }

            return output.ToString();
        }

        private static (string output, int total) Iterate(string input, int index, int total)
        {
            var current = input[index].ToString();
            var next = NextIndex(input, index);
            var output = string.Empty;
            total += 1;
            if (next != current)
            {
                output = $"{current}{total}";
                total = 0;
            }
            return (output, total);
        }

        private static string NextIndex(string input, int index)
        {
            return index + 1 < input.Length ? input[index + 1].ToString() : string.Empty;
        }
    }
}
