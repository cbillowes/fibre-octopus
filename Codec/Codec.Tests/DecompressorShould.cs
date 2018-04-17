using System;
using Codec.Core;
using NUnit.Framework;

namespace Codec.Tests
{
    [TestFixture]
    public class DecompressorShould
    {
        [Test]
        public void Disallow_missing_input()
        {
            // Arrange
            var decompressor = new Decompressor();

            // Act
            string Actual() => decompressor.Decompress(null);

            // Assert
            Assert.That(Actual, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Returns_an_empty_string()
        {
            // Arrange
            var decompressor = new Decompressor();

            // Act
            var actual = decompressor.Decompress(string.Empty);

            // Assert
            Assert.That(actual, Is.Empty);
        }

        [Test]
        public void Decompress_string()
        {
            // Arrange
            const string input = "a2b3c5a2";
            var decompressor = new Decompressor();

            // Act
            var actual = decompressor.Decompress(input);

            // Assert
            Assert.That(actual, Is.EqualTo("aabbbcccccaa"));
        }

        [Test]
        public void Break_decompression_when_string_is_malformed_string()
        {
            // Arrange
            const string input = "aabbbcccccaa";
            var decompressor = new Decompressor();

            // Act
            string Actual() => decompressor.Decompress(input);

            // Assert
            Assert.That(Actual, Throws.TypeOf<InvalidOperationException>());
        }
    }
}
