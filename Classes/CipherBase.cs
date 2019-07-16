namespace Classes
{ //base class for crypting methods
    public abstract class CipherBase : ICipher
    {
        public string Name { get; set; }

        public bool HasKey { get; set; }

        public abstract string DeCipher(string code);

        public abstract string Cipher(string text);

    }
}
