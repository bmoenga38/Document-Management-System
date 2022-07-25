using System.Web.UI;

namespace FINNETT.data
{
    using Newtonsoft.Json;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    using System.Web;
    using System.Web.Script.Serialization;
    using System.Web.Script.Services;
    using System.Web.Services;
    using System.Web.UI.WebControls;

    public class SuiteDreamLiner
    {
        public static string PasswordPolicy()
        {
            string policies = string.Empty;
            //RequiresUpperAndLowerCase,PasswordLength,MinimumNumeric,MinimumSymbols,MinimumLowerCase,MinimumUpperCase,TrialCounter
            policies = "false,0,0,0,0,0,0";
            return policies;
        }

        public static string DecimalPoints()
        {
            string _point = "n3";
            try
            {
                string[] thisdata = BusinessData().Split('#');
                _point = "n" + thisdata[6].ToString();
            }
            catch (Exception)
            {
                _point = "n2";
            }
            return _point;
        }

        public static void WriteDicData(string key, string data)
        {
            try
            {
                string filePath = @"C:\Finnett\dicdata.txt"; //System.Web.HttpContext.Current.Server.MapPath("~/data/dicdata.txt");
                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }
                File.AppendAllText(filePath, key + "  " + data + "\n");
            }
            catch (Exception)
            {
            }
        }

        public static void WriteDicCount(string count)
        {
            try
            {
                string filePath = @"C:\Finnett\diccount.txt"; //System.Web.HttpContext.Current.Server.MapPath("~/data/dicdata.txt");
                if (!File.Exists(filePath))
                {
                    File.Create(filePath);
                }
                File.WriteAllText(filePath, count + "\n");
            }
            catch (Exception)
            {
            }
        }

        public static string GetConnection()
        {
            return ConfigurationManager.ConnectionStrings["FinnettConnection"].ConnectionString;
        }

        private const int _defaultNumberOfCharacters = 8;
        private const int _defaultExpireDays = 10;
        private static readonly string _allowedCharacters = "abcdfghjklmnpqrstvxz0123456789";

        public static string GetRandomString(int numberOfCharacters)
        {
            const int from = 0;
            int to = _allowedCharacters.Length;
            Random r = new Random();

            StringBuilder qs = new StringBuilder();
            for (int i = 0; i < numberOfCharacters; i++)
            {
                qs.Append(_allowedCharacters.Substring(r.Next(from, to), 1));
            }
            return qs.ToString();
        }

        public static string GetUserSessionCookie()
        {
            string _udata = string.Empty;
            try
            {
                try
                {
                    //
                    //_udata = data.StringUtil.DecryptData(System.Web.HttpContext.Current.Request.Cookies["SES360"].Value);
                    // _udata = data.StringUtil.DecryptData(System.Web.HttpContext.Current.Request.Cookies["ASP.NET_SessionId"].Value);

                    _udata = "peter";
                }
                catch (Exception)
                {
                    _udata = string.Empty;
                }
            }
            catch (Exception)
            {
            }
            return _udata;
        }

        public static string AspNetSession(int caller)
        {
            string _udata = string.Empty;
            try
            {
                try
                {
                    _udata = GetUserSessionCookie(); // string.Empty;//DecryptData(System.Web.HttpContext.Current.Request.Cookies["F360"].Value);
                }
                catch (Exception)
                {
                    _udata = string.Empty;
                }

                //if (_udata == string.Empty)
                //{
                //    _udata = data.SuiteDreamLiner.GetRandomString(7).ToLower();
                //    System.Web.HttpContext.Current.Response.Cookies["F360"].Value = EncryptData(_udata);
                //}
            }
            catch (Exception)
            {
            }
            return _udata;
        }

        public static string UserAccessModules()
        {
            string _udata = string.Empty;
            try
            {
                _udata = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_USER_MODULES"); //DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETTZ105"].Value);
            }
            catch (Exception)
            {
                _udata = string.Empty;
            }
            return _udata;
        }

        public static string UserSubModulesAccess(string modulename)
        {
            string _udata = string.Empty;
            try
            {
                _udata = DecryptData(System.Web.HttpContext.Current.Request.Cookies[modulename].Value);
            }
            catch (Exception)
            {
                _udata = string.Empty;
            }
            return _udata;
        }

        public static string UserModulesRights()
        {
            string _udata = string.Empty;
            try
            {
                _udata = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_USER_MODULES"); //DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETTZ105"].Value);
            }
            catch (Exception)
            {
                _udata = string.Empty;
            }
            return _udata;
        }

        public static string UserData()
        {
            string _udata = string.Empty;
            try
            {
                _udata = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_USER_DATA"); //DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETTZ103"].Value);
            }
            catch (Exception)
            {
                _udata = string.Empty;
            }
            return _udata;
        }

        public static string BusinessData()
        {
            string _bdata = string.Empty;
            try
            {
                _bdata = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_COMPANY_DATA"); //DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETTZ100"].Value);
            }
            catch (Exception)
            {
                _bdata = string.Empty;
            }
            return _bdata;
        }

        public static string LicensedModules()
        {
            string _ldata = string.Empty;
            try
            {//
                _ldata = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_LICENSED_MODULES"); //DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETTZ101"].Value);
            }
            catch (Exception)
            {
                _ldata = string.Empty;
            }
            return _ldata;
        }

        public static string AllReceivedData()
        {
            string _adata = string.Empty;
            try
            {
                _adata = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_RECEIVED_DATA"); //DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETTZ102"].Value);
            }
            catch (Exception)
            {
                _adata = string.Empty;
            }
            return _adata;
        }

        public static string AllViewRights()
        {
            string _adata = string.Empty;
            try
            {
                _adata = DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETTZ113"].Value);
            }
            catch (Exception)
            {
                _adata = string.Empty;
            }
            return _adata;
        }

        public static DataTable GetDataTable(List<string> ColumnNames, GridView myGrid)
        {
            DataTable dt = new DataTable();
            for (int i = 0; i < ColumnNames.Count; i++)
            {
                dt.Columns.Add(ColumnNames[i]);
            }
            foreach (GridViewRow row in myGrid.Rows)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < myGrid.HeaderRow.Cells.Count; j++)
                {
                    dr[ColumnNames[j]] = row.Cells[j].Text;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }

        public static string GenerateCode()
        {
            //Random r = new Random();
            //Or Passing in a seed value
            //Random r2 = new Random(65);
            //var mycode = r2.NextDouble();
            string mycode = DateTime.Now.ToString("yyyyMMddHHmmss");
            return mycode.ToString();
        }

        public static void CheckDirectoryExists(string url)
        {
            try
            {
                if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(url)))
                {
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(url));
                }
            }
            catch (Exception)
            {
            }
        }

        public static string GetLoanSerialNumber(string productid)
        {
            string serial = string.Empty;
            //FinnettData db = new FinnettData();
            //db.GenerateLoanSerialNumber(GetCompanyID(), productid, ref serial);
            return serial;
        }

        public static string GetAgeDifference(DateTime checkdate, DateTime datenow)
        {
            string age = string.Empty;
            //FinnettData db = new FinnettData();
            //age = db.DateDIFFYearsMonthsDays(checkdate, datenow);
            return age;
        }

        public static string ValidateData(string data)
        {
            string receivedData = string.Empty;
            try { receivedData = data; } catch (Exception) { receivedData = ""; }
            if (string.IsNullOrEmpty(receivedData))
            {
                receivedData = "";
            }
            return receivedData;
        }

        public static void CheckDocumentPaths(string businessCode)
        {
            try
            {
                string mainDocPath = "~/uploads/documents";
                if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(mainDocPath)))
                {
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(mainDocPath));
                }

                string businessPath = mainDocPath + "/" + businessCode;

                if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(businessPath)))
                {
                    Directory.CreateDirectory(businessPath);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void CheckUploadPath()
        {
            try
            {
                string mainUploadPath = "~/uploads/fileuploads";
                if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(mainUploadPath)))
                {
                    Directory.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(mainUploadPath));
                }
            }
            catch (Exception)
            {
            }
        }

        public static bool CheckIfModuleIsLicensed(string modulename)
        {
            bool isLicensed = false;
            try
            {
                string businessInformation = LicensedModules();
                if (businessInformation.ToLower().Contains(modulename))
                {
                    isLicensed = true;
                }
                else
                {
                    isLicensed = false;
                }
            }
            catch (Exception)
            {
                isLicensed = false;
            }

            return isLicensed;
        }

        public static void CompressFIle(string FilePath, string _DestinationPath)
        {
            if (File.Exists(_DestinationPath))
            {
                File.Delete(_DestinationPath);
            }

            //ZipFile.CreateFromDirectory(FilePath, _DestinationPath);
        }

        public static string DatabaseConnection()
        {
            return ConfigurationManager.ConnectionStrings["FinnettConnection"].ConnectionString;
        }

        public static string GetSMSBalance()
        {
            string balance = "0";
            try
            {
                string _accountname = string.Empty;
                string _accountkey = string.Empty;
                using (SqlConnection con =
                    new SqlConnection(DatabaseConnection()))
                {
                    SqlCommand com = new SqlCommand("SELECT TOP 1 * from [UBSCRM00601] where CompanyID=@companyid", con);
                    com.Parameters.AddWithValue("@companyid", SuiteDreamLiner.GetCompanyID());
                    con.Open();
                    SqlDataReader reader = com.ExecuteReader();
                    if (reader.Read() && reader.HasRows)
                    {
                        _accountname = reader["AccountName"].ToString();
                        _accountkey = reader["AccountKey"].ToString();
                    }

                    reader.Close();
                    con.Close();
                    con.Dispose();
                }

                //get balance
                if (_accountkey != string.Empty || _accountname != string.Empty)
                {
                    string _balance = data.SuiteDreamLiner.GetSMSBalance(_accountname, _accountkey);
                    balance = _balance;
                }
            }
            catch (Exception)
            {
                balance = "0";
            }

            return balance;
        }

        public static DataTable HeaderDataSetX(string companyid)
        {
            //bizcode.Text = businesscode.Text;
            RestClient client = new RestClient(SuiteDreamLiner.APIUrul());
            RestRequest request = new RestRequest("business/verification2", Method.POST);
            request.AddHeader("Accept", "application/json");
            var body = new
            {
                BusinessKey = companyid,
                TerminalType = "WEB",
                TerminalID = data.SuiteDreamLiner.GetIPAddress(),
                TimeStamp = data.SuiteDreamLiner.GetTimeStamp()
            };
            request.AddJsonBody(body); client.Timeout = 999999999;
            string response = client.Execute(request).Content;

            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic receivedData = serializer.Deserialize<dynamic>(response);
            dynamic thisData_ = serializer.Deserialize<object>(receivedData);
            thisData_[0].Remove("LicensedModules");
            receivedData = serializer.Serialize(thisData_);
            System.Data.DataTable dt =
                (System.Data.DataTable)Newtonsoft.Json.JsonConvert.DeserializeObject(receivedData,
                    (typeof(System.Data.DataTable)));
            return dt;
        }

        public static string GetBusinessInfo()
        {
            string _bdata = string.Empty;
            try
            {
                _bdata = data.SessionDataStore.GetSessionData(AspNetSession(1) + "_RECEIVED_DATA"); //DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETTZ102"].Value);
            }
            catch (Exception)
            {
                _bdata = string.Empty;
            }
            return _bdata;
        }

        public static DataTable HeaderDataSet()
        {
            RestClient client = new RestClient(SuiteDreamLiner.APIUrul());
            RestRequest request = new RestRequest("get/company/info", Method.POST);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Authorization", Secure360.GetAuthorization());
            request.AddHeader("Signature", Secure360.GetSignature());
            var bodyParameters = new
            {
                code = 1,
                SearchParameter = "1"
            };
            string finalData = JsonConvert.SerializeObject(bodyParameters).ToString();
            var body = new
            {
                Data = finalData
            };
            request.AddJsonBody(body);
            var responseOUT = client.Execute(request).Content;
            var serializer = new JavaScriptSerializer();
            var receivedData = serializer.Deserialize<dynamic>(responseOUT);
            //var receivedData2 = serializer.Deserialize<dynamic>(receivedData);

            DataTable dt = new DataTable();
            try
            {
                dt = (DataTable)JsonConvert.DeserializeObject(receivedData, (typeof(DataTable)));
            }
            catch (Exception ex)
            {
                dt = null;
            }

            return dt;
        }

        public static void GetClientInformation(string parameter)
        {
            RestClient client = new RestClient(SuiteDreamLiner.APIUrul());
            RestRequest request = new RestRequest("client/search", Method.POST);
            request.AddHeader("Accept", "application/json");
            var body = new
            {
                BusinessKey = GetBusinessKeyNoEncryption(),
                AccessKey = data.SuiteDreamLiner.GetAccessKeyNoEncryptionPOST(),
                TerminalType = "WEB",
                TerminalID = data.SuiteDreamLiner.GetIPAddress(),
                TimeStamp = data.SuiteDreamLiner.GetTimeStamp(),
                SearchParameter = parameter,
                SearchCode = "ANY"
            };

            request.AddJsonBody(body); client.Timeout = 999999999;
            string response = client.Execute(request).Content;
            SaveReceivedClientData(response);
        }

        public static void SaveReceivedClientData(string _thisData)
        {
            try
            {
                data.SessionDataStore.SaveSessionData(SuiteDreamLiner.AspNetSession(1) + "_FCLIENT_DATA", _thisData);
                string responseCode = string.Empty;
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                dynamic receivedData = serializer.Deserialize<dynamic>(_thisData);
                dynamic finalDeser = serializer.Deserialize<dynamic>(receivedData);
                responseCode = finalDeser["ResponseCode"].ToString();
                if (responseCode == "000")
                {
                    string _clientID = string.Empty;
                    string _clientNumber = string.Empty;
                    string _clientName = string.Empty;
                    string _clientType = string.Empty;
                    string _nationalID = string.Empty;
                    string _primaryEmail = string.Empty;
                    string _phoneNumber = string.Empty;

                    try { _clientID = finalDeser["ClientID"].ToString(); } catch (Exception) { }
                    try { _clientNumber = finalDeser["ClientNumber"].ToString(); } catch (Exception) { }
                    try { _clientName = finalDeser["FullName"].ToString(); } catch (Exception) { }
                    try { _phoneNumber = finalDeser["CellPhone"].ToString(); } catch (Exception) { }
                    try { _clientType = finalDeser["ClientType"].ToString(); } catch (Exception) { }
                    try { _nationalID = finalDeser["NationalID"].ToString(); } catch (Exception) { }
                    try { _primaryEmail = finalDeser["PrimaryEmail"].ToString(); } catch (Exception) { }

                    string data_ = _clientID + "#" + _clientNumber + "#" + _clientName + "#" + _phoneNumber + "#" + _clientType + "#" + _nationalID + "#" + _primaryEmail;
                    data.SessionDataStore.SaveSessionData(SuiteDreamLiner.AspNetSession(1) + "_CLIENT_DATA", data_);
                    //System.Web.HttpContext.Current.Response.Cookies["FINNETTZ130"].Value = EncryptData(data_);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void CompressMyBackup(string FilePath, string _DestinationFile, string _SavetoPath)
        {
            FileStream sourceFileStream = File.OpenRead(FilePath);
            FileStream destFileStream = File.Create(_SavetoPath + _DestinationFile + ".gz");

            GZipStream compressingStream = new GZipStream(destFileStream,
                CompressionMode.Compress);

            byte[] bytes = new byte[2048];
            int bytesRead;
            while ((bytesRead = sourceFileStream.Read(bytes, 0, bytes.Length)) != 0)
            {
                compressingStream.Write(bytes, 0, bytesRead);
            }

            sourceFileStream.Close();
            compressingStream.Close();
            destFileStream.Close();
        }

        public static void BackupDatabase(string _ConnectionString, string _BackupType, string _BackupPath,
            string _DestinationPath)
        {
            try
            {
                SqlConnection con = new SqlConnection(_ConnectionString);
                string _Command = string.Empty;
                System.Data.SqlClient.SqlConnectionStringBuilder builder =
                    new System.Data.SqlClient.SqlConnectionStringBuilder(_ConnectionString);
                string _DatabaseName = builder.InitialCatalog;
                string _DatabaseBackupNameNoEXT = _BackupType.ToUpper() + _DatabaseName + GetTimeStamp();
                string _DatabaseBackupName = _DatabaseBackupNameNoEXT + ".BAK";
                string _DatabaseBackupPath = _BackupPath + _DatabaseBackupName;
                if (_BackupType.ToUpper() == "FULLBACKUP")
                {
                    _Command = "BACKUP DATABASE " + _DatabaseName + " TO DISK = " + "'" + _DatabaseBackupPath + "'";
                }

                if (_BackupType.ToUpper() == "DIFFERENTIAL")
                {
                    _Command = "BACKUP DATABASE " + _DatabaseName + " TO DISK = " + "'" + _DatabaseBackupPath +
                               "' WITH  DIFFERENTIAL , NOFORMAT, NOINIT";
                }

                SqlCommand com = new SqlCommand(_Command, con)
                {
                    CommandTimeout = 999999999
                };
                con.Open();

                com.ExecuteNonQuery();
                con.Close();
                con.Dispose();
                com.Dispose();

                //INITIATE COMPRESSION
                FileStream sourceFileStream = File.OpenRead(_DatabaseBackupPath);
                FileStream destFileStream = File.Create(_DestinationPath + _DatabaseBackupNameNoEXT); // + ".gz");

                GZipStream compressingStream = new GZipStream(destFileStream,
                    CompressionMode.Compress);

                byte[] bytes = new byte[2048];
                int bytesRead;
                while ((bytesRead = sourceFileStream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    compressingStream.Write(bytes, 0, bytesRead);
                }

                sourceFileStream.Close();
                compressingStream.Close();
                destFileStream.Close();

                //DELETE ORIGINAL FILE
                File.Delete(_DatabaseBackupPath);
            }
            catch (Exception)
            {
            }
        }

        public static string GetUserName()
        {
            string foundData = string.Empty;
            try
            {
                string[] thisdata = UserData().Split('#');
                foundData = thisdata[1].ToString(); //DataDictionary.GetFromGlobalStore(GetAccessKeyNoEncryption() + "USERNAME");
            }
            catch (Exception)
            {
                //foundData = null;
                System.Web.HttpContext.Current.Response.Redirect("~/connect/index", false);
            }

            return foundData;
        }

        public static string GetUserID()
        {
            string foundData = string.Empty;
            try
            {
                string[] thisdata = UserData().Split('#');
                foundData = thisdata[0].ToString();// DataDictionary.GetFromGlobalStore(GetAccessKeyNoEncryption() + "USERID");
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetUserSession()
        {
            string foundData = string.Empty;
            try
            {
                foundData = GetAccessKey();
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static bool VerifyUserSession()
        {
            bool sessionisokay = false;// DataDictionary.CheckUserSession(GetAccessKeyNoEncryption());
            if (!string.IsNullOrEmpty(UserData()))
            {
                sessionisokay = true;
            }
            else
            {
                sessionisokay = false;
            }
            return sessionisokay;
        }

        public static bool VerifyBusinessSession()
        {
            bool sessionisokay = false;// DataDictionary.CheckUserSession(GetAccessKeyNoEncryption());
            if (!string.IsNullOrEmpty(BusinessData()))
            {
                sessionisokay = true;
            }
            else
            {
                sessionisokay = false;
            }
            return sessionisokay;
        }

        public static string GetSlaveCompanyInformation()
        {
            string foundData = string.Empty;
            try
            {
                foundData = data.SessionDataStore.GetSessionData(data.SuiteDreamLiner.AspNetSession(1) + "_BUSINESS_DATA"); //DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETT0007"].Value);
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetShopID()
        {
            string foundData = string.Empty;
            try
            {
                foundData = data.SessionDataStore.GetSessionData(data.SuiteDreamLiner.AspNetSession(1) + "_SHOP_ID");
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetShopName()
        {
            string foundData = string.Empty;
            try
            {
                foundData = data.SessionDataStore.GetSessionData(data.SuiteDreamLiner.AspNetSession(1) + "_SHOP_NAME");
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetClientGroupID()
        {
            string foundData = string.Empty;
            try
            {
                foundData = DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETTCNTGRP"].Value);
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetClientGroupName()
        {
            string foundData = string.Empty;
            try
            {
                foundData = DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETTCNTGRPD"].Value);
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetClientGroupwhatdata()
        {
            string foundData = string.Empty;
            try
            {
                foundData = DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETTCNTGRPV"].Value);
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetSlaveCompanyID()
        {
            string foundData = string.Empty;
            try
            {
                string slaveData = GetSlaveCompanyInformation();
                string[] slaveDatax = slaveData.Split(',');
                string companyid = slaveDatax[0];
                foundData = companyid;
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetCompanyIDNonSession()
        {
            string foundData = string.Empty;
            try
            {
                foundData = GetCompanyID();
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetCompanyID()
        {
            string foundData = string.Empty;
            string[] thisdata = BusinessData().Split('#');
            foundData = thisdata[0].ToString();
            //if (CheckTimeout() == false)
            //{
            //    string[] thisdata = BusinessData().Split('#');
            //    foundData = thisdata[0].ToString();
            //}
            //else
            //{
            //    string localPath = HttpContext.Current.Request.Url.LocalPath;
            //    string xpath = System.Web.HttpContext.Current.Request.ApplicationPath;
            //    if (xpath.Length > 3)
            //    {
            //        localPath = localPath.Replace(xpath, string.Empty);
            //    }
            //    SystemTimeOUT(localPath);
            //}
            return foundData;
        }

        public static string CreateClientDocumentFolder(string clientnumber)
        {
            string clientfolderRETURN = string.Empty;
            string businesscode = string.Empty;
            string fileLocation = "~/uploads/documents/";
            string fileLocationFULL = System.Web.HttpContext.Current.Server.MapPath(fileLocation);
            ;
            try
            {
                businesscode = GetBusinessCode();
                if (!Directory.Exists(fileLocationFULL + businesscode))
                {
                    Directory.CreateDirectory(fileLocationFULL + businesscode + "/" + clientnumber);
                }

                clientfolderRETURN = fileLocationFULL + businesscode + "/" + clientnumber;
            }
            catch (Exception)
            {
                businesscode = null;
            }

            return clientfolderRETURN;
        }

        public static string CreateCompanyDocumentFolder()
        {
            string businesscodeRETURN = string.Empty;
            string businesscode = string.Empty;
            string fileLocation = "~/uploads/documents/";
            string fileLocationFULL = System.Web.HttpContext.Current.Server.MapPath(fileLocation);
            ;
            try
            {
                string foundData = string.Empty;
                businesscode = GetBusinessCode();
                if (!Directory.Exists(fileLocationFULL + businesscode))
                {
                    Directory.CreateDirectory(fileLocationFULL + businesscode);
                }

                businesscodeRETURN = fileLocationFULL + businesscode;
            }
            catch (Exception)
            {
                businesscode = null;
            }

            return businesscodeRETURN;
        }

        public static string GetBusinessCode()
        {
            string foundData = string.Empty;
            string[] thisdata = BusinessData().Split('#');
            foundData = thisdata[1].ToString();
            //foundData = DataDictionary.GetFromGlobalStore(GetBusinessKeyNoEncryption() + "COMPANYCODE");
            return foundData;
        }

        public static string GetStatementTemplate()
        {
            string foundData = string.Empty;
            string[] thisdata = UserData().Split('#');
            try { foundData = thisdata[6].ToString(); } catch (Exception) { }
            if (foundData == string.Empty) { foundData = "V1"; }
            return foundData;
        }

        public static string GetUserLandingPage()
        {
            string foundData = string.Empty;// DataDictionary.GetLandingPage(GetAccessKeyNoEncryption() + GetUserName());
            string[] thisdata = UserData().Split('#');
            foundData = thisdata[5].ToString();
            return foundData;
        }

        public static string GetHomePage()
        {
            string foundData = string.Empty;
            string businessInformation = AllReceivedData(); //data.SuiteDreamLiner.GetBusinessInfo(); //DataDictionary.GetBusinessInformation(GetBusinessKeyNoEncryption());
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            dynamic receivedData = serializer.Deserialize<dynamic>(businessInformation);
            foundData = receivedData[0]["HomePage"].ToString();
            return foundData;
        }

        /// <summary>
        /// The GetFullUserName
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetFullUserName()
        {
            string foundData = string.Empty;
            try
            {
                string[] thisdata = UserData().Split('#');
                foundData = thisdata[2].ToString();
                //bool _SessionISOkay = VerifyUserSession();
                //if (_SessionISOkay == true)
                //{
                //foundData = DataDictionary.GetFromGlobalStore(GetAccessKeyNoEncryption() + "FULLNAME");
                //string userInformation = DataDictionary.GetUserInformation(GetAccessKeyNoEncryption());
                //JavaScriptSerializer serializer = new JavaScriptSerializer();
                //dynamic receivedData = serializer.Deserialize<dynamic>(userInformation);
                //foundData = receivedData[0]["FullName"].ToString();
                //}
                //else
                //{
                //    foundData = null;
                //    //HttpContext.Current.System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
                //}
            }
            catch (Exception)
            {
                foundData = null;
                //HttpContext.Current.System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
            }

            return foundData;
        }

        /// <summary>
        /// The GetBranchNonSession
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetBranchNonSession()
        {
            string foundData = string.Empty;
            try
            {
                foundData = GetBranch();
            }
            catch (Exception)
            {
                foundData = null;
                //HttpContext.Current.System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
            }

            return foundData;
        }

        /// <summary>
        /// The GetBusinessKey
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetBusinessKey()
        {
            string businesskey = string.Empty;
            try
            {
                businesskey = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_BUSINESSKEY");//DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETT0000"].Value);
            }
            catch (Exception)
            {
                businesskey = string.Empty;
            }

            return businesskey;
        }

        /// <summary>
        /// The GetBusinessKeyNoEncryption
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetBusinessKeyNoEncryption()
        {
            string businesskey = string.Empty;
            try
            {
                businesskey = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_BUSINESSKEY"); //DataPurifier.Decrypt(System.Web.HttpContext.Current.Request.Cookies["FINNETT0000"].Value);
            }
            catch (Exception)
            {
                businesskey = string.Empty;
                // System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
            }

            if (string.IsNullOrEmpty(businesskey))
            {
                try
                {
                    //System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
                }
                catch (Exception)
                {
                }
            }

            return businesskey;
        }

        /// <summary>
        /// The GetClientKey
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetClientKey()
        {
            string clientkey = string.Empty;
            try
            {
                clientkey = System.Web.HttpContext.Current.Request.Cookies["FINNETT0002"].Value;
            }
            catch (Exception)
            {
                clientkey = string.Empty;
            }

            return clientkey;
        }

        /// <summary>
        /// The GetClientKeyNoEncryption
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetClientKeyNoEncryption()
        {
            string clientkey = string.Empty;
            try
            {
                clientkey = System.Web.HttpContext.Current.Request.Cookies["FINNETT0002"].Value;
            }
            catch (Exception)
            {
                clientkey = string.Empty;
            }

            return clientkey;
        }

        /// <summary>
        /// The GetAccessKey
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetAccessKey()
        {
            string accesskey = string.Empty;
            try
            {
                accesskey = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_SESSION_KEY");// System.Web.HttpContext.Current.Request.Cookies["FINNETT0001"].Value;
            }
            catch (Exception)
            {
                accesskey = string.Empty;
            }
            if (accesskey == string.Empty)
            {
                System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
            }
            return accesskey;
        }

        /// <summary>
        /// The GetReceiptNoEncryption
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetReceiptNoEncryption()
        {
            string accesskey = string.Empty;
            try
            {
                accesskey = data.SessionDataStore.GetSessionData(data.SuiteDreamLiner.AspNetSession(1) + "_RECEIPT_NUMBER"); //DataPurifier.Decrypt(System.Web.HttpContext.Current.Request.Cookies["FINNETT0003"].Value);
            }
            catch (Exception)
            {
                accesskey = string.Empty;
            }

            return accesskey;
        }

        /// <summary>
        /// The GetAccessKeyNoEncryption
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        ///
        public static string GetAccessKeyNoEncryption()
        {
            string accesskey = string.Empty;
            try
            {
                accesskey = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_SESSION_KEY");//DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETT0001"].Value);
            }
            catch (Exception)
            {
                accesskey = string.Empty;
            }
            if (accesskey == string.Empty)
            {
                System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
            }
            return accesskey;
        }

        public static string GetAccessKeyNoEncryptionPOST()
        {
            string accesskey = string.Empty;
            try
            {
                accesskey = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_SESSION_KEY");//DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETT0001"].Value);
            }
            catch (Exception)
            {
                accesskey = string.Empty;
            }
            if (accesskey == string.Empty)
            {
                System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
            }
            return accesskey;
        }

        /// <summary>
        /// The GetBusinessName
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetBusinessName()
        {
            string resp = string.Empty;
            try
            {
                //resp = DataDictionary.GetFromGlobalStore(GetBusinessKeyNoEncryption() + "COMPANYNAME");
                string[] thisdata = BusinessData().Split('#');
                resp = thisdata[2].ToString();
            }
            catch (Exception)
            {
                //System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
            }

            return resp;
        }

        public static string GetLicenseExpiry()
        {
            string resp = string.Empty;
            try
            {
                //resp = DataDictionary.GetFromGlobalStore(GetBusinessKeyNoEncryption() + "LICENSEEXPIRY");
                string[] thisdata = BusinessData().Split('#');
                resp = thisdata[4].ToString();
            }
            catch (Exception)
            {
                resp = string.Empty;
            }

            return resp;
        }

        public static string GetExpiryNote()
        {
            string resp = string.Empty;
            try
            {
                // resp = SuiteDreamLiner.DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETTXP01"].Value);
                string[] thisdata = BusinessData().Split('#');
                resp = thisdata[5].ToString();
            }
            catch (Exception)
            {
                resp = string.Empty;
            }

            return resp;
        }

        public static string GetLicenseNumber()
        {
            string resp = string.Empty;
            try
            {
                //resp = DataDictionary.GetFromGlobalStore(GetBusinessKeyNoEncryption() + "LICENSENUMBER");
                string[] thisdata = BusinessData().Split('#');
                resp = thisdata[3].ToString();
            }
            catch (Exception)
            {
                resp = string.Empty;
            }

            return resp;
        }

        public static bool GetIsGrandMaster()
        {
            bool resp = false;
            try
            {
                string businessInformation = AllReceivedData(); //data.SuiteDreamLiner.GetBusinessInfo(); //DataDictionary.GetBusinessInformation(GetBusinessKeyNoEncryption());
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                dynamic receivedData = serializer.Deserialize<dynamic>(businessInformation);
                resp = bool.Parse(receivedData[0]["IsGM"].ToString());
            }
            catch (Exception)
            {
                //System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
            }

            return resp;
        }

        public static bool GetIsMaster()
        {
            bool resp = false;
            try
            {
                string businessInformation = AllReceivedData(); //data.SuiteDreamLiner.GetBusinessInfo(); //DataDictionary.GetBusinessInformation(GetBusinessKeyNoEncryption());
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                dynamic receivedData = serializer.Deserialize<dynamic>(businessInformation);
                resp = bool.Parse(receivedData[0]["IsM"].ToString());
            }
            catch (Exception)
            {
                //System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
            }

            return resp;
        }

        public static bool GetIsSlave()
        {
            bool resp = false;
            try
            {
                string businessInformation = AllReceivedData();//data.SuiteDreamLiner.GetBusinessInfo(); //DataDictionary.GetBusinessInformation(GetBusinessKeyNoEncryption());
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                dynamic receivedData = serializer.Deserialize<dynamic>(businessInformation);
                resp = bool.Parse(receivedData[0]["IsS"].ToString());
            }
            catch (Exception)
            {
                //System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
            }

            return resp;
        }

        /// <summary>
        /// The GetTerminalType
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetTerminalType()
        {
            return "WEB";
        }

        /// <summary>
        /// The GetBranch
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetBranch()
        {
            string foundData = string.Empty;
            try
            {
                //bool _SessionISOkay = VerifyUserSession();
                //if (_SessionISOkay == true)
                //{
                //foundData = DataDictionary.GetFromGlobalStore(GetAccessKeyNoEncryption() + "BRANCHID");
                //}
                //else
                //{
                //    foundData = null;
                //}
                string[] thisdata = UserData().Split('#');
                foundData = thisdata[3].ToString();
            }
            catch (Exception)
            {
                foundData = null;
            }
            if (string.IsNullOrEmpty(foundData))
            {
                foundData = "0";
            }
            return foundData;
        }

        public static string GetBranchName()
        {
            string foundData = string.Empty;
            try
            {
                //bool _SessionISOkay = VerifyUserSession();
                //if (_SessionISOkay == true)
                //{
                ////string userInformation = DataDictionary.GetUserInformation(GetAccessKeyNoEncryption());
                ////JavaScriptSerializer serializer = new JavaScriptSerializer();
                ////dynamic receivedData = serializer.Deserialize<dynamic>(userInformation);
                ////foundData = receivedData[0]["BranchName"].ToString();
                //foundData = DataDictionary.GetFromGlobalStore(GetAccessKeyNoEncryption() + "BRANCHNAME");
                //}
                //else
                //{
                //    foundData = null;
                //    //HttpContext.Current.System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
                //}
                string[] thisdata = UserData().Split('#');
                foundData = thisdata[4].ToString();
            }
            catch (Exception)
            {
                foundData = null;
                //HttpContext.Current.System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
            }

            return foundData;
        }

        public static string GetClientData()
        {
            string _udata = string.Empty;
            try
            {
                _udata = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_CLIENT_DATA"); //DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETTZ130"].Value);
            }
            catch (Exception)
            {
                _udata = string.Empty;
            }
            return _udata;
        }

        public static string GetClientID()
        {
            string foundData = string.Empty;
            try
            {
                string[] _clientData = GetClientData().Split('#');
                foundData = _clientData[0];
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string ClientEmailAddress()
        {
            string foundData = string.Empty;
            try
            {
                string[] _clientData = GetClientData().Split('#');
                foundData = _clientData[6];
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string ClientNationalID()
        {
            string foundData = string.Empty;
            try
            {
                string[] _clientData = GetClientData().Split('#');
                foundData = _clientData[5];
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetClientPhoneNumber()
        {
            string foundData = string.Empty;
            try
            {
                string[] _clientData = GetClientData().Split('#');
                foundData = _clientData[3];
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetAccountData()
        {
            string foundData = string.Empty;
            try
            {
                foundData = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_ACCOUNT_DATA"); //DataPurifier.Decrypt(System.Web.HttpContext.Current.Request.Cookies["FINNETT0004"].Value);
            }
            catch (Exception)
            {
                foundData = string.Empty;
            }

            return foundData;
        }

        public static string GetStatementData()
        {
            string foundData = string.Empty;
            try
            {
                foundData = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_ACCOUNT_ID"); //DataPurifier.Decrypt(System.Web.HttpContext.Current.Request.Cookies["FINNETT0004"].Value);
            }
            catch (Exception)
            {
                foundData = string.Empty;
            }

            return foundData;
        }

        public static string GetVoucherNo()
        {
            string foundData = string.Empty;
            try
            {
                foundData = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_VOUCHER_NUMBER");// DataPurifier.Decrypt(System.Web.HttpContext.Current.Request.Cookies["FINNETT0060"].Value);
            }
            catch (Exception)
            {
                foundData = string.Empty;
            }

            return foundData;
        }

        /// <summary>
        /// The GetClientFullName
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetClientFullName()
        {
            string foundData = string.Empty;
            try
            {
                string[] _clientData = GetClientData().Split('#');
                foundData = _clientData[2];
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetClientNumber()
        {
            string foundData = string.Empty;
            try
            {
                string[] _clientData = GetClientData().Split('#');
                foundData = _clientData[1];
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetClientType()
        {
            string foundData = string.Empty;
            try
            {
                string clientkey = GetClientKey();
                if (clientkey != string.Empty)
                {
                    string[] _clientData = GetClientData().Split('#');
                    foundData = _clientData[4];
                }
                else
                {
                    foundData = null;
                }
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetSpecificAccountNumber()
        {
            string foundData = string.Empty;
            try
            {
                foundData = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_ACCOUNT_ID"); //DataPurifier.Decrypt(System.Web.HttpContext.Current.Request.Cookies["FINNETT0004A"].Value);
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static void SaveUISessionToDB(string _sessionid)
        {
            string olduisession = string.Empty;
            string olddbsession = string.Empty;
            string _olddb = AspNetSession(1);
            string _username = GetUserName();
            string _companyid = GetCompanyID();
            //FinnettData db = new FinnettData();

            //db.SaveUserSession(_companyid, _username, _sessionid, _olddb, ref olduisession, ref olddbsession);
            if (olduisession != _olddb && !string.IsNullOrEmpty(olduisession) && olduisession != "")
            {
                try
                {
                    try
                    {
                        string businessInformation = UserAccessModules();
                        string sessionK = data.SessionDataStore.GetSessionData(olduisession + "_SESSION_KEY"); ;
                        if (businessInformation != string.Empty && businessInformation != null && businessInformation != "" && !string.IsNullOrEmpty(sessionK))
                        {
                            string[] module = businessInformation.Split(':');
                            foreach (string item in module)
                            {
                                try
                                {
                                    try { RightsAndAccess.DeleteRights(sessionK + item + "VIEW"); } catch (Exception) { }
                                    try { RightsAndAccess.DeleteRights(sessionK + item + "ADD"); } catch (Exception) { }
                                    try { RightsAndAccess.DeleteRights(sessionK + item + "UPDATE"); } catch (Exception) { }
                                    try { RightsAndAccess.DeleteRights(sessionK + item + "DELETE"); } catch (Exception) { }
                                    try { RightsAndAccess.DeleteRights(sessionK + item + "PRINT"); } catch (Exception) { }
                                    try { RightsAndAccess.DeleteRights(sessionK + item + "IMPORT"); } catch (Exception) { }
                                    try { RightsAndAccess.DeleteRights(sessionK + item + "EXPORT"); } catch (Exception) { }
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                    }
                    catch (Exception) { }

                    if (!string.IsNullOrEmpty(olduisession))
                    {
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_VOUCHER_NUMBER"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_ACCOUNT_ID"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_CLIENT_DATA"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_SESSION_KEY"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_RECEIPT_NUMBER"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_BUSINESSKEY"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_BUSINESS_DATA"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_CLIENT_DATA"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_RECEIVED_DATA"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_LICENSED_MODULES"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_USER_MODULES"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_USER_DATA"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_RECEIPT_NUMBER"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_LEDGER_DATA"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_CLIENT_DATA"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "_COMPANY_DATA"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "TIME_OUT"); } catch (Exception) { }
                        try { data.SessionDataStore.DeleteSessionData(olduisession + "SESSION_DATE"); } catch (Exception) { }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        public static string GetAccountID()
        {
            string foundData = string.Empty;
            try
            {
                foundData = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_ACCOUNT_ID");// DataPurifier.Decrypt(System.Web.HttpContext.Current.Request.Cookies["FINNETT0004"].Value);
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetLedgerID()
        {
            string foundData = string.Empty;
            try
            {
                //bool _SessionISOkay = VerifyUserSession();
                //if (_SessionISOkay == true)
                //{
                foundData = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_LEDGER_ID");// DataPurifier.Decrypt(System.Web.HttpContext.Current.Request.Cookies["FINNETT0005"].Value);
                //}
                //else
                //{
                //    foundData = null;
                //}
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        public static string GetLedgerData()
        {
            string foundData = string.Empty;
            try
            {
                //bool _SessionISOkay = VerifyUserSession();
                //if (_SessionISOkay == true)
                //{
                foundData = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_LEDGER_DATA");// DataPurifier.Decrypt(System.Web.HttpContext.Current.Request.Cookies["FINNETT0005"].Value);
                //}
                //else
                //{
                //    foundData = null;
                //}
            }
            catch (Exception)
            {
                foundData = null;
            }

            return foundData;
        }

        /// <summary>
        /// The GetIPAddress
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public static string GetIPAddress()
        {
            string ip = string.Empty;
            try
            {
                ip = HttpContext.Current.Request.UserHostAddress;
                return ip;
            }
            catch (Exception)
            {
                ip = "127.0.0.1";
            }

            return ip;
        }

        public static string GetTransactionCode()
        {
            string transactioncode = string.Empty;
            //FinnettData db = new FinnettData();
            //db.GlobalGetTransactionCodeN(ref transactioncode);

            return transactioncode;
        }

        public static string GetTransferReference()
        {
            string reference = string.Empty;
            //FinnettData db = new FinnettData();
            //db.GetIFTReference(GetCompanyID(), ref reference);

            return reference;
        }

        public static string EncryptData(string inText)
        {
            string encrypted = StringUtil.Crypt(inText); //DataPurifier.Encrypt(inText);
            return encrypted;
        }

        public static string DecryptData(string inText)
        {
            string decrypted = StringUtil.Decrypt(inText); //DataPurifier.Decrypt(inText);
            return decrypted;
        }

        public static string GetNewClientNumber(int companyid, string groupid)
        {
            string nClientNo = string.Empty;
            string nCoreClientNo = string.Empty;
            string respCode = string.Empty;
            try
            {
                //data.FinnettData db = new data.FinnettData
                //{
                //    CommandTimeout = 999999999
                //};

                //db.AdminNewClientNumber(int.Parse(GetCompanyID()), groupid, string.Empty, ref nClientNo, ref nCoreClientNo, ref respCode);
            }
            catch (Exception)
            {
                nClientNo = null;
            }

            return nClientNo;
        }

        public static string SystemResponse(string responsecode)
        {
            //data.FinnettData db = new data.FinnettData
            //{
            //    CommandTimeout = 999999999
            //};
            string description = string.Empty;
            //db.GlobalGetResponseDescription(responsecode, ref description);
            return description;
        }

        public static string APIUrul()
        {
            string api = string.Empty;
            try
            {
                //api = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath("~/data/apipath.txt"));
                //api = "http://localhost:60873/";
                //api = "http://localhost:60873/";
                //api = "http://localhost:14/PI360/";
                api = "http://localhost:60003/";
            }
            catch (Exception ex)
            {
                api = ex.Message;
            }

            return api;
        }

        public static string GetTimeStamp()
        {
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            return timestamp;
        }

        public static string DateToString(DateTime mydate)
        {
            string dateString = mydate.ToString("yyyyMMddHHmmss");
            return dateString;
        }

        public static string KillUserSession()
        {
            string response = string.Empty;
            try
            {
                KillAllSessions();
                response = "000";
            }
            catch (Exception)
            {
                response = "001";
            }

            return response;
        }

        public static string KillReceiptSession()
        {
            string response = string.Empty;
            try
            {
                //KillCookieX("FINNETT0003");
                data.SessionDataStore.DeleteSessionData(data.SuiteDreamLiner.AspNetSession(1) + "_RECEIPT_NUMBER");
                response = "000";
            }
            catch (Exception)
            {
                response = "001";
            }

            return response;
        }

        public static string KillStatementSession()
        {
            string response = string.Empty;
            try
            {
                //KillCookieX("FINNETT0003");
                data.SessionDataStore.DeleteSessionData(data.SuiteDreamLiner.AspNetSession(1) + "_RECEIPT_NUMBER");
                response = "000";
            }
            catch (Exception)
            {
                response = "001";
            }

            return response;
        }

        public static string KillAllAccountGetSession()
        {
            string response = string.Empty;
            try
            {
                data.SessionDataStore.DeleteSessionData(SuiteDreamLiner.AspNetSession(1) + "_ACCOUNT_OP");
                //KillCookieX("1ACD");
                response = "000";
            }
            catch (Exception)
            {
                response = "001";
            }
            KillCookieX("FINNETTCNTGRP");
            return response;
        }

        public static string KillBusinessSession()
        {
            string response = string.Empty;
            try
            {
                KillCookieX("FINNETT0000");
                response = "000";
            }
            catch (Exception)
            {
                response = "001";
            }

            return response;
        }

        public static string KillClientSession()
        {
            string response = string.Empty;
            try
            {
                data.SessionDataStore.DeleteSessionData(SuiteDreamLiner.AspNetSession(1) + "_CLIENT_DATA");
                //KillCookieX("FINNETTZ130");
                response = "000";
            }
            catch (Exception)
            {
                response = "001";
            }

            return response;
        }

        public static void KillCookieX(string cookiename)
        {
            try
            {
                if (System.Web.HttpContext.Current.Request.Cookies[cookiename] != null)
                {
                    System.Web.HttpCookie c = System.Web.HttpContext.Current.Request.Cookies[cookiename];
                    c.Expires = DateTime.Now.AddMonths(-1);
                    System.Web.HttpContext.Current.Response.AppendCookie(c);
                }
            }
            catch (Exception)
            {
            }
        }

        public static void KillAllCookisNOW()
        {
            try
            {
                foreach (string key in System.Web.HttpContext.Current.Request.Cookies.AllKeys)
                {
                    KillCookieX(key);
                }
            }
            catch (Exception)
            {
            }
        }

        public static string KillAllSessions()
        {
            string response = string.Empty;
            try
            {
                try
                {
                    //REMOVE RIGHTS
                    string businessInformation = UserAccessModules();
                    string sessionK = GetAccessKeyNoEncryption();
                    if (businessInformation != string.Empty && businessInformation != null && businessInformation != "")
                    {
                        string[] module = businessInformation.Split(':');
                        foreach (string item in module)
                        {
                            try
                            {
                                RightsAndAccess.DeleteRights(sessionK + item + "VIEW");
                                RightsAndAccess.DeleteRights(sessionK + item + "ADD");
                                RightsAndAccess.DeleteRights(sessionK + item + "UPDATE");
                                RightsAndAccess.DeleteRights(sessionK + item + "DELETE");
                                RightsAndAccess.DeleteRights(sessionK + item + "PRINT");
                                RightsAndAccess.DeleteRights(sessionK + item + "IMPORT");
                                RightsAndAccess.DeleteRights(sessionK + item + "EXPORT");
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }

                    //KILL ALL SESSIONS
                    foreach (string key in System.Web.HttpContext.Current.Request.Cookies.AllKeys)
                    {
                        KillCookieX(key);
                    }

                    string _sessionx = SuiteDreamLiner.AspNetSession(1);
                    try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }

                    //try { data.SessionDataStore.DeleteSessionData(_sessionx + "_CLIENT_DATA"); } catch (Exception) { }
                }
                catch (Exception)
                {
                }
                response = "000";
            }
            catch (Exception)
            {
                response = "001";
            }

            return response;
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static string GetSMSBalance(string strUsername, string apiKey)
        {
            string balancexx = string.Empty;
            Widegateway widegatewayPI = new Widegateway();
            dynamic result = widegatewayPI.AccountBalance(strUsername, apiKey);

            string _currency = string.Empty;
            string _balance = string.Empty;
            foreach (Dictionary<string, object> item in (result as object[]))
            {
                _currency = item["currency"].ToString();
                _balance = item["balance"].ToString();
            }

            string bal = float.Parse(_balance).ToString(data.SuiteDreamLiner.DecimalPoints());
            if (bal == string.Empty)
            {
                bal = "0.00";
            }

            balancexx = _currency + " : " + bal;
            return balancexx;
        }

        public static void ExitLogic()
        {
            try
            {
                //data.FinnettData db = new data.FinnettData
                //{
                //    CommandTimeout = 999999999
                //}; string response = string.Empty;
                ////db.AdminUserSessions(int.Parse(SuiteDreamLiner.GetCompanyID()), int.Parse(SuiteDreamLiner.GetBranch()), int.Parse(SuiteDreamLiner.GetUserID()),
                //SuiteDreamLiner.GetUserName(), SuiteDreamLiner.GetUserName(), DateTime.Now, SuiteDreamLiner.GetIPAddress(), SuiteDreamLiner.GetUserSession(), false, true, DateTime.Now,
                //"USER_LOGGED_OUT", false, true, ref response);

                SuiteDreamLiner.KillAllSessions();
            }
            catch (System.Exception)
            {
                // System.Web.HttpContext.Current.Response.Redirect("~/connect/index");
            }
        }

        public static bool CheckTimeout()
        {
            bool timedout = false;
            try
            {
                string loginTIME = string.Empty;
                string timeOUT = string.Empty;
                timeOUT = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_TIME_OUT");
                //try { timeOUT = data.SuiteDreamLiner.DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETTYT00"].Value); } catch (Exception) { loginTIME = string.Empty; }
                //try { loginTIME = data.SuiteDreamLiner.DecryptData(System.Web.HttpContext.Current.Request.Cookies["FINNETTXT01"].Value); } catch (Exception) { loginTIME = string.Empty; }
                loginTIME = data.SessionDataStore.GetSessionData(SuiteDreamLiner.AspNetSession(1) + "_SESSION_DATE");
                if (timeOUT == string.Empty) { timeOUT = "10"; }
                if (!string.IsNullOrEmpty(loginTIME))
                {
                    TimeSpan timespan = DateTime.Now.Subtract(DateTime.Parse(loginTIME));
                    if (timespan.Minutes >= int.Parse(timeOUT))
                    {
                        timedout = true;
                    }
                    else
                    {
                        timedout = false;
                    }
                }
                else
                {
                    timedout = true;
                }
            }
            catch (Exception) { }
            return timedout;
        }

        public static void SystemTimeOUT(string currentPage, Page callerPage)
        {
            try
            {
                if (CheckTimeout() == true)
                {
                    data.SessionDataStore.SaveSessionData(SuiteDreamLiner.AspNetSession(1) + "_TIMEOUT_PAGE", "~" + currentPage);
                    //System.Web.HttpContext.Current.Response.Cookies["FINNETTYT01"].Value = data.SuiteDreamLiner.EncryptData("~" + currentPage);
                    //data.FinnettData db = new data.FinnettData
                    //{
                    //    CommandTimeout = 999999999
                    //};
                    string response = string.Empty;
                    //db.AdminUserSessions(int.Parse(SuiteDreamLiner.GetCompanyID()), int.Parse(SuiteDreamLiner.GetBranch()), int.Parse(SuiteDreamLiner.GetUserID()),
                    //SuiteDreamLiner.GetUserName(), SuiteDreamLiner.GetUserName(), DateTime.Now, SuiteDreamLiner.GetIPAddress(), SuiteDreamLiner.GetUserSession(), false, true, DateTime.Now,
                    //"SESSION_EXPIRED_DUE_TO_NOACTIVITY", false, true, ref response);

                    System.Web.HttpContext.Current.Response.Redirect("~/connect/lockedout", false);
                }
                else
                {
                    data.SessionDataStore.SaveSessionData(SuiteDreamLiner.AspNetSession(1) + "_SESSION_DATE", DateTime.Now.ToString());
                    //System.Web.HttpContext.Current.Response.Cookies["FINNETTXT01"].Value = data.SuiteDreamLiner.EncryptData(DateTime.Now.ToString());
                }
            }
            catch (Exception) { }
        }
    }
}