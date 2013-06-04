using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.IO;

namespace SharpUtil
{
    public static class IdKeyGenerator
    {

        // output example: 19-109
        //public static string NumberHash()
        //{
        //    byte[] buffer = GetRandom(2);
        //    return string.Format("{0:00}-{1:00}", buffer[0], buffer[1]);
        //}

        // output example: v5m0
        public static string AlphaNumeric(string str)
        {
            str = str.ToAlphaNumeric();
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < 4; i++)
            {
                int index = random.Next(1, str.Length);
                builder.Append(str[index]);
            }
            return builder.ToString();
        }

        // output example: v5m0
        public static string AlphaNumeric()
        {
            string str = Guid.NewGuid().ToString();
            return AlphaNumeric(str);
        }

        // output example: 32fb1dfe
        public static string StringHash(string str)
        {
            int hashcode = str.GetHashCode();
            return string.Format("{0:X}", hashcode).ToLower();
        }

        // output example: 32fb1dfe
        public static string StringHash(Guid guid)
        {
            int hashcode = guid.GetHashCode();
            return string.Format("{0:X}", hashcode).ToLower();
        }

        public static string ShortGuid(out Guid guid)
        {
            guid = Guid.NewGuid();
            return StringHash(guid);
        }

        public static string ShortGuid()
        {
            Guid guid = Guid.NewGuid();
            return StringHash(guid);
        }

        // output example: 22ba
        public static string TimeToHexString()
        {
            long ms = DateTime.Now.Second;
            long ms2 = DateTime.Now.Millisecond;
            return string.Format("{0:X}{1:X}", ms, ms2).ToLower();
        }

        // output example: 8cb46e251f0f610
        public static string TicksToString()
        {
            long ticks = DateTime.Now.Ticks;
            return string.Format("{0:X}", ticks).ToLower();
        }

        // output example: 7cbae8cd41a9d13892c8feb8e435c5e
        //public static string RandomMD5()
        //{
        //    byte[] buffer = GetRandom(16);
        //    MD5 md5 = System.Security.Cryptography.MD5.Create();
        //    byte[] output = md5.ComputeHash(buffer);
        //    StringBuilder builder = new StringBuilder();

        //    for (int i = 0; i < output.Length; i++)
        //        builder.AppendFormat("{0:x2}", output[i]);

        //    return builder.ToString();
        //}

        public static string Base62Random()
        {
            Random rand = new Random();
            int random = rand.Next();
            return Base62ToString(random);
        }

        private static string Base62ToString(long value)
        {
            // Divides the number by 64, so how many 64s are in
            // 'value'. This number is stored in Y.
            // e.g #1
            // 1) 1000 / 62 = 16, plus 8 remainder (stored in x).
            // 2) 16 / 62 = 0, remainder 16
            // 3) 16, 8 or G8:
            // 4) 65 is A, add 6 to this = 71 or G.
            //
            // e.g #2:
            // 1) 10000 / 62 = 161, remainder 18
            // 2) 161 / 62 = 2, remainder 37
            // 3) 2 / 62 = 0, remainder 2
            // 4) 2, 37, 18, or 2,b,I:
            // 5) 65 is A, add 27 to this (minus 10 from 37 as these are digits) = 92.
            //    Add 6 to 92, as 91-96 are symbols. 98 is b.
            // 6)
            long x = 0;
            long y = Math.DivRem(value, 62, out x);
            if (y > 0)
            {
                return Base62ToString(y) + ValToChar(x).ToString();
            }
            else
            {
                return ValToChar(x).ToString();
            }
        }

        private static char ValToChar(long value)
        {
            if (value > 9)
            {
                int ascii = (65 + ((int)value - 10));
                if (ascii > 90)
                    ascii += 6;
                return (char)ascii;
            }
            else
            {
                return value.ToString()[0];
            }
        }

        #region cryptography

        // generate salt by string and phrase
        public static string CreateRfc2898Salt(string plainText, string saltPhrase)
        {
            Rfc2898DeriveBytes salt = new Rfc2898DeriveBytes(plainText, Encoding.UTF8.GetBytes(saltPhrase), 10000);
            return Convert.ToBase64String(salt.GetBytes(25));
        }

        // generate byte key
        public static byte[] CreateSalt(int keySizeInBytes)
        {
            byte[] salt = new byte[keySizeInBytes];
            using (var provider = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                provider.GetBytes(salt);
            }
            return salt;
        }

        public static string CreateSaltAsBase64String(int keySizeInBytes)
        {
            return Convert.ToBase64String(CreateSalt(keySizeInBytes));
        }

        // generate SHA256 key
        public static byte[] CreateSHA256(byte[] key, string phrase)
        {
            byte[] hashPhrase;
            using (HMACSHA256 hmac = new HMACSHA256(key))
            {
                byte[] dataPhrase = Encoding.UTF8.GetBytes(phrase);
                hashPhrase = hmac.ComputeHash(dataPhrase);
            }

            return hashPhrase;
        }

        public static string CreateSHA256(string key, string phrase)
        {
            byte[] hashPhrase = CreateSHA256(Convert.FromBase64String(key), phrase);
            return Convert.ToBase64String(hashPhrase);
        }

        // generate SHA384 key
        public static byte[] CreateSHA384(byte[] key, string phrase)
        {
            byte[] hashPhrase;
            using (HMACSHA384 hmac = new HMACSHA384(key))
            {
                byte[] dataPhrase = Encoding.UTF8.GetBytes(phrase);
                hashPhrase = hmac.ComputeHash(dataPhrase);
            }

            return hashPhrase;
        }

        public static string CreateSHA384(string key, string phrase)
        {
            byte[] hashPhrase = CreateSHA384(Convert.FromBase64String(key), phrase);
            return Convert.ToBase64String(hashPhrase);
        }

        // generate SHA512 key
        public static byte[] CreateSHA512(byte[] key, string phrase)
        {
            byte[] hashPhrase;
            using (HMACSHA512 hmac = new HMACSHA512(key))
            {
                byte[] dataPhrase = Encoding.UTF8.GetBytes(phrase);
                hashPhrase = hmac.ComputeHash(dataPhrase);
            }

            return hashPhrase;
        }

        public static string CreateSHA512(string key, string phrase)
        {
            byte[] hashPhrase = CreateSHA512(Convert.FromBase64String(key), phrase);
            return Convert.ToBase64String(hashPhrase);
        }

        public static string MD5Hash(byte[] bytes)
        {
            MD5 md5 = MD5.Create();
            return md5.ComputeHash(bytes).Byte2String();
        }







        // not done yet........
        public static void PasswordEncryption()
        {










            string usageText = "Usage: RFC2898 <password>\nYou must specify the password for encryption.\n";

            string passwordargs = "pass1234";

            string outPut = string.Empty;


            //If no file name is specified, write usage text. 
            if (passwordargs.Length == 0)
            {
                outPut = usageText;
            }
            else
            {
                string pwd1 = passwordargs;

                string sSalt = "ZjcNuTsOt7w=";
                string sPwd1 = "TWdp9pSeifyzUTqp7McxvQ==";



                int byteSize = 8;


                // Create a byte array to hold the random value.  
                //byte[] salt1 = new byte[byteSize];
                //using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
                //{
                //    // Fill the array with a random value.
                //    rngCsp.GetBytes(salt1);
                //}


                byte[] salt1 = Convert.FromBase64String(sSalt);

                string k1_1 = string.Empty;
                string k2_2 = string.Empty;

                //data1 can be a string or contents of a file. 
                string data1 = "this is my salt 2, please guess";

                //The default iteration count is 1000 so the two methods use the same iteration count.
                int myIterations = 1000;
                try
                {
                    Rfc2898DeriveBytes k1 = new Rfc2898DeriveBytes(pwd1, salt1, myIterations);

                    Rfc2898DeriveBytes k2 = new Rfc2898DeriveBytes(pwd1, salt1);

                    // Encrypt the data.
                    TripleDES encAlg = TripleDES.Create();
                    encAlg.Key = Convert.FromBase64String("kXH1I8m9wW1Z2/9fLvWm6A==");//k1.GetBytes(byteSize * 2);


                    k2_2 = Convert.ToBase64String(encAlg.Key);





                    MemoryStream encryptionStream = new MemoryStream();
                    CryptoStream encrypt = new CryptoStream(encryptionStream, encAlg.CreateEncryptor(), CryptoStreamMode.Write);
                    byte[] utfD1 = new System.Text.UTF8Encoding(false).GetBytes(data1);

                    encrypt.Write(utfD1, 0, utfD1.Length);
                    encrypt.FlushFinalBlock();
                    encrypt.Close();
                    byte[] edata1 = encryptionStream.ToArray();

                    k1.Reset();



                    k1_1 = Convert.ToBase64String(edata1);


                    //byte[] edata2 = Convert.FromBase64String(sPwd1);

                    //k2_2 = Convert.ToBase64String(edata2);



                    // Try to decrypt, thus showing it can be round-tripped.
                    TripleDES decAlg = TripleDES.Create();
                    decAlg.Key = k2.GetBytes(byteSize * 2);
                    decAlg.IV = encAlg.IV;
                    MemoryStream decryptionStreamBacking = new MemoryStream();
                    CryptoStream decrypt = new CryptoStream(decryptionStreamBacking, decAlg.CreateDecryptor(), CryptoStreamMode.Write);
                    decrypt.Write(edata1, 0, edata1.Length);
                    decrypt.Flush();
                    decrypt.Close();
                    k2.Reset();
                    string data2 = new UTF8Encoding(false).GetString(decryptionStreamBacking.ToArray());

                    if (!data1.Equals(data2))
                    {
                        outPut = "Error: The two values are not equal: data1 = " + data1 + " - data2 = " + data2;
                    }
                    else
                    {
                        outPut = "The two values are equal. data1 = " + data1.ToString() + " - data2 = " + data2.ToString() + " - salt1 = " + Convert.ToBase64String(salt1) + " - edata1 = " + k1_1 + " - edata2 = " + k2_2;
                        outPut += "<br>" + string.Format("k1 iterations: {0}", k1.IterationCount);
                        outPut += "<br>" + string.Format("k2 iterations: {0}", k2.IterationCount);
                    }
                }
                catch (Exception e)
                {
                    outPut = string.Format("Error: ", e);
                }

            }
        }






















        #endregion cryptography
    }
}
