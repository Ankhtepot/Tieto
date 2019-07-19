using AppOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class OptionsTest
    {
        [Fact]
        public void testSetKeyValue_withCipherKeyBaseCryptingMethod()
        {
            Options.CryptingMethod = CipherTestInstances.cipherWithKey;

            Options.KeyValue = CipherTestInstances.cipherWithKey.KeyValue;

            Assert.Equal(Options.KeyValue, CipherTestInstances.cipherWithKey.KeyValue);
        }

        [Fact]
        public void testSetKeyValue_withCipherBaseCryptingMethod()
        {
            Options.CryptingMethod = CipherTestInstances.cipherWithoutKey;

            Options.KeyValue = CipherTestInstances.cipherWithKey.KeyValue;

            Assert.Equal(Options.KeyValue, 0);
        }
    }
}
