using CryptingMethods;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AppOptions
{
    public static class OptionsService
    {
        //TODO move Strings into seperate file and make them translatable via JSON
        public const string CIPHER_WITH_KEY_LABEL_PREFIX = " method Key value ";
        public const string CIPHER_WITHOUT_KEY_LABEL_PREFIX = " method is not using crypting key value.";
        //method to cipher/decipher
        public static string CipherExecute(string input, bool cipherDirection) =>
             cipherDirection ? Options.CryptingMethod.Cipher(input) : Options.CryptingMethod.DeCipher(input);


        //just demonstration of possibility to check if all is ready to Exit app
        public static bool ExitCheck()
        {
            return true;
        }

        //sets AppOptions when crypting method changes
        public static bool SetOptions(CipherBase cipher)
        {
            if (cipher == null)
            { 
                MessageBox.Show("Setting the crypting method failed");
                return false;
            }

            Options.CryptingMethod = cipher;
            Options.LbKeyText = buildLbKeyText(Options.CryptingMethod);

            if (Options.CryptingMethod.IsKeyBasedCipher())
            {
                CipherKeyBase keyCipherMethod = (CipherKeyBase)Options.CryptingMethod;
                Options.NudKeyVisible = true;
                Options.NudKeyMinimum = keyCipherMethod.KeyMinConstraint;
                Options.NudKeyMaximum = keyCipherMethod.KeyMaxConstraint;
                Options.KeyValue = keyCipherMethod.KeyValue;
            }
            else
            {
                Options.NudKeyVisible = false;
            }

            return true;
        }

        //for getting cipher method
        public static CipherBase GetCipher(int methodSelection)
        {
            string assemblyName = System.Reflection.Assembly.GetExecutingAssembly().FullName;

            List<Type> cipherTypes = new List<Type> {
                GetType("CryptingMethods.CipherMorse"), GetType("CryptingMethods.CipherCaesar") };

            List<CipherBase> cipherInstances = new List<CipherBase>();

            Type keyCipher = typeof(CipherKeyBase);

            foreach (var cipherType in cipherTypes)
            {
                if (cipherType.IsSubclassOf(keyCipher))
                {
                    var instance = cipherType.GetMethod("Create").Invoke(cipherType, new object[] { 1 });
                    cipherInstances.Add((CipherKeyBase)instance);
                }
                else
                {
                    cipherInstances.Add((CipherBase)cipherType.GetMethod("Create").Invoke(cipherType, new object[] { "" }));
                }
            }

            return cipherInstances[methodSelection];
            //switch (methodSelection)
            //{
            //    case 0: return CipherMorse.Create();
            //    case 1: return CipherCaesar.Create(Options.KeyValue > 0 ? Options.KeyValue : 1);
            //    default: return null;
            //}
        }

        //Serves as check if chosen crypting method supports keyValue
        public static bool IsCryptingMethodWithKey() =>
            Options.CryptingMethod.IsKeyBasedCipher();

        public static string buildLbKeyText(CipherBase cipher)
        {
            return string.Format($"{cipher.Name}" +
                    (cipher.IsKeyBasedCipher() ? CIPHER_WITH_KEY_LABEL_PREFIX + $"({((CipherKeyBase)cipher).KeyMinConstraint}" + $" - {((CipherKeyBase)cipher).KeyMaxConstraint})" 
                                   : CIPHER_WITHOUT_KEY_LABEL_PREFIX));
        }

        //source: Sarath Avanavu/StackOverflow
        public static Type GetType(string strFullyQualifiedName)
        {
            Type type = Type.GetType(strFullyQualifiedName);
            //if (type != null)
            //    return Activator.CreateInstance(type);
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = asm.GetType(strFullyQualifiedName);
                if (type != null)
                    return type;
                        //type == typeof(CipherKeyBase) ? (CipherKeyBase)Activator.CreateInstance(type) 
                        //: (CipherBase)Activator.CreateInstance(type);
            }
            return null;
        }


    }
}

