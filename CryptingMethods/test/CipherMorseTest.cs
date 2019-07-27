using CryptingMethods;
using Xunit;

namespace Tests
{
    public class CipherMorseTest
    {
        CipherMorse testCipherMorse = CipherMorse.Create();

        [Fact]
        public void testCreate()
        {
            Assert.IsType<CipherMorse>(testCipherMorse);
        }

        [Fact]
        public void testName()
        {
            Assert.Equal("Morse", testCipherMorse.Name);
        }

        [Fact]
        public void testCipher_withKnownChars()
        {
            Assert.Equal("-.--/--../.-/-.../", testCipherMorse.Cipher("YZAB"));
        }

        [Fact]
        public void testCipher_withUnknownChars()
        {
            Assert.Equal("-.--/@/@/.-/", testCipherMorse.Cipher("YđĐA"));
        }

        [Fact]
        public void testDeCipher_withUnknownChars()
        {
            Assert.Equal("YZAB", testCipherMorse.DeCipher("-.--/--../.-/-.../"));
        }

        [Fact]
        public void testDecipher_withUknownChars()
        {
            Assert.Equal("YA", testCipherMorse.DeCipher("-.--/@/@/.-/"));
        }

        [Fact]
        public void testIsKeyBasedCipher()
        {
            Assert.False(testCipherMorse.IsKeyBasedCipher());
        }
    }
}
