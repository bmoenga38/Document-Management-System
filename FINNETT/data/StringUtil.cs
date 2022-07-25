namespace FINNETT.data
{
    public static class StringUtil
    {
        private static readonly byte[] key = new byte[8] { 1, 20, 33, 41, 57, 66, 77, 83 };
        private static readonly byte[] iv = new byte[8] { 1, 20, 33, 41, 57, 66, 77, 83 };

        public static string Crypt(this string text)
        {
            return text;
            //SymmetricAlgorithm algorithm = DES.Create();
            //ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            //byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
            //byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            //return Convert.ToBase64String(outputBuffer);
        }

        public static string Decrypt(this string text)
        {
            return text;
            //SymmetricAlgorithm algorithm = DES.Create();
            //ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            //byte[] inputbuffer = Convert.FromBase64String(text);
            //byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            //return Encoding.Unicode.GetString(outputBuffer);
        }

        public static string CryptData(this string text)
        {
            return text;
            //SymmetricAlgorithm algorithm = DES.Create();
            //ICryptoTransform transform = algorithm.CreateEncryptor(key, iv);
            //byte[] inputbuffer = Encoding.Unicode.GetBytes(text);
            //byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            //return Convert.ToBase64String(outputBuffer);
        }

        public static string DecryptData(this string text)
        {
            return text;
            //SymmetricAlgorithm algorithm = DES.Create();
            //ICryptoTransform transform = algorithm.CreateDecryptor(key, iv);
            //byte[] inputbuffer = Convert.FromBase64String(text);
            //byte[] outputBuffer = transform.TransformFinalBlock(inputbuffer, 0, inputbuffer.Length);
            //return Encoding.Unicode.GetString(outputBuffer);
        }
    }
}