using AppOptions;
using Cipher;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests
{
    public class OptionsServiceTest
    {
        private const int MORSE_ID = 1;
        private const int CAESAR_ID = 2;

        [Fact]
        public void testExitCheck()
        {
            Assert.True(OptionsService.ExitCheck());
        }

        [Fact]
        public void testSetAppOptionsCryptingMethod_cryptingMethodWithKey()
        {
            CipherKeyBase testCipher = CipherTestInstances.cipherWithKey;

            OptionsService.SetOptions(testCipher);

            Assert.Equal(Options.CryptingMethod, testCipher);
            Assert.Equal(Options.LbKeyText, testCipher.Name
                + OptionsService.CIPHER_WITH_KEY_LABEL_PREFIX
                + $"({CipherTestInstances.TEST_MIN_KEY} - {CipherTestInstances.TEST_MAX_KEY})");
            Assert.True(Options.NudKeyVisible);
            Assert.Equal(Options.NudKeyMinimum, CipherTestInstances.TEST_MIN_KEY);
            Assert.Equal(Options.NudKeyMaximum, CipherTestInstances.TEST_MAX_KEY);
            Assert.Equal(Options.KeyValue, CipherTestInstances.TEST_KEY_VALUE);
            Assert.True(Options.CryptingMethod.IsKeyBasedCipher());
        }

        [Fact]
        public void testSetAppOptionsCryptingMethod_cryptingMethodWithoutKey()
        {
            CipherBase testCipher =  CipherTestInstances.cipherWithoutKey;

            OptionsService.SetOptions(testCipher);

            Assert.Equal(Options.CryptingMethod, testCipher);
            Assert.Equal(Options.LbKeyText, testCipher.Name + OptionsService.CIPHER_WITHOUT_KEY_LABEL_PREFIX);
            OptionsService.SetOptions(testCipher);
            Assert.False(Options.CryptingMethod.IsKeyBasedCipher());
        }

        [Fact]
        public void testSetAppOptionsCryptingMethod_withNullMethod()
        {
            Assert.False(OptionsService.SetOptions(null));
        }

        [Fact]
        public void testGetCipher_morseCipher()
        {
            Assert.IsType<CipherMorse>(OptionsService.GetCipher(MORSE_ID));
        }

        [Fact]
        public void testGetCipher_caesarCipher()
        {
            Assert.IsType<CipherCaesar>(OptionsService.GetCipher(CAESAR_ID));
        }

        [Fact]
        public void testGetCipher_withIndexOutOfRange()
        {
            Assert.Null(OptionsService.GetCipher(int.MaxValue));
        }

        [Fact]
        public void testIsCrypringMethodWithKey_returnFalse()
        {
            OptionsService.SetOptions(CipherTestInstances.cipherWithoutKey);

            Assert.False(OptionsService.IsCryptingMethodWithKey());
        }

        [Fact]
        public void testIsCryptingMethodWithKey_returnTrue()
        {
            OptionsService.SetOptions(CipherTestInstances.cipherWithKey);

            Assert.True(OptionsService.IsCryptingMethodWithKey());
        }
    }

    
}
