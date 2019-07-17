using Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Controls.test
{
    public class CtrlsTest
    {
        private const int CIPHER_ID = 1;

        [Fact]
        public void testExitCheck()
        {
            Assert.True(Ctrls.ExitCheck());
        }



        [Fact]
        public void testSetAppOptionsCryptingMethod_cryptingMethodWithKey()
        {
            CipherKeyBase testCipher = 
                new CipherTestInstances.TestCipherWithKey(CipherTestInstances.TEST_KEY_VALUE);

            Ctrls.SetAppOptionsCryptingMethod(testCipher);

            Assert.Equal(AppOptions.CryptingMethod, testCipher);
            Assert.Equal(AppOptions.LbKeyText, testCipher.Name 
                + Ctrls.CIPHER_WITH_KEY_LABEL_PREFIX 
                + $"({CipherTestInstances.TEST_MINKEY} - {CipherTestInstances.TEST_MAXKEY})");
            Assert.True(AppOptions.NudKeyVisible);
            Assert.Equal(AppOptions.NudKeyMinimum, CipherTestInstances.TEST_MINKEY);
            Assert.Equal(AppOptions.NudKeyMaximum, CipherTestInstances.TEST_MAXKEY);
            Assert.Equal(AppOptions.KeyValue, CipherTestInstances.TEST_KEY_VALUE);
        }

        [Fact]
        public void testGetCipher_morseCipher()
        {
            Assert.IsType<CipherMorse>(Ctrls.GetCipher(1));
        }

        [Fact]
        public void testGetCipher_caesarCipher()
        {
            Assert.IsType<CipherCaesar>(Ctrls.GetCipher(2));
        }

        
    }

    
}
