namespace Cipher
{   //Interface to ensure crypting classes can serve theyr purpose
    public interface ICipher
    {
        string Cipher(string text);
        string DeCipher(string code);
        bool IsKeyBasedCipher();
    }
}
