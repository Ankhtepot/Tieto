using Classes.Resources;
using CryptingMethods;
using CryptingMethods.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AppOptions
{
    public static class OptionsService
    {
        //TODO move Strings into seperate file and make them translatable via JSON
        public const string CIPHER_DESCRIPTIONS_PATH = "./CipherDescriptions.json";
        public const string CIPHER_WITH_KEY_LABEL_PREFIX = " method Key value ";
        public const string CIPHER_WITHOUT_KEY_LABEL_PREFIX = " method is not using crypting key value.";

        /// <summary>
        /// Triggers cripting/decripting process of a selected method
        /// </summary>
        /// <param name="input">String from Input field</param>
        /// <param name="cipherDirection">True = cipher ; False = Decipher</param>
        /// <returns></returns>
        public static string CipherExecute(string input, bool cipherDirection) =>
             cipherDirection ? Options.CryptingMethod.Cipher(input) : Options.CryptingMethod.DeCipher(input);

        //just demonstration of possibility to check if all is ready to Exit app
        public static bool ExitCheck()
        {
            return true;
        }

        /// <summary>
        /// Loads crypting method setup from CipherDescriptions.json
        /// </summary>
        public static void InitializeOptionsCiphers(string alternativeFilePath = "")
        {
            var filePath = alternativeFilePath == "" ? CIPHER_DESCRIPTIONS_PATH : alternativeFilePath;
            Options.Ciphers = createCiphers(JSONParser.ParseJson<CipherDescription>(filePath));
            if (Options.Ciphers == null || !Options.Ciphers.Any())
            {
                MessageBox.Show("Loading Crypting methods failed"); 
            }
        }

        /// <summary>
        /// Extract names from active crypting methods
        /// </summary>
        /// <returns>List of names</returns>
        public static List<string> GetCiphersNames()
        {
            return (Options.Ciphers == null || !Options.Ciphers.Any()) ? null : Options.Ciphers.Select(x => x.Name).ToList(); 
        }

        /// <summary>
        /// Sets AppOptions according to desired crypting method.
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns>return <see langword="true"/>, if was crypting method assigned</returns>
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

        /// <summary>
        /// Returns Cipher previously set in Options
        /// </summary>
        /// <param name="methodSelection"></param>
        /// <returns>Cipher</returns>
        public static CipherBase GetCipher(int methodSelection)
        {
            return Options.Ciphers != null ? Options.Ciphers[methodSelection] : null;
        }

        /// <summary>
        /// Serves as check if chosen crypting method supports keyValue
        /// </summary>
        /// <returns></returns>
        public static bool IsCryptingMethodWithKey()
        {
            if(Options.CryptingMethod == null)
            {
                return false;
            }
            return Options.CryptingMethod.IsKeyBasedCipher(); 
        }

        private static string buildLbKeyText(CipherBase cipher)
        {
            return string.Format($"{cipher.Name}" +
                    (cipher.IsKeyBasedCipher() ? CIPHER_WITH_KEY_LABEL_PREFIX + $"({((CipherKeyBase)cipher).KeyMinConstraint}" + $" - {((CipherKeyBase)cipher).KeyMaxConstraint})" 
                                   : CIPHER_WITHOUT_KEY_LABEL_PREFIX));
        }

        /// <summary>
        /// Searches for type in all assemblies
        /// </summary>
        /// <param name="fullyQualifiedName"></param>
        /// <returns>found type or null</returns>
        private static Type getType(string fullyQualifiedName)
        {
            foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type type = assembly.GetType(fullyQualifiedName);
                if (type != null)
                    return type;
            }
            return null;
        }

        /// <summary>
        /// Creates List of Cipher instances from cipher descriptions (f.ex. previously parsed from json).
        /// </summary>
        /// <param name="cipherDescriptions"></param>
        /// <returns></returns>
        private static List<CipherBase> createCiphers(List<CipherDescription> cipherDescriptions)
        {
            //TODO implement using optional int and string from CipherDescription
            if (cipherDescriptions == null || !cipherDescriptions.Any())
            {
                return null;
            }

            List<CipherBase> cipherInstances = new List<CipherBase>();

            cipherDescriptions.ForEach(description => {
                var cipherType = getType(description.Name);
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
    }
}

