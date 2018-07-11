using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes
{
    public interface ICipher : IDisposable
    {
        String Cipher(String text);
        String DeCipher(String code);
    }
}
