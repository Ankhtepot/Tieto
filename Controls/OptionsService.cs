using Classes.Resources;
using CryptingMethods;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public static void InitializeOptionsCiphers()
        {
            Options.Ciphers = loadCiphers(JSONParser.parseJson<CipherDescription>("./CipherDescriptions.json"));
        }

        public static List<string> GetCiphersNames()
        {
            return Options.Ciphers.Select(x => x.Name).ToList();
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

        public static List<CipherBase> loadCiphers(List<CipherDescription> cipherDescriptions )
        {
            //TODO implement using optional int and string from CipherDescription
            
            List<CipherBase> cipherInstances = new List<CipherBase>();

            cipherDescriptions.ForEach(description => {
                var cipherType = GetType(description.Name);
                if (cipherType.IsSubclassOf(typeof(CipherKeyBase)))
                {
                    var instance = cipherType.GetMethod("Create").Invoke(cipherType, new object[] { description.Key });
                    cipherInstances.Add((CipherKeyBase)instance);
                }
                else
                {
                    cipherInstances.Add((CipherBase)cipherType.GetMethod("Create").Invoke(cipherType, new object[] { description.ResourcePath }));
                }
            });

            return cipherInstances;
        }

        //for getting cipher method
        public static CipherBase GetCipher(int methodSelection)
        {
            return Options.Ciphers[methodSelection];
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

