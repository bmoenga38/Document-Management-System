using Newtonsoft.Json;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace FINNETT.data
{
    public class GlassWipe
    {
        public static string HashData(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hasheddata = string.Empty;
            foreach (byte x in hash)
            {
                hasheddata += String.Format("{0:x2}", x);
            }

            return hasheddata;
        }

        public static string GenerateSHA256String(string inputString)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha256.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }

        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }

            return result.ToString();
        }

        public static string DataReaderToJSON(SqlDataReader reader)
        {
            string _json = string.Empty;
            try
            {
                var dTable = new DataTable();
                dTable.Load(reader);
                _json = JsonConvert.SerializeObject(dTable);
            }
            catch (Exception ex)
            {
                _json = "invalid";
            }

            return _json;
        }

        public static string DataTableToJSON(DataTable table)
        {
            string _json = string.Empty;
            try
            {
                _json = JsonConvert.SerializeObject(table);
            }
            catch (Exception ex)
            {
                _json = "invalid";
            }

            return _json;
        }
    }
}