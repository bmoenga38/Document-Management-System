using System;
using System.Collections.Generic;

namespace FINNETT.data
{
    public class RightsAndAccess
    {
        public static Dictionary<string, string> UserAccessRights = new Dictionary<string, string>();

        public static string UserRights(string userR, string Username, string sessionK)
        {
            string response = string.Empty;
            try
            {
                string accesskey = sessionK;
                List<string> accessModules = new List<string>();
                string username = Username;
                string _ViewRights = string.Empty;
                string _AddRights = string.Empty;
                string _UpdateRights = string.Empty;
                string _PrintRights = string.Empty;
                string _ExportRights = string.Empty;
                string _ImportRights = string.Empty;
                string _DeleteRights = string.Empty;

                string _ViewRights1 = string.Empty;
                string _AddRights1 = string.Empty;
                string _UpdateRights1 = string.Empty;
                string _PrintRights1 = string.Empty;
                string _ExportRights1 = string.Empty;
                string _ImportRights1 = string.Empty;
                string _DeleteRights1 = string.Empty;

                string _FullModulesList = string.Empty;

                List<Modules> rights = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<List<Modules>>(userR);
                List<string> fullSubModules = new List<string>();
                List<SubModulesItemsResources> fullSubModuleResources = new List<SubModulesItemsResources>();
                foreach (Modules item in rights)
                {
                    string module = item.Module.ToLower();
                    if (!accessModules.Contains(module)) { accessModules.Add(module); }

                    if (_FullModulesList == string.Empty) { _FullModulesList = module; } else { _FullModulesList = _FullModulesList + ":" + module; }
                    List<SubModules> smodules = item.SModules;
                    foreach (SubModules smodule in smodules)
                    {
                        string resourcekey = module.ToLower() + "/" + smodule.SModuleName.ToLower();
                        string smodname = smodule.SModuleName.ToLower();
                        if (string.IsNullOrEmpty(_ViewRights)) { _ViewRights = smodname; } else { _ViewRights = _ViewRights + ":" + smodname; }

                        List<SubModulesItemsResources> resources = smodule.SModuleItems;
                        List<string> viewModulesList = new List<string>();
                        string viewResourceList = string.Empty;
                        foreach (SubModulesItemsResources resource in resources)
                        {
                            string thisresource = resource.Resource.ToLower();
                            if (resource.View == true)
                            {
                                _ViewRights1 = thisresource;
                                if (string.IsNullOrEmpty(_ViewRights)) { _ViewRights = _ViewRights1; } else { _ViewRights = _ViewRights + ":" + _ViewRights1; }
                                //if (!viewModulesList.Contains(thisresource)) { viewModulesList.Add(thisresource); }
                            }

                            if (resource.Add == true)
                            {
                                _AddRights1 = thisresource;
                                if (string.IsNullOrEmpty(_AddRights)) { _AddRights = _AddRights1; } else { _AddRights = _AddRights + ":" + _AddRights1; }
                            }

                            if (resource.Update == true)
                            {
                                _UpdateRights1 = thisresource;
                                if (string.IsNullOrEmpty(_UpdateRights)) { _UpdateRights = _UpdateRights1; } else { _UpdateRights = _UpdateRights + ":" + _UpdateRights1; }
                            }

                            if (resource.Update == true)
                            {
                                _DeleteRights1 = thisresource;
                                if (string.IsNullOrEmpty(_DeleteRights)) { _DeleteRights = _DeleteRights1; } else { _DeleteRights = _DeleteRights + ":" + _DeleteRights1; }
                            }

                            if (resource.Print == true)
                            {
                                _AddRights1 = thisresource;
                                if (string.IsNullOrEmpty(_PrintRights)) { _PrintRights = _PrintRights1; } else { _PrintRights = _PrintRights + ":" + _PrintRights1; }
                            }

                            if (resource.Export == true)
                            {
                                _ExportRights1 = thisresource;
                                if (string.IsNullOrEmpty(_ExportRights)) { _ExportRights = _ExportRights1; } else { _ExportRights = _ExportRights + ":" + _ExportRights1; }
                            }

                            if (resource.Upload == true)
                            {
                                _ImportRights1 = thisresource;
                                if (string.IsNullOrEmpty(_ImportRights)) { _ImportRights = _ImportRights1; } else { _ImportRights = _ImportRights + ":" + _ImportRights1; }
                            }
                        }
                    }
                    SaveRights(sessionK + module + "VIEW", _ViewRights);
                    SaveRights(sessionK + module + "ADD", _AddRights);
                    SaveRights(sessionK + module + "UPDATE", _UpdateRights);
                    SaveRights(sessionK + module + "DELETE", _DeleteRights);
                    SaveRights(sessionK + module + "PRINT", _PrintRights);
                    SaveRights(sessionK + module + "EXPORT", _ExportRights);
                    SaveRights(sessionK + module + "IMPORT", _ImportRights);

                    _ViewRights = string.Empty;
                    _AddRights = string.Empty;
                    _UpdateRights = string.Empty;
                    _PrintRights = string.Empty;
                    _ExportRights = string.Empty;
                    _ImportRights = string.Empty;
                    _DeleteRights = string.Empty;

                    _ViewRights1 = string.Empty;
                    _AddRights1 = string.Empty;
                    _UpdateRights1 = string.Empty;
                    _PrintRights1 = string.Empty;
                    _ExportRights1 = string.Empty;
                    _ImportRights1 = string.Empty;
                    _DeleteRights1 = string.Empty;
                }
                data.SessionDataStore.SaveSessionData(SuiteDreamLiner.AspNetSession(1) + "_USER_MODULES", _FullModulesList);
                //System.Web.HttpContext.Current.Response.Cookies["FINNETTZ105"].Value = data.SuiteDreamLiner.EncryptData(_FullModulesList);
            }
            catch (Exception ex)
            {
                response = ex.Message;
            }
            response = "000";
            return response;
        }

        public static void SaveRights(string key, string value)
        {
            try
            {
                UserAccessRights.Add(key, value);
            }
            catch (Exception)
            {
            }
        }

        public static void DeleteRights(string key)
        {
            try
            {
                UserAccessRights.Remove(key);
            }
            catch (Exception)
            {
            }
        }

        public static string GetRights(string resource)
        {
            string session = SuiteDreamLiner.GetAccessKeyNoEncryption();
            string viewrights = string.Empty;
            try
            {
                viewrights = UserAccessRights[session + resource].ToString();
            }
            catch (Exception)
            {
                viewrights = string.Empty;
            }
            return viewrights;
        }
    }
}

public class Modules
{
    public string Module { get; set; }
    public List<SubModules> SModules { get; set; }
}

public class SubModules
{
    public string SModuleName { get; set; }
    public List<SubModulesItemsResources> SModuleItems { get; set; }
}

public class SubModulesItemsResources
{
    public string Resource { get; set; }
    public bool View { get; set; }
    public bool Add { get; set; }
    public bool Update { get; set; }
    public bool Checker { get; set; }
    public bool Export { get; set; }
    public bool Print { get; set; }
    public bool Upload { get; set; }
}