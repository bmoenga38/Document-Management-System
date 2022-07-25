namespace FINNETT.data
{
    using Newtonsoft.Json;
    using RestSharp;
    using System;
    using System.Data;
    using System.Web.Script.Serialization;

    /// <summary>
    /// Defines the <see cref="GetAPIData" />
    /// </summary>
    public class GetAPIData
    {
        /// <summary>
        /// The BranchInformation
        /// </summary>
        /// <param name="type">The type<see cref="int"/></param>
        /// <param name="code">The code<see cref="int"/></param>
        /// <param name="reference">The reference<see cref="string"/></param>
        /// <param name="BusinessKey">The BusinessKey<see cref="string"/></param>
        /// <param name="AccessKey">The AccessKey<see cref="string"/></param>
        /// <returns>The <see cref="DataTable"/></returns>
        public static DataTable BranchInformation(int type, int code, string reference, string BusinessKey,
            string AccessKey)
        {
            DataTable outputList = null;
            try
            {
                RestClient client = new RestClient(SuiteDreamLiner.APIUrul());
                RestRequest request = new RestRequest("business/getallbranches", Method.POST);
                request.AddHeader("Accept", "application/json");
                var body = new
                {
                    BusinessKey = data.SuiteDreamLiner.GetBusinessKeyNoEncryption(),
                    AccessKey = data.SuiteDreamLiner.GetAccessKeyNoEncryptionPOST(),
                    TerminalType = "WEB",
                    TerminalID = data.SuiteDreamLiner.GetIPAddress(),
                    TimeStamp = data.SuiteDreamLiner.GetTimeStamp(),
                    FilterCode = code,
                    FilterReference = reference,
                };
                request.AddJsonBody(body); client.Timeout = 999999999;
                string response = client.Execute(request).Content;
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                dynamic receivedData = serializer.Deserialize<dynamic>(response);
                try
                {
                    outputList = (DataTable) JsonConvert.DeserializeObject(receivedData, (typeof(DataTable)));
                }
                catch (Exception)
                {
                    outputList = null;
                }
            }
            catch (Exception)
            {
                outputList = null;
            }

            return outputList;
        }
    }
}