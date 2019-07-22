namespace CryptingMethods
{ //base class for crypting methods
    public abstract class CipherBase : ICipher
    {
        public string Name { get; set; }

        public abstract string DeCipher(string code);

        public abstract string Cipher(string text);

        public abstract bool IsKeyBasedCipher();
    }
}
