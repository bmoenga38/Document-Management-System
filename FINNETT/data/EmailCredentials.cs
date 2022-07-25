namespace FINNETT.data
{
    /// <summary>
    /// Defines the <see cref="EmailCredentials" />
    /// </summary>
    public class EmailCredentials
    {
        /// <summary>
        /// Defines the smstpserver
        /// </summary>
        public static string smstpserver;

        /// <summary>
        /// Defines the username
        /// </summary>
        public static string username;

        /// <summary>
        /// Defines the psd
        /// </summary>
        public static string psd;

        /// <summary>
        /// Defines the port
        /// </summary>
        public static int port;

        /// <summary>
        /// Defines the displayName
        /// </summary>
        public static string displayName;

        /// <summary>
        /// Defines the usesSSL
        /// </summary>
        public static bool usesSSL;

        /// <summary>
        /// The GetGatewayData
        /// </summary>
        /// <param name="emailaddress">The emailaddress<see cref="string"/></param>
        /// <returns>The <see cref="string"/></returns>
        public static string GetGatewayData(string emailaddress)
        {
            string status = string.Empty;
            //try
            //{
            //using (
            //    var con =
            //        new SqlConnection(SocketWire.con))
            //{
            //    using (
            //        var com =
            //            new SqlCommand("SELECT * FROM eqEmailGateway WHERE username='" + emailaddress + "'", con))
            //    {
            //        con.Open();
            //        var reader = com.ExecuteReader();
            //        if (reader.Read() && reader.HasRows)
            //        {
            smstpserver = "smtp.gmail.com"; // reader["SmtpServer"].ToString();
            username = "thecompanydelivery@gmail.com"; //reader["Username"].ToString();
            psd = "l@#*1234##"; //reader["Password"].ToString();
            port = 587; //int.Parse(reader["Port"].ToString());
            displayName = "smtp.gmail.com"; //reader["DisplayName"].ToString();
            usesSSL = true; // bool.Parse(reader["UsesSSL"].ToString());
            status = "FLIP";
            //            }
            //            else
            //            {
            //                status = "FLOP";
            //            }
            //            reader.Close();
            //            reader.Dispose();
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    status = "FLOP";
            //}
            return status;
        }
    }
}