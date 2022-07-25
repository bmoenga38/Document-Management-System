namespace FINNETT.data
{
    using System.Web;

    /// <summary>
    /// Defines the <see cref="PengerData" />
    /// </summary>
    public class PengerData
    {
        /// <summary>
        /// The businessverification
        /// </summary>
        /// <param name="content">The content<see cref="string"/></param>
        /// <param name="terminaladdress">The terminaladdress<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string businessverification(string content, string terminaladdress)
        {
            //string url = "http://cloud.unistrat.co.ke/pi360/admin/business/verify?businesscode="+ HttpUtility.UrlEncode(content) +"&terminaladdress="+  HttpUtility.UrlEncode(terminaladdress);
            string url = "http://localhost/finnettapi/admin/business/verify?businesscode=" +
                         HttpUtility.UrlEncode(content) + "&terminaladdress=" + HttpUtility.UrlEncode(terminaladdress);

            return url;
        }

        /// <summary>
        /// The balanceurl
        /// </summary>
        /// <param name="content">The content<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string balanceurl(string content)
        {
            string url = "http://cloud.unistrat.co.ke/pi360/mpesa/accountbalancerequest?requestdata=" +
                         HttpUtility.UrlEncode(content);
            return url;
        }

        /// <summary>
        /// The b2burl
        /// </summary>
        /// <param name="content">The content<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string b2burl(string content)
        {
            string url = "http://cloud.unistrat.co.ke/pi360/mpesa/b2brequest?requestdata=" +
                         HttpUtility.UrlEncode(content);
            return url;
        }

        /// <summary>
        /// The b2curl
        /// </summary>
        /// <param name="content">The content<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string b2curl(string content)
        {
            string url = "http://cloud.unistrat.co.ke/pi360/mpesa/b2crequest?requestdata=" +
                         HttpUtility.UrlEncode(content);
            return url;
        }

        /// <summary>
        /// The registerurl
        /// </summary>
        /// <param name="_requestid">The _requestid<see cref="string"/></param>
        /// <param name="_consumerkey">The _consumerkey<see cref="string"/></param>
        /// <param name="_consumersecret">The _consumersecret<see cref="string"/></param>
        /// <param name="_shortcode">The _shortcode<see cref="string"/></param>
        /// <param name="_validationurl">The _validationurl<see cref="string"/></param>
        /// <param name="_confirmationurl">The _confirmationurl<see cref="string"/></param>
        /// <param name="_responsetype">The _responsetype<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string registerurl(string _requestid, string _consumerkey, string _consumersecret,
            string _shortcode, string _validationurl, string _confirmationurl, string _responsetype)
        {
            string url = "http://cloud.unistrat.co.ke/pi360/mpesa/registerurl?requestid=" +
                         HttpUtility.UrlEncode(_requestid) + "&shortcode=" + HttpUtility.UrlEncode(_shortcode) +
                         "&appkey=" + HttpUtility.UrlEncode(_consumerkey) + "&appsecret=" +
                         HttpUtility.UrlEncode(_consumersecret) + "&responsetype=" +
                         HttpUtility.UrlEncode(_responsetype) + "&validationurl=" +
                         HttpUtility.UrlEncode(_validationurl) + "&confirmationurl=" +
                         HttpUtility.UrlEncode(_confirmationurl) + "";
            return url;
        }
    }
}