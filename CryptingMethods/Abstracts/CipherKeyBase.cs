namespace CryptingMethods
{ //base class for crypting methods with keyValue
    public abstract class CipherKeyBase : CipherBase
    {
        public int KeyMinConstraint { get; set; }
        public int KeyMaxConstraint { get; set; }
        private int keyValue;

        public CipherKeyBase(int keyMin, int keyMax, int keyVal)
        {
            KeyMinConstraint = keyMin;
            KeyMaxConstraint = keyMax;
            keyValue = keyVal;
        }
        
        public virtual int KeyValue {
            get => keyValue;
            set {
                if (value >= KeyMinConstraint && value <= KeyMaxConstraint) keyValue = value;
                else if (value <= KeyMinConstraint) keyValue = KeyMinConstraint;
                else if (value >= KeyMaxConstraint) keyValue = KeyMaxConstraint;
            }
        }

        public override abstract string Cipher(string text);

        public override abstract string DeCipher(string code);

        public abstract override bool IsKeyBasedCipher();
    }
}
