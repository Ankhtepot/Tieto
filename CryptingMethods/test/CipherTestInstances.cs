using CryptingMethods;

namespace Tests
{
    public class CipherTestInstances
    {
        public const string TEST_CIPHER_WITH_KEY = "TestCipherWithKey - cipher";
        public const string TEST_DECIPHER_WITH_KEY = "TestCipherWithKey - decipher";
        public const string TEST_CIPHER_WITHOUT_KEY = "TestCipherWithoutKey - cipher";
        public const string TEST_DECIPHER_WITHOUT_KEY = "TestCipherWithoutKey - decipher";
        public const int TEST_MIN_KEY = 1;
        public const int TEST_MAX_KEY = 26;
        public const int TEST_KEY_VALUE = 5;


        public static CipherBase cipherWithoutKey = new TestCipherWithoutKey();
        public static readonly CipherKeyBase cipherWithKey = new TestCipherWithKey(
                                                            TEST_MIN_KEY,
                                                            TEST_MAX_KEY,
                                                            TEST_KEY_VALUE);
        public class TestCipherWithKey : CipherKeyBase
        {
            public TestCipherWithKey(int minKey, int maxKey, int keyValue) : base(minKey, maxKey, keyValue)
            {
                this.Name = "TestCipherWithKey";
            }
            public override string Cipher(string text)
            {
                return TEST_CIPHER_WITH_KEY;
            }

            public override string DeCipher(string code)
            {
                return TEST_DECIPHER_WITH_KEY;
            }

            public override bool IsKeyBasedCipher()
            {
                return true;
            }
        }

        public class TestCipherWithoutKey : CipherBase
        {
            public TestCipherWithoutKey() 
            {
                this.Name = "TestCipherWithoutKey";
            }
            public override string Cipher(string text)
            {
                return TEST_CIPHER_WITHOUT_KEY;
            }

            public override string DeCipher(string code)
            {
                return TEST_DECIPHER_WITHOUT_KEY;
            }

            public override bool IsKeyBasedCipher()
            {
                return false;
            }
        }
    }
}
