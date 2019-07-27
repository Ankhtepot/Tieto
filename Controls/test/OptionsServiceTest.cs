using AppOptions;
using CryptingMethods;
using System;
using System.Collections.Generic;
using Xunit;

namespace AppOptions.Tests
{
    public class OptionsServiceTest
    {
        private const int MORSE_ID = 0;
        private const int CAESAR_ID = 1;

        [Fact]
        public void testCipherExecute_directionToCipherSomething()
        {
            OptionsService.SetOptions(CipherTestInstances.cipherWithoutKey);

            Assert.Equal(CipherTestInstances.TEST_CIPHER_WITHOUT_KEY, OptionsService.CipherExecute("whatever", true));
        }

        [Fact]
        public void testCipherExecute_directionToDecipherSomething()
        {
            OptionsService.SetOptions(CipherTestInstances.cipherWithKey);

            Assert.Equal(CipherTestInstances.TEST_DECIPHER_WITH_KEY, OptionsService.CipherExecute("whatever", false));
        }

        [Fact]
        public void testExitCheck()
        {
            Assert.True(OptionsService.ExitCheck());
        }

        [Fact]
        public void testInitializeOptionsCiphers_withDefaultFilePath()
        {
            OptionsService.InitializeOptionsCiphers();

            Assert.NotNull(Options.Ciphers);
            Assert.NotEmpty(Options.Ciphers);
        }

        [Fact]
        public void testInitializeOptionsCiphers_withWrongPath()
        {
            OptionsService.InitializeOptionsCiphers("./NonExistent.json");

            Assert.Null(Options.Ciphers);
        }

        [Fact]
        public void testGetCipherNames_withValidData()
        {
            OptionsService.InitializeOptionsCiphers();

            Assert.Equal(OptionsService.GetCiphersNames(), new List<string> { CipherTestInstances.CIPHER_NAME_MORSE, CipherTestInstances.CIPHER_NAME_CAESAR });
        }

        [Fact]
        public void testGetCipherNames_withNullAndEmptyListListData()
        {
            Options.Ciphers = null;

            Assert.Null(OptionsService.GetCiphersNames());

            Options.Ciphers = new List<CipherBase>();

            Assert.Null(OptionsService.GetCiphersNames());
        }

        [Fact]
        public void testSetOptions_cryptingMethodWithKey()
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
        public void testSetOptions_cryptingMethodWithoutKey()
        {
            CipherBase testCipher =  CipherTestInstances.cipherWithoutKey;

            OptionsService.SetOptions(testCipher);

            Assert.Equal(Options.CryptingMethod, testCipher);
            Assert.Equal(Options.LbKeyText, testCipher.Name + OptionsService.CIPHER_WITHOUT_KEY_LABEL_PREFIX);
            OptionsService.SetOptions(testCipher); // TODO find out why is not changing CipherMethod after first SetOptions
            Assert.False(Options.CryptingMethod.IsKeyBasedCipher());
        }

        [Fact]
        public void testSetOptions_withNullMethod()
        {
            OptionsService.InitializeOptionsCiphers();
            Assert.False(OptionsService.SetOptions(null));
        }

        [Fact]
        public void testGetCipher_morseCipher()
        {
            OptionsService.InitializeOptionsCiphers();
            Assert.IsType<CipherMorse>(OptionsService.GetCipher(MORSE_ID));
        }

        [Fact]
        public void testGetCipher_caesarCipher()
        {
            OptionsService.InitializeOptionsCiphers();
            Assert.IsType<CipherCaesar>(OptionsService.GetCipher(CAESAR_ID));
        }

        [Fact]
        public void testGetCipher_withIndexOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => OptionsService.GetCipher(int.MaxValue));
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
