using Cipher;
using Xunit;

namespace Tests
{
    public class CipherCaesarTest
    {
        CipherCaesar testCipherCaesar = CipherCaesar.Create(1);

        [Fact]
        public void CreateTest()
        {
            Assert.IsType<CipherCaesar>(testCipherCaesar);
        }

        [Fact]
        public void testName()
        {
            Assert.Equal("Caesar", testCipherCaesar.Name);
        }

        [Fact]
        public void testCipher()
        {
            Assert.Equal("ZABC", testCipherCaesar.Cipher("YZAB"));
        }

        [Fact]
        public void testDecipher()
        {
            Assert.Equal("XYZA", testCipherCaesar.DeCipher("YZAB"));
        }

        [Fact]
        public void testIsKeyBasedCipher()
        {
            Assert.True(testCipherCaesar.IsKeyBasedCipher());
        }
    }
}
