using CryptingMethods;
using Xunit;

namespace Tests
{
    public class CipherKeyBaseTest
    {
        [Fact]
        public void CipherKeyBaseConstructorTest()
        {
            CipherKeyBase testCipher = new CipherTestInstances.TestCipherWithKey(
                CipherTestInstances.TEST_MIN_KEY,
                CipherTestInstances.TEST_MAX_KEY,
                CipherTestInstances.TEST_KEY_VALUE);

            Assert.Equal(CipherTestInstances.TEST_MIN_KEY, testCipher.KeyMinConstraint);
            Assert.Equal(CipherTestInstances.TEST_MAX_KEY, testCipher.KeyMaxConstraint);
            Assert.Equal(CipherTestInstances.TEST_KEY_VALUE, testCipher.KeyValue);
        }

        [Fact]
        public void KeyValueTest_setBaseTestValue()
        {
            CipherKeyBase testCipher = CipherTestInstances.cipherWithKey;

            testCipher.KeyValue = CipherTestInstances.TEST_KEY_VALUE;
            Assert.Equal(CipherTestInstances.TEST_KEY_VALUE, testCipher.KeyValue);
        }

        [Fact]
        public void KeyValueTest_setBaseTestValuePlusOne()
        {
            CipherKeyBase testCipher = CipherTestInstances.cipherWithKey;

            testCipher.KeyValue = CipherTestInstances.TEST_KEY_VALUE + 1;
            Assert.Equal(CipherTestInstances.TEST_KEY_VALUE + 1, testCipher.KeyValue);
        }

        [Fact]
        public void KeyValueTest_setValueBiggerThanMaxConstraint()
        {
            CipherKeyBase testCipher = CipherTestInstances.cipherWithKey;

            testCipher.KeyValue = CipherTestInstances.TEST_MAX_KEY + 1;
            Assert.Equal(CipherTestInstances.TEST_MAX_KEY, testCipher.KeyValue);
        }

        [Fact]
        public void KeyValueTest_setValueLowerThanMinConstraint()
        { 
            CipherKeyBase testCipher = CipherTestInstances.cipherWithKey;

            testCipher.KeyValue = CipherTestInstances.TEST_MIN_KEY - 1;
            Assert.Equal(CipherTestInstances.TEST_MIN_KEY, testCipher.KeyValue);
        }
    }
}
