using System;
using Codec.Core;
using NUnit.Framework;

namespace Codec.Tests
{
    [TestFixture]
    public class CompressorShould
    {
        [Test]
        public void Disallow_missing_input()
        {
            // Arrange
            var compressor = new Compressor();

            // Act
            string Actual() => compressor.Compress(null);

            // Assert
            Assert.That(Actual, Throws.TypeOf<ArgumentNullException>());
        }

        [Test]
        public void Returns_an_empty_string()
        {
            // Arrange
            var compressor = new Compressor();

            // Act
            var actual = compressor.Compress(string.Empty);

            // Assert
            Assert.That(actual, Is.Empty);
        }

        [Test]
        public void Return_letter_and_one_instance_when_one_letter_is_provided()
        {
            // Arrange
            const string input = "a";
            var compressor = new Compressor();

            // Act
            var actual = compressor.Compress(input);

            // Assert
            Assert.That(actual, Is.EqualTo("a1"));
        }

        [Test]
        public void Compress_string()
        {
            // Arrange
            const string input = "aabbbcccccaa";
            var compressor = new Compressor();

            // Act
            var actual = compressor.Compress(input);

            // Assert
            Assert.That(actual, Is.EqualTo("a2b3c5a2"));
        }
    }
}
