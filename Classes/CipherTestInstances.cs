using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public class CipherTestInstances
    {
        public const string TEST_CIPHER_WITH_KEY = "TestCipherWithKey - cipher";
        public const string TEST_DECIPHER_WITH_KEY = "TestCipherWithKey - decipher";
        public const string TEST_CIPHER_WITHOUT_KEY = "TestCipherWithoutKey - cipher";
        public const string TEST_DECIPHER_WITHOUT_KEY = "TestCipherWithoutKey - decipher";
        public const int TEST_MINKEY = 1;
        public const int TEST_MAXKEY = 26;
        public const int TEST_KEY_VALUE = 5;
        public class TestCipherWithKey : CipherKeyBase
        {
            public TestCipherWithKey(int keyValue) : base(TEST_MINKEY, TEST_MAXKEY, keyValue)
            {
                this.Name = "TestCipherWithKey";
                this.HasKey = true;
            }
            public override string Cipher(string text)
            {
                return TEST_CIPHER_WITH_KEY;
            }

            public override string DeCipher(string code)
            {
                return TEST_DECIPHER_WITH_KEY;
            }
        }

        public class TestCipherWithoutKey : CipherBase
        {
            public TestCipherWithoutKey() 
            {
                this.Name = "TestCipherWithoutKey";
                this.HasKey = true;
            }
            public override string Cipher(string text)
            {
                return TEST_CIPHER_WITHOUT_KEY;
            }

            public override string DeCipher(string code)
            {
                return TEST_DECIPHER_WITHOUT_KEY;
            }
        }
    }
}
