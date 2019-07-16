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
        [Fact]
        public void testExitCheck()
        {
            Assert.True(Ctrls.ExitCheck());
        }

        [Fact]
        public void testSetAppOptionsCryptingMethod()
        {

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
