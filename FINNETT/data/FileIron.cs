namespace FINNETT.data
{
    using System;
    using System.IO;

    public class FileIron
    {
        public static string FileTo64(string path)
        {
            string string64 = string.Empty;
            byte[] bytes = File.ReadAllBytes(path);
            string64 = Convert.ToBase64String(bytes);
            return string64;
        }
    }
}