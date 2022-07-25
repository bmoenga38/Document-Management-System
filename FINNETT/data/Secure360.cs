using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Web;

namespace FINNETT.data
{
    public class Secure360
    {
        public static string GetCertificateInformation()
        {
            string URl = HttpContext.Current.Request.Url.AbsoluteUri;
            HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URl);
            File.WriteAllText(@"C:\finnett\request1.txt", request1.ToString());
            HttpWebResponse responsee = (HttpWebResponse)request1.GetResponse();
            responsee.Close();

            //retrieve the ssl cert and assign it to an X509Certificate object
            X509Certificate cert = request1.ServicePoint.Certificate;

            File.WriteAllText(@"C:\finnett\cert.txt", request1.ToString());
            //convert the X509Certificate to an X509Certificate2 object by passing it into the constructor
            X509Certificate2 cert2 = new X509Certificate2(cert);

            string cn = cert2.GetIssuerName();
            string cedate = cert2.GetExpirationDateString();
            string cpub = cert2.GetPublicKeyString();
            string cp = cert2.GetSerialNumberString();
            string Thumbprint = cert2.Thumbprint;
            //string URl = System.Web.HttpContext.Current.Request.Url.AbsoluteUri;
            //HttpWebRequest request1 = (HttpWebRequest)WebRequest.Create(URl);
            //HttpWebResponse webResponse = (HttpWebResponse)request1.GetResponse();
            //webResponse.Close();
            //X509Certificate cert = request1.ServicePoint.Certificate;
            //X509Certificate2 cert2 = new X509Certificate2(cert);
            //return cert.GetSerialNumber().ToString();
            return cert2.GetSerialNumberString();//"CER0001";
        }

        public static string GetSignature()
        {
            string sig = string.Empty;
            string _TerminalType = string.Empty;
            string _TerminalID = string.Empty;
            string _TimeStamp = string.Empty;
            var encodedSignature = string.Empty;
            try
            {
                _TerminalType = SuiteDreamLiner.GetTerminalType();
                _TerminalID = SuiteDreamLiner.GetIPAddress();
                _TimeStamp = SuiteDreamLiner.GetTimeStamp();
                var signatureBody = new
                {
                    TerminalType = _TerminalType,
                    TerminalID = _TerminalID,
                    TimeStamp = _TimeStamp

                };
                var json_Signature = JsonConvert.SerializeObject(signatureBody);
                encodedSignature = Convert.ToBase64String(Encoding.UTF8.GetBytes(json_Signature));

            }
            catch (Exception ex) { }
            return encodedSignature;
        }

        public static string GetTerminalType()
        {
            return "FINNETT360WEB";
        }

        public static string GetAuthorization()
        {
            //string auth = string.Empty;
            //try
            //{
            //    auth = SuiteDreamLiner.GetAccessKeyNoEncryption(); // DataPurifier.Decrypt(System.Web.HttpContext.Current.Request.Cookies["X3600"].Value);
            //}
            //catch (System.Exception)
            //{
            //    auth = string.Empty;
            //}
            //if (auth == string.Empty)
            //{
            //    auth = SuiteDreamLiner.GetAccessKey();
            //}
            return "1234567890";
        }

        public static string GetTerminalID()
        {
            return GetCertificateInformation() + ":" + GetTerminalType();
        }
    }
}