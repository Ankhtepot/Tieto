using Cipher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class CipherKeyBaseTest
    {
        [Fact]
        public void CipherKeyBaseConstructorTest()
        {
            CipherKeyBase testCipher = CipherTestInstances.cipherWithKey;

            Assert.Equal(testCipher.KeyMinConstraint, CipherTestInstances.TEST_MIN_KEY);
            Assert.Equal(testCipher.KeyMinConstraint, CipherTestInstances.TEST_MIN_KEY);
        }
    }
}
