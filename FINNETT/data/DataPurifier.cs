namespace FINNETT.data
{
    using System;
    using System.Security.Cryptography;
    using System.Text;

    public class DataPurifier
    {
        private const int Keysize = 256;

        private const string passPhrase = "#UNISTRAT_BUSUSINESS_SUITE@#*2017###";

        private const int DerivationIterations = 10000;

        public static string Encrypt(string plainText)
        {
            return StringUtil.Crypt(plainText);
            //byte[] saltStringBytes = Generate256BitsOfRandomEntropy();
            //byte[] ivStringBytes = Generate256BitsOfRandomEntropy();
            //byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            //using (Rfc2898DeriveBytes password =
            //    new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            //{
            //    byte[] keyBytes = password.GetBytes(Keysize / 8);
            //    using (RijndaelManaged symmetricKey = new RijndaelManaged())
            //    {
            //        symmetricKey.BlockSize = 256;
            //        symmetricKey.Mode = CipherMode.CBC;
            //        symmetricKey.Padding = PaddingMode.PKCS7;
            //        using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes))
            //        {
            //            using (MemoryStream memoryStream = new MemoryStream())
            //            {
            //                using (CryptoStream cryptoStream =
            //                    new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            //                {
            //                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            //                    cryptoStream.FlushFinalBlock();
            //                    byte[] cipherTextBytes = saltStringBytes;
            //                    cipherTextBytes = cipherTextBytes.Concat(ivStringBytes).ToArray();
            //                    cipherTextBytes = cipherTextBytes.Concat(memoryStream.ToArray()).ToArray();
            //                    memoryStream.Close();
            //                    cryptoStream.Close();
            //                    return Convert.ToBase64String(cipherTextBytes);
            //                }
            //            }
            //        }
            //    }
            //}
        }

        public static string Decrypt(string cipherText)
        {
            return StringUtil.Decrypt(cipherText);
            //byte[] cipherTextBytesWithSaltAndIv = Convert.FromBase64String(cipherText);
            //byte[] saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            //byte[] ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            //byte[] cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2)
            //    .Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();
            //using (Rfc2898DeriveBytes password =
            //    new Rfc2898DeriveBytes(passPhrase, saltStringBytes, DerivationIterations))
            //{
            //    byte[] keyBytes = password.GetBytes(Keysize / 8);
            //    using (RijndaelManaged symmetricKey = new RijndaelManaged())
            //    {
            //        symmetricKey.BlockSize = 256;
            //        symmetricKey.Mode = CipherMode.CBC;
            //        symmetricKey.Padding = PaddingMode.PKCS7;
            //        using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes))
            //        {
            //            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
            //            {
            //                using (CryptoStream cryptoStream =
            //                    new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
            //                {
            //                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            //                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            //                    memoryStream.Close();
            //                    cryptoStream.Close();
            //                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
            //                }
            //            }
            //        }
            //    }
            //}
        }

        private static byte[] Generate256BitsOfRandomEntropy()
        {
            byte[] randomBytes = new byte[32];
            using (RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetBytes(randomBytes);
            }

            return randomBytes;
        }

        public static byte[] GenerateSalt()
        {
            const int saltLength = 64;

            using (RNGCryptoServiceProvider randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                byte[] randomNumber = new byte[saltLength];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }

        private static byte[] Combine(byte[] first, byte[] second)
        {
            byte[] ret = new byte[first.Length + second.Length];

            Buffer.BlockCopy(first, 0, ret, 0, first.Length);
            Buffer.BlockCopy(second, 0, ret, first.Length, second.Length);

            return ret;
        }

        public static byte[] HashPasswordWithSalt(byte[] toBeHashed, byte[] salt)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] combinedHash = Combine(toBeHashed, salt);

                return sha256.ComputeHash(combinedHash);
            }
        }

        public static string HashOutPsd(string password)
        {
            byte[] salt = GenerateSalt();
            string hashedPSD = Convert.ToBase64String(salt);
            byte[] hashedPassword = HashPasswordWithSalt(Encoding.UTF8.GetBytes(password), salt);
            string saltedHas = Convert.ToBase64String(hashedPassword);
            return saltedHas;
        }

        public static string EncodePassword(string pass)
        {
            byte[] originalBytes;
            byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            originalBytes = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(originalBytes);
            return BitConverter.ToString(encodedBytes);
        }
    }
}