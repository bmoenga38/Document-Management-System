using System.IO;
using System.Net;
using System.Web.Script.Serialization;

public class Widegateway
{
    //public static string SendSmsAPI = "http://www.widegateway.cloud/api/messaging";

    //public static string AirtimeAPI = "http://www.widegateway.cloud/api/airtime";

    //public static string BalancesAPI = "http://www.widegateway.cloud/api/balances";
    public static string SendSmsAPI = "http://www.widegateway.cloud/api/messaging";

    public static string AirtimeAPI = "http://www.widegateway.cloud/api/airtime";
    public static string BalancesAPI = "http://www.widegateway.cloud/api/balances";

    public static string smsBalUri(string username, string apikey)
    {
        string callURL = string.Empty;
        string _URL = "/smsbalance/?username=" + username + "&apikey=" + apikey;
        callURL = BalancesAPI + _URL;
        return callURL;
    }

    public static string smsSendUri(string UserName, string ApiKey, string recipient, string Message, int BulkSMSMode,
        string SenderId)
    {
        string callURL = string.Empty;
        string _URL = "/sendsms/?username=" + UserName + "&apikey=" + ApiKey + "&recipient=" + recipient + "&message=" +
                      Message + "&senderid=" + SenderId + "&bulksmsmode=" + BulkSMSMode + "";
        callURL = SendSmsAPI + _URL;
        return callURL;
    }

    public static string eTopupUri(string username, string apikey, string phoneno, string amount, string currency)
    {
        string callURL = string.Empty;
        string _URL = "/buy/?username=" + username + "&apikey=" + apikey + "&recipient=" + phoneno + "&amount=" +
                      amount + "&currency=" + currency + "";
        callURL = AirtimeAPI + _URL;
        return callURL;
    }

    public dynamic SendSMS(string UserName, string ApiKey, string recipient, string Message, int BulkSMSMode,
        string SenderId)
    {
        string piCall = smsSendUri(UserName, ApiKey, recipient, Message, BulkSMSMode, SenderId);
        string piPush = wwwcall(piCall);
        JavaScriptSerializer JavaScriptSerializer = new JavaScriptSerializer();
        object rcvObject = JavaScriptSerializer.Deserialize<object>(piPush);
        dynamic rcvData = JavaScriptSerializer.Deserialize<object>(rcvObject.ToString());
        return rcvData;
    }

    public dynamic AccountBalance(string Username, string ApiKey)
    {
        string piCall = smsBalUri(Username, ApiKey);
        string piPush = wwwcall(piCall);
        JavaScriptSerializer JavaScriptSerializer = new JavaScriptSerializer();
        object rcvObject = JavaScriptSerializer.Deserialize<object>(piPush);
        dynamic rcvData = JavaScriptSerializer.Deserialize<object>(rcvObject.ToString());
        return rcvData;
    }

    public dynamic BuyAirtime(string Username, string ApiKey, string Recipient, string Amount, string currency)
    {
        string piCall = eTopupUri(Username, ApiKey, Recipient, Amount, currency);
        string piPush = wwwcall(piCall);
        JavaScriptSerializer JavaScriptSerializer = new JavaScriptSerializer();
        object rcvObject = JavaScriptSerializer.Deserialize<object>(piPush);
        dynamic rcvData = JavaScriptSerializer.Deserialize<object>(rcvObject.ToString());
        return rcvData;
    }

    private string wwwcall(string url)
    {
        string responseJson = string.Empty;
        HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(url);
        http.ContentType = "application/json";
        HttpWebResponse response = (HttpWebResponse)http.GetResponse();
        using (StreamReader sr = new StreamReader(response.GetResponseStream()))
        {
            responseJson = sr.ReadToEnd();
        }

        return responseJson;
    }

    public static HttpWebRequest CreateWebRequest(string URL)
    {
        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(URL);
        webRequest.ContentType = "application/json";
        webRequest.Method = "GET";
        return webRequest;
    }
}